namespace Configuration {
    using System;
    using System.Xml.Serialization;
    using System.Xml;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.ComponentModel;
    using System.Collections.Generic;
    
    
    /// <remarks/>
    [GeneratedCode("xsd2c", "1.0.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType=true, Namespace="http://BlueToque.ca/XsdToClasses.Configuration")]
    [XmlRoot(Namespace="http://BlueToque.ca/XsdToClasses.Configuration", IsNullable=false)]
    public partial class Configuration : ConfigurationNodeBase {
        
        /// <remarks/>
        public Boolean EnableDataBinding;
        
        /// <remarks/>
        public Boolean GenerateOrder;
        
        /// <remarks/>
        public Boolean GenerateProperties;
        
        /// <remarks/>
        public Boolean GenerateComplexTypes;
        
        /// <remarks/>
        [XmlIgnore()]
        public Boolean GenerateComplexTypesSpecified;
        
        /// <remarks/>
        [XmlArrayItem("CodeModifier", IsNullable=false)]
        public AssemblyType[] CodeModifiers;
        
        /// <remarks/>
        [XmlArrayItem("SchemaImporterExtension", IsNullable=false)]
        public AssemblyType[] SchemaImporterExtensions;
        
        /// <remarks/>
        [XmlAnyElement()]
        public XmlElement Any;
        
        public override object Accept(IConfigurationNodeVisitor visitor, object arg) {
            return visitor.Visit(this, arg);
        }
    }
    
    /// <remarks/>
    [GeneratedCode("xsd2c", "1.0.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(Namespace="http://BlueToque.ca/XsdToClasses.Configuration")]
    [XmlRoot(Namespace="http://BlueToque.ca/XsdToClasses.Configuration", IsNullable=true)]
    public partial class AssemblyType : ConfigurationNodeBase {
        
        /// <remarks/>
        [XmlAnyElement()]
        public XmlElement Any;
        
        /// <remarks/>
        [XmlAttribute()]
        public String Name;
        
        /// <remarks/>
        [XmlAttribute()]
        public String Type;
        
        /// <remarks/>
        [XmlAttribute()]
        public String Assembly;
        
        public override object Accept(IConfigurationNodeVisitor visitor, object arg) {
            return visitor.Visit(this, arg);
        }
    }
    
    /// <remarks/>
    [GeneratedCode("xsd2c", "1.0.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(Namespace="http://BlueToque.ca/XsdToClasses.Configuration")]
    [XmlRoot(Namespace="http://BlueToque.ca/XsdToClasses.Configuration", IsNullable=true)]
    public partial class CodeModifiersType : ConfigurationNodeBase {
        
        /// <remarks/>
        [XmlElement("CodeModifier")]
        public AssemblyType[] CodeModifier;
        
        public override object Accept(IConfigurationNodeVisitor visitor, object arg) {
            return visitor.Visit(this, arg);
        }
    }
    
    /// <remarks/>
    [GeneratedCode("xsd2c", "1.0.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(Namespace="http://BlueToque.ca/XsdToClasses.Configuration")]
    [XmlRoot(Namespace="http://BlueToque.ca/XsdToClasses.Configuration", IsNullable=true)]
    public partial class SchemaImporterExtensionsType : ConfigurationNodeBase {
        
        /// <remarks/>
        [XmlElement("SchemaImporterExtension")]
        public AssemblyType[] SchemaImporterExtension;
        
        public override object Accept(IConfigurationNodeVisitor visitor, object arg) {
            return visitor.Visit(this, arg);
        }
    }
    
    public interface IConfigurationNodeVisitor {
        
        object Visit(Configuration node, object arg);
        
        object Visit(AssemblyType node, object arg);
        
        object Visit(CodeModifiersType node, object arg);
        
        object Visit(SchemaImporterExtensionsType node, object arg);
    }
    
    public abstract class ConfigurationNodeBase {
        
        public abstract object Accept(IConfigurationNodeVisitor visitor, object arg);
    }
    
    public class ConfigurationNodeVisitor : IConfigurationNodeVisitor {
        
        private void AcceptAll(IEnumerable<ConfigurationNodeBase> items, object arg) {
            if ((items == null)) {
                return;
            }
            for (var en = items.GetEnumerator(); en.MoveNext(); ) {
                AcceptSingle(en.Current, arg);
            }
        }
        
        private void AcceptSingle(ConfigurationNodeBase item, object arg) {
            item?.Accept(this, arg);
        }
        
        public virtual object Visit(Configuration node, object arg) {
            AcceptAll(node.CodeModifiers, arg);
            AcceptAll(node.SchemaImporterExtensions, arg);
            return default(object);
        }
        
        public virtual object Visit(AssemblyType node, object arg) {
            return default(object);
        }
        
        public virtual object Visit(CodeModifiersType node, object arg) {
            AcceptAll(node.CodeModifier, arg);
            return default(object);
        }
        
        public virtual object Visit(SchemaImporterExtensionsType node, object arg) {
            AcceptAll(node.SchemaImporterExtension, arg);
            return default(object);
        }
    }
}
