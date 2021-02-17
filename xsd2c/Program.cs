using System;
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
                var generator = new XsdClassGenerator(schema, @namespace, None)
                {
                    CodeModifiers =
                    {
                        new RemoveAttrsCodeModifier(),
                        //new RenameTypeCodeModifier(),
                        new ImplementVisitorCodeModifier(),
                        new SimplifyCodeModifier(),
                    }
                };
                generator.Generate(codeWriter);
                foreach (var error in generator.Errors)
                {
                    var oldColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    var err = error.Error;
                    var indent = "";
                    while (err != null)
                    {
                        Console.WriteLine($"{indent}{err.Message}");
                        indent += "   ";
                        err = err.InnerException;
                    }
                    Console.ForegroundColor = oldColor;
                }
            }
        }
    }
}
