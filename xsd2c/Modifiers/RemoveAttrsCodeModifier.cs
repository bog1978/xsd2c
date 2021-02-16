using System.CodeDom;
using xsd2c.Generator;

namespace xsd2c.Modifiers
{
    internal class RemoveAttrsCodeModifier : ICodeModifier
    {
        public void Execute(CodeNamespace codeNamespace)
        {
            var visitor = new RemoveAttrsVisitor(codeNamespace);
            codeNamespace.Accept(visitor, null);
        }
    }
}