using System.CodeDom;
using System.Linq;

using xsd2c.Generator;

namespace xsd2c.Modifiers
{
    internal class SimplfyCodeModifier : ICodeModifier
    {
        public void Execute(CodeNamespace codeNamespace)
        {
            var visitor = new SimplfyVisitor(codeNamespace);
            codeNamespace.Accept(visitor, null);
        }
    }

    internal class SimplfyVisitor : CodeDomVisitor<object, object>
    {
        private readonly CodeNamespace _codeNamespace;

        public SimplfyVisitor(CodeNamespace codeNamespace)
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

            if(!_codeNamespace.Imports.OfType<CodeNamespaceImport>().Any(x => x.Namespace == ns))
                _codeNamespace.Imports.Add(new CodeNamespaceImport(ns));

            var attr = "Attribute";
            if (type.EndsWith(attr))
                type = type.Substring(0, type.Length - attr.Length);

            code.BaseType = type;

            return arg;
        }
    }
}