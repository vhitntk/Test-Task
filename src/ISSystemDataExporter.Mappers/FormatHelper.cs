using System.Text.Json;
using System.Xml.Serialization;

namespace ISSystemDataExporter.Mappers;

public static class FormatHelper
{
    public static T DeserializeFromXML<T>(Stream xmlStream)
        where T : class, new()
    {
        var serializer = new XmlSerializer(typeof(T));
        return (serializer.Deserialize(xmlStream) as T)!;
    }

    public static T DeserializeFromJson<T>(Stream jsonStream)
            where T : class
    {
        var jso = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        using var reader = new StreamReader(jsonStream);
        return JsonSerializer.Deserialize<T>(reader.ReadToEnd(), jso)!;
    }

    public static string SerializeToJson<T>(T entity)
    {
        var jso = new JsonSerializerOptions
        {
            DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
        return JsonSerializer.Serialize(entity, jso);
    }
}