using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;

namespace xsd2c.Generator
{
    public abstract class CodeDomVisitor<TArg, TResult>
    {
        #region Конструкторы

        protected CodeDomVisitor()
        {
            Path = new Stack<CodeObject>();
        }

        #endregion

        #region События, свойства, индексаторы

        public Stack<CodeObject> Path { get; }

        #endregion

        #region Другое

        public virtual TResult Visit(CodeComment code, TArg arg) => default;

        public virtual TResult Visit(CodeSnippetCompileUnit code, TArg arg) => throw new NotImplementedException();

        public virtual TResult Visit(CodeCompileUnit code, TArg arg) => throw new NotImplementedException();

        public virtual TResult Visit(CodeNamespace code, TArg arg)
        {
            VisitAll(code.Imports, arg);
            VisitAll(code.Types, arg);
            VisitAll(code.Comments, arg);
            return default;
        }

        public virtual TResult Visit(CodeNamespaceImport code, TArg arg) => default;

        public virtual TResult Visit(CodeTypeParameter code, TArg arg) => throw new NotImplementedException();

        public virtual TResult Visit(CodeTypeReference code, TArg arg)
        {
            code.ArrayElementType.Accept(this, arg);
            VisitAll(code.TypeArguments, arg);
            return default;
        }

        public virtual TResult Visit(CodeChecksumPragma pragma, TArg arg) => throw new NotImplementedException();

        public virtual TResult Visit(CodeRegionDirective regionDirective, TArg arg) => throw new NotImplementedException();

        public virtual TResult Visit(CodeDirective regionDirective, TArg arg) => throw new NotImplementedException();

        public virtual TResult Visit(CodeArgumentReferenceExpression code, TArg arg) => default;

        public virtual TResult Visit(CodeArrayCreateExpression regionDirective, TArg arg) => throw new NotImplementedException();

        public virtual TResult Visit(CodeArrayIndexerExpression regionDirective, TArg arg) => throw new NotImplementedException();

        public virtual TResult Visit(CodeBaseReferenceExpression regionDirective, TArg arg) => throw new NotImplementedException();

        public virtual TResult Visit(CodeBinaryOperatorExpression code, TArg arg)
        {
            code.Left.Accept(this, arg);
            code.Right.Accept(this, arg);
            return default;
        }

        public virtual TResult Visit(CodeCastExpression regionDirective, TArg arg) => throw new NotImplementedException();

        public virtual TResult Visit(CodeDefaultValueExpression regionDirective, TArg arg) => throw new NotImplementedException();

        public virtual TResult Visit(CodeDelegateCreateExpression regionDirective, TArg arg) => throw new NotImplementedException();

        public virtual TResult Visit(CodeDelegateInvokeExpression code, TArg arg)
        {
            code.TargetObject.Accept(this, arg);
            VisitAll(code.Parameters, arg);
            return default;
        }

        public virtual TResult Visit(CodeDirectionExpression regionDirective, TArg arg) => throw new NotImplementedException();

        public virtual TResult Visit(CodeEventReferenceExpression code, TArg arg)
        {
            code.TargetObject.Accept(this, arg);
            return default;
        }

        public virtual TResult Visit(CodeFieldReferenceExpression code, TArg arg)
        {
            code.TargetObject.Accept(this, arg);
            return default;
        }

        public virtual TResult Visit(CodeIndexerExpression regionDirective, TArg arg) => throw new NotImplementedException();

        public virtual TResult Visit(CodeMethodInvokeExpression code, TArg arg)
        {
            VisitAll(code.Parameters, arg);
            code.Method.Accept(this, arg);
            return default;
        }

        public virtual TResult Visit(CodeMethodReferenceExpression code, TArg arg)
        {
            code.TargetObject.Accept(this, arg);
            VisitAll(code.TypeArguments, arg);
            return default;
        }

        public virtual TResult Visit(CodeObjectCreateExpression code, TArg arg)
        {
            code.CreateType.Accept(this, arg);
            VisitAll(code.Parameters, arg);
            return default;
        }

