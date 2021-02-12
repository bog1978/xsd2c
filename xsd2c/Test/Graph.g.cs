namespace Graph {
    using System.Xml.Serialization;
    using System.CodeDom.Compiler;
    using System;
    using System.Diagnostics;
    using System.ComponentModel;
    using System.Collections.Generic;
    
    
    /// <remarks/>
    [GeneratedCode("xsd2c", "1.0.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlRoot("Digraph", Namespace="", IsNullable=false)]
    public partial class GraphType : NodeType {
        
        /// <remarks/>
        [XmlElement("Vertex")]
        public VertexType[] Vertex;
        
        /// <remarks/>
        [XmlElement("Edge")]
        public EdgeType[] Edge;
        
        public override object Accept(IGraphNodeVisitor visitor, object arg) {
            return visitor.Visit(this, arg);
        }
    }
    
    /// <remarks/>
    [GeneratedCode("xsd2c", "1.0.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlRoot(Namespace="", IsNullable=true)]
    public partial class VertexType : NodeType {
        
        /// <remarks/>
        [XmlAttribute()]
        public String id;
        
        /// <remarks/>
        [XmlAttribute()]
        public ShapeType shape;
        
        /// <remarks/>
        [XmlIgnore()]
        public Boolean shapeSpecified;
        
        public override object Accept(IGraphNodeVisitor visitor, object arg) {
            return visitor.Visit(this, arg);
        }
    }
    
    /// <remarks/>
    [GeneratedCode("xsd2c", "1.0.0")]
    [Serializable()]
    public enum ShapeType {
        
        /// <remarks/>
        rectangle,
        
        /// <remarks/>
        ellipse,
    }
    
    /// <remarks/>
    [XmlInclude(typeof(GraphType))]
    [XmlInclude(typeof(EdgeType))]
    [XmlInclude(typeof(VertexType))]
    [GeneratedCode("xsd2c", "1.0.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlRoot(Namespace="", IsNullable=true)]
    public partial class NodeType : GraphNodeBase {
        
        /// <remarks/>
        public AttrType Attr;
        
        /// <remarks/>
        [XmlAttribute()]
        public String label;
        
        public override object Accept(IGraphNodeVisitor visitor, object arg) {
            return visitor.Visit(this, arg);
        }
    }
    
    /// <remarks/>
    [GeneratedCode("xsd2c", "1.0.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlRoot(Namespace="", IsNullable=true)]
    public partial class AttrType : GraphNodeBase {
        
        /// <remarks/>
        [XmlAttribute()]
        public String Color;
        
        /// <remarks/>
        [XmlAttribute()]
        public String Rank;
        
        /// <remarks/>
        [XmlAttribute()]
        public String Shape;
        
        /// <remarks/>
        [XmlAttribute()]
        public String Width;
        
        /// <remarks/>
        [XmlAttribute()]
        public String Height;
        
        public override object Accept(IGraphNodeVisitor visitor, object arg) {
            return visitor.Visit(this, arg);
        }
    }
    
    /// <remarks/>
    [GeneratedCode("xsd2c", "1.0.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlRoot(Namespace="", IsNullable=true)]
    public partial class EdgeType : NodeType {
        
        /// <remarks/>
        [XmlAttribute("id-src")]
        public String idsrc;
        
        /// <remarks/>
        [XmlAttribute("id-dst")]
        public String iddst;
        
        public override object Accept(IGraphNodeVisitor visitor, object arg) {
            return visitor.Visit(this, arg);
        }
    }
    
    public interface IGraphNodeVisitor {
        
        object Visit(GraphType node, object arg);
        
        object Visit(VertexType node, object arg);
        
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
        
        public virtual object Visit(VertexType node, object arg) {
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
