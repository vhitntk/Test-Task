using ISSystemDataExporter.DI;
using ISSystemDataExporter.Host.Api;
using ISSystemDataExporter.Host.Configuration;
using Microsoft.AspNetCore.Server.Kestrel.Core;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault;
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.RegisterMappers();
var clientConfig = builder.Configuration.GetRequiredSection("Api:Storelocator").Get<StorelocatorApiClientConfig>();

builder.Services.AddHttpClient<IStorelocatorApiClient, StorelocatorApiClient>((client) =>
{
    client.BaseAddress = new Uri(clientConfig.BaseAddress);
});

builder.Services.Configure<KestrelServerOptions>(options =>
{
    options.AllowSynchronousIO = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
