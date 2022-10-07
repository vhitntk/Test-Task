namespace ISSystemDataExporter.Models.Storelocator;

public class Company
{
    public string? ContactUid { get; set; } = default;
    public string? Name { get; set; } = default!;
    public string? FullName { get; set; } = default!;
    public DictionaryItem LegalForm { get; set; } = default!;
    public string? LegalName { get; set; } = default!;
    public Address ActualAddress { get; set; } = default!;
    public Address LegalAddress { get; set; } = default!;
    public Companydetail[] CompanyDetails { get; set; } = default!;
    public DictionaryItem EntityType { get; set; } = default!;
    public DictionaryItem[] Activities { get; set; } = default!;
    public DictionaryItem[] BusinessRegions { get; set; } = default!;
    public object[] Contacts { get; set; } = default!;
}

public class DictionaryItem
{
    public int Id { get; set; }
    public string? Text { get; set; } = default;
}

public class Address
{
    public string ZipCode { get; set; } = default!;
    public DictionaryItem Country { get; set; } = default!;
    public DictionaryItem Area { get; set; } = default!;
    public DictionaryItem Locality { get; set; } = default!;
    public string? Thoroughfare { get; set; } = default!;
    public string House { get; set; } = default!;
    public string Premise { get; set; } = default!;
}

public class Companydetail
{
    public string Code { get; set; } = default!;
    public string? Name { get; set; } = default!;
    public string Value { get; set; } = default!;
}
