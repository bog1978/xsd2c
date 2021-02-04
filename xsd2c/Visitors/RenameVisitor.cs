using System.CodeDom;
using xsd2c.Generator;

namespace xsd2c.Visitors
{
    internal class RenameVisitor : CodeDomVisitor<(string oldName, string newName), object>
    {
        public override object Visit(CodeTypeDeclaration code, (string oldName, string newName) arg)
        {
            if (code.Name == arg.oldName)
                code.Name = arg.newName;
            return base.Visit(code, arg);
        }

        public override object Visit(CodeTypeReference code, (string oldName, string newName) arg)
        {
            if (code.BaseType == arg.oldName)
                code.BaseType = arg.newName;
            return base.Visit(code, arg);
        }
    }
}