        public virtual TResult Visit(CodeParameterDeclarationExpression code, TArg arg)
        {
            VisitAll(code.CustomAttributes, arg);
            code.Type.Accept(this, arg);
            return default;
        }

        public virtual TResult Visit(CodePrimitiveExpression code, TArg arg) => default;

        public virtual TResult Visit(CodePropertyReferenceExpression regionDirective, TArg arg) => throw new NotImplementedException();

        public virtual TResult Visit(CodePropertySetValueReferenceExpression code, TArg arg) => default;

        public virtual TResult Visit(CodeSnippetExpression regionDirective, TArg arg) => throw new NotImplementedException();

        public virtual TResult Visit(CodeThisReferenceExpression code, TArg arg) => default;

        public virtual TResult Visit(CodeTypeOfExpression code, TArg arg)
        {
            code.Type.Accept(this, arg);
            return default;
        }

        public virtual TResult Visit(CodeTypeReferenceExpression regionDirective, TArg arg) => throw new NotImplementedException();

        public virtual TResult Visit(CodeVariableReferenceExpression code, TArg arg) => default;

        public virtual TResult Visit(CodeExpression regionDirective, TArg arg) => throw new NotImplementedException();

        public virtual TResult Visit(CodeAssignStatement code, TArg arg)
        {
            VisitAll(code.StartDirectives, arg);
            code.Left.Accept(this, arg);
            code.Right.Accept(this, arg);
            VisitAll(code.EndDirectives, arg);
            return default;
        }

        public virtual TResult Visit(CodeAttachEventStatement regionDirective, TArg arg) => throw new NotImplementedException();

        public virtual TResult Visit(CodeCommentStatement code, TArg arg)
        {
            code.Comment.Accept(this, arg);
            VisitAll(code.StartDirectives, arg);
            VisitAll(code.EndDirectives, arg);
            return default;
        }

        public virtual TResult Visit(CodeConditionStatement code, TArg arg)
        {
            VisitAll(code.StartDirectives, arg);
            code.Condition.Accept(this, arg);
            VisitAll(code.TrueStatements, arg);
            VisitAll(code.FalseStatements, arg);
            VisitAll(code.EndDirectives, arg);
            return default;
        }

        public virtual TResult Visit(CodeExpressionStatement code, TArg arg)
        {
            VisitAll(code.StartDirectives, arg);
            code.Expression.Accept(this, arg);
            VisitAll(code.EndDirectives, arg);
            return default;
        }

        public virtual TResult Visit(CodeGotoStatement regionDirective, TArg arg) => throw new NotImplementedException();

        public virtual TResult Visit(CodeIterationStatement regionDirective, TArg arg) => throw new NotImplementedException();

        public virtual TResult Visit(CodeLabeledStatement regionDirective, TArg arg) => throw new NotImplementedException();

        public virtual TResult Visit(CodeMethodReturnStatement code, TArg arg)
        {
            VisitAll(code.StartDirectives, arg);
            code.Expression.Accept(this, arg);
            VisitAll(code.EndDirectives, arg);
            return default;
        }

        public virtual TResult Visit(CodeRemoveEventStatement regionDirective, TArg arg) => throw new NotImplementedException();

        public virtual TResult Visit(CodeSnippetStatement regionDirective, TArg arg) => throw new NotImplementedException();

        public virtual TResult Visit(CodeThrowExceptionStatement regionDirective, TArg arg) => throw new NotImplementedException();

        public virtual TResult Visit(CodeTryCatchFinallyStatement regionDirective, TArg arg) => throw new NotImplementedException();

        public virtual TResult Visit(CodeVariableDeclarationStatement code, TArg arg)
        {
            VisitAll(code.StartDirectives, arg);
            code.InitExpression.Accept(this, arg);
            code.Type.Accept(this, arg);
            VisitAll(code.EndDirectives, arg);
            return default;
        }

        public virtual TResult Visit(CodeStatement regionDirective, TArg arg) => throw new NotImplementedException();

        public virtual TResult Visit(CodeConstructor regionDirective, TArg arg) => throw new NotImplementedException();

        public virtual TResult Visit(CodeEntryPointMethod regionDirective, TArg arg) => throw new NotImplementedException();

        public virtual TResult Visit(CodeTypeConstructor regionDirective, TArg arg) => throw new NotImplementedException();

        public virtual TResult Visit(CodeMemberMethod code, TArg arg)
        {
            VisitAll(code.StartDirectives, arg);
            VisitAll(code.Comments, arg);
            VisitAll(code.Statements, arg);
            VisitAll(code.CustomAttributes, arg);
            VisitAll(code.ImplementationTypes, arg);
            VisitAll(code.Parameters, arg);
            VisitAll(code.TypeParameters, arg);
            VisitAll(code.ReturnTypeCustomAttributes, arg);
            code.PrivateImplementationType.Accept(this, arg);
            code.ReturnType.Accept(this, arg);
            VisitAll(code.EndDirectives, arg);
            return default;
        }

        public virtual TResult Visit(CodeTypeDelegate regionDirective, TArg arg) => throw new NotImplementedException();

        public virtual TResult Visit(CodeTypeDeclaration code, TArg arg)
        {
            VisitAll(code.StartDirectives, arg);
            VisitAll(code.BaseTypes, arg);
            VisitAll(code.Members, arg);
            VisitAll(code.TypeParameters, arg);
            VisitAll(code.Comments, arg);
            VisitAll(code.CustomAttributes, arg);
            VisitAll(code.EndDirectives, arg);
            return default;
        }

        public virtual TResult Visit(CodeMemberEvent code, TArg arg)
        {
            VisitAll(code.StartDirectives, arg);
            VisitAll(code.Comments, arg);
            VisitAll(code.CustomAttributes, arg);
            VisitAll(code.ImplementationTypes, arg);
            code.PrivateImplementationType.Accept(this, arg);
            code.Type.Accept(this, arg);
            VisitAll(code.EndDirectives, arg);
            return default;
        }

        public virtual TResult Visit(CodeMemberField code, TArg arg)
        {
            VisitAll(code.Comments, arg);
            VisitAll(code.CustomAttributes, arg);
            VisitAll(code.StartDirectives, arg);
            VisitAll(code.EndDirectives, arg);
            code.InitExpression?.Accept(this, arg);
            code.Type?.Accept(this, arg);
            return default;
        }

        public virtual TResult Visit(CodeMemberProperty code, TArg arg)
        {
            VisitAll(code.StartDirectives, arg);
            code.Type.Accept(this, arg);
            VisitAll(code.GetStatements, arg);
            VisitAll(code.SetStatements, arg);
            VisitAll(code.ImplementationTypes, arg);
            VisitAll(code.Parameters, arg);
            code.PrivateImplementationType.Accept(this, arg);
            VisitAll(code.Comments, arg);
            VisitAll(code.CustomAttributes, arg);
            VisitAll(code.EndDirectives, arg);
            return default;
        }

        public virtual TResult Visit(CodeSnippetTypeMember regionDirective, TArg arg) => throw new NotImplementedException();

        public virtual TResult Visit(CodeTypeMember regionDirective, TArg arg) => throw new NotImplementedException();

        public virtual TResult Visit(CodeObject regionDirective, TArg arg) => throw new NotImplementedException();

        public virtual TResult Visit(CodeAttributeDeclaration code, TArg arg)
        {
            code.AttributeType.Accept(this, arg);
            VisitAll(code.Arguments, arg);
            return default;
        }

        public virtual TResult Visit(CodeAttributeArgument code, TArg arg)
        {
            code.Value.Accept(this, arg);
            return default;
        }

        private void VisitAll(CodeAttributeDeclarationCollection items, TArg arg)
        {
            if (items == null)
                return;
            foreach (CodeAttributeDeclaration item in items)
                Visit(item, arg);
        }

        private void VisitAll(CodeAttributeArgumentCollection items, TArg arg)
        {
            if (items == null)
                return;
            foreach (CodeAttributeArgument item in items)
                Visit(item, arg);
        }

        private void VisitAll(IEnumerable items, TArg arg)
        {
            if (items == null)
                return;
            foreach (CodeObject item in items)
                item.Accept(this, arg);
        }

        #endregion
    }
}