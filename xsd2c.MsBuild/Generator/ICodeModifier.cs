using System.CodeDom;

namespace xsd2c.Generator
{
    public interface ICodeModifier
    {
        void Execute(CodeNamespace codeNamespace);
    }
}