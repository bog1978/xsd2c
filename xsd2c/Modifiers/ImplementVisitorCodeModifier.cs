﻿using System.CodeDom;
using xsd2c.Generator;

namespace xsd2c.Modifiers
{
    internal class ImplementVisitorCodeModifier : ICodeModifier
    {
        public void Execute(CodeNamespace codeNamespace)
        {
            var generators = new BaseVisitorGenerator[]
            {
                new InterfaceNodeVisitorGenerator(codeNamespace),
                new BaseNodeVisitorGenerator(codeNamespace),
                new ImplementationVisitorGenerator(codeNamespace),
            };

            codeNamespace.Imports.Add(new CodeNamespaceImport("System.Collections.Generic"));

            foreach (var generator in generators)
                generator.Generate();
        }
    }
}