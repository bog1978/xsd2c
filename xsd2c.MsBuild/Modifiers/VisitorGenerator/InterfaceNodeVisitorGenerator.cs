using System.CodeDom;

namespace xsd2c.Modifiers
{
    internal class InterfaceNodeVisitorGenerator : BaseVisitorGenerator
    {
        public InterfaceNodeVisitorGenerator(CodeNamespace @namespace) : base(@namespace)
        {
        }

        public override void Generate()
        {
            var interfaceCode = new CodeTypeDeclaration(InterfaceName)
            {
                IsInterface = true,
            };

            foreach (var type in TypesToVisit)
                interfaceCode.Members.Add(CreateVisitMethod(type));

            Namespace.Types.Add(interfaceCode);
        }

        private static CodeMemberMethod CreateVisitMethod(CodeTypeDeclaration type) =>
            new()
            {
                Name = VisitMethodName,
                ReturnType = new CodeTypeReference(typeof(object)),
                Attributes = MemberAttributes.Public,
                Parameters =
                {
                    new CodeParameterDeclarationExpression(new CodeTypeReference(type.Name), "node"),
                    new CodeParameterDeclarationExpression(new CodeTypeReference(typeof(object)), "arg"),
                },
            };
    }
}