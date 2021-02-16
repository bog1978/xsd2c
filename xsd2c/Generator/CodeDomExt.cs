using System.CodeDom;

namespace xsd2c.Generator
{
    public static class CodeDomExt
    {
        public static void AcceptAll<TArg, TResult>(this CodeAttributeDeclarationCollection items, CodeDomVisitor<TArg, TResult> visitor, TArg arg)
        {
            if (items != null)
                foreach (CodeAttributeDeclaration item in items)
                    item.Accept(visitor, arg);
        }

        public static void AcceptAll<TArg, TResult>(this CodeAttributeArgumentCollection items, CodeDomVisitor<TArg, TResult> visitor, TArg arg)
        {
            if (items != null)
                foreach (CodeAttributeArgument item in items)
                    item.Accept(visitor, arg);
        }

        public static void AcceptAll<TArg, TResult>(this CodeNamespaceImportCollection items, CodeDomVisitor<TArg, TResult> visitor, TArg arg)
        {
            if (items != null)
                foreach (CodeNamespaceImport item in items)
                    item.Accept(visitor, arg);
        }

        public static void AcceptAll<TArg, TResult>(this CodeTypeDeclarationCollection items, CodeDomVisitor<TArg, TResult> visitor, TArg arg)
        {
            if (items != null)
                foreach (CodeTypeDeclaration item in items)
                    item.Accept(visitor, arg);
        }

        public static void AcceptAll<TArg, TResult>(this CodeCommentStatementCollection items, CodeDomVisitor<TArg, TResult> visitor, TArg arg)
        {
            if (items != null)
                foreach (CodeCommentStatement item in items)
                    item.Accept(visitor, arg);
        }

        public static void AcceptAll<TArg, TResult>(this CodeDirectiveCollection items, CodeDomVisitor<TArg, TResult> visitor, TArg arg)
        {
            if (items != null)
                foreach (CodeDirective item in items)
                    item.Accept(visitor, arg);
        }

        public static void AcceptAll<TArg, TResult>(this CodeTypeReferenceCollection items, CodeDomVisitor<TArg, TResult> visitor, TArg arg)
        {
            if (items != null)
                foreach (CodeTypeReference item in items)
                    item.Accept(visitor, arg);
        }

        public static void AcceptAll<TArg, TResult>(this CodeExpressionCollection items, CodeDomVisitor<TArg, TResult> visitor, TArg arg)
        {
            if (items != null)
                foreach (CodeExpression item in items)
                    item.Accept(visitor, arg);
        }

        public static void AcceptAll<TArg, TResult>(this CodeStatementCollection items, CodeDomVisitor<TArg, TResult> visitor, TArg arg)
        {
            if (items != null)
                foreach (CodeStatement item in items)
                    item.Accept(visitor, arg);
        }

        public static void AcceptAll<TArg, TResult>(this CodeParameterDeclarationExpressionCollection items, CodeDomVisitor<TArg, TResult> visitor, TArg arg)
        {
            if (items != null)
                foreach (CodeParameterDeclarationExpression item in items)
                    item.Accept(visitor, arg);
        }

        public static void AcceptAll<TArg, TResult>(this CodeTypeParameterCollection items, CodeDomVisitor<TArg, TResult> visitor, TArg arg)
        {
            if (items != null)
                foreach (CodeTypeParameter item in items)
                    item.Accept(visitor, arg);
        }

        public static void AcceptAll<TArg, TResult>(this CodeTypeMemberCollection items, CodeDomVisitor<TArg, TResult> visitor, TArg arg)
        {
            if (items != null)
                foreach (CodeTypeMember item in items)
                    item.Accept(visitor, arg);
        }

        public static TResult Accept<TArg, TResult>(this CodeAttributeDeclaration code, CodeDomVisitor<TArg, TResult> visitor, TArg arg) => visitor.Visit(code, arg);

        public static TResult Accept<TArg, TResult>(this CodeAttributeArgument code, CodeDomVisitor<TArg, TResult> visitor, TArg arg) => visitor.Visit(code, arg);

        public static TResult Accept<TArg, TResult>(this CodeLinePragma code, CodeDomVisitor<TArg, TResult> visitor, TArg arg) => visitor.Visit(code, arg);

