namespace xsdschema
{
    using System.Collections.Generic;
    using System;
    using System.Xml.Serialization;
    using System.Xml.Schema;
    using System.Xml;
    using System.ComponentModel;
    
    
    [XmlInclude(typeof(annotated))]
    [XmlInclude(typeof(extensionType))]
    [XmlInclude(typeof(simpleExtensionType))]
    [XmlInclude(typeof(attributeGroup))]
    [XmlInclude(typeof(namedAttributeGroup))]
    [XmlInclude(typeof(attributeGroupRef))]
    [XmlInclude(typeof(wildcard))]
    [XmlInclude(typeof(keybase))]
    [XmlInclude(typeof(element))]
    [XmlInclude(typeof(localElement))]
    [XmlInclude(typeof(narrowMaxMin))]
    [XmlInclude(typeof(topLevelElement))]
    [XmlInclude(typeof(group))]
    [XmlInclude(typeof(explicitGroup))]
    [XmlInclude(typeof(all))]
    [XmlInclude(typeof(simpleExplicitGroup))]
    [XmlInclude(typeof(realGroup))]
    [XmlInclude(typeof(groupRef))]
    [XmlInclude(typeof(namedGroup))]
    [XmlInclude(typeof(restrictionType))]
    [XmlInclude(typeof(simpleRestrictionType))]
    [XmlInclude(typeof(complexRestrictionType))]
    [XmlInclude(typeof(complexType))]
    [XmlInclude(typeof(topLevelComplexType))]
    [XmlInclude(typeof(localComplexType))]
    [XmlInclude(typeof(facet))]
    [XmlInclude(typeof(numFacet))]
    [XmlInclude(typeof(noFixedFacet))]
    [XmlInclude(typeof(simpleType))]
    [XmlInclude(typeof(topLevelSimpleType))]
    [XmlInclude(typeof(localSimpleType))]
    [XmlInclude(typeof(attribute))]
    [XmlInclude(typeof(topLevelAttribute))]
    [XmlType(Namespace="http://www.w3.org/2001/XMLSchema")]
    [XmlRoot(Namespace="http://www.w3.org/2001/XMLSchema", IsNullable=true)]
    public partial class openAttrs : xsdschemaNodeBase
    {
        
        public override Object Accept(IxsdschemaNodeVisitor visitor, Object arg)
        {
            return visitor.Visit(this, arg);
        }
    }
    
    [XmlInclude(typeof(extensionType))]
    [XmlInclude(typeof(simpleExtensionType))]
    [XmlInclude(typeof(attributeGroup))]
    [XmlInclude(typeof(namedAttributeGroup))]
    [XmlInclude(typeof(attributeGroupRef))]
    [XmlInclude(typeof(wildcard))]
    [XmlInclude(typeof(keybase))]
    [XmlInclude(typeof(element))]
    [XmlInclude(typeof(localElement))]
    [XmlInclude(typeof(narrowMaxMin))]
    [XmlInclude(typeof(topLevelElement))]
    [XmlInclude(typeof(group))]
    [XmlInclude(typeof(explicitGroup))]
    [XmlInclude(typeof(all))]
    [XmlInclude(typeof(simpleExplicitGroup))]
    [XmlInclude(typeof(realGroup))]
    [XmlInclude(typeof(groupRef))]
    [XmlInclude(typeof(namedGroup))]
    [XmlInclude(typeof(restrictionType))]
    [XmlInclude(typeof(simpleRestrictionType))]
    [XmlInclude(typeof(complexRestrictionType))]
    [XmlInclude(typeof(complexType))]
    [XmlInclude(typeof(topLevelComplexType))]
    [XmlInclude(typeof(localComplexType))]
    [XmlInclude(typeof(facet))]
    [XmlInclude(typeof(numFacet))]
    [XmlInclude(typeof(noFixedFacet))]
    [XmlInclude(typeof(simpleType))]
    [XmlInclude(typeof(topLevelSimpleType))]
    [XmlInclude(typeof(localSimpleType))]
    [XmlInclude(typeof(attribute))]
    [XmlInclude(typeof(topLevelAttribute))]
    [XmlType(Namespace="http://www.w3.org/2001/XMLSchema")]
    [XmlRoot(Namespace="http://www.w3.org/2001/XMLSchema", IsNullable=true)]
    public partial class annotated : openAttrs
    {
        
        public annotation annotation;
        
        [XmlAttribute(DataType="ID")]
        public String id;
        
        public override Object Accept(IxsdschemaNodeVisitor visitor, Object arg)
        {
            return visitor.Visit(this, arg);
        }
    }
    
    [XmlType(AnonymousType=true, Namespace="http://www.w3.org/2001/XMLSchema")]
    public partial class annotation : openAttrs
    {
        
        [XmlElement("appinfo", typeof(appinfo))]
        [XmlElement("documentation", typeof(documentation))]
        public object[] Items;
        
        [XmlAttribute(DataType="ID")]
        public String id;
        
        public override Object Accept(IxsdschemaNodeVisitor visitor, Object arg)
        {
            return visitor.Visit(this, arg);
        }
    }
    
    [XmlType(AnonymousType=true, Namespace="http://www.w3.org/2001/XMLSchema")]
    public partial class appinfo : xsdschemaNodeBase
    {
        
        [XmlText()]
        [XmlAnyElement()]
        public System.Xml.XmlNode[] Any;
        
        [XmlAttribute(DataType="anyURI")]
        public String source;
        
        [XmlAnyAttribute()]
        public System.Xml.XmlAttribute[] AnyAttr;
        
        public override Object Accept(IxsdschemaNodeVisitor visitor, Object arg)
        {
            return visitor.Visit(this, arg);
        }
    }
    
