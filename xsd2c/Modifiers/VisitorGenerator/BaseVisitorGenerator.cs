using System.CodeDom;
using System.Collections.Generic;
using System.Linq;

namespace xsd2c.Modifiers
{
    internal abstract class BaseVisitorGenerator
    {
        protected const string VisitMethodName = "Visit";
        protected const string AcceptMethodName = "Accept";

        protected readonly CodeNamespace Namespace;
        protected readonly List<CodeTypeDeclaration> TypesToVisit;
        protected readonly string InterfaceName;
        protected readonly string BaseTypeName;

        protected BaseVisitorGenerator(CodeNamespace @namespace)
        {
            Namespace = @namespace;
            TypesToVisit = Namespace.Types.OfType<CodeTypeDeclaration>()
                .Where(x => x.IsClass)
                .ToList();

            InterfaceName = $"I{Namespace.Name}NodeVisitor";
            BaseTypeName = $"{Namespace.Name}NodeBase";
        }

        public abstract void Generate();
    }
}