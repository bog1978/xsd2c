using System.CodeDom;
using System.Linq;
using xsd2c.Generator;

namespace xsd2c.Modifiers
{
    internal class SimplifyVisitor : CodeDomVisitor<object, object>
    {
        private readonly CodeNamespace _codeNamespace;

        public SimplifyVisitor(CodeNamespace codeNamespace)
        {
            _codeNamespace = codeNamespace;
        }

        public override object Visit(CodeTypeReference code, object arg)
        {
            if (code.ArrayRank > 0)
                return arg;

            var parts = code.BaseType.Split('.');
            if (parts.Length == 1)
                return arg;

            var ns = string.Join(".", parts.Take(parts.Length - 1));
            var type = parts.Last();

            if(_codeNamespace.Imports.OfType<CodeNamespaceImport>().All(x => x.Namespace != ns))
                _codeNamespace.Imports.Add(new CodeNamespaceImport(ns));

            const string attr = "Attribute";
            if (type.EndsWith(attr))
                type = type.Substring(0, type.Length - attr.Length);

            code.BaseType = type;

            return arg;
        }

        public override object Visit(CodeTypeDeclaration code, object arg)
        {
            code.Comments.Clear();
            return base.Visit(code, arg);
        }

        public override object Visit(CodeMemberProperty code, object arg)
        {
            code.Comments.Clear();
            return base.Visit(code, arg);
        }

        public override object Visit(CodeMemberField code, object arg)
        {
            code.Comments.Clear();
            return base.Visit(code, arg);
        }
    }
}