    [XmlType(AnonymousType=true, Namespace="http://www.w3.org/2001/XMLSchema")]
    public partial class documentation : xsdschemaNodeBase
    {
        
        [XmlText()]
        [XmlAnyElement()]
        public System.Xml.XmlNode[] Any;
        
        [XmlAttribute(DataType="anyURI")]
        public String source;
        
        [XmlAttribute(Form=XmlSchemaForm.Qualified, Namespace="http://www.w3.org/XML/1998/namespace")]
        public String lang;
        
        [XmlAnyAttribute()]
        public System.Xml.XmlAttribute[] AnyAttr;
        
        public override Object Accept(IxsdschemaNodeVisitor visitor, Object arg)
        {
            return visitor.Visit(this, arg);
        }
    }
    
    [XmlInclude(typeof(simpleExtensionType))]
    [XmlType(Namespace="http://www.w3.org/2001/XMLSchema")]
    [XmlRoot(Namespace="http://www.w3.org/2001/XMLSchema", IsNullable=true)]
    public partial class extensionType : annotated
    {
        
        public groupRef group;
        
        public all all;
        
        public explicitGroup choice;
        
        public explicitGroup sequence;
        
        [XmlElement("attribute", typeof(attribute))]
        [XmlElement("attributeGroup", typeof(attributeGroupRef))]
        public annotated[] Items;
        
        public wildcard anyAttribute;
        
        [XmlAttribute()]
        public XmlQualifiedName @base;
        
        public override Object Accept(IxsdschemaNodeVisitor visitor, Object arg)
        {
            return visitor.Visit(this, arg);
        }
    }
    
    [XmlType(Namespace="http://www.w3.org/2001/XMLSchema")]
    [XmlRoot(Namespace="http://www.w3.org/2001/XMLSchema", IsNullable=true)]
    public partial class groupRef : realGroup
    {
        
        public override Object Accept(IxsdschemaNodeVisitor visitor, Object arg)
        {
            return visitor.Visit(this, arg);
        }
    }
    
    [XmlInclude(typeof(groupRef))]
    [XmlInclude(typeof(namedGroup))]
    [XmlType(Namespace="http://www.w3.org/2001/XMLSchema")]
    [XmlRoot(Namespace="http://www.w3.org/2001/XMLSchema", IsNullable=true)]
    public partial class realGroup : group
    {
        
        public override Object Accept(IxsdschemaNodeVisitor visitor, Object arg)
        {
            return visitor.Visit(this, arg);
        }
    }
    
    [XmlInclude(typeof(explicitGroup))]
    [XmlInclude(typeof(all))]
    [XmlInclude(typeof(simpleExplicitGroup))]
    [XmlInclude(typeof(realGroup))]
    [XmlInclude(typeof(groupRef))]
    [XmlInclude(typeof(namedGroup))]
    [XmlType(Namespace="http://www.w3.org/2001/XMLSchema")]
    [XmlRoot(Namespace="http://www.w3.org/2001/XMLSchema", IsNullable=true)]
    public abstract partial class group : annotated
    {
        
        public group()
        {
            this.minOccurs = "1";
            this.maxOccurs = "1";
        }
        
        [XmlElement("all", typeof(all))]
        [XmlElement("any", typeof(any))]
        [XmlElement("choice", typeof(explicitGroup))]
        [XmlElement("element", typeof(localElement))]
        [XmlElement("group", typeof(groupRef))]
        [XmlElement("sequence", typeof(explicitGroup))]
        [XmlChoiceIdentifier("ItemsElementName")]
        public annotated[] Items;
        
        [XmlElement("ItemsElementName")]
        [XmlIgnore()]
        public ItemsChoiceType[] ItemsElementName;
        
        [XmlAttribute(DataType="NCName")]
        public String name;
        
        [XmlAttribute()]
        public XmlQualifiedName @ref;
        
        [XmlAttribute(DataType="nonNegativeInteger")]
        [DefaultValue("1")]
        public String minOccurs;
        
        [XmlAttribute()]
        [DefaultValue("1")]
        public String maxOccurs;
        
        public override Object Accept(IxsdschemaNodeVisitor visitor, Object arg)
        {
            return visitor.Visit(this, arg);
        }
    }
    
    [XmlType(Namespace="http://www.w3.org/2001/XMLSchema")]
    [XmlRoot(Namespace="http://www.w3.org/2001/XMLSchema", IsNullable=true)]
    public partial class all : explicitGroup
    {
        
        public override Object Accept(IxsdschemaNodeVisitor visitor, Object arg)
        {
            return visitor.Visit(this, arg);
        }
    }
    
    [XmlInclude(typeof(all))]
    [XmlInclude(typeof(simpleExplicitGroup))]
    [XmlType(Namespace="http://www.w3.org/2001/XMLSchema")]
    [XmlRoot(Namespace="http://www.w3.org/2001/XMLSchema", IsNullable=true)]
    public partial class explicitGroup : group
    {
        
        public override Object Accept(IxsdschemaNodeVisitor visitor, Object arg)
        {
            return visitor.Visit(this, arg);
        }
    }
    
    [XmlType(Namespace="http://www.w3.org/2001/XMLSchema")]
    [XmlRoot(Namespace="http://www.w3.org/2001/XMLSchema", IsNullable=true)]
    public partial class simpleExplicitGroup : explicitGroup
    {
        
        public override Object Accept(IxsdschemaNodeVisitor visitor, Object arg)
        {
            return visitor.Visit(this, arg);
        }
    }
    
    [XmlType(AnonymousType=true, Namespace="http://www.w3.org/2001/XMLSchema")]
    public partial class any : wildcard
    {
        
        public any()
        {
            this.minOccurs = "1";
            this.maxOccurs = "1";
        }
        
