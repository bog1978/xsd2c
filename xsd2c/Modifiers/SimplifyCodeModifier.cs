using System.CodeDom;
using xsd2c.Generator;

namespace xsd2c.Modifiers
{
    internal class SimplifyCodeModifier : ICodeModifier
    {
        public void Execute(CodeNamespace codeNamespace)
        {
            var visitor = new SimplifyVisitor(codeNamespace);
            codeNamespace.Accept(visitor, null);
        }
    }
}