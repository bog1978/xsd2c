using System.CodeDom;

namespace xsd2c.Generator
{
    public static class CodeDomExt
    {
        #region Другое

        public static TResult Accept<TArg, TResult>(this CodeAttributeDeclaration code, CodeDomVisitor<TArg, TResult> visitor, TArg arg) =>
            visitor.Visit(code, arg);

        public static TResult Accept<TArg, TResult>(this CodeAttributeArgument code, CodeDomVisitor<TArg, TResult> visitor, TArg arg) =>
            visitor.Visit(code, arg);

        public static TResult Accept<TArg, TResult>(this CodeLinePragma code, CodeDomVisitor<TArg, TResult> visitor, TArg arg) => visitor.Visit(code, arg);

        public static TResult Accept<TArg, TResult>(this CodeObject obj, CodeDomVisitor<TArg, TResult> visitor, TArg arg)
        {
            if (obj == null)
                return default;

            visitor.Path.Push(obj);

            var result = obj switch
            {
                CodeComment code => visitor.Visit(code, arg),
                CodeNamespace code => visitor.Visit(code, arg),
                CodeNamespaceImport code => visitor.Visit(code, arg),
                CodeTypeParameter code => visitor.Visit(code, arg),
                CodeTypeReference code => visitor.Visit(code, arg),
                CodeCompileUnit code => code.Accept(visitor, arg),
                CodeDirective code => code.Accept(visitor, arg),
                CodeExpression code => code.Accept(visitor, arg),
                CodeStatement code => code.Accept(visitor, arg),
                CodeTypeMember code => code.Accept(visitor, arg),
                _ => visitor.Visit(obj, arg)
            };

            visitor.Path.Pop();

            return result;
        }

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

        private static TResult Accept<TArg, TResult>(this CodeDirective code, CodeDomVisitor<TArg, TResult> visitor, TArg arg) =>
            code switch
            {
                CodeChecksumPragma c => visitor.Visit(c, arg),
                CodeRegionDirective c => visitor.Visit(c, arg),
                _ => visitor.Visit(code, arg)
            };

        private static TResult Accept<TArg, TResult>(this CodeCompileUnit code, CodeDomVisitor<TArg, TResult> visitor, TArg arg) =>
            code switch
            {
                CodeSnippetCompileUnit c => visitor.Visit(c, arg),
                _ => visitor.Visit(code, arg)
            };

        private static TResult Accept<TArg, TResult>(this CodeTypeMember code, CodeDomVisitor<TArg, TResult> visitor, TArg arg) =>
            code switch
            {
                CodeMemberEvent c => visitor.Visit(c, arg),
                CodeMemberField c => visitor.Visit(c, arg),
                CodeMemberProperty c => visitor.Visit(c, arg),
                CodeSnippetTypeMember c => visitor.Visit(c, arg),
                CodeMemberMethod c => c.Accept(visitor, arg),
                CodeTypeDeclaration c => c.Accept(visitor, arg),
                _ => visitor.Visit(code, arg)
            };

        private static TResult Accept<TArg, TResult>(this CodeTypeDeclaration code, CodeDomVisitor<TArg, TResult> visitor, TArg arg) =>
            code switch
            {
                CodeTypeDelegate c => visitor.Visit(c, arg),
                _ => visitor.Visit(code, arg)
            };

        private static TResult Accept<TArg, TResult>(this CodeMemberMethod code, CodeDomVisitor<TArg, TResult> visitor, TArg arg) =>
            code switch
            {
                CodeConstructor c => visitor.Visit(c, arg),
                CodeEntryPointMethod c => visitor.Visit(c, arg),
                CodeTypeConstructor c => visitor.Visit(c, arg),
                _ => visitor.Visit(code, arg)
            };

        private static TResult Accept<TArg, TResult>(this CodeStatement code, CodeDomVisitor<TArg, TResult> visitor, TArg arg) =>
            code switch
            {
                CodeAssignStatement c => visitor.Visit(c, arg),
                CodeAttachEventStatement c => visitor.Visit(c, arg),
                CodeCommentStatement c => visitor.Visit(c, arg),
                CodeConditionStatement c => visitor.Visit(c, arg),
                CodeExpressionStatement c => visitor.Visit(c, arg),
                CodeGotoStatement c => visitor.Visit(c, arg),
                CodeIterationStatement c => visitor.Visit(c, arg),
                CodeLabeledStatement c => visitor.Visit(c, arg),
                CodeMethodReturnStatement c => visitor.Visit(c, arg),
                CodeRemoveEventStatement c => visitor.Visit(c, arg),
                CodeSnippetStatement c => visitor.Visit(c, arg),
                CodeThrowExceptionStatement c => visitor.Visit(c, arg),
                CodeTryCatchFinallyStatement c => visitor.Visit(c, arg),
                CodeVariableDeclarationStatement c => visitor.Visit(c, arg),
                _ => visitor.Visit(code, arg)
            };

        private static TResult Accept<TArg, TResult>(this CodeExpression code, CodeDomVisitor<TArg, TResult> visitor, TArg arg) =>
            code switch
            {
                CodeArgumentReferenceExpression c => visitor.Visit(c, arg),
                CodeArrayCreateExpression c => visitor.Visit(c, arg),
                CodeArrayIndexerExpression c => visitor.Visit(c, arg),
                CodeBaseReferenceExpression c => visitor.Visit(c, arg),
                CodeBinaryOperatorExpression c => visitor.Visit(c, arg),
                CodeCastExpression c => visitor.Visit(c, arg),
                CodeDefaultValueExpression c => visitor.Visit(c, arg),
                CodeDelegateCreateExpression c => visitor.Visit(c, arg),
                CodeDelegateInvokeExpression c => visitor.Visit(c, arg),
                CodeDirectionExpression c => visitor.Visit(c, arg),
                CodeEventReferenceExpression c => visitor.Visit(c, arg),
                CodeFieldReferenceExpression c => visitor.Visit(c, arg),
                CodeIndexerExpression c => visitor.Visit(c, arg),
                CodeMethodInvokeExpression c => visitor.Visit(c, arg),
                CodeMethodReferenceExpression c => visitor.Visit(c, arg),
                CodeObjectCreateExpression c => visitor.Visit(c, arg),
                CodeParameterDeclarationExpression c => visitor.Visit(c, arg),
                CodePrimitiveExpression c => visitor.Visit(c, arg),
                CodePropertyReferenceExpression c => visitor.Visit(c, arg),
                CodePropertySetValueReferenceExpression c => visitor.Visit(c, arg),
                CodeSnippetExpression c => visitor.Visit(c, arg),
                CodeThisReferenceExpression c => visitor.Visit(c, arg),
                CodeTypeOfExpression c => visitor.Visit(c, arg),
                CodeTypeReferenceExpression c => visitor.Visit(c, arg),
                CodeVariableReferenceExpression c => visitor.Visit(c, arg),
                _ => visitor.Visit(code, arg)
            };

        #endregion
    }
}