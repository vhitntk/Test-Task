using ISSystemDataExporter.Mappers.Parsers;
using ISSystemDataExporter.Mappers.Functional.Tests.Resources;
using ISSystemDataExporter.Models.ISSystem;
using NUnit.Framework;

namespace ISSystemDataExporter.Mappers.Tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        using var xmlStream = Resource.GetStream("getCompany78477_ASMX.XML");
        var companyContainer = FormatHelper.DeserializeFromXML<CompanyPropertyContainer>(xmlStream);
         Assert.That(companyContainer, Is.Not.Null);
    }

    [Test]
    public void Test2()
    {
        var xml = "&lt;list&gt;&lt;item LanguageID=\"1049\"&gt;Юритест&lt;/item&gt;&lt;/list&gt;";
        var a = new XMLContentParser();
        var b = a.GetTagInnerText(xml);
        Assert.That(b, Is.EqualTo("Юритест"));
    }

    [Test]
    public void Test3()
    {
        var xml = "&lt;list&gt;&lt;item LanguageID=\"1049\"&gt;Клиент&lt;/item&gt;&lt;item LanguageID=\"1033\"&gt;Front office&lt;/item&gt;&lt;item LanguageID=\"2074\"&gt;Front office&lt;/item&gt;&lt;/list&gt;";
        var a = new XMLContentParser();
        var b = a.GetTagInnerText(xml);
        Assert.That(b, Is.EqualTo("Клиент"));
    }

    [Test]
    public void Test4()
    {
        var xml = "&lt;list&gt;&lt;item LanguageID=\"1049\"&gt;Ltd.&lt;/item&gt;&lt;item LanguageID=\"2074\"&gt;Ltd.&lt;/item&gt;&lt;/list&gt;";
        var a = new XMLContentParser();
        var b = a.GetTagInnerText(xml);
        Assert.That(b, Is.EqualTo("Ltd."));
    }

    [Test]
    public void Test5()
    {
        var xml = "&lt;list&gt;&lt;item LanguageID=\"1049\"&gt;#тест владелец&lt;/item&gt;&lt;/list&gt;";
        var a = new XMLContentParser();
        var b = a.GetTagInnerText(xml);
        Assert.That(b, Is.EqualTo("#тест владелец"));
    }    
}