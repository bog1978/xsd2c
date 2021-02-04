using System.CodeDom;
using xsd2c.Generator;
using xsd2c.Visitors;

namespace xsd2c.Modifiers
{
    internal class MyCodeModifier : ICodeModifier
    {
        public void Execute(CodeNamespace codeNamespace)
        {
            var visitor = new RenameVisitor();
            codeNamespace.Accept(visitor, ("VertexType", "VertexType1"));
            codeNamespace.Accept(visitor, ("VertexTypeCollection", "VertexType1Collection"));
        }
    }
}