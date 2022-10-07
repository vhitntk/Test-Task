using ISSystemDataExporter.Host.Api;
using ISSystemDataExporter.Mappers;
using ISSystemDataExporter.Mappers.Mappers;
using ISSystemDataExporter.Models.ISSystem;
using Microsoft.AspNetCore.Mvc;

namespace ISSystemDataExporter.Host.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MapController : ControllerBase
{
    private readonly ICompanyMapper companyMapper;
    //private readonly IStorelocatorApiClient apiClient;

    public MapController(ICompanyMapper companyMapper)
        //IStorelocatorApiClient apiClient)
    {
        this.companyMapper = companyMapper;
        //this.apiClient = apiClient;
    }

    /// <summary>
    /// Демонстрационный эндпоинт, с помощью которого можно сверить результирующий JSON с образцом
    /// </summary>
    /// <returns></returns>
    [HttpGet("company")]
    public async Task<IActionResult> MapCompany(CancellationToken cancellationToken)
    {
        using var stream = new FileStream("Files/getCompany78477_ASMX.XML", FileMode.Open);
        var companyPropertyContainer = FormatHelper.DeserializeFromXML<CompanyPropertyContainer>(stream);
        var mapped = companyMapper.Map(companyPropertyContainer);
        //var reslt = await apiClient.ExportCompany<Company>(mapped, cancellationToken);
        return Ok(mapped);
    }
}
