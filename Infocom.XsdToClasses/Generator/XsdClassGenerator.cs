using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
//using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;
using System.Xml.Serialization.Advanced;

namespace xsd2c.Generator
{
    public class XsdClassGenerator
    {
        #region Константы и поля

        private readonly CodeNamespace _codeNamespace;
        private readonly List<GenerationError> _errors;
        private readonly CodeGenerationOptions _options;
        private readonly XmlSchema _schema;
        private readonly List<XmlSchema> _schemaList;

        #endregion

        #region Конструкторы

        public XsdClassGenerator(XmlSchema schema, string @namespace,
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
            _errors = new List<GenerationError>();

            CompileSchema(schema);
            PreProcessSchemas();
        }

        #endregion

        #region События, свойства, индексаторы

        public ICollection<ICodeModifier> CodeModifiers { get; }

        public IReadOnlyCollection<GenerationError> Errors => _errors;

        public SchemaImporterExtensionCollection SchemaImporterExtensions { get; }

        #endregion

        #region Другое

        private static void CompileSchema(XmlSchema schema)
        {
            if (schema.IsCompiled)
                return;
            var set = new XmlSchemaSet();
            set.Add(schema);
            set.CompilationSettings.EnableUpaCheck = false;
            set.Compile();
        }

        public void Generate(TextWriter textWriter)
        {
            var xmlSchemas = new XmlSchemas { _schema };
            foreach (var s in _schemaList)
                xmlSchemas.Add(s);

            var schemaImporter = new XmlSchemaImporter(xmlSchemas);
            foreach (SchemaImporterExtension extension in SchemaImporterExtensions)
                schemaImporter.Extensions.Add(extension);

            var codeExporter = new XmlCodeExporter(_codeNamespace, new CodeCompileUnit(), _options);

            GenerateForAll(schemaImporter, codeExporter);
            ModifyCodeDom();

            var options = new CodeGeneratorOptions
            {
                VerbatimOrder = true,
                BracingStyle = "C",
                BlankLinesBetweenMembers = true,
            };
            var provider = CodeDomProvider.CreateProvider("CSharp");
            provider.GenerateCodeFromNamespace(_codeNamespace, textWriter, options);
        }

        protected void ModifyCodeDom()
        {
            foreach (var codeModifier in CodeModifiers)
                codeModifier.Execute(_codeNamespace);
        }

        private void GenerateForAll(XmlSchemaImporter importer, XmlCodeExporter exporter)
        {
            foreach (XmlSchemaObject type in _schema.SchemaTypes.Values)
            {
                XmlTypeMapping? mapping = null;
                try
                {
                    mapping = type switch
                    {
                        XmlSchemaComplexType ct => importer.ImportSchemaType(ct.QualifiedName),
                        XmlSchemaElement elt => importer.ImportSchemaType(elt.QualifiedName),
                        _ => null
                    };

                    if (mapping != null)
                        exporter.ExportTypeMapping(mapping);
                }
                catch (Exception ex)
                {
                    ReportError(type, mapping, ex);
                }
            }
        }

        private void PreProcessSchemas()
        {
            foreach (var includedSchema in _schema.Includes.OfType<XmlSchemaExternal>())
                if (includedSchema.Schema != null && !_schemaList.Contains(includedSchema.Schema))
                    _schemaList.Add(includedSchema.Schema);
        }

        private void ReportError(XmlSchemaObject? obj, XmlTypeMapping? mapping, Exception error)
        {
            _errors.Add(new GenerationError(obj, mapping, error));
        }

        #endregion
    }
}