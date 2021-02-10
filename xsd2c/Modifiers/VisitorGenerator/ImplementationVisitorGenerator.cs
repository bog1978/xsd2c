﻿using System.CodeDom;
using System.Linq;

namespace xsd2c.Modifiers
{
    internal class ImplementationVisitorGenerator : BaseVisitorGenerator
    {
        private const string AcceptAllMethodName = "AcceptAll";
        private const string AcceptSingleMethodName = "AcceptSingle";

        private readonly string _visitorName;

        public ImplementationVisitorGenerator(CodeNamespace @namespace) : base(@namespace)
        {
            _visitorName = $"{Namespace.Name}NodeVisitor";
        }

        public override void Generate()
        {
            var visitorCode = new CodeTypeDeclaration(_visitorName)
            {
                BaseTypes = { new CodeTypeReference(InterfaceName) },
                Members =
                {
                    CreateAcceptAllMethod(),
                    CreateAcceptSingleMethod(),
                }
            };

            foreach (var type in TypesToVisit)
                visitorCode.Members.Add(CreateVisitMethod(type));

            Namespace.Types.Add(visitorCode);
        }

        private CodeMemberMethod CreateVisitMethod(CodeTypeDeclaration type)
        {
            var typeMap = TypesToVisit.ToDictionary(x => x.Name);
            var method = new CodeMemberMethod
            {
                Name = VisitMethodName,
                ReturnType = new CodeTypeReference(typeof(object)),
                Attributes = MemberAttributes.Public,
                Parameters =
                {
                    new CodeParameterDeclarationExpression(new CodeTypeReference(type.Name), "node"),
                    new CodeParameterDeclarationExpression(new CodeTypeReference(typeof(object)), "arg"),
                }
            };

            foreach (CodeTypeMember member in type.Members)
            {
                if (member is not CodeMemberProperty p)
                    continue;

                if (!typeMap.ContainsKey(p.Type.BaseType))
                    continue;

                var methodName = p.Type.ArrayRank == 0
                    ? AcceptSingleMethodName
                    : AcceptAllMethodName;

                method.Statements.Add(
                    new CodeMethodInvokeExpression(
                        new CodeMethodReferenceExpression(null, methodName),
                        new CodePropertyReferenceExpression(
                            new CodeVariableReferenceExpression("node"),
                            p.Name),
                        new CodeVariableReferenceExpression("arg")));
            }

            method.Statements.Add(
                new CodeMethodReturnStatement(
                    new CodeDefaultValueExpression(
                        new CodeTypeReference(typeof(object)))));
            return method;
        }

        private CodeMemberMethod CreateAcceptAllMethod() =>
            new()
            {
                Name = AcceptAllMethodName,
                //ReturnType = new CodeTypeReference(typeof(object)),
                Attributes = MemberAttributes.Private,
                Parameters =
                {
                    new CodeParameterDeclarationExpression(new CodeTypeReference(BaseTypeName, 1), "items"),
                    new CodeParameterDeclarationExpression(new CodeTypeReference(typeof(object)), "arg"),
                },
                Statements =
                {
                    new CodeConditionStatement(
                        new CodeBinaryOperatorExpression(
                            new CodeVariableReferenceExpression("items"),
                            CodeBinaryOperatorType.IdentityInequality,
                            new CodePrimitiveExpression(null)),
                        new CodeIterationStatement(
                            new CodeVariableDeclarationStatement(
                                typeof(int),
                                "index",
                                new CodePrimitiveExpression(0)),
                            new CodeBinaryOperatorExpression(
                                new CodeVariableReferenceExpression("index"),
                                CodeBinaryOperatorType.LessThan,
                                new CodePropertyReferenceExpression(
                                    new CodeVariableReferenceExpression("items"), "Length")),
                            new CodeAssignStatement(
                                new CodeVariableReferenceExpression("index"),
                                new CodeBinaryOperatorExpression(
                                    new CodeVariableReferenceExpression("index"),
                                    CodeBinaryOperatorType.Add,
                                    new CodePrimitiveExpression(1))),
                            new CodeExpressionStatement(
                                new CodeMethodInvokeExpression(
                                    new CodeArrayIndexerExpression(
                                        new CodeVariableReferenceExpression("items"),
                                        new CodeVariableReferenceExpression("index")),
                                    AcceptMethodName,
                                    new CodeThisReferenceExpression(),
                                    new CodeVariableReferenceExpression("arg")))))
                }
            };

        private CodeMemberMethod CreateAcceptSingleMethod() =>
            new()
            {
                Name = AcceptSingleMethodName,
                //ReturnType = new CodeTypeReference(typeof(object)),
                Attributes = MemberAttributes.Private,
                Parameters =
                {
                    new CodeParameterDeclarationExpression(new CodeTypeReference(BaseTypeName), "item"),
                    new CodeParameterDeclarationExpression(new CodeTypeReference(typeof(object)), "arg"),
                },
                Statements =
                {
                    new CodeConditionStatement(
                        new CodeBinaryOperatorExpression(
                            new CodeVariableReferenceExpression("item"),
                            CodeBinaryOperatorType.IdentityInequality,
                            new CodePrimitiveExpression(null)),
                        new CodeExpressionStatement(
                            new CodeMethodInvokeExpression(
                                new CodeVariableReferenceExpression("item"),
                                AcceptMethodName,
                                new CodeThisReferenceExpression(),
                                new CodeVariableReferenceExpression("arg"))))
                }
            };
    }
}