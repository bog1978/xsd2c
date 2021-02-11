﻿using System;
using System.IO;
using System.Xml.Schema;
using xsd2c.Generator;
using xsd2c.Modifiers;
using static System.Xml.Serialization.CodeGenerationOptions;

namespace xsd2c
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var path = Path.Combine(Environment.CurrentDirectory, "..\\..\\..\\Test");
            foreach (var schemaPath in Directory.GetFiles(path, "*.xsd"))
            {
                var codePath = Path.ChangeExtension(schemaPath, "g.cs");
                var @namespace = Path.GetFileNameWithoutExtension(schemaPath);
                using var schemaReader = File.OpenText(schemaPath);
                using var codeWriter = File.CreateText(codePath);
                var schema = XmlSchema.Read(schemaReader, null);
                var generator = new XsdClassGenerator(schema, @namespace, GenerateProperties)
                {
                    CodeModifiers =
                    {
                        new RenameTypeCodeModifier(),
                        new ImplementVisitorCodeModifier(),
                    }
                };
                generator.Generate(codeWriter);
            }
        }
    }
}
