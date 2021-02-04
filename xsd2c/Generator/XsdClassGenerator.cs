using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;
using System.Xml.Serialization.Advanced;

namespace xsd2c.Generator
{
    internal class XsdClassGenerator
    {
        #region Константы и поля

        private readonly CodeNamespace _codeNamespace;
        private readonly XmlSchema _schema;
        private readonly List<XmlSchema> _schemaList;
        private readonly CodeGenerationOptions _options;

        #endregion

        #region Конструкторы

        public XsdClassGenerator(XmlSchema schema, string @namespace = null,
            CodeGenerationOptions options = CodeGenerationOptions.None)
        {
            _schema = schema ?? throw new ArgumentNullException(nameof(schema), "Xml Schema cannot be null");
            _schemaList = new List<XmlSchema>();
            _codeNamespace = string.IsNullOrEmpty(@namespace)
                ? new CodeNamespace()
                : new CodeNamespace(@namespace);

            CodeModifiers = new List<ICodeModifier>();
            _options = options;
            SchemaImporterExtensions = new SchemaImporterExtensionCollection();

            CompileSchema(schema);
            PreProcessSchemas();
        }

        #endregion

        #region События, свойства, индексаторы

        public ICollection<ICodeModifier> CodeModifiers { get; }

        public SchemaImporterExtensionCollection SchemaImporterExtensions { get; }

        #endregion

        #region Другое

        private static void CompileSchema(XmlSchema schema)
        {
            if (schema.IsCompiled)
                return;
            Trace.TraceInformation("Compiling schema");
            var set = new XmlSchemaSet();
            set.Add(schema);
            set.CompilationSettings.EnableUpaCheck = false;
            set.Compile();
        }

        public void Generate(TextWriter textWriter)
        {
            var xmlSchemas = new XmlSchemas {_schema};
            foreach (var s in _schemaList)
                xmlSchemas.Add(s);

            var schemaImporter = new XmlSchemaImporter(xmlSchemas);
            foreach (SchemaImporterExtension extension in SchemaImporterExtensions)
                schemaImporter.Extensions.Add(extension);

            var codeExporter = new XmlCodeExporter(_codeNamespace, new CodeCompileUnit(), _options);

            try
            {
                GenerateForElements(schemaImporter, codeExporter);
                GenerateForComplexTypes(schemaImporter, codeExporter);
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                throw new ApplicationException("Error Loading Schema: ", ex);
            }

            ModifyCodeDom();

            var options = new CodeGeneratorOptions {VerbatimOrder = true};
            var provider = CodeDomProvider.CreateProvider("CSharp");
            provider.GenerateCodeFromNamespace(_codeNamespace, textWriter, options);
        }

        protected void ModifyCodeDom()
        {
            foreach (var codeModifier in CodeModifiers)
                codeModifier.Execute(_codeNamespace);
        }

        private void GenerateForComplexTypes(XmlSchemaImporter importer, XmlCodeExporter exporter)
        {
            foreach (XmlSchemaObject type in _schema.SchemaTypes.Values)
                if (type is XmlSchemaComplexType ct)
                {
                    var mapping = importer.ImportSchemaType(ct.QualifiedName);
                    exporter.ExportTypeMapping(mapping);
                }
        }

        private void GenerateForElements(XmlSchemaImporter importer, XmlCodeExporter exporter)
        {
            foreach (XmlSchemaElement element in _schema.Elements.Values)
            {
                Trace.TraceInformation("Generating for element: {0}", element.Name);
                try
                {
                    var mapping = importer.ImportTypeMapping(element.QualifiedName);
                    exporter.ExportTypeMapping(mapping);
                }
                catch (Exception ex)
                {
                    Trace.TraceError(ex.ToString());
                }
            }
        }

        private void PreProcessSchemas()
        {
            Trace.Assert(_schema != null);
            foreach (var includedSchema in _schema.Includes.OfType<XmlSchemaExternal>())
                if (includedSchema.Schema != null && !_schemaList.Contains(includedSchema.Schema))
                    _schemaList.Add(includedSchema.Schema);
        }

        #endregion
    }
}