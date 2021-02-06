namespace ToDo {
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd2c", "1.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://BlueToque.ca/XsdToClasses.Configuration")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://BlueToque.ca/XsdToClasses.Configuration", IsNullable=false)]
    public partial class Configuration : object, System.ComponentModel.INotifyPropertyChanged {
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
        
        private bool enableDataBindingField;
        
        /// <remarks/>
        public bool EnableDataBinding {
            get {
                return this.enableDataBindingField;
            }
            set {
                this.enableDataBindingField = value;
                this.RaisePropertyChanged("EnableDataBinding");
            }
        }
        
        private bool generateOrderField;
        
        /// <remarks/>
        public bool GenerateOrder {
            get {
                return this.generateOrderField;
            }
            set {
                this.generateOrderField = value;
                this.RaisePropertyChanged("GenerateOrder");
            }
        }
        
        private bool generatePropertiesField;
        
        /// <remarks/>
        public bool GenerateProperties {
            get {
                return this.generatePropertiesField;
            }
            set {
                this.generatePropertiesField = value;
                this.RaisePropertyChanged("GenerateProperties");
            }
        }
        
        private bool generateComplexTypesField;
        
        /// <remarks/>
        public bool GenerateComplexTypes {
            get {
                return this.generateComplexTypesField;
            }
            set {
                this.generateComplexTypesField = value;
                this.RaisePropertyChanged("GenerateComplexTypes");
            }
        }
        
        private bool generateComplexTypesFieldSpecified;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool GenerateComplexTypesSpecified {
            get {
                return this.generateComplexTypesFieldSpecified;
            }
            set {
                this.generateComplexTypesFieldSpecified = value;
                this.RaisePropertyChanged("GenerateComplexTypesSpecified");
            }
        }
        
        private AssemblyType[] codeModifiersField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("CodeModifier", IsNullable=false)]
        public AssemblyType[] CodeModifiers {
            get {
                return this.codeModifiersField;
            }
            set {
                this.codeModifiersField = value;
                this.RaisePropertyChanged("CodeModifiers");
            }
        }
        
        private AssemblyType[] schemaImporterExtensionsField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("SchemaImporterExtension", IsNullable=false)]
        public AssemblyType[] SchemaImporterExtensions {
            get {
                return this.schemaImporterExtensionsField;
            }
            set {
                this.schemaImporterExtensionsField = value;
                this.RaisePropertyChanged("SchemaImporterExtensions");
            }
        }
        
        private System.Xml.XmlElement anyField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAnyElementAttribute()]
        public System.Xml.XmlElement Any {
            get {
                return this.anyField;
            }
            set {
                this.anyField = value;
                this.RaisePropertyChanged("Any");
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd2c", "1.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://BlueToque.ca/XsdToClasses.Configuration")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://BlueToque.ca/XsdToClasses.Configuration", IsNullable=true)]
    public partial class AssemblyType : object, System.ComponentModel.INotifyPropertyChanged {
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
        
        private System.Xml.XmlElement anyField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAnyElementAttribute()]
        public System.Xml.XmlElement Any {
            get {
                return this.anyField;
            }
            set {
                this.anyField = value;
                this.RaisePropertyChanged("Any");
            }
        }
        
        private string nameField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
                this.RaisePropertyChanged("Name");
            }
        }
        
        private string typeField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Type {
            get {
                return this.typeField;
            }
            set {
                this.typeField = value;
                this.RaisePropertyChanged("Type");
            }
        }
        
        private string assemblyField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Assembly {
            get {
                return this.assemblyField;
            }
            set {
                this.assemblyField = value;
                this.RaisePropertyChanged("Assembly");
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd2c", "1.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://BlueToque.ca/XsdToClasses.Configuration")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://BlueToque.ca/XsdToClasses.Configuration", IsNullable=true)]
    public partial class CodeModifiersType : object, System.ComponentModel.INotifyPropertyChanged {
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
        
        private AssemblyType[] codeModifierField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("CodeModifier")]
        public AssemblyType[] CodeModifier {
            get {
                return this.codeModifierField;
            }
            set {
                this.codeModifierField = value;
                this.RaisePropertyChanged("CodeModifier");
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd2c", "1.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://BlueToque.ca/XsdToClasses.Configuration")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://BlueToque.ca/XsdToClasses.Configuration", IsNullable=true)]
    public partial class SchemaImporterExtensionsType : object, System.ComponentModel.INotifyPropertyChanged {
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
        
        private AssemblyType[] schemaImporterExtensionField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SchemaImporterExtension")]
        public AssemblyType[] SchemaImporterExtension {
            get {
                return this.schemaImporterExtensionField;
            }
            set {
                this.schemaImporterExtensionField = value;
                this.RaisePropertyChanged("SchemaImporterExtension");
            }
        }
    }
}
