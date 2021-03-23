using System;
using System.Diagnostics;
using System.IO;
using System.Xml.Schema;
using System.Xml.Serialization;

using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

using xsd2c.Generator;
using xsd2c.Modifiers;

namespace xsd2c.MsBuild
{
    public class XsdTask : Task
    {
        [Required]
        public ITaskItem[] Schemas { get; set; }

        public override bool Execute()
        {
            Debugger.Launch();
            if (Schemas != null)
            {
                foreach (var item in Schemas)
                {
                    var schemaPath = item.GetMetadata("FullPath");
                    Log.LogWarning($"TODO: XSD-схема: {schemaPath}.");

                    var codePath = Path.ChangeExtension(schemaPath, "cs");
                    var @namespace = Path.GetFileNameWithoutExtension(schemaPath);
                    using var schemaReader = File.OpenText(schemaPath);
                    using var codeWriter = File.CreateText(codePath);
                    var schema = XmlSchema.Read(schemaReader, null);
                    var generator = new XsdClassGenerator(schema, @namespace, CodeGenerationOptions.None)
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
            return true;
        }
    }
}