        public static TResult Accept<TArg, TResult>(this CodeObject obj, CodeDomVisitor<TArg, TResult> visitor, TArg arg)
        {
            if (obj == null)
                return default;

            visitor.Path.Push(obj);

            var result = obj switch
            {
                CodeComment code => visitor.Visit(code, arg),
                CodeCompileUnit code => code switch
                {
                    CodeSnippetCompileUnit c1 => visitor.Visit(c1, arg),
                    _ => visitor.Visit(code, arg)
                },
                CodeDirective code => code switch
                {
                    CodeChecksumPragma c1 => visitor.Visit(c1, arg),
                    CodeRegionDirective c1 => visitor.Visit(c1, arg),
                    _ => visitor.Visit(code, arg)
                },
                CodeExpression code => code switch
                {
                    CodeArgumentReferenceExpression c1 => visitor.Visit(c1, arg),
                    CodeArrayCreateExpression c1 => visitor.Visit(c1, arg),
                    CodeArrayIndexerExpression c1 => visitor.Visit(c1, arg),
                    CodeBaseReferenceExpression c1 => visitor.Visit(c1, arg),
                    CodeBinaryOperatorExpression c1 => visitor.Visit(c1, arg),
                    CodeCastExpression c1 => visitor.Visit(c1, arg),
                    CodeDefaultValueExpression c1 => visitor.Visit(c1, arg),
                    CodeDelegateCreateExpression c1 => visitor.Visit(c1, arg),
                    CodeDelegateInvokeExpression c1 => visitor.Visit(c1, arg),
                    CodeDirectionExpression c1 => visitor.Visit(c1, arg),
                    CodeEventReferenceExpression c1 => visitor.Visit(c1, arg),
                    CodeFieldReferenceExpression c1 => visitor.Visit(c1, arg),
                    CodeIndexerExpression c1 => visitor.Visit(c1, arg),
                    CodeMethodInvokeExpression c1 => visitor.Visit(c1, arg),
                    CodeMethodReferenceExpression c1 => visitor.Visit(c1, arg),
                    CodeObjectCreateExpression c1 => visitor.Visit(c1, arg),
                    CodeParameterDeclarationExpression c1 => visitor.Visit(c1, arg),
                    CodePrimitiveExpression c1 => visitor.Visit(c1, arg),
                    CodePropertyReferenceExpression c1 => visitor.Visit(c1, arg),
                    CodePropertySetValueReferenceExpression c1 => visitor.Visit(c1, arg),
                    CodeSnippetExpression c1 => visitor.Visit(c1, arg),
                    CodeThisReferenceExpression c1 => visitor.Visit(c1, arg),
                    CodeTypeOfExpression c1 => visitor.Visit(c1, arg),
                    CodeTypeReferenceExpression c1 => visitor.Visit(c1, arg),
                    CodeVariableReferenceExpression c1 => visitor.Visit(c1, arg),
                    _ => visitor.Visit(code, arg)
                },
                CodeNamespace code => visitor.Visit(code, arg),
                CodeNamespaceImport code => visitor.Visit(code, arg),
                CodeStatement code => code switch
                {
                    CodeAssignStatement c1 => visitor.Visit(c1, arg),
                    CodeAttachEventStatement c1 => visitor.Visit(c1, arg),
                    CodeCommentStatement c1 => visitor.Visit(c1, arg),
                    CodeConditionStatement c1 => visitor.Visit(c1, arg),
                    CodeExpressionStatement c1 => visitor.Visit(c1, arg),
                    CodeGotoStatement c1 => visitor.Visit(c1, arg),
                    CodeIterationStatement c1 => visitor.Visit(c1, arg),
                    CodeLabeledStatement c1 => visitor.Visit(c1, arg),
                    CodeMethodReturnStatement c1 => visitor.Visit(c1, arg),
                    CodeRemoveEventStatement c1 => visitor.Visit(c1, arg),
                    CodeSnippetStatement c1 => visitor.Visit(c1, arg),
                    CodeThrowExceptionStatement c1 => visitor.Visit(c1, arg),
                    CodeTryCatchFinallyStatement c1 => visitor.Visit(c1, arg),
                    CodeVariableDeclarationStatement c1 => visitor.Visit(c1, arg),
                    _ => visitor.Visit(code, arg)
                },
                CodeTypeMember code => code switch
                {
                    CodeMemberEvent c1 => visitor.Visit(c1, arg),
                    CodeMemberField c1 => visitor.Visit(c1, arg),
                    CodeMemberMethod c1 => c1 switch
                    {
                        CodeConstructor c2 => visitor.Visit(c2, arg),
                        CodeEntryPointMethod c2 => visitor.Visit(c2, arg),
                        CodeTypeConstructor c2 => visitor.Visit(c2, arg),
                        _ => visitor.Visit(c1, arg)
                    },
                    CodeMemberProperty c1 => visitor.Visit(c1, arg),
                    CodeSnippetTypeMember c1 => visitor.Visit(c1, arg),
                    CodeTypeDeclaration c1 => c1 switch
                    {
                        CodeTypeDelegate c2 => visitor.Visit(c2, arg),
                        _ => visitor.Visit(c1, arg)
                    },
                    _ => visitor.Visit(code, arg)
                },
                CodeTypeParameter code => visitor.Visit(code, arg),
                CodeTypeReference code => visitor.Visit(code, arg),
                _ => visitor.Visit(obj, arg)
            };

            visitor.Path.Pop();

            return result;
        }
    }
}