using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using xsd2c.Generator;

namespace xsd2c.Modifiers
{
    internal class ImplementVisitorCodeModifier : ICodeModifier
    {
        public ImplementVisitorCodeModifier()
        {

        }

        public void Execute(CodeNamespace codeNamespace)
        {
            var typesToVisit = codeNamespace.Types
                .OfType<CodeTypeDeclaration>()
                .Where(x => x.IsClass)
                .ToList();

            var interfaceName = $"I{codeNamespace.Name}NodeVisitor";
            var baseTypeName = $"{codeNamespace.Name}NodeBase";
            var visitorName = $"{codeNamespace.Name}NodeVisitor";

            var interfaceCode = GenerateInterface(typesToVisit, interfaceName);
            codeNamespace.Types.Add(interfaceCode);

            var baseTypeCode = GenerateBaseType(baseTypeName, interfaceName);
            codeNamespace.Types.Add(baseTypeCode);

            ImplementAccept(typesToVisit, interfaceName);
            InheritFromBaseType(typesToVisit, baseTypeName);

            var visitorTypeCode = ImplementDefaultVisitor(typesToVisit, visitorName, interfaceName);
            codeNamespace.Types.Add(visitorTypeCode);
        }

        private static CodeTypeDeclaration ImplementDefaultVisitor(List<CodeTypeDeclaration> typesToVisit, string visitorName, string interfaceName)
        {
            var visitorInterfaceRef = new CodeTypeReference(interfaceName);
            var visitorCode = new CodeTypeDeclaration(visitorName)
            {
                BaseTypes = { visitorInterfaceRef }
            };

            foreach (var type in typesToVisit)
            {
                visitorCode.Members.Add(new CodeMemberMethod()
                {
                    Name = "Visit",
                    ReturnType = new CodeTypeReference(typeof(object)),
                    Attributes = MemberAttributes.Public,
                    Parameters =
                    {
                        new CodeParameterDeclarationExpression(new CodeTypeReference(type.Name), "node"),
                        new CodeParameterDeclarationExpression(new CodeTypeReference(typeof(object)), "arg"),
                    },
                    Statements =
                    {
                        new CodeMethodReturnStatement(
                            new CodeDefaultValueExpression(
                                new CodeTypeReference(typeof(object))))
                    }
                });
            }

            return visitorCode;
        }


        private void InheritFromBaseType(List<CodeTypeDeclaration> typesToVisit, string baseTypeName)
        {
            foreach (var t in typesToVisit)
            {
                var typeRef = FindBaseType(typesToVisit, t);
                if (typeRef == null)
                    t.BaseTypes.Insert(0, new CodeTypeReference(baseTypeName));
            }
        }

        private CodeTypeReference FindBaseType(List<CodeTypeDeclaration> typesToVisit, CodeTypeDeclaration codeType)
        {
            foreach (CodeTypeReference r in codeType.BaseTypes)
            {
                if (typesToVisit.Any(x => x.Name == r.BaseType))
                    return r;
                if (r.BaseType == typeof(object).FullName)
                {
                    codeType.BaseTypes.Remove(r);
                    return null;
                }
            }
            return null;
        }

        private static void ImplementAccept(List<CodeTypeDeclaration> typesToVisit, string visitorInterfaceName)
        {
            var visitorInterfaceRef = new CodeTypeReference(visitorInterfaceName);
            foreach (var t in typesToVisit)
            {
                t.Members.Add(new CodeMemberMethod()
                {
                    Name = "Accept",
                    ReturnType = new CodeTypeReference(typeof(object)),
                    Attributes = MemberAttributes.Public | MemberAttributes.Override,
                    Parameters =
                        {
                            new CodeParameterDeclarationExpression(visitorInterfaceRef, "visitor"),
                            new CodeParameterDeclarationExpression(new CodeTypeReference(typeof(object)), "arg"),
                        },
                    Statements =
                    {
                        new CodeMethodReturnStatement(
                            new CodeMethodInvokeExpression(
                                new CodeMethodReferenceExpression(
                                    new CodeVariableReferenceExpression("visitor"), "Visit"),
                                    new CodeThisReferenceExpression(),
                                    new CodeVariableReferenceExpression("arg")))
                    }
                });
            }
        }

        private static CodeTypeDeclaration GenerateBaseType(string visitorBaseNodeName, string visitorInterfaceName)
        {
            var visitorInterfaceRef = new CodeTypeReference(visitorInterfaceName);
            var visitorBaseNodeCode = new CodeTypeDeclaration(visitorBaseNodeName)
            {
                TypeAttributes = TypeAttributes.Public | TypeAttributes.Abstract,
                Members =
                {
                    new CodeMemberMethod()
                    {
                        Name = "Accept",
                        ReturnType = new CodeTypeReference(typeof(object)),
                        Attributes = MemberAttributes.Public | MemberAttributes.Abstract,
                        Parameters =
                        {
                            new CodeParameterDeclarationExpression(visitorInterfaceRef, "visitor"),
                            new CodeParameterDeclarationExpression(new CodeTypeReference(typeof(object)), "arg"),
                        },
                    }
                },
            };
            return visitorBaseNodeCode;
        }

        private static CodeTypeDeclaration GenerateInterface(List<CodeTypeDeclaration> typesToVisit, string visitorInterfaceName)
        {
            var interfaceCode = new CodeTypeDeclaration(visitorInterfaceName)
            {
                IsInterface = true,
            };

            foreach (var type in typesToVisit)
            {
                interfaceCode.Members.Add(new CodeMemberMethod()
                {
                    Name = "Visit",
                    ReturnType = new CodeTypeReference(typeof(object)),
                    Attributes = MemberAttributes.Public,
                    Parameters =
                    {
                        new CodeParameterDeclarationExpression(new CodeTypeReference(type.Name), "node"),
                        new CodeParameterDeclarationExpression(new CodeTypeReference(typeof(object)), "arg"),
                    },
                });
            }
            return interfaceCode;
        }
    }
}