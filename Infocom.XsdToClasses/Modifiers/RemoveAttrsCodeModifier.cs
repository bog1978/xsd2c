using System.CodeDom;
using xsd2c.Generator;

namespace xsd2c.Modifiers
{
    public class RemoveAttrsCodeModifier : ICodeModifier
    {
        public void Execute(CodeNamespace codeNamespace)
        {
            var visitor = new RemoveAttrsVisitor(codeNamespace);
            codeNamespace.Accept(visitor, null);
        }
    }
}