        [XmlAttribute(DataType="nonNegativeInteger")]
        [DefaultValue("1")]
        public String minOccurs;
        
        [XmlAttribute()]
        [DefaultValue("1")]
        public String maxOccurs;
        
        public override Object Accept(IxsdschemaNodeVisitor visitor, Object arg)
        {
            return visitor.Visit(this, arg);
        }
    }
    
    [XmlType(Namespace="http://www.w3.org/2001/XMLSchema")]
    [XmlRoot(Namespace="http://www.w3.org/2001/XMLSchema", IsNullable=true)]
    public partial class wildcard : annotated
    {
        
        public wildcard()
        {
            this.@namespace = "##any";
            this.processContents = wildcardProcessContents.strict;
        }
        
        [XmlAttribute()]
        [DefaultValue("##any")]
        public String @namespace;
        
        [XmlAttribute()]
        [DefaultValue(wildcardProcessContents.strict)]
        public wildcardProcessContents processContents;
        
        public override Object Accept(IxsdschemaNodeVisitor visitor, Object arg)
        {
            return visitor.Visit(this, arg);
        }
    }
    
    [XmlType(AnonymousType=true, Namespace="http://www.w3.org/2001/XMLSchema")]
    public enum wildcardProcessContents
    {
        
        skip,
        
        lax,
        
        strict,
    }
    
    [XmlInclude(typeof(narrowMaxMin))]
    [XmlType(Namespace="http://www.w3.org/2001/XMLSchema")]
    [XmlRoot(Namespace="http://www.w3.org/2001/XMLSchema", IsNullable=true)]
    public partial class localElement : element
    {
        
        public override Object Accept(IxsdschemaNodeVisitor visitor, Object arg)
        {
            return visitor.Visit(this, arg);
        }
    }
    
    [XmlInclude(typeof(localElement))]
    [XmlInclude(typeof(narrowMaxMin))]
    [XmlInclude(typeof(topLevelElement))]
    [XmlType(Namespace="http://www.w3.org/2001/XMLSchema")]
    [XmlRoot(Namespace="http://www.w3.org/2001/XMLSchema", IsNullable=true)]
    public abstract partial class element : annotated
    {
        
        public element()
        {
            this.minOccurs = "1";
            this.maxOccurs = "1";
            this.nillable = false;
            this.@abstract = false;
        }
        
        [XmlElement("complexType", typeof(localComplexType))]
        [XmlElement("simpleType", typeof(localSimpleType))]
        public annotated Item;
        
        [XmlElement("unique")]
        public keybase[] unique;
        
        [XmlElement("key")]
        public keybase[] key;
        
        [XmlElement("keyref")]
        public keyref[] keyref;
        
        [XmlAttribute(DataType="NCName")]
        public String name;
        
        [XmlAttribute()]
        public XmlQualifiedName @ref;
        
        [XmlAttribute()]
        public XmlQualifiedName type;
        
        [XmlAttribute()]
        public XmlQualifiedName substitutionGroup;
        
        [XmlAttribute(DataType="nonNegativeInteger")]
        [DefaultValue("1")]
        public String minOccurs;
        
        [XmlAttribute()]
        [DefaultValue("1")]
        public String maxOccurs;
        
        [XmlAttribute()]
        public String @default;
        
        [XmlAttribute()]
        public String @fixed;
        
        [XmlAttribute()]
        [DefaultValue(false)]
        public Boolean nillable;
        
        [XmlAttribute()]
        [DefaultValue(false)]
        public Boolean @abstract;
        
        [XmlAttribute()]
        public String final;
        
        [XmlAttribute()]
        public String block;
        
        [XmlAttribute()]
        public formChoice form;
        
        [XmlIgnore()]
        public Boolean formSpecified;
        
        public override Object Accept(IxsdschemaNodeVisitor visitor, Object arg)
        {
            return visitor.Visit(this, arg);
        }
    }
    
    [XmlType(Namespace="http://www.w3.org/2001/XMLSchema")]
    [XmlRoot(Namespace="http://www.w3.org/2001/XMLSchema", IsNullable=true)]
    public partial class localComplexType : complexType
    {
        
        public override Object Accept(IxsdschemaNodeVisitor visitor, Object arg)
        {
            return visitor.Visit(this, arg);
        }
    }
    
    [XmlInclude(typeof(topLevelComplexType))]
    [XmlInclude(typeof(localComplexType))]
    [XmlType(Namespace="http://www.w3.org/2001/XMLSchema")]
    [XmlRoot(Namespace="http://www.w3.org/2001/XMLSchema", IsNullable=true)]
    public abstract partial class complexType : annotated
    {
        
        public complexType()
        {
            this.mixed = false;
            this.@abstract = false;
        }
        
        [XmlElement("all", typeof(all))]
        [XmlElement("anyAttribute", typeof(wildcard))]
        [XmlElement("attribute", typeof(attribute))]
        [XmlElement("attributeGroup", typeof(attributeGroupRef))]
        [XmlElement("choice", typeof(explicitGroup))]
        [XmlElement("complexContent", typeof(complexContent))]
        [XmlElement("group", typeof(groupRef))]
        [XmlElement("sequence", typeof(explicitGroup))]
        [XmlElement("simpleContent", typeof(simpleContent))]
        [XmlChoiceIdentifier("ItemsElementName")]
        public annotated[] Items;
        
        [XmlElement("ItemsElementName")]
        [XmlIgnore()]
        public ItemsChoiceType2[] ItemsElementName;
        
        [XmlAttribute(DataType="NCName")]
        public String name;
        
        [XmlAttribute()]
        [DefaultValue(false)]
        public Boolean mixed;
        
        [XmlAttribute()]
        [DefaultValue(false)]
        public Boolean @abstract;
        
