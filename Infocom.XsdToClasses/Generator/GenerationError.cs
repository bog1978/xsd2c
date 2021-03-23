using System;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace xsd2c.Generator
{
    public class GenerationError
    {
        #region ������������

        public GenerationError(XmlSchemaObject? schemaObject, XmlTypeMapping? typeMapping, Exception error)
        {
            SchemaObject = schemaObject;
            TypeMapping = typeMapping;
            Error = error;
        }

        #endregion

        #region �������, ��������, �����������

        public Exception Error { get; }

        public XmlSchemaObject? SchemaObject { get; }
        public XmlTypeMapping? TypeMapping { get; }

        #endregion
    }
}