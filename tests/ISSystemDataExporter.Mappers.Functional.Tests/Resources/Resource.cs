using System.Reflection;

namespace ISSystemDataExporter.Mappers.Functional.Tests.Resources;

public static class Resource
{
    public static Stream GetStream(string key)
    {
        var assembly = Assembly.GetCallingAssembly();        
        return assembly.GetManifestResourceStream($"{typeof(Resource).Namespace}.{key}")!;
    }

    public static string GetString(string key)
    {
        using var stream = GetStream(key);
        using var reader = new StreamReader(stream!);
        return reader.ReadToEnd();
    }
}