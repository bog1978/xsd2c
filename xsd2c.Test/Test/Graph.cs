namespace Graph
{
    using System.Collections.Generic;
    using System.Xml.Serialization;
    using System;
    
    
    [XmlInclude(typeof(GraphType))]
    [XmlInclude(typeof(EdgeType))]
    [XmlInclude(typeof(VertexType))]
    [XmlRoot(Namespace="", IsNullable=true)]
    public partial class NodeType : GraphNodeBase
    {
        
        public AttrType Attr;
        
        [XmlAttribute()]
        public String label;
        
        public override Object Accept(IGraphNodeVisitor visitor, Object arg)
        {
            return visitor.Visit(this, arg);
        }
    }
    
    [XmlRoot(Namespace="", IsNullable=true)]
    public partial class AttrType : GraphNodeBase
    {
        
        [XmlAttribute()]
        public String Color;
        
        [XmlAttribute()]
        public String Rank;
        
        [XmlAttribute()]
        public String Shape;
        
        [XmlAttribute()]
        public String Width;
        
        [XmlAttribute()]
        public String Height;
        
        public override Object Accept(IGraphNodeVisitor visitor, Object arg)
        {
            return visitor.Visit(this, arg);
        }
    }
    
    [XmlRoot(Namespace="", IsNullable=true)]
    public partial class GraphType : NodeType
    {
        
        [XmlElement("Vertex")]
        public VertexType[] Vertex;
        
        [XmlElement("Edge")]
        public EdgeType[] Edge;
        
        public override Object Accept(IGraphNodeVisitor visitor, Object arg)
        {
            return visitor.Visit(this, arg);
        }
    }
    
    [XmlRoot(Namespace="", IsNullable=true)]
    public partial class VertexType : NodeType
    {
        
        [XmlAttribute()]
        public String id;
        
        [XmlAttribute()]
        public ShapeType shape;
        
        [XmlIgnore()]
        public Boolean shapeSpecified;
        
        public override Object Accept(IGraphNodeVisitor visitor, Object arg)
        {
            return visitor.Visit(this, arg);
        }
    }
    
    public enum ShapeType
    {
        
        rectangle,
        
        ellipse,
    }
    
    [XmlRoot(Namespace="", IsNullable=true)]
    public partial class EdgeType : NodeType
    {
        
        [XmlAttribute("id-src")]
        public String idsrc;
        
        [XmlAttribute("id-dst")]
        public String iddst;
        
        public override Object Accept(IGraphNodeVisitor visitor, Object arg)
        {
            return visitor.Visit(this, arg);
        }
    }
    
    public interface IGraphNodeVisitor
    {
        
        Object Visit(NodeType node, Object arg);
        
        Object Visit(AttrType node, Object arg);
        
        Object Visit(GraphType node, Object arg);
        
        Object Visit(VertexType node, Object arg);
        
        Object Visit(EdgeType node, Object arg);
    }
    
    public abstract class GraphNodeBase
    {
        
        public abstract Object Accept(IGraphNodeVisitor visitor, Object arg);
    }
    
    public class GraphNodeVisitor : IGraphNodeVisitor
    {
        
        private Object AcceptAll(IEnumerable<GraphNodeBase> items, Object arg)
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
        
        private Object AcceptSingle(GraphNodeBase item, Object arg)
        {
            item?.Accept(this, arg);
            return default(Object);
        }
        
        public virtual Object Visit(NodeType node, Object arg)
        {
            AcceptSingle(node.Attr, arg);
            return default(Object);
        }
        
        public virtual Object Visit(AttrType node, Object arg)
        {
            return default(Object);
        }
        
        public virtual Object Visit(GraphType node, Object arg)
        {
            AcceptAll(node.Vertex, arg);
            AcceptAll(node.Edge, arg);
            return default(Object);
        }
        
        public virtual Object Visit(VertexType node, Object arg)
        {
            return default(Object);
        }
        
        public virtual Object Visit(EdgeType node, Object arg)
        {
            return default(Object);
        }
    }
}
