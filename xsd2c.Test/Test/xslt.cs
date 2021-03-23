namespace xslt
{
    using System.Collections.Generic;
    using System;
    using System.Xml.Serialization;
    using System.ComponentModel;
    using System.Xml.Schema;
    
    
    [XmlType(TypeName="apply-imports", Namespace="http://www.w3.org/1999/XSL/Transform")]
    [XmlRoot("apply-imports", Namespace="http://www.w3.org/1999/XSL/Transform", IsNullable=true)]
    public partial class applyimports : xsltNodeBase
    {
        
        public override Object Accept(IxsltNodeVisitor visitor, Object arg)
        {
            return visitor.Visit(this, arg);
        }
    }
    
    public partial class attributeset : xsltNodeBase
    {
        
        public attributeset()
        {
        }
        
        [XmlElement("attribute")]
        public attribute[] attribute;
        
        [XmlAttribute(DataType="NMTOKEN")]
        public String name;
        
        [XmlAttribute("use-attribute-sets", DataType="NMTOKENS")]
        public String useattributesets;
        
        public override Object Accept(IxsltNodeVisitor visitor, Object arg)
        {
            return visitor.Visit(this, arg);
        }
    }
    
    public partial class attribute : xsltNodeBase
    {
        
        public attribute()
        {
        }
        
        public override Object Accept(IxsltNodeVisitor visitor, Object arg)
        {
            return visitor.Visit(this, arg);
        }
    }
    
    public partial class calltemplate : xsltNodeBase
    {
        
        public calltemplate()
        {
        }
        
        [XmlElement("with-param")]
        public withparam[] withparam;
        
        [XmlAttribute(DataType="NMTOKEN")]
        public String name;
        
        public override Object Accept(IxsltNodeVisitor visitor, Object arg)
        {
            return visitor.Visit(this, arg);
        }
    }
    
    public partial class withparam : xsltNodeBase
    {
        
        public withparam()
        {
        }
        
        public override Object Accept(IxsltNodeVisitor visitor, Object arg)
        {
            return visitor.Visit(this, arg);
        }
    }
    
    [XmlType(TypeName="copy-of", Namespace="http://www.w3.org/1999/XSL/Transform")]
    [XmlRoot("copy-of", Namespace="http://www.w3.org/1999/XSL/Transform", IsNullable=true)]
    public partial class copyof : xsltNodeBase
    {
        
        [XmlAttribute()]
        public String select;
        
        public override Object Accept(IxsltNodeVisitor visitor, Object arg)
        {
            return visitor.Visit(this, arg);
        }
    }
    
    [XmlType(TypeName="decimal-format", Namespace="http://www.w3.org/1999/XSL/Transform")]
    [XmlRoot("decimal-format", Namespace="http://www.w3.org/1999/XSL/Transform", IsNullable=true)]
    public partial class decimalformat : xsltNodeBase
    {
        
        public decimalformat()
        {
            this.decimalseparator = ".";
            this.digit = "#";
            this.groupingseparator = ",";
            this.infinity = "Infinity";
            this.minussign = "-";
            this.NaN = "NaN";
            this.patternseparator = ";";
            this.percent = "%";
            this.permille = "‰";
            this.zerodigit = "0";
        }
        
        [XmlAttribute("decimal-separator")]
        [DefaultValue(".")]
        public String decimalseparator;
        
        [XmlAttribute()]
        [DefaultValue("#")]
        public String digit;
        
        [XmlAttribute("grouping-separator")]
        [DefaultValue(",")]
        public String groupingseparator;
        
        [XmlAttribute()]
        [DefaultValue("Infinity")]
        public String infinity;
        
        [XmlAttribute("minus-sign")]
        [DefaultValue("-")]
        public String minussign;
        
        [XmlAttribute(DataType="NMTOKEN")]
        public String name;
        
        [XmlAttribute()]
        [DefaultValue("NaN")]
        public String NaN;
        
        [XmlAttribute("pattern-separator")]
        [DefaultValue(";")]
        public String patternseparator;
        
        [XmlAttribute()]
        [DefaultValue("%")]
        public String percent;
        
        [XmlAttribute("per-mille")]
        [DefaultValue("‰")]
        public String permille;
        
        [XmlAttribute("zero-digit")]
        [DefaultValue("0")]
        public String zerodigit;
        
        public override Object Accept(IxsltNodeVisitor visitor, Object arg)
        {
            return visitor.Visit(this, arg);
        }
    }
    
    public partial class @foreach : xsltNodeBase
    {
        
        public @foreach()
        {
        }
        
        public override Object Accept(IxsltNodeVisitor visitor, Object arg)
        {
            return visitor.Visit(this, arg);
        }
    }
    
    [XmlType(Namespace="http://www.w3.org/1999/XSL/Transform")]
    [XmlRoot(Namespace="http://www.w3.org/1999/XSL/Transform", IsNullable=true)]
    public partial class import : xsltNodeBase
    {
        
        [XmlAttribute()]
        public String href;
        
        public override Object Accept(IxsltNodeVisitor visitor, Object arg)
        {
            return visitor.Visit(this, arg);
        }
    }
    
    [XmlType(Namespace="http://www.w3.org/1999/XSL/Transform")]
    [XmlRoot(Namespace="http://www.w3.org/1999/XSL/Transform", IsNullable=true)]
    public partial class include : xsltNodeBase
    {
        
        [XmlAttribute()]
        public String href;
        
        public override Object Accept(IxsltNodeVisitor visitor, Object arg)
        {
            return visitor.Visit(this, arg);
        }
    }
    
    [XmlType(Namespace="http://www.w3.org/1999/XSL/Transform")]
    [XmlRoot(Namespace="http://www.w3.org/1999/XSL/Transform", IsNullable=true)]
    public partial class key : xsltNodeBase
    {
        
        [XmlAttribute()]
        public String match;
        
        [XmlAttribute(DataType="NMTOKEN")]
        public String name;
        
        [XmlAttribute()]
        public String use;
        
        public override Object Accept(IxsltNodeVisitor visitor, Object arg)
        {
            return visitor.Visit(this, arg);
        }
    }
    
    [XmlType(TypeName="namespace-alias", Namespace="http://www.w3.org/1999/XSL/Transform")]
    [XmlRoot("namespace-alias", Namespace="http://www.w3.org/1999/XSL/Transform", IsNullable=true)]
    public partial class namespacealias : xsltNodeBase
    {
        
        [XmlAttribute("result-prefix")]
        public String resultprefix;
        
        [XmlAttribute("stylesheet-prefix")]
        public String stylesheetprefix;
        
        public override Object Accept(IxsltNodeVisitor visitor, Object arg)
        {
            return visitor.Visit(this, arg);
        }
    }
    
    [XmlType(Namespace="http://www.w3.org/1999/XSL/Transform")]
    [XmlRoot(Namespace="http://www.w3.org/1999/XSL/Transform", IsNullable=true)]
    public partial class number : xsltNodeBase
    {
        
        public number()
        {
            this.format = "1";
            this.level = numberLevel.single;
        }
        
        [XmlAttribute()]
        public String count;
        
        [XmlAttribute()]
        [DefaultValue("1")]
        public String format;
        
        [XmlAttribute()]
        public String from;
        
        [XmlAttribute("grouping-separator")]
        public String groupingseparator;
        
        [XmlAttribute("grouping-size")]
        public String groupingsize;
        
        [XmlAttribute()]
        public String lang;
        
        [XmlAttribute("letter-value")]
        public String lettervalue;
        
        [XmlAttribute()]
        [DefaultValue(numberLevel.single)]
        public numberLevel level;
        
        [XmlAttribute()]
        public String value;
        
        public override Object Accept(IxsltNodeVisitor visitor, Object arg)
        {
            return visitor.Visit(this, arg);
        }
    }
    
    [XmlType(AnonymousType=true, Namespace="http://www.w3.org/1999/XSL/Transform")]
    public enum numberLevel
    {
        
        single,
        
        multiple,
        
        any,
    }
    
    [XmlType(Namespace="http://www.w3.org/1999/XSL/Transform")]
    [XmlRoot(Namespace="http://www.w3.org/1999/XSL/Transform", IsNullable=true)]
    public partial class output : xsltNodeBase
    {
        
        [XmlAttribute("cdata-section-elements", DataType="NMTOKENS")]
        public String cdatasectionelements;
        
        [XmlAttribute("doctype-public")]
        public String doctypepublic;
        
        [XmlAttribute("doctype-system")]
        public String doctypesystem;
        
        [XmlAttribute()]
        public String encoding;
        
        [XmlAttribute()]
        public outputIndent indent;
        
        [XmlIgnore()]
        public Boolean indentSpecified;
        
        [XmlAttribute("media-type")]
        public String mediatype;
        
        [XmlAttribute()]
        public String method;
        
        [XmlAttribute("omit-xml-declaration")]
        public outputOmitxmldeclaration omitxmldeclaration;
        
        [XmlIgnore()]
        public Boolean omitxmldeclarationSpecified;
        
        [XmlAttribute()]
        public outputStandalone standalone;
        
        [XmlIgnore()]
        public Boolean standaloneSpecified;
        
        [XmlAttribute(DataType="NMTOKEN")]
        public String version;
        
        public override Object Accept(IxsltNodeVisitor visitor, Object arg)
        {
            return visitor.Visit(this, arg);
        }
    }
    
    [XmlType(AnonymousType=true, Namespace="http://www.w3.org/1999/XSL/Transform")]
    public enum outputIndent
    {
        
        yes,
        
        no,
    }
    
    [XmlType(AnonymousType=true, Namespace="http://www.w3.org/1999/XSL/Transform")]
    public enum outputOmitxmldeclaration
    {
        
        yes,
        
        no,
    }
    
    [XmlType(AnonymousType=true, Namespace="http://www.w3.org/1999/XSL/Transform")]
    public enum outputStandalone
    {
        
        yes,
        
        no,
    }
    
    [XmlType(TypeName="preserve-space", Namespace="http://www.w3.org/1999/XSL/Transform")]
    [XmlRoot("preserve-space", Namespace="http://www.w3.org/1999/XSL/Transform", IsNullable=true)]
    public partial class preservespace : xsltNodeBase
    {
        
        [XmlAttribute()]
        public String elements;
        
        public override Object Accept(IxsltNodeVisitor visitor, Object arg)
        {
            return visitor.Visit(this, arg);
        }
    }
    
    [XmlType(Namespace="http://www.w3.org/1999/XSL/Transform")]
    [XmlRoot(Namespace="http://www.w3.org/1999/XSL/Transform", IsNullable=true)]
    public partial class sort : xsltNodeBase
    {
        
        public sort()
        {
            this.select = ".";
            this.datatype = "text";
            this.order = "ascending";
        }
        
        [XmlAttribute()]
        [DefaultValue(".")]
        public String select;
        
        [XmlAttribute()]
        public String lang;
        
        [XmlAttribute("data-type")]
        [DefaultValue("text")]
        public String datatype;
        
        [XmlAttribute()]
        [DefaultValue("ascending")]
        public String order;
        
        [XmlAttribute("case-order")]
        public String caseorder;
        
        public override Object Accept(IxsltNodeVisitor visitor, Object arg)
        {
            return visitor.Visit(this, arg);
        }
    }
    
    [XmlType(TypeName="strip-space", Namespace="http://www.w3.org/1999/XSL/Transform")]
    [XmlRoot("strip-space", Namespace="http://www.w3.org/1999/XSL/Transform", IsNullable=true)]
    public partial class stripspace : xsltNodeBase
    {
        
        [XmlAttribute()]
        public String elements;
        
        public override Object Accept(IxsltNodeVisitor visitor, Object arg)
        {
            return visitor.Visit(this, arg);
        }
    }
    
    [XmlType(Namespace="http://www.w3.org/1999/XSL/Transform")]
    [XmlRoot(Namespace="http://www.w3.org/1999/XSL/Transform", IsNullable=true)]
    public partial class text : xsltNodeBase
    {
        
        public text()
        {
            this.disableoutputescaping = textDisableoutputescaping.no;
        }
        
        [XmlAttribute("disable-output-escaping")]
        [DefaultValue(textDisableoutputescaping.no)]
        public textDisableoutputescaping disableoutputescaping;
        
        [XmlAttribute(Form=XmlSchemaForm.Qualified, Namespace="http://www.w3.org/XML/1998/namespace")]
        public String space;
        
        [XmlText()]
        public String Value;
        
        public override Object Accept(IxsltNodeVisitor visitor, Object arg)
        {
            return visitor.Visit(this, arg);
        }
    }
    
    [XmlType(AnonymousType=true, Namespace="http://www.w3.org/1999/XSL/Transform")]
    public enum textDisableoutputescaping
    {
        
        yes,
        
        no,
    }
    
    [XmlType(TypeName="value-of", Namespace="http://www.w3.org/1999/XSL/Transform")]
    [XmlRoot("value-of", Namespace="http://www.w3.org/1999/XSL/Transform", IsNullable=true)]
    public partial class valueof : xsltNodeBase
    {
        
        public valueof()
        {
            this.disableoutputescaping = valueofDisableoutputescaping.no;
        }
        
        [XmlAttribute("disable-output-escaping")]
        [DefaultValue(valueofDisableoutputescaping.no)]
        public valueofDisableoutputescaping disableoutputescaping;
        
        [XmlAttribute()]
        public String select;
        
        public override Object Accept(IxsltNodeVisitor visitor, Object arg)
        {
            return visitor.Visit(this, arg);
        }
    }
    
    [XmlType(AnonymousType=true, Namespace="http://www.w3.org/1999/XSL/Transform")]
    public enum valueofDisableoutputescaping
    {
        
        yes,
        
        no,
    }
    
    public partial class variable : xsltNodeBase
    {
        
        public variable()
        {
        }
        
        public override Object Accept(IxsltNodeVisitor visitor, Object arg)
        {
            return visitor.Visit(this, arg);
        }
    }
    
    public partial class when : xsltNodeBase
    {
        
        public when()
        {
        }
        
        public override Object Accept(IxsltNodeVisitor visitor, Object arg)
        {
            return visitor.Visit(this, arg);
        }
    }
    
    public interface IxsltNodeVisitor
    {
        
        Object Visit(applyimports node, Object arg);
        
        Object Visit(attributeset node, Object arg);
        
        Object Visit(attribute node, Object arg);
        
        Object Visit(calltemplate node, Object arg);
        
        Object Visit(withparam node, Object arg);
        
        Object Visit(copyof node, Object arg);
        
        Object Visit(decimalformat node, Object arg);
        
        Object Visit(@foreach node, Object arg);
        
        Object Visit(import node, Object arg);
        
        Object Visit(include node, Object arg);
        
        Object Visit(key node, Object arg);
        
        Object Visit(namespacealias node, Object arg);
        
        Object Visit(number node, Object arg);
        
        Object Visit(output node, Object arg);
        
        Object Visit(preservespace node, Object arg);
        
        Object Visit(sort node, Object arg);
        
        Object Visit(stripspace node, Object arg);
        
        Object Visit(text node, Object arg);
        
        Object Visit(valueof node, Object arg);
        
        Object Visit(variable node, Object arg);
        
        Object Visit(when node, Object arg);
    }
    
    public abstract class xsltNodeBase
    {
        
        public abstract Object Accept(IxsltNodeVisitor visitor, Object arg);
    }
    
    public class xsltNodeVisitor : IxsltNodeVisitor
    {
        
        private Object AcceptAll(IEnumerable<xsltNodeBase> items, Object arg)
        {
            if ((items != null))
            {
                for (var en = items.GetEnumerator(); en.MoveNext(); )
                {
                    AcceptSingle(en.Current, arg);
                }
            }
            return default(Object);
        }
        
        private Object AcceptSingle(xsltNodeBase item, Object arg)
        {
            item?.Accept(this, arg);
            return default(Object);
        }
        
        public virtual Object Visit(applyimports node, Object arg)
        {
            return default(Object);
        }
        
        public virtual Object Visit(attributeset node, Object arg)
        {
            AcceptAll(node.attribute, arg);
            return default(Object);
        }
        
        public virtual Object Visit(attribute node, Object arg)
        {
            return default(Object);
        }
        
        public virtual Object Visit(calltemplate node, Object arg)
        {
            AcceptAll(node.withparam, arg);
            return default(Object);
        }
        
        public virtual Object Visit(withparam node, Object arg)
        {
            return default(Object);
        }
        
        public virtual Object Visit(copyof node, Object arg)
        {
            return default(Object);
        }
        
        public virtual Object Visit(decimalformat node, Object arg)
        {
            return default(Object);
        }
        
        public virtual Object Visit(@foreach node, Object arg)
        {
            return default(Object);
        }
        
        public virtual Object Visit(import node, Object arg)
        {
            return default(Object);
        }
        
        public virtual Object Visit(include node, Object arg)
        {
            return default(Object);
        }
        
        public virtual Object Visit(key node, Object arg)
        {
            return default(Object);
        }
        
        public virtual Object Visit(namespacealias node, Object arg)
        {
            return default(Object);
        }
        
        public virtual Object Visit(number node, Object arg)
        {
            return default(Object);
        }
        
        public virtual Object Visit(output node, Object arg)
        {
            return default(Object);
        }
        
        public virtual Object Visit(preservespace node, Object arg)
        {
            return default(Object);
        }
        
        public virtual Object Visit(sort node, Object arg)
        {
            return default(Object);
        }
        
        public virtual Object Visit(stripspace node, Object arg)
        {
            return default(Object);
        }
        
        public virtual Object Visit(text node, Object arg)
        {
            return default(Object);
        }
        
        public virtual Object Visit(valueof node, Object arg)
        {
            return default(Object);
        }
        
        public virtual Object Visit(variable node, Object arg)
        {
            return default(Object);
        }
        
        public virtual Object Visit(when node, Object arg)
        {
            return default(Object);
        }
    }
}