        [XmlAttribute()]
        public String final;
        
        [XmlAttribute()]
        public String block;
        
        public override Object Accept(IxsdschemaNodeVisitor visitor, Object arg)
        {
            return visitor.Visit(this, arg);
        }
    }
    
    [XmlInclude(typeof(topLevelAttribute))]
    [XmlType(Namespace="http://www.w3.org/2001/XMLSchema")]
    [XmlRoot(Namespace="http://www.w3.org/2001/XMLSchema", IsNullable=true)]
    public partial class attribute : annotated
    {
        
        public attribute()
        {
            this.use = attributeUse.optional;
        }
        
        public localSimpleType simpleType;
        
        [XmlAttribute(DataType="NCName")]
        public String name;
        
        [XmlAttribute()]
        public XmlQualifiedName @ref;
        
        [XmlAttribute()]
        public XmlQualifiedName type;
        
        [XmlAttribute()]
        [DefaultValue(attributeUse.optional)]
        public attributeUse use;
        
        [XmlAttribute()]
        public String @default;
        
        [XmlAttribute()]
        public String @fixed;
        
        [XmlAttribute()]
        public formChoice form;
        
        [XmlIgnore()]
        public Boolean formSpecified;
        
        public override Object Accept(IxsdschemaNodeVisitor visitor, Object arg)
        {
            return visitor.Visit(this, arg);
        }
    }
    
    [XmlType(Namespace="http://www.w3.org/2001/XMLSchema")]
    [XmlRoot(Namespace="http://www.w3.org/2001/XMLSchema", IsNullable=true)]
    public partial class localSimpleType : simpleType
    {
        
        public override Object Accept(IxsdschemaNodeVisitor visitor, Object arg)
        {
            return visitor.Visit(this, arg);
        }
    }
    
    [XmlInclude(typeof(topLevelSimpleType))]
    [XmlInclude(typeof(localSimpleType))]
    [XmlType(Namespace="http://www.w3.org/2001/XMLSchema")]
    [XmlRoot(Namespace="http://www.w3.org/2001/XMLSchema", IsNullable=true)]
    public abstract partial class simpleType : annotated
    {
        
        [XmlElement("list", typeof(list))]
        [XmlElement("restriction", typeof(restriction))]
        [XmlElement("union", typeof(union))]
        public annotated Item;
        
        [XmlAttribute()]
        public String final;
        
        [XmlAttribute(DataType="NCName")]
        public String name;
        
        public override Object Accept(IxsdschemaNodeVisitor visitor, Object arg)
        {
            return visitor.Visit(this, arg);
        }
    }
    
    [XmlType(AnonymousType=true, Namespace="http://www.w3.org/2001/XMLSchema")]
    public partial class list : annotated
    {
        
        public localSimpleType simpleType;
        
        [XmlAttribute()]
        public XmlQualifiedName itemType;
        
        public override Object Accept(IxsdschemaNodeVisitor visitor, Object arg)
        {
            return visitor.Visit(this, arg);
        }
    }
    
    [XmlType(AnonymousType=true, Namespace="http://www.w3.org/2001/XMLSchema")]
    public partial class restriction : annotated
    {
        
        public localSimpleType simpleType;
        
        [XmlElement("minExclusive")]
        public facet[] minExclusive;
        
        [XmlElement("minInclusive")]
        public facet[] minInclusive;
        
        [XmlElement("maxExclusive")]
        public facet[] maxExclusive;
        
        [XmlElement("maxInclusive")]
        public facet[] maxInclusive;
        
        [XmlElement("totalDigits")]
        public totalDigits[] totalDigits;
        
        [XmlElement("fractionDigits")]
        public numFacet[] fractionDigits;
        
        [XmlElement("length")]
        public numFacet[] length;
        
        [XmlElement("minLength")]
        public numFacet[] minLength;
        
        [XmlElement("maxLength")]
        public numFacet[] maxLength;
        
        [XmlElement("enumeration")]
        public noFixedFacet[] enumeration;
        
        [XmlElement("whiteSpace")]
        public whiteSpace[] whiteSpace;
        
        [XmlElement("pattern")]
        public pattern[] pattern;
        
        [XmlAttribute()]
        public XmlQualifiedName @base;
        
        public override Object Accept(IxsdschemaNodeVisitor visitor, Object arg)
        {
            return visitor.Visit(this, arg);
        }
    }
    
    [XmlInclude(typeof(numFacet))]
    [XmlInclude(typeof(noFixedFacet))]
    [XmlType(Namespace="http://www.w3.org/2001/XMLSchema")]
    [XmlRoot(Namespace="http://www.w3.org/2001/XMLSchema", IsNullable=true)]
    public partial class facet : annotated
    {
        
        public facet()
        {
            this.@fixed = false;
        }
        
        [XmlAttribute()]
        public String value;
        
        [XmlAttribute()]
        [DefaultValue(false)]
        public Boolean @fixed;
        
        public override Object Accept(IxsdschemaNodeVisitor visitor, Object arg)
        {
            return visitor.Visit(this, arg);
        }
    }
    
    [XmlType(Namespace="http://www.w3.org/2001/XMLSchema")]
    [XmlRoot(Namespace="http://www.w3.org/2001/XMLSchema", IsNullable=true)]
    public partial class numFacet : facet
    {
        
        public override Object Accept(IxsdschemaNodeVisitor visitor, Object arg)
        {
            return visitor.Visit(this, arg);
        }
    }
    
    [XmlType(Namespace="http://www.w3.org/2001/XMLSchema")]
    [XmlRoot(Namespace="http://www.w3.org/2001/XMLSchema", IsNullable=true)]
    public partial class noFixedFacet : facet
    {
        
