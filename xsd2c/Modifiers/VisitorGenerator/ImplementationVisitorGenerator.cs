using System.CodeDom;
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
                if (!member.Attributes.HasFlag(MemberAttributes.Public)
                    || member.Attributes.HasFlag(MemberAttributes.Static))
                    continue;

                CodeTypeReference t;
                string name;

                switch (member)
                {
                    case CodeMemberProperty p:
                        t = p.Type;
                        name = p.Name;
                        break;
                    case CodeMemberField f:
                        t = f.Type;
                        name = f.Name;
                        break;
                    default:
                        continue;
                }

                if (!typeMap.ContainsKey(t.BaseType))
                    continue;

                var methodName = t.ArrayRank == 0
                    ? AcceptSingleMethodName
                    : AcceptAllMethodName;

                method.Statements.Add(
                    new CodeMethodInvokeExpression(
                        new CodeMethodReferenceExpression(null, methodName),
                        new CodePropertyReferenceExpression(new CodeVariableReferenceExpression("node"), name),
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
                    new CodeParameterDeclarationExpression(
                        new CodeTypeReference("IEnumerable", new CodeTypeReference(BaseTypeName)), "items"),
                    new CodeParameterDeclarationExpression(
                        new CodeTypeReference(typeof(object)), "arg"),
                },
                Statements =
                {
                    new CodeConditionStatement(
                        new CodeBinaryOperatorExpression(
                            new CodeVariableReferenceExpression("items"),
                            CodeBinaryOperatorType.IdentityEquality,
                            new CodePrimitiveExpression(null)),
                        new CodeMethodReturnStatement()),
                    new CodeIterationStatement(
                        new CodeVariableDeclarationStatement("var", "en",
                            new CodeMethodInvokeExpression(new CodeVariableReferenceExpression("items"), "GetEnumerator")),
                        new CodeMethodInvokeExpression(new CodeVariableReferenceExpression("en"), "MoveNext"),
                        new CodeExpressionStatement(new CodeVariableReferenceExpression("")),
                        new CodeExpressionStatement(
                            new CodeMethodInvokeExpression(
                                null,
                                AcceptSingleMethodName,
                                new CodePropertyReferenceExpression(new CodeVariableReferenceExpression("en"), "Current"),
                                new CodeVariableReferenceExpression("arg"))))
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
                    new CodeExpressionStatement(
                        new CodeMethodInvokeExpression(
                            new CodeVariableReferenceExpression("item?"),
                            AcceptMethodName,
                            new CodeThisReferenceExpression(),
                            new CodeVariableReferenceExpression("arg")))
                }
            };
    }
}