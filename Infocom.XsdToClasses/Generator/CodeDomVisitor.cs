using System;
using System.CodeDom;
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
            code.Comments.AcceptAll(this, arg);
            code.Imports.AcceptAll(this, arg);
            code.Types.AcceptAll(this, arg);
            return default;
        }

        public virtual TResult Visit(CodeNamespaceImport code, TArg arg)
        {
            code.LinePragma.Accept(this, arg);
            return default;
        }

        public virtual TResult Visit(CodeTypeParameter code, TArg arg) => throw new NotImplementedException();

        public virtual TResult Visit(CodeTypeReference code, TArg arg)
        {
            code.ArrayElementType.Accept(this, arg);
            code.TypeArguments.AcceptAll(this, arg);
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

        public virtual TResult Visit(CodeDefaultValueExpression code, TArg arg)
        {
            code.Type.Accept(this, arg);
            return default;
        }

        public virtual TResult Visit(CodeDelegateCreateExpression regionDirective, TArg arg) => throw new NotImplementedException();

        public virtual TResult Visit(CodeDelegateInvokeExpression code, TArg arg)
        {
            code.TargetObject.Accept(this, arg);
            code.Parameters.AcceptAll(this, arg);
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
            code.Parameters.AcceptAll(this, arg);
            code.Method.Accept(this, arg);
            return default;
        }

        public virtual TResult Visit(CodeMethodReferenceExpression code, TArg arg)
        {
            code.TargetObject.Accept(this, arg);
            code.TypeArguments.AcceptAll(this, arg);
            return default;
        }

        public virtual TResult Visit(CodeObjectCreateExpression code, TArg arg)
        {
            code.CreateType.Accept(this, arg);
            code.Parameters.AcceptAll(this, arg);
            return default;
        }

        public virtual TResult Visit(CodeParameterDeclarationExpression code, TArg arg)
        {
            code.CustomAttributes.AcceptAll(this, arg);
            code.Type.Accept(this, arg);
            return default;
        }

        public virtual TResult Visit(CodePrimitiveExpression code, TArg arg) => default;

        public virtual TResult Visit(CodePropertyReferenceExpression code, TArg arg)
        {
            code.TargetObject.Accept(this, arg);
            return default;
        }

        public virtual TResult Visit(CodePropertySetValueReferenceExpression code, TArg arg) => default;

        public virtual TResult Visit(CodeSnippetExpression regionDirective, TArg arg) => throw new NotImplementedException();

        public virtual TResult Visit(CodeThisReferenceExpression code, TArg arg) => default;

        public virtual TResult Visit(CodeTypeOfExpression code, TArg arg)
        {
            code.Type.Accept(this, arg);
            return default;
        }

        public virtual TResult Visit(CodeTypeReferenceExpression code, TArg arg)
        {
            code.Type.Accept(this, arg);
            return default;
        }

        public virtual TResult Visit(CodeVariableReferenceExpression code, TArg arg) => default;

        public virtual TResult Visit(CodeExpression regionDirective, TArg arg) => throw new NotImplementedException();

        public virtual TResult Visit(CodeAssignStatement code, TArg arg)
        {
            code.LinePragma.Accept(this, arg);
            code.StartDirectives.AcceptAll(this, arg);
            code.Left.Accept(this, arg);
            code.Right.Accept(this, arg);
            code.EndDirectives.AcceptAll(this, arg);
            return default;
        }

        public virtual TResult Visit(CodeAttachEventStatement regionDirective, TArg arg) => throw new NotImplementedException();

        public virtual TResult Visit(CodeCommentStatement code, TArg arg)
        {
            code.LinePragma.Accept(this, arg);
            code.Comment.Accept(this, arg);
            code.StartDirectives.AcceptAll(this, arg);
            code.EndDirectives.AcceptAll(this, arg);
            return default;
        }

        public virtual TResult Visit(CodeConditionStatement code, TArg arg)
        {
            code.LinePragma.Accept(this, arg);
            code.StartDirectives.AcceptAll(this, arg);
            code.Condition.Accept(this, arg);
            code.TrueStatements.AcceptAll(this, arg);
            code.FalseStatements.AcceptAll(this, arg);
            code.EndDirectives.AcceptAll(this, arg);
            return default;
        }

        public virtual TResult Visit(CodeExpressionStatement code, TArg arg)
        {
            code.LinePragma.Accept(this, arg);
            code.StartDirectives.AcceptAll(this, arg);
            code.Expression.Accept(this, arg);
            code.EndDirectives.AcceptAll(this, arg);
            return default;
        }

        public virtual TResult Visit(CodeGotoStatement regionDirective, TArg arg) => throw new NotImplementedException();

        public virtual TResult Visit(CodeIterationStatement code, TArg arg)
        {
            code.LinePragma.Accept(this, arg);
            code.StartDirectives.AcceptAll(this, arg);
            code.Statements.AcceptAll(this, arg);
            code.InitStatement.Accept(this, arg);
            code.TestExpression.Accept(this, arg);
            code.IncrementStatement.Accept(this, arg);
            code.EndDirectives.AcceptAll(this, arg);
            return default;
        }

        public virtual TResult Visit(CodeLabeledStatement regionDirective, TArg arg) => throw new NotImplementedException();

        public virtual TResult Visit(CodeMethodReturnStatement code, TArg arg)
        {
            code.LinePragma.Accept(this, arg);
            code.StartDirectives.AcceptAll(this, arg);
            code.Expression.Accept(this, arg);
            code.EndDirectives.AcceptAll(this, arg);
            return default;
        }

        public virtual TResult Visit(CodeRemoveEventStatement regionDirective, TArg arg) => throw new NotImplementedException();

        public virtual TResult Visit(CodeSnippetStatement regionDirective, TArg arg) => throw new NotImplementedException();

        public virtual TResult Visit(CodeThrowExceptionStatement regionDirective, TArg arg) => throw new NotImplementedException();

        public virtual TResult Visit(CodeTryCatchFinallyStatement regionDirective, TArg arg) => throw new NotImplementedException();

        public virtual TResult Visit(CodeVariableDeclarationStatement code, TArg arg)
        {
            code.LinePragma.Accept(this, arg);
            code.StartDirectives.AcceptAll(this, arg);
            code.InitExpression.Accept(this, arg);
            code.Type.Accept(this, arg);
            code.EndDirectives.AcceptAll(this, arg);
            return default;
        }

        public virtual TResult Visit(CodeStatement code, TArg arg) => throw new NotImplementedException();

        public virtual TResult Visit(CodeConstructor code, TArg arg)
        {
            code.StartDirectives.AcceptAll(this, arg);
            code.BaseConstructorArgs.AcceptAll(this, arg);
            code.ChainedConstructorArgs.AcceptAll(this, arg);
            code.CustomAttributes.AcceptAll(this, arg);
            code.Comments.AcceptAll(this, arg);
            code.ImplementationTypes.AcceptAll(this, arg);
            code.LinePragma.Accept(this, arg);
            code.Parameters.AcceptAll(this, arg);
            code.PrivateImplementationType.Accept(this, arg);
            code.ReturnType.Accept(this, arg);
            code.ReturnTypeCustomAttributes.AcceptAll(this, arg);
            code.Statements.AcceptAll(this, arg);
            code.TypeParameters.AcceptAll(this, arg);
            code.EndDirectives.AcceptAll(this, arg);
            return default;
        }

        public virtual TResult Visit(CodeEntryPointMethod regionDirective, TArg arg) => throw new NotImplementedException();

        public virtual TResult Visit(CodeTypeConstructor regionDirective, TArg arg) => throw new NotImplementedException();

        public virtual TResult Visit(CodeMemberMethod code, TArg arg)
        {
            code.LinePragma.Accept(this, arg);
            code.StartDirectives.AcceptAll(this, arg);
            code.Comments.AcceptAll(this, arg);
            code.Statements.AcceptAll(this, arg);
            code.CustomAttributes.AcceptAll(this, arg);
            code.ImplementationTypes.AcceptAll(this, arg);
            code.Parameters.AcceptAll(this, arg);
            code.TypeParameters.AcceptAll(this, arg);
            code.ReturnTypeCustomAttributes.AcceptAll(this, arg);
            code.PrivateImplementationType.Accept(this, arg);
            code.ReturnType.Accept(this, arg);
            code.EndDirectives.AcceptAll(this, arg);
            return default;
        }

        public virtual TResult Visit(CodeTypeDelegate regionDirective, TArg arg) => throw new NotImplementedException();

        public virtual TResult Visit(CodeTypeDeclaration code, TArg arg)
        {
            code.LinePragma.Accept(this, arg);
            code.StartDirectives.AcceptAll(this, arg);
            code.BaseTypes.AcceptAll(this, arg);
            code.Members.AcceptAll(this, arg);
            code.TypeParameters.AcceptAll(this, arg);
            code.Comments.AcceptAll(this, arg);
            code.CustomAttributes.AcceptAll(this, arg);
            code.EndDirectives.AcceptAll(this, arg);
            return default;
        }

        public virtual TResult Visit(CodeMemberEvent code, TArg arg)
        {
            code.LinePragma.Accept(this, arg);
            code.StartDirectives.AcceptAll(this, arg);
            code.Comments.AcceptAll(this, arg);
            code.CustomAttributes.AcceptAll(this, arg);
            code.ImplementationTypes.AcceptAll(this, arg);
            code.PrivateImplementationType.Accept(this, arg);
            code.Type.Accept(this, arg);
            code.EndDirectives.AcceptAll(this, arg);
            return default;
        }

        public virtual TResult Visit(CodeMemberField code, TArg arg)
        {
            code.LinePragma.Accept(this, arg);
            code.Comments.AcceptAll(this, arg);
            code.CustomAttributes.AcceptAll(this, arg);
            code.StartDirectives.AcceptAll(this, arg);
            code.EndDirectives.AcceptAll(this, arg);
            code.InitExpression.Accept(this, arg);
            code.Type.Accept(this, arg);
            return default;
        }

        public virtual TResult Visit(CodeMemberProperty code, TArg arg)
        {
            code.LinePragma.Accept(this, arg);
            code.StartDirectives.AcceptAll(this, arg);
            code.Type.Accept(this, arg);
            code.GetStatements.AcceptAll(this, arg);
            code.SetStatements.AcceptAll(this, arg);
            code.ImplementationTypes.AcceptAll(this, arg);
            code.Parameters.AcceptAll(this, arg);
            code.PrivateImplementationType.Accept(this, arg);
            code.Comments.AcceptAll(this, arg);
            code.CustomAttributes.AcceptAll(this, arg);
            code.EndDirectives.AcceptAll(this, arg);
            return default;
        }

        public virtual TResult Visit(CodeSnippetTypeMember regionDirective, TArg arg) => throw new NotImplementedException();

        public virtual TResult Visit(CodeTypeMember regionDirective, TArg arg) => throw new NotImplementedException();

        public virtual TResult Visit(CodeObject regionDirective, TArg arg) => throw new NotImplementedException();

        public virtual TResult Visit(CodeAttributeDeclaration code, TArg arg)
        {
            code.AttributeType.Accept(this, arg);
            code.Arguments.AcceptAll(this, arg);
            return default;
        }

        public virtual TResult Visit(CodeAttributeArgument code, TArg arg)
        {
            code.Value.Accept(this, arg);
            return default;
        }

        public virtual TResult Visit(CodeLinePragma code, TArg arg) => default;

        #endregion
    }
}