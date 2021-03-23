using System.CodeDom;
using System.Linq;
using System.Reflection;

namespace xsd2c.Modifiers
{
    internal class BaseNodeVisitorGenerator : BaseVisitorGenerator
    {
        public BaseNodeVisitorGenerator(CodeNamespace @namespace) : base(@namespace)
        {
        }

        public override void Generate()
        {
            var baseTypeCode = GenerateBaseType();
            Namespace.Types.Add(baseTypeCode);

            ImplementAccept();
            InheritFromBaseType();
        }

        private void InheritFromBaseType()
        {
            foreach (var type in TypesToVisit)
                if (FindBaseType(type) == null)
                    type.BaseTypes.Insert(0, new CodeTypeReference(BaseTypeName));
        }

        private CodeTypeReference FindBaseType(CodeTypeDeclaration codeType)
        {
            foreach (CodeTypeReference r in codeType.BaseTypes)
            {
                if (TypesToVisit.Any(x => x.Name == r.BaseType))
                    return r;
                if (r.BaseType == typeof(object).FullName)
                {
                    codeType.BaseTypes.Remove(r);
                    return null;
                }
            }
            return null;
        }

        private void ImplementAccept()
        {
            foreach (var type in TypesToVisit) 
                type.Members.Add(CreateAcceptMethodImpl());
        }

        private CodeMemberMethod CreateAcceptMethodImpl() =>
            new()
            {
                Name = AcceptMethodName,
                ReturnType = new CodeTypeReference(typeof(object)),
                Attributes = MemberAttributes.Public | MemberAttributes.Override,
                Parameters =
                {
                    new CodeParameterDeclarationExpression(new CodeTypeReference(InterfaceName), "visitor"),
                    new CodeParameterDeclarationExpression(new CodeTypeReference(typeof(object)), "arg"),
                },
                Statements =
                {
                    new CodeMethodReturnStatement(
                        new CodeMethodInvokeExpression(
                            new CodeMethodReferenceExpression(
                                new CodeVariableReferenceExpression("visitor"), VisitMethodName),
                            new CodeThisReferenceExpression(),
                            new CodeVariableReferenceExpression("arg")))
                }
            };

        private CodeTypeDeclaration GenerateBaseType() =>
            new(BaseTypeName)
            {
                TypeAttributes = TypeAttributes.Public | TypeAttributes.Abstract,
                Members = { CreateAcceptMethodAbstract() }
            };

        private CodeMemberMethod CreateAcceptMethodAbstract() =>
            new()
            {
                Name = AcceptMethodName,
                ReturnType = new CodeTypeReference(typeof(object)),
                Attributes = MemberAttributes.Public | MemberAttributes.Abstract,
                Parameters =
                {
                    new CodeParameterDeclarationExpression(new CodeTypeReference(InterfaceName), "visitor"),
                    new CodeParameterDeclarationExpression(new CodeTypeReference(typeof(object)), "arg"),
                },
            };
    }
}