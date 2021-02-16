using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using xsd2c.Generator;

namespace xsd2c.Modifiers
{
    internal class RemoveAttrsVisitor : CodeDomVisitor<object, object>
    {
        private readonly CodeNamespace _codeNamespace;

        private List<string> _attrsToRemove = new()
        {
            nameof(GeneratedCodeAttribute),
            nameof(SerializableAttribute),
            nameof(DebuggerStepThroughAttribute),
            nameof(DesignerCategoryAttribute),
        };

        public RemoveAttrsVisitor(CodeNamespace codeNamespace)
        {
            _codeNamespace = codeNamespace;
        }

        public override object Visit(CodeTypeDeclaration code, object arg)
        {
            //code.CustomAttributes.Clear();
            for (var i = code.CustomAttributes.Count - 1; i >= 0; i--)
            {
                var attr = code.CustomAttributes[i];
                var name = attr.Name.Split('.').Last();
                if (_attrsToRemove.Contains(name))
                    code.CustomAttributes.RemoveAt(i);
            }
            return arg;
        }
    }
}