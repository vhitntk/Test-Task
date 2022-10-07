using System.Xml.Serialization;

namespace ISSystemDataExporter.Models.ISSystem;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

[XmlRoot(ElementName = "Starred", Namespace = "it_rus/contact")]
public class Starred
{
    [XmlAttribute(AttributeName = "xmlns")]
    public string Xmlns { get; set; }

    [XmlText]
    public string Text { get; set; }
}

[XmlRoot(ElementName = "Labels", Namespace = "it_rus/contact")]
public class Labels
{
    [XmlAttribute(AttributeName = "xmlns")]
    public string Xmlns { get; set; }
}

[XmlRoot(ElementName = "UserClassification", Namespace = "http://ee.intra-global.net/is")]
public class UserClassification
{
    [XmlElement(ElementName = "Starred", Namespace = "it_rus/contact")]
    public Starred Starred { get; set; }
    [XmlElement(ElementName = "Labels", Namespace = "it_rus/contact")]
    public Labels Labels { get; set; }
}

[XmlRoot(ElementName = "DictionaryItem", Namespace = "http://ee.intra-global.net/is")]
public class DictionaryItem
{
    [XmlElement(ElementName = "ItemID", Namespace = "http://ee.intra-global.net/is")]
    public int ItemID { get; set; }
    [XmlElement(ElementName = "ItemCaption", Namespace = "http://ee.intra-global.net/is")]
    public string ItemCaption { get; set; }
    [XmlElement(ElementName = "SortOrder", Namespace = "http://ee.intra-global.net/is")]
    public string? SortOrder { get; set; }
}

public class Address
{
    [XmlElement(ElementName = "ZipCode", Namespace = "http://ee.intra-global.net/is")]
    public string ZipCode { get; set; }
    [XmlElement(ElementName = "Country", Namespace = "http://ee.intra-global.net/is")]
    public DictionaryItem Country { get; set; }
    [XmlElement(ElementName = "Region", Namespace = "http://ee.intra-global.net/is")]
    public DictionaryItem Region { get; set; }
    [XmlElement(ElementName = "Town", Namespace = "http://ee.intra-global.net/is")]
    public DictionaryItem Town { get; set; }
    [XmlElement(ElementName = "Street", Namespace = "http://ee.intra-global.net/is")]
    public string Street { get; set; }
    [XmlElement(ElementName = "House", Namespace = "http://ee.intra-global.net/is")]
    public string House { get; set; }
    [XmlElement(ElementName = "ExtraList", Namespace = "http://ee.intra-global.net/is")]
    public string ExtraList { get; set; }
}

[XmlRoot(ElementName = "Value", Namespace = "http://ee.intra-global.net/is")]
public class Value
{
    [XmlAttribute(AttributeName = "type", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
    public string Type { get; set; }
    [XmlText]
    public string Text { get; set; }
}

[XmlRoot(ElementName = "AdditionalParameter", Namespace = "http://ee.intra-global.net/is")]
[XmlType("AdditionalParameter", Namespace = "http://ee.intra-global.net/is")]
[XmlInclude(typeof(AdditionalParameterCheck))]
[XmlInclude(typeof(AdditionalParameterDictionary))]
[XmlInclude(typeof(AdditionalParameterMultiChoiceDictionary))]
[XmlInclude(typeof(AdditionalParameterString))]
public abstract class AdditionalParameter
{
    [XmlElement(ElementName = "ID", Namespace = "http://ee.intra-global.net/is")]
    public string ID { get; set; }
    [XmlElement(ElementName = "Name", Namespace = "http://ee.intra-global.net/is")]
    public string Name { get; set; }
    [XmlElement(ElementName = "Code", Namespace = "http://ee.intra-global.net/is")]
    public string Code { get; set; }
    [XmlElement(ElementName = "Required", Namespace = "http://ee.intra-global.net/is")]
    public string Required { get; set; }
    [XmlElement(ElementName = "Value", Namespace = "http://ee.intra-global.net/is")]
    public string Value { get; set; }
    [XmlAttribute(AttributeName = "type", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
    public string Type { get; set; }
    [XmlElement(ElementName = "WCFValue", Namespace = "http://ee.intra-global.net/is")]
    public string? WCFValue { get; set; }
    [XmlElement(ElementName = "RestrictRegex", Namespace = "http://ee.intra-global.net/is")]
    public string RestrictRegex { get; set; }
    [XmlElement(ElementName = "Unit", Namespace = "http://ee.intra-global.net/is")]
    public DictionaryItem Unit { get; set; }
}

[XmlRoot(ElementName = "AdditionalParameter", Namespace = "http://ee.intra-global.net/is")]
[XmlType("AdditionalParameterString", Namespace = "http://ee.intra-global.net/is")]
public class AdditionalParameterString : AdditionalParameter
{
}

[XmlRoot(ElementName = "AdditionalParameter", Namespace = "http://ee.intra-global.net/is")]
[XmlType("AdditionalParameterDictionary", Namespace = "http://ee.intra-global.net/is")]
public class AdditionalParameterDictionary : AdditionalParameter
{
}

[XmlRoot(ElementName = "AdditionalParameter", Namespace = "http://ee.intra-global.net/is")]
[XmlType("AdditionalParameterMultiChoiceDictionary", Namespace = "http://ee.intra-global.net/is")]
public class AdditionalParameterMultiChoiceDictionary : AdditionalParameter
{
}

[XmlRoot(ElementName = "AdditionalParameter", Namespace = "http://ee.intra-global.net/is")]
[XmlType("AdditionalParameterCheck", Namespace = "http://ee.intra-global.net/is")]
public class AdditionalParameterCheck : AdditionalParameter
{
}

[XmlRoot(ElementName = "Parameters", Namespace = "http://ee.intra-global.net/is")]
public class Parameters
{
    [XmlElement(ElementName = "AdditionalParameter", Namespace = "http://ee.intra-global.net/is")]   
    public List<AdditionalParameter> AdditionalParameter { get; set; }
}

[XmlRoot(ElementName = "AdditionalParameterSet", Namespace = "http://ee.intra-global.net/is")]
public class AdditionalParameterSet
{
    [XmlElement(ElementName = "Parameters", Namespace = "http://ee.intra-global.net/is")]
    public Parameters Parameters { get; set; }
}

[XmlRoot(ElementName = "FiscalAdditionalParameterSet", Namespace = "http://ee.intra-global.net/is")]
public class FiscalAdditionalParameterSet
{
    [XmlElement(ElementName = "Parameters", Namespace = "http://ee.intra-global.net/is")]
    public Parameters Parameters { get; set; }
}

[XmlRoot(ElementName = "Details", Namespace = "http://ee.intra-global.net/is")]
public class Details
{
    [XmlElement(ElementName = "UserClassification", Namespace = "http://ee.intra-global.net/is")]
    public UserClassification UserClassification { get; set; }
    [XmlElement(ElementName = "Name", Namespace = "http://ee.intra-global.net/is")]
    public string Name { get; set; }
    [XmlElement(ElementName = "LegalName", Namespace = "http://ee.intra-global.net/is")]
    public string LegalName { get; set; }
    [XmlElement(ElementName = "EntityType", Namespace = "http://ee.intra-global.net/is")]
    public DictionaryItem EntityType { get; set; }
    [XmlElement(ElementName = "LegalForm", Namespace = "http://ee.intra-global.net/is")]
    public DictionaryItem LegalForm { get; set; }
    [XmlArray("BusinessRegion", Namespace = "http://ee.intra-global.net/is")]
    [XmlArrayItem("DictionaryItem", Namespace = "http://ee.intra-global.net/is")]
    public DictionaryItem[] BusinessRegion { get; set; }

    [XmlArray("Activities", Namespace = "http://ee.intra-global.net/is")]
    [XmlArrayItem("DictionaryItem", Namespace = "http://ee.intra-global.net/is")]
    public DictionaryItem[] Activities { get; set; }
    [XmlElement(ElementName = "ActualAddress", Namespace = "http://ee.intra-global.net/is")]
    public Address ActualAddress { get; set; }
    
    [XmlElement(ElementName = "Notes", Namespace = "http://ee.intra-global.net/is")]
    public string Notes { get; set; }
    [XmlElement(ElementName = "LegalAddress", Namespace = "http://ee.intra-global.net/is")]
    public Address LegalAddress { get; set; }
    [XmlElement(ElementName = "BankList", Namespace = "http://ee.intra-global.net/is")]
    public string BankList { get; set; }
    
    //TODO: remove extra nesting
    [XmlElement(ElementName = "FiscalAdditionalParameterSet", Namespace = "http://ee.intra-global.net/is")]
    public FiscalAdditionalParameterSet FiscalAdditionalParameterSet { get; set; }
    [XmlElement(ElementName = "Suppliers", Namespace = "http://ee.intra-global.net/is")]
    public string Suppliers { get; set; }
    [XmlElement(ElementName = "CompetitorSuppliers", Namespace = "http://ee.intra-global.net/is")]
    public string CompetitorSuppliers { get; set; }
    [XmlElement(ElementName = "CompanyContact", Namespace = "http://ee.intra-global.net/is")]
    public string CompanyContact { get; set; }
    [XmlElement(ElementName = "Files", Namespace = "http://ee.intra-global.net/is")]
    public string Files { get; set; }
}

[XmlRoot(ElementName = "Link", Namespace = "http://ee.intra-global.net/is")]
public class Link
{
    [XmlElement(ElementName = "ParentPerson", Namespace = "http://ee.intra-global.net/is")]
    public string ParentPerson { get; set; }
    [XmlElement(ElementName = "ParentCompany", Namespace = "http://ee.intra-global.net/is")]
    public string ParentCompany { get; set; }
    [XmlElement(ElementName = "ChildrenCompany", Namespace = "http://ee.intra-global.net/is")]
    public string ChildrenCompany { get; set; }
    [XmlElement(ElementName = "Staff", Namespace = "http://ee.intra-global.net/is")]
    public string Staff { get; set; }
}

[XmlRoot(ElementName = "VersionInfo", Namespace = "http://ee.intra-global.net/is")]
public class VersionInfo
{
    [XmlElement(ElementName = "CreatedBy", Namespace = "http://ee.intra-global.net/is")]
    public DictionaryItem CreatedBy { get; set; }
    [XmlElement(ElementName = "UpdatedBy", Namespace = "http://ee.intra-global.net/is")]
    public DictionaryItem UpdatedBy { get; set; }
    [XmlElement(ElementName = "UpdateDateTime", Namespace = "http://ee.intra-global.net/is")]
    public string UpdateDateTime { get; set; }
    [XmlElement(ElementName = "DeleteDateTime", Namespace = "http://ee.intra-global.net/is")]
    public string DeleteDateTime { get; set; }
    [XmlElement(ElementName = "RestoreDateTime", Namespace = "http://ee.intra-global.net/is")]
    public string RestoreDateTime { get; set; }
}

[XmlRoot(ElementName = "Export", Namespace = "http://ee.intra-global.net/is")]
public class Export
{
    [XmlElement(ElementName = "DestinationSystem", Namespace = "http://ee.intra-global.net/is")]
    public string DestinationSystem { get; set; }
    [XmlElement(ElementName = "Name", Namespace = "http://ee.intra-global.net/is")]
    public string Name { get; set; }
    [XmlElement(ElementName = "Comments", Namespace = "http://ee.intra-global.net/is")]
    public string Comments { get; set; }
}

[XmlRoot(ElementName = "Company", Namespace = "http://ee.intra-global.net/is")]
public class Company
{
    [XmlElement(ElementName = "Deleted", Namespace = "http://ee.intra-global.net/is")]
    public string Deleted { get; set; }
    [XmlElement(ElementName = "ReadOnly", Namespace = "http://ee.intra-global.net/is")]
    public string ReadOnly { get; set; }
    [XmlElement(ElementName = "CompanyID", Namespace = "http://ee.intra-global.net/is")]
    public string CompanyID { get; set; }
    [XmlElement(ElementName = "UID", Namespace = "http://ee.intra-global.net/is")]
    public string UID { get; set; }
    [XmlElement(ElementName = "Version", Namespace = "http://ee.intra-global.net/is")]
    public string Version { get; set; }
    [XmlElement(ElementName = "InheritedID", Namespace = "http://ee.intra-global.net/is")]
    public string InheritedID { get; set; }
    [XmlElement(ElementName = "Details", Namespace = "http://ee.intra-global.net/is")]
    public Details Details { get; set; }
    [XmlElement(ElementName = "Link", Namespace = "http://ee.intra-global.net/is")]
    public Link Link { get; set; }
    [XmlElement(ElementName = "VersionInfo", Namespace = "http://ee.intra-global.net/is")]
    public VersionInfo VersionInfo { get; set; }
    [XmlElement(ElementName = "SchemeVersion", Namespace = "http://ee.intra-global.net/is")]
    public string SchemeVersion { get; set; }
    [XmlElement(ElementName = "Export", Namespace = "http://ee.intra-global.net/is")]
    public Export Export { get; set; }
    [XmlAttribute(AttributeName = "xmlns")]
    public string Xmlns { get; set; }
}

[XmlRoot(ElementName = "Owner", Namespace = "http://ee.intra-global.net/is")]
public class Owner
{
    [XmlElement(ElementName = "ID", Namespace = "http://ee.intra-global.net/is")]
    public string ID { get; set; }
    [XmlElement(ElementName = "UID", Namespace = "http://ee.intra-global.net/is")]
    public string UID { get; set; }
    [XmlElement(ElementName = "VersionUID", Namespace = "http://ee.intra-global.net/is")]
    public string VersionUID { get; set; }
    [XmlElement(ElementName = "Caption", Namespace = "http://ee.intra-global.net/is")]
    public string Caption { get; set; }
    [XmlElement(ElementName = "Address", Namespace = "http://ee.intra-global.net/is")]
    public string Address { get; set; }
}

[XmlRoot(ElementName = "Property", Namespace = "http://ee.intra-global.net/is")]
public class Property
{
    [XmlElement(ElementName = "ID", Namespace = "http://ee.intra-global.net/is")]
    public string ID { get; set; }
    [XmlElement(ElementName = "UID", Namespace = "http://ee.intra-global.net/is")]
    public string UID { get; set; }
    [XmlElement(ElementName = "VersionUID", Namespace = "http://ee.intra-global.net/is")]
    public string VersionUID { get; set; }
    [XmlElement(ElementName = "Caption", Namespace = "http://ee.intra-global.net/is")]
    public string Caption { get; set; }
    [XmlElement(ElementName = "Address", Namespace = "http://ee.intra-global.net/is")]
    public string Address { get; set; }
}

[XmlRoot(ElementName = "PropertyConnectionItem", Namespace = "http://ee.intra-global.net/is")]
public class PropertyConnectionItem
{
    [XmlElement(ElementName = "Owner", Namespace = "http://ee.intra-global.net/is")]
    public Owner Owner { get; set; }
    [XmlElement(ElementName = "Property", Namespace = "http://ee.intra-global.net/is")]
    public Property Property { get; set; }
    [XmlElement(ElementName = "AuthorID", Namespace = "http://ee.intra-global.net/is")]
    public string AuthorID { get; set; }
    [XmlElement(ElementName = "ConnectionType", Namespace = "http://ee.intra-global.net/is")]
    public string ConnectionType { get; set; }
    [XmlElement(ElementName = "Updated", Namespace = "http://ee.intra-global.net/is")]
    public string Updated { get; set; }
    [XmlElement(ElementName = "ReadOnly", Namespace = "http://ee.intra-global.net/is")]
    public string ReadOnly { get; set; }
    [XmlElement(ElementName = "Key", Namespace = "http://ee.intra-global.net/is")]
    public string Key { get; set; }
    [XmlElement(ElementName = "SchemeVersion", Namespace = "http://ee.intra-global.net/is")]
    public string SchemeVersion { get; set; }
}

[XmlRoot(ElementName = "Coordinates", Namespace = "http://ee.intra-global.net/is")]
public class Coordinates
{
    [XmlElement(ElementName = "Latitude", Namespace = "http://ee.intra-global.net/is")]
    public string Latitude { get; set; }
    [XmlElement(ElementName = "Longitude", Namespace = "http://ee.intra-global.net/is")]
    public string Longitude { get; set; }
    [XmlElement(ElementName = "Accuracy", Namespace = "http://ee.intra-global.net/is")]
    public string Accuracy { get; set; }
    [XmlAttribute(AttributeName = "xmlns")]
    public string Xmlns { get; set; }
}

[XmlRoot(ElementName = "CompanyPropertyContainer")]
public class CompanyPropertyContainer
{
    [XmlElement(ElementName = "Company", Namespace = "http://ee.intra-global.net/is")]
    public Company Company { get; set; }
    
    [XmlArray("Property", Namespace = "http://ee.intra-global.net/is")]
    [XmlArrayItem("PropertyConnectionItem", Namespace = "http://ee.intra-global.net/is")]
    public PropertyConnectionItem[] Property { get; set; }
    [XmlElement(ElementName = "Coordinates", Namespace = "http://ee.intra-global.net/is")]
    public Coordinates Coordinates { get; set; }
}

#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