        public override Object Accept(IxsdschemaNodeVisitor visitor, Object arg)
        {
            return visitor.Visit(this, arg);
        }
    }
    
    [XmlType(AnonymousType=true, Namespace="http://www.w3.org/2001/XMLSchema")]
    public partial class totalDigits : numFacet
    {
        
        public override Object Accept(IxsdschemaNodeVisitor visitor, Object arg)
        {
            return visitor.Visit(this, arg);
        }
    }
    
    [XmlType(AnonymousType=true, Namespace="http://www.w3.org/2001/XMLSchema")]
    public partial class whiteSpace : facet
    {
        
        public override Object Accept(IxsdschemaNodeVisitor visitor, Object arg)
        {
            return visitor.Visit(this, arg);
        }
    }
    
    [XmlType(AnonymousType=true, Namespace="http://www.w3.org/2001/XMLSchema")]
    public partial class pattern : noFixedFacet
    {
        
        public override Object Accept(IxsdschemaNodeVisitor visitor, Object arg)
        {
            return visitor.Visit(this, arg);
        }
    }
    
    [XmlType(AnonymousType=true, Namespace="http://www.w3.org/2001/XMLSchema")]
    public partial class union : annotated
    {
        
        [XmlElement("simpleType")]
        public localSimpleType[] simpleType;
        
        [XmlAttribute()]
        public System.Xml.XmlQualifiedName[] memberTypes;
        
        public override Object Accept(IxsdschemaNodeVisitor visitor, Object arg)
        {
            return visitor.Visit(this, arg);
        }
    }
    
    [XmlType(Namespace="http://www.w3.org/2001/XMLSchema")]
    [XmlRoot(Namespace="http://www.w3.org/2001/XMLSchema", IsNullable=true)]
    public partial class topLevelSimpleType : simpleType
    {
        
        public override Object Accept(IxsdschemaNodeVisitor visitor, Object arg)
        {
            return visitor.Visit(this, arg);
        }
    }
    
    [XmlType(AnonymousType=true, Namespace="http://www.w3.org/2001/XMLSchema")]
    public enum attributeUse
    {
        
        prohibited,
        
        optional,
        
        required,
    }
    
    [XmlType(Namespace="http://www.w3.org/2001/XMLSchema")]
    public enum formChoice
    {
        
        qualified,
        
        unqualified,
    }
    
    [XmlType(Namespace="http://www.w3.org/2001/XMLSchema")]
    [XmlRoot(Namespace="http://www.w3.org/2001/XMLSchema", IsNullable=true)]
    public partial class topLevelAttribute : attribute
    {
        
        public override Object Accept(IxsdschemaNodeVisitor visitor, Object arg)
        {
            return visitor.Visit(this, arg);
        }
    }
    
    [XmlType(Namespace="http://www.w3.org/2001/XMLSchema")]
    [XmlRoot(Namespace="http://www.w3.org/2001/XMLSchema", IsNullable=true)]
    public partial class attributeGroupRef : attributeGroup
    {
        
        public override Object Accept(IxsdschemaNodeVisitor visitor, Object arg)
        {
            return visitor.Visit(this, arg);
        }
    }
    
    [XmlInclude(typeof(namedAttributeGroup))]
    [XmlInclude(typeof(attributeGroupRef))]
    [XmlType(Namespace="http://www.w3.org/2001/XMLSchema")]
    [XmlRoot(Namespace="http://www.w3.org/2001/XMLSchema", IsNullable=true)]
    public abstract partial class attributeGroup : annotated
    {
        
        [XmlElement("attribute", typeof(attribute))]
        [XmlElement("attributeGroup", typeof(attributeGroupRef))]
        public annotated[] Items;
        
        public wildcard anyAttribute;
        
        [XmlAttribute(DataType="NCName")]
        public String name;
        
        [XmlAttribute()]
        public XmlQualifiedName @ref;
        
        public override Object Accept(IxsdschemaNodeVisitor visitor, Object arg)
        {
            return visitor.Visit(this, arg);
        }
    }
    
    [XmlType(Namespace="http://www.w3.org/2001/XMLSchema")]
    [XmlRoot(Namespace="http://www.w3.org/2001/XMLSchema", IsNullable=true)]
    public partial class namedAttributeGroup : attributeGroup
    {
        
        public override Object Accept(IxsdschemaNodeVisitor visitor, Object arg)
        {
            return visitor.Visit(this, arg);
        }
    }
    
    [XmlType(AnonymousType=true, Namespace="http://www.w3.org/2001/XMLSchema")]
    public partial class complexContent : annotated
    {
        
        [XmlElement("extension", typeof(extensionType))]
        [XmlElement("restriction", typeof(complexRestrictionType))]
        public annotated Item;
        
        [XmlAttribute()]
        public Boolean mixed;
        
        [XmlIgnore()]
        public Boolean mixedSpecified;
        
        public override Object Accept(IxsdschemaNodeVisitor visitor, Object arg)
        {
            return visitor.Visit(this, arg);
        }
    }
    
    [XmlType(Namespace="http://www.w3.org/2001/XMLSchema")]
    [XmlRoot(Namespace="http://www.w3.org/2001/XMLSchema", IsNullable=true)]
    public partial class complexRestrictionType : restrictionType
    {
        
        public override Object Accept(IxsdschemaNodeVisitor visitor, Object arg)
        {
            return visitor.Visit(this, arg);
        }
    }
    
    [XmlInclude(typeof(simpleRestrictionType))]
    [XmlInclude(typeof(complexRestrictionType))]
    [XmlType(Namespace="http://www.w3.org/2001/XMLSchema")]
    [XmlRoot(Namespace="http://www.w3.org/2001/XMLSchema", IsNullable=true)]
    public partial class restrictionType : annotated
    {
        
