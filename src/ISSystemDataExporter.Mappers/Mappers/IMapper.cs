namespace ISSystemDataExporter.Mappers.Mappers;

public interface IMapper<TSource, TDestination>
{
    TDestination Map(TSource source);
}
