namespace ToDo {
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd2c", "1.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlRootAttribute("Digraph", Namespace="", IsNullable=false)]
    public partial class GraphType : NodeType {
        
        private VertexType1[] vertexField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Vertex")]
        public VertexType1[] Vertex {
            get {
                return this.vertexField;
            }
            set {
                this.vertexField = value;
                this.RaisePropertyChanged("Vertex");
            }
        }
        
        private EdgeType[] edgeField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Edge")]
        public EdgeType[] Edge {
            get {
                return this.edgeField;
            }
            set {
                this.edgeField = value;
                this.RaisePropertyChanged("Edge");
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd2c", "1.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=true)]
    public partial class VertexType1 : NodeType {
        
        private string idField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
                this.RaisePropertyChanged("id");
            }
        }
        
        private ShapeType shapeField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ShapeType shape {
            get {
                return this.shapeField;
            }
            set {
                this.shapeField = value;
                this.RaisePropertyChanged("shape");
            }
        }
        
        private bool shapeFieldSpecified;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool shapeSpecified {
            get {
                return this.shapeFieldSpecified;
            }
            set {
                this.shapeFieldSpecified = value;
                this.RaisePropertyChanged("shapeSpecified");
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd2c", "1.0.0")]
    [System.SerializableAttribute()]
    public enum ShapeType {
        
        /// <remarks/>
        rectangle,
        
        /// <remarks/>
        ellipse,
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(GraphType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(EdgeType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(VertexType1))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd2c", "1.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=true)]
    public partial class NodeType : object, System.ComponentModel.INotifyPropertyChanged {
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
        
        private string labelField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string label {
            get {
                return this.labelField;
            }
            set {
                this.labelField = value;
                this.RaisePropertyChanged("label");
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd2c", "1.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=true)]
    public partial class EdgeType : NodeType {
        
        private string idsrcField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute("id-src")]
        public string idsrc {
            get {
                return this.idsrcField;
            }
            set {
                this.idsrcField = value;
                this.RaisePropertyChanged("idsrc");
            }
        }
        
        private string iddstField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute("id-dst")]
        public string iddst {
            get {
                return this.iddstField;
            }
            set {
                this.iddstField = value;
                this.RaisePropertyChanged("iddst");
            }
        }
    }
}