        [XmlElement("all", typeof(all))]
        [XmlElement("choice", typeof(explicitGroup))]
        [XmlElement("enumeration", typeof(noFixedFacet))]
        [XmlElement("fractionDigits", typeof(numFacet))]
        [XmlElement("group", typeof(groupRef))]
        [XmlElement("length", typeof(numFacet))]
        [XmlElement("maxExclusive", typeof(facet))]
        [XmlElement("maxInclusive", typeof(facet))]
        [XmlElement("maxLength", typeof(numFacet))]
        [XmlElement("minExclusive", typeof(facet))]
        [XmlElement("minInclusive", typeof(facet))]
        [XmlElement("minLength", typeof(numFacet))]
        [XmlElement("pattern", typeof(pattern))]
        [XmlElement("sequence", typeof(explicitGroup))]
        [XmlElement("simpleType", typeof(localSimpleType))]
        [XmlElement("totalDigits", typeof(totalDigits))]
        [XmlElement("whiteSpace", typeof(whiteSpace))]
        [XmlChoiceIdentifier("ItemsElementName")]
        public annotated[] Items;
        
        [XmlElement("ItemsElementName")]
        [XmlIgnore()]
        public ItemsChoiceType1[] ItemsElementName;
        
        [XmlElement("attribute", typeof(attribute))]
        [XmlElement("attributeGroup", typeof(attributeGroupRef))]
        public annotated[] Items1;
        
        public wildcard anyAttribute;
        
        [XmlAttribute()]
        public XmlQualifiedName @base;
        
        public override Object Accept(IxsdschemaNodeVisitor visitor, Object arg)
        {
            return visitor.Visit(this, arg);
        }
    }
    
    [XmlType(Namespace="http://www.w3.org/2001/XMLSchema", IncludeInSchema=false)]
    public enum ItemsChoiceType1
    {
        
        all,
        
        choice,
        
        enumeration,
        
        fractionDigits,
        
        group,
        
        length,
        
        maxExclusive,
        
        maxInclusive,
        
        maxLength,
        
        minExclusive,
        
        minInclusive,
        
        minLength,
        
        pattern,
        
        sequence,
        
        simpleType,
        
        totalDigits,
        
        whiteSpace,
    }
    
    [XmlType(Namespace="http://www.w3.org/2001/XMLSchema")]
    [XmlRoot(Namespace="http://www.w3.org/2001/XMLSchema", IsNullable=true)]
    public partial class simpleRestrictionType : restrictionType
    {
        
        public override Object Accept(IxsdschemaNodeVisitor visitor, Object arg)
        {
            return visitor.Visit(this, arg);
        }
    }
    
    [XmlType(AnonymousType=true, Namespace="http://www.w3.org/2001/XMLSchema")]
    public partial class simpleContent : annotated
    {
        
        [XmlElement("extension", typeof(simpleExtensionType))]
        [XmlElement("restriction", typeof(simpleRestrictionType))]
        public annotated Item;
        
        public override Object Accept(IxsdschemaNodeVisitor visitor, Object arg)
        {
            return visitor.Visit(this, arg);
        }
    }
    
    [XmlType(Namespace="http://www.w3.org/2001/XMLSchema")]
    [XmlRoot(Namespace="http://www.w3.org/2001/XMLSchema", IsNullable=true)]
    public partial class simpleExtensionType : extensionType
    {
        
        public override Object Accept(IxsdschemaNodeVisitor visitor, Object arg)
        {
            return visitor.Visit(this, arg);
        }
    }
    
    [XmlType(Namespace="http://www.w3.org/2001/XMLSchema", IncludeInSchema=false)]
    public enum ItemsChoiceType2
    {
        
        all,
        
        anyAttribute,
        
        attribute,
        
        attributeGroup,
        
        choice,
        
        complexContent,
        
        group,
        
        sequence,
        
        simpleContent,
    }
    
    [XmlType(Namespace="http://www.w3.org/2001/XMLSchema")]
    [XmlRoot(Namespace="http://www.w3.org/2001/XMLSchema", IsNullable=true)]
    public partial class topLevelComplexType : complexType
    {
        
        public override Object Accept(IxsdschemaNodeVisitor visitor, Object arg)
        {
            return visitor.Visit(this, arg);
        }
    }
    
    [XmlType(Namespace="http://www.w3.org/2001/XMLSchema")]
    [XmlRoot(Namespace="http://www.w3.org/2001/XMLSchema", IsNullable=true)]
    public partial class keybase : annotated
    {
        
        public selector selector;
        
        [XmlElement("field")]
        public field[] field;
        
        [XmlAttribute(DataType="NCName")]
        public String name;
        
        public override Object Accept(IxsdschemaNodeVisitor visitor, Object arg)
        {
            return visitor.Visit(this, arg);
        }
    }
    
    [XmlType(AnonymousType=true, Namespace="http://www.w3.org/2001/XMLSchema")]
    public partial class selector : annotated
    {
        
        [XmlAttribute()]
        public String xpath;
        
        public override Object Accept(IxsdschemaNodeVisitor visitor, Object arg)
        {
            return visitor.Visit(this, arg);
        }
    }
    
    [XmlType(AnonymousType=true, Namespace="http://www.w3.org/2001/XMLSchema")]
    public partial class field : annotated
    {
        
        [XmlAttribute()]
        public String xpath;
        
        public override Object Accept(IxsdschemaNodeVisitor visitor, Object arg)
        {
            return visitor.Visit(this, arg);
        }
    }
    
    [XmlType(AnonymousType=true, Namespace="http://www.w3.org/2001/XMLSchema")]
    public partial class keyref : keybase
    {
        
        [XmlAttribute()]
        public XmlQualifiedName refer;
        
        public override Object Accept(IxsdschemaNodeVisitor visitor, Object arg)
        {
            return visitor.Visit(this, arg);
        }
    }
    
    [XmlType(Namespace="http://www.w3.org/2001/XMLSchema")]
    [XmlRoot(Namespace="http://www.w3.org/2001/XMLSchema", IsNullable=true)]
    public partial class topLevelElement : element
    {
        
        public override Object Accept(IxsdschemaNodeVisitor visitor, Object arg)
        {
            return visitor.Visit(this, arg);
        }
    }
    
    [XmlType(Namespace="http://www.w3.org/2001/XMLSchema")]
    [XmlRoot(Namespace="http://www.w3.org/2001/XMLSchema", IsNullable=true)]
    public partial class narrowMaxMin : localElement
    {
        
        public override Object Accept(IxsdschemaNodeVisitor visitor, Object arg)
        {
            return visitor.Visit(this, arg);
        }
    }
    
    [XmlType(Namespace="http://www.w3.org/2001/XMLSchema", IncludeInSchema=false)]
    public enum ItemsChoiceType
    {
        
        all,
        
        any,
        
        choice,
        
        element,
        
        group,
        
        sequence,
    }
    
    [XmlType(Namespace="http://www.w3.org/2001/XMLSchema")]
    [XmlRoot(Namespace="http://www.w3.org/2001/XMLSchema", IsNullable=true)]
    public partial class namedGroup : realGroup
    {
        
        public override Object Accept(IxsdschemaNodeVisitor visitor, Object arg)
        {
            return visitor.Visit(this, arg);
        }
    }
    
    public interface IxsdschemaNodeVisitor
    {
        
        Object Visit(openAttrs node, Object arg);
        
        Object Visit(annotated node, Object arg);
        
        Object Visit(annotation node, Object arg);
        
        Object Visit(appinfo node, Object arg);
        
        Object Visit(documentation node, Object arg);
        
        Object Visit(extensionType node, Object arg);
        
        Object Visit(groupRef node, Object arg);
        
        Object Visit(realGroup node, Object arg);
        
        Object Visit(group node, Object arg);
        
        Object Visit(all node, Object arg);
        
        Object Visit(explicitGroup node, Object arg);
        
        Object Visit(simpleExplicitGroup node, Object arg);
        
        Object Visit(any node, Object arg);
        
        Object Visit(wildcard node, Object arg);
        
        Object Visit(localElement node, Object arg);
        
        Object Visit(element node, Object arg);
        
        Object Visit(localComplexType node, Object arg);
        
        Object Visit(complexType node, Object arg);
        
        Object Visit(attribute node, Object arg);
        
        Object Visit(localSimpleType node, Object arg);
        
        Object Visit(simpleType node, Object arg);
        
        Object Visit(list node, Object arg);
        
        Object Visit(restriction node, Object arg);
        
        Object Visit(facet node, Object arg);
        
        Object Visit(numFacet node, Object arg);
        
        Object Visit(noFixedFacet node, Object arg);
        
        Object Visit(totalDigits node, Object arg);
        
        Object Visit(whiteSpace node, Object arg);
        
        Object Visit(pattern node, Object arg);
        
        Object Visit(union node, Object arg);
        
        Object Visit(topLevelSimpleType node, Object arg);
        
        Object Visit(topLevelAttribute node, Object arg);
        
        Object Visit(attributeGroupRef node, Object arg);
        
        Object Visit(attributeGroup node, Object arg);
        
        Object Visit(namedAttributeGroup node, Object arg);
        
        Object Visit(complexContent node, Object arg);
        
        Object Visit(complexRestrictionType node, Object arg);
        
        Object Visit(restrictionType node, Object arg);
        
        Object Visit(simpleRestrictionType node, Object arg);
        
        Object Visit(simpleContent node, Object arg);
        
        Object Visit(simpleExtensionType node, Object arg);
        
        Object Visit(topLevelComplexType node, Object arg);
        
        Object Visit(keybase node, Object arg);
        
        Object Visit(selector node, Object arg);
        
        Object Visit(field node, Object arg);
        
        Object Visit(keyref node, Object arg);
        
        Object Visit(topLevelElement node, Object arg);
        
        Object Visit(narrowMaxMin node, Object arg);
        
        Object Visit(namedGroup node, Object arg);
    }
    
    public abstract class xsdschemaNodeBase
    {
        
        public abstract Object Accept(IxsdschemaNodeVisitor visitor, Object arg);
    }
    
    public class xsdschemaNodeVisitor : IxsdschemaNodeVisitor
    {
        
        private Object AcceptAll(IEnumerable<xsdschemaNodeBase> items, Object arg)
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
        
        private Object AcceptSingle(xsdschemaNodeBase item, Object arg)
        {
            item?.Accept(this, arg);
            return default(Object);
        }
        
        public virtual Object Visit(openAttrs node, Object arg)
        {
            return default(Object);
        }
        
        public virtual Object Visit(annotated node, Object arg)
        {
            AcceptSingle(node.annotation, arg);
            return default(Object);
        }
        
        public virtual Object Visit(annotation node, Object arg)
        {
            return default(Object);
        }
        
        public virtual Object Visit(appinfo node, Object arg)
        {
            return default(Object);
        }
        
        public virtual Object Visit(documentation node, Object arg)
        {
            return default(Object);
        }
        
        public virtual Object Visit(extensionType node, Object arg)
        {
            AcceptSingle(node.group, arg);
            AcceptSingle(node.all, arg);
            AcceptSingle(node.choice, arg);
            AcceptSingle(node.sequence, arg);
            AcceptAll(node.Items, arg);
            AcceptSingle(node.anyAttribute, arg);
            return default(Object);
        }
        
        public virtual Object Visit(groupRef node, Object arg)
        {
            return default(Object);
        }
        
