using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using xsd2c.Generator;

namespace xsd2c.Modifiers
{
    internal class ImplementVisitorCodeModifier : ICodeModifier
    {
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

            var visitorTypeCode = ImplementDefaultVisitor(typesToVisit, visitorName, interfaceName, baseTypeName);
            codeNamespace.Types.Add(visitorTypeCode);
        }

        private static CodeTypeDeclaration ImplementDefaultVisitor(ICollection<CodeTypeDeclaration> typesToVisit, string visitorName, string interfaceName,
            string baseTypeName)
        {
            var visitorInterfaceRef = new CodeTypeReference(interfaceName);
            var visitorCode = new CodeTypeDeclaration(visitorName)
            {
                BaseTypes = { visitorInterfaceRef }
            };

            var typeMap = typesToVisit.ToDictionary(x => x.Name);

            foreach (var type in typesToVisit)
            {
                var method = new CodeMemberMethod
                {
                    Name = "Visit",
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
                    if (member is CodeMemberProperty p)
                    {
                        var propertyType = p.Type;
                        if (typeMap.TryGetValue(propertyType.BaseType, out _))
                        {
                            if (propertyType.ArrayRank == 0)
                            {
                                method.Statements.Add(
                                    new CodeConditionStatement(
                                        new CodeBinaryOperatorExpression(
                                            new CodePropertyReferenceExpression(
                                                new CodeVariableReferenceExpression("node"),
                                                p.Name),
                                            CodeBinaryOperatorType.IdentityInequality,
                                            new CodePrimitiveExpression(null)),
                                        new CodeExpressionStatement(
                                            new CodeMethodInvokeExpression(
                                                new CodePropertyReferenceExpression(
                                                    new CodeVariableReferenceExpression("node"),
                                                    p.Name),
                                                "Accept",
                                                new CodeThisReferenceExpression(),
                                                new CodeVariableReferenceExpression("arg")))));
                            }
                            else
                            {
                                method.Statements.Add(
                                    new CodeMethodInvokeExpression(
                                        new CodeMethodReferenceExpression(
                                            new CodeThisReferenceExpression(),
                                            "VisitAll"),
                                        new CodePropertyReferenceExpression(
                                            new CodeVariableReferenceExpression("node"),
                                            p.Name),
                                        new CodeVariableReferenceExpression("arg")));
                            }
                        }
                    }
                }

                method.Statements.Add(
                    new CodeMethodReturnStatement(
                        new CodeDefaultValueExpression(
                            new CodeTypeReference(typeof(object)))));

                visitorCode.Members.Add(method);
            }

            var visitAllMethod = new CodeMemberMethod
            {
                Name = "VisitAll",
                //ReturnType = new CodeTypeReference(typeof(object)),
                Attributes = MemberAttributes.Private,
                Parameters =
                {
                    new CodeParameterDeclarationExpression(new CodeTypeReference(baseTypeName, 1), "items"),
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
                                    "Accept",
                                    new CodeThisReferenceExpression(),
                                    new CodeVariableReferenceExpression("arg")))))
                }
            };

            visitorCode.Members.Add(visitAllMethod);

            return visitorCode;
        }


        private static void InheritFromBaseType(ICollection<CodeTypeDeclaration> typesToVisit, string baseTypeName)
        {
            foreach (var t in typesToVisit)
            {
                var typeRef = FindBaseType(typesToVisit, t);
                if (typeRef == null)
                    t.BaseTypes.Insert(0, new CodeTypeReference(baseTypeName));
            }
        }

        private static CodeTypeReference FindBaseType(ICollection<CodeTypeDeclaration> typesToVisit, CodeTypeDeclaration codeType)
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

        private static void ImplementAccept(ICollection<CodeTypeDeclaration> typesToVisit, string visitorInterfaceName)
        {
            var visitorInterfaceRef = new CodeTypeReference(visitorInterfaceName);
            foreach (var t in typesToVisit)
            {
                t.Members.Add(new CodeMemberMethod
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
            };

            visitorBaseNodeCode.Members.Add(
                new CodeMemberMethod
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
            );

            return visitorBaseNodeCode;
        }

        private static CodeTypeDeclaration GenerateInterface(ICollection<CodeTypeDeclaration> typesToVisit, string visitorInterfaceName)
        {
            var interfaceCode = new CodeTypeDeclaration(visitorInterfaceName)
            {
                IsInterface = true,
            };

            foreach (var type in typesToVisit)
            {
                interfaceCode.Members.Add(new CodeMemberMethod
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