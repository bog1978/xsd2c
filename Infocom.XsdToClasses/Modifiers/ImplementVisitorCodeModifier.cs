using System.CodeDom;
using System.Linq;

using xsd2c.Generator;

namespace xsd2c.Modifiers
{
    public class ImplementVisitorCodeModifier : ICodeModifier
    {
        public void Execute(CodeNamespace codeNamespace)
        {
            var generators = new BaseVisitorGenerator[]
            {
                new InterfaceNodeVisitorGenerator(codeNamespace),
                new BaseNodeVisitorGenerator(codeNamespace),
                new ImplementationVisitorGenerator(codeNamespace),
            };

            if(!codeNamespace.Imports.OfType<CodeNamespaceImport>().Any(x => x.Namespace == "System.Collections.Generic"))
                codeNamespace.Imports.Add(new CodeNamespaceImport("System.Collections.Generic"));

            foreach (var generator in generators)
                generator.Generate();
        }
    }
}