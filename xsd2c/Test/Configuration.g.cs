namespace Configuration {
    using System.Collections.Generic;
    using System;
    using System.Xml.Serialization;
    using System.Xml;
    
    
    [XmlType(AnonymousType=true, Namespace="http://BlueToque.ca/XsdToClasses.Configuration")]
    [XmlRoot(Namespace="http://BlueToque.ca/XsdToClasses.Configuration", IsNullable=false)]
    public partial class Configuration : ConfigurationNodeBase {
        
        public Boolean EnableDataBinding;
        
        public Boolean GenerateOrder;
        
        public Boolean GenerateProperties;
        
        public Boolean GenerateComplexTypes;
        
        [XmlIgnore()]
        public Boolean GenerateComplexTypesSpecified;
        
        [XmlArrayItem("CodeModifier", IsNullable=false)]
        public AssemblyType[] CodeModifiers;
        
        [XmlArrayItem("SchemaImporterExtension", IsNullable=false)]
        public AssemblyType[] SchemaImporterExtensions;
        
        [XmlAnyElement()]
        public XmlElement Any;
        
        public override Object Accept(IConfigurationNodeVisitor visitor, Object arg) {
            return visitor.Visit(this, arg);
        }
    }
    
    [XmlType(Namespace="http://BlueToque.ca/XsdToClasses.Configuration")]
    [XmlRoot(Namespace="http://BlueToque.ca/XsdToClasses.Configuration", IsNullable=true)]
    public partial class AssemblyType : ConfigurationNodeBase {
        
        [XmlAnyElement()]
        public XmlElement Any;
        
        [XmlAttribute()]
        public String Name;
        
        [XmlAttribute()]
        public String Type;
        
        [XmlAttribute()]
        public String Assembly;
        
        public override Object Accept(IConfigurationNodeVisitor visitor, Object arg) {
            return visitor.Visit(this, arg);
        }
    }
    
    [XmlType(Namespace="http://BlueToque.ca/XsdToClasses.Configuration")]
    [XmlRoot(Namespace="http://BlueToque.ca/XsdToClasses.Configuration", IsNullable=true)]
    public partial class CodeModifiersType : ConfigurationNodeBase {
        
        [XmlElement("CodeModifier")]
        public AssemblyType[] CodeModifier;
        
        public override Object Accept(IConfigurationNodeVisitor visitor, Object arg) {
            return visitor.Visit(this, arg);
        }
    }
    
    [XmlType(Namespace="http://BlueToque.ca/XsdToClasses.Configuration")]
    [XmlRoot(Namespace="http://BlueToque.ca/XsdToClasses.Configuration", IsNullable=true)]
    public partial class SchemaImporterExtensionsType : ConfigurationNodeBase {
        
        [XmlElement("SchemaImporterExtension")]
        public AssemblyType[] SchemaImporterExtension;
        
        public override Object Accept(IConfigurationNodeVisitor visitor, Object arg) {
            return visitor.Visit(this, arg);
        }
    }
    
    public interface IConfigurationNodeVisitor {
        
        Object Visit(Configuration node, Object arg);
        
        Object Visit(AssemblyType node, Object arg);
        
        Object Visit(CodeModifiersType node, Object arg);
        
        Object Visit(SchemaImporterExtensionsType node, Object arg);
    }
    
    public abstract class ConfigurationNodeBase {
        
        public abstract Object Accept(IConfigurationNodeVisitor visitor, Object arg);
    }
    
    public class ConfigurationNodeVisitor : IConfigurationNodeVisitor {
        
        private Object AcceptAll(IEnumerable<ConfigurationNodeBase> items, Object arg) {
            if ((items != null)) {
                for (var en = items.GetEnumerator(); en.MoveNext(); ) {
                    AcceptSingle(en.Current, arg);
                }
            }
            return default(Object);
        }
        
        private Object AcceptSingle(ConfigurationNodeBase item, Object arg) {
            item?.Accept(this, arg);
            return default(Object);
        }
        
        public virtual Object Visit(Configuration node, Object arg) {
            AcceptAll(node.CodeModifiers, arg);
            AcceptAll(node.SchemaImporterExtensions, arg);
            return default(Object);
        }
        
        public virtual Object Visit(AssemblyType node, Object arg) {
            return default(Object);
        }
        
        public virtual Object Visit(CodeModifiersType node, Object arg) {
            AcceptAll(node.CodeModifier, arg);
            return default(Object);
        }
        
        public virtual Object Visit(SchemaImporterExtensionsType node, Object arg) {
            AcceptAll(node.SchemaImporterExtension, arg);
            return default(Object);
        }
    }
}
