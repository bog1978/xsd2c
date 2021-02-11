namespace Graph {
    using System.Collections.Generic;
    
    
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
            }
        }
        
        public override object Accept(IGraphNodeVisitor visitor, object arg) {
            return visitor.Visit(this, arg);
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
            }
        }
        
        public override object Accept(IGraphNodeVisitor visitor, object arg) {
            return visitor.Visit(this, arg);
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
    public partial class NodeType : GraphNodeBase {
        
        private AttrType attrField;
        
        /// <remarks/>
        public AttrType Attr {
            get {
                return this.attrField;
            }
            set {
                this.attrField = value;
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
            }
        }
        
        public override object Accept(IGraphNodeVisitor visitor, object arg) {
            return visitor.Visit(this, arg);
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd2c", "1.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=true)]
    public partial class AttrType : GraphNodeBase {
        
        private string colorField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Color {
            get {
                return this.colorField;
            }
            set {
                this.colorField = value;
            }
        }
        
        private string rankField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Rank {
            get {
                return this.rankField;
            }
            set {
                this.rankField = value;
            }
        }
        
        private string shapeField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Shape {
            get {
                return this.shapeField;
            }
            set {
                this.shapeField = value;
            }
        }
        
        private string widthField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Width {
            get {
                return this.widthField;
            }
            set {
                this.widthField = value;
            }
        }
        
        private string heightField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Height {
            get {
                return this.heightField;
            }
            set {
                this.heightField = value;
            }
        }
        
        public override object Accept(IGraphNodeVisitor visitor, object arg) {
            return visitor.Visit(this, arg);
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
            }
        }
        
        public override object Accept(IGraphNodeVisitor visitor, object arg) {
            return visitor.Visit(this, arg);
        }
    }
    
    public interface IGraphNodeVisitor {
        
        object Visit(GraphType node, object arg);
        
        object Visit(VertexType1 node, object arg);
        
        object Visit(NodeType node, object arg);
        
        object Visit(AttrType node, object arg);
        
        object Visit(EdgeType node, object arg);
    }
    
    public abstract class GraphNodeBase {
        
        public abstract object Accept(IGraphNodeVisitor visitor, object arg);
    }
    
    public class GraphNodeVisitor : IGraphNodeVisitor {
        
        private void AcceptAll(IEnumerable<GraphNodeBase> items, object arg) {
            if ((items == null)) {
                return;
            }
            for (var en = items.GetEnumerator(); en.MoveNext(); ) {
                AcceptSingle(en.Current, arg);
            }
        }
        
        private void AcceptSingle(GraphNodeBase item, object arg) {
            item?.Accept(this, arg);
        }
        
        public virtual object Visit(GraphType node, object arg) {
            AcceptAll(node.Vertex, arg);
            AcceptAll(node.Edge, arg);
            return default(object);
        }
        
        public virtual object Visit(VertexType1 node, object arg) {
            return default(object);
        }
        
        public virtual object Visit(NodeType node, object arg) {
            AcceptSingle(node.Attr, arg);
            return default(object);
        }
        
        public virtual object Visit(AttrType node, object arg) {
            return default(object);
        }
        
        public virtual object Visit(EdgeType node, object arg) {
            return default(object);
        }
    }
}
