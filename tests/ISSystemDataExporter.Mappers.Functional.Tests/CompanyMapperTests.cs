using FluentAssertions;
using ISSystemDataExporter.DI;
using ISSystemDataExporter.Mappers.Functional.Tests.Resources;
using ISSystemDataExporter.Mappers.Mappers;
using ISSystemDataExporter.Models.ISSystem;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Company = ISSystemDataExporter.Models.Storelocator.Company;

namespace ISSystemDataExporter.Mappers.Functional.Tests;

public class CompanyMapperTests
{
    private ICompanyMapper companyMapper;

    [OneTimeSetUp]
    public void Setup()
    {
        var services = new ServiceCollection();
        //Для функционального тестирования не используется подмена зависимостей (aka mocks),
        //вместо этого инициализируется DI контейнер и все зависимости штатно в нём регистрируются 
        services.RegisterMappers();
        var serviceProvider = services.BuildServiceProvider();

        //Экземпляр тестируемого сервиса получается из упомянутого контейнера
        companyMapper = serviceProvider.GetRequiredService<ICompanyMapper>();
    }

    [Test]
    public void CompanyMapper_Maps_From_ISSystem_to_Storelocator_Correctly()
    {
        //Arrange
        //Файлы XML и JSON, из письма, добавлены как Embedded Resource
        using var xmlStream = Resource.GetStream("getCompany78477_ASMX.XML");
        using var jsonStream = Resource.GetStream("getCompany78477_API.JSON");

        //Исходный объект CompanyPropertyContainer, полученный путём десериализации представленного XML
        var companyContainer = FormatHelper.DeserializeFromXML<CompanyPropertyContainer>(xmlStream);
        
        //Ожидаемый результат типа Company, полученный путём десериализации представленного JSON
        var expectedResult = FormatHelper.DeserializeFromJson<Company>(jsonStream);

        //Act
        //Результат кода преобразования
        var actualResult = companyMapper.Map(companyContainer);

        //Assert
        actualResult.Should().NotBeNull();

        //Сравнение фактического и ожидаемого объектов типа Company по содержимому.
        actualResult.Should().BeEquivalentTo(expectedResult);
    }
}