        public virtual Object Visit(realGroup node, Object arg)
        {
            return default(Object);
        }
        
        public virtual Object Visit(group node, Object arg)
        {
            AcceptAll(node.Items, arg);
            return default(Object);
        }
        
        public virtual Object Visit(all node, Object arg)
        {
            return default(Object);
        }
        
        public virtual Object Visit(explicitGroup node, Object arg)
        {
            return default(Object);
        }
        
        public virtual Object Visit(simpleExplicitGroup node, Object arg)
        {
            return default(Object);
        }
        
        public virtual Object Visit(any node, Object arg)
        {
            return default(Object);
        }
        
        public virtual Object Visit(wildcard node, Object arg)
        {
            return default(Object);
        }
        
        public virtual Object Visit(localElement node, Object arg)
        {
            return default(Object);
        }
        
        public virtual Object Visit(element node, Object arg)
        {
            AcceptSingle(node.Item, arg);
            AcceptAll(node.unique, arg);
            AcceptAll(node.key, arg);
            AcceptAll(node.keyref, arg);
            return default(Object);
        }
        
        public virtual Object Visit(localComplexType node, Object arg)
        {
            return default(Object);
        }
        
        public virtual Object Visit(complexType node, Object arg)
        {
            AcceptAll(node.Items, arg);
            return default(Object);
        }
        
        public virtual Object Visit(attribute node, Object arg)
        {
            AcceptSingle(node.simpleType, arg);
            return default(Object);
        }
        
        public virtual Object Visit(localSimpleType node, Object arg)
        {
            return default(Object);
        }
        
        public virtual Object Visit(simpleType node, Object arg)
        {
            AcceptSingle(node.Item, arg);
            return default(Object);
        }
        
        public virtual Object Visit(list node, Object arg)
        {
            AcceptSingle(node.simpleType, arg);
            return default(Object);
        }
        
        public virtual Object Visit(restriction node, Object arg)
        {
            AcceptSingle(node.simpleType, arg);
            AcceptAll(node.minExclusive, arg);
            AcceptAll(node.minInclusive, arg);
            AcceptAll(node.maxExclusive, arg);
            AcceptAll(node.maxInclusive, arg);
            AcceptAll(node.totalDigits, arg);
            AcceptAll(node.fractionDigits, arg);
            AcceptAll(node.length, arg);
            AcceptAll(node.minLength, arg);
            AcceptAll(node.maxLength, arg);
            AcceptAll(node.enumeration, arg);
            AcceptAll(node.whiteSpace, arg);
            AcceptAll(node.pattern, arg);
            return default(Object);
        }
        
        public virtual Object Visit(facet node, Object arg)
        {
            return default(Object);
        }
        
        public virtual Object Visit(numFacet node, Object arg)
        {
            return default(Object);
        }
        
        public virtual Object Visit(noFixedFacet node, Object arg)
        {
            return default(Object);
        }
        
        public virtual Object Visit(totalDigits node, Object arg)
        {
            return default(Object);
        }
        
        public virtual Object Visit(whiteSpace node, Object arg)
        {
            return default(Object);
        }
        
        public virtual Object Visit(pattern node, Object arg)
        {
            return default(Object);
        }
        
        public virtual Object Visit(union node, Object arg)
        {
            AcceptAll(node.simpleType, arg);
            return default(Object);
        }
        
        public virtual Object Visit(topLevelSimpleType node, Object arg)
        {
            return default(Object);
        }
        
        public virtual Object Visit(topLevelAttribute node, Object arg)
        {
            return default(Object);
        }
        
        public virtual Object Visit(attributeGroupRef node, Object arg)
        {
            return default(Object);
        }
        
        public virtual Object Visit(attributeGroup node, Object arg)
        {
            AcceptAll(node.Items, arg);
            AcceptSingle(node.anyAttribute, arg);
            return default(Object);
        }
        
        public virtual Object Visit(namedAttributeGroup node, Object arg)
        {
            return default(Object);
        }
        
        public virtual Object Visit(complexContent node, Object arg)
        {
            AcceptSingle(node.Item, arg);
            return default(Object);
        }
        
        public virtual Object Visit(complexRestrictionType node, Object arg)
        {
            return default(Object);
        }
        
        public virtual Object Visit(restrictionType node, Object arg)
        {
            AcceptAll(node.Items, arg);
            AcceptAll(node.Items1, arg);
            AcceptSingle(node.anyAttribute, arg);
            return default(Object);
        }
        
        public virtual Object Visit(simpleRestrictionType node, Object arg)
        {
            return default(Object);
        }
        
        public virtual Object Visit(simpleContent node, Object arg)
        {
            AcceptSingle(node.Item, arg);
            return default(Object);
        }
        
        public virtual Object Visit(simpleExtensionType node, Object arg)
        {
            return default(Object);
        }
        
        public virtual Object Visit(topLevelComplexType node, Object arg)
        {
            return default(Object);
        }
        
        public virtual Object Visit(keybase node, Object arg)
        {
            AcceptSingle(node.selector, arg);
            AcceptAll(node.field, arg);
            return default(Object);
        }
        
        public virtual Object Visit(selector node, Object arg)
        {
            return default(Object);
        }
        
        public virtual Object Visit(field node, Object arg)
        {
            return default(Object);
        }
        
        public virtual Object Visit(keyref node, Object arg)
        {
            return default(Object);
        }
        
        public virtual Object Visit(topLevelElement node, Object arg)
        {
            return default(Object);
        }
        
        public virtual Object Visit(narrowMaxMin node, Object arg)
        {
            return default(Object);
        }
        
        public virtual Object Visit(namedGroup node, Object arg)
        {
            return default(Object);
        }
    }
}
