namespace ApplicationCore.Utility.Mapper
{
    /// <summary>
    /// Entity mapper interface
    /// </summary>
    public interface IMapper { TDestination Map<TSource, TDestination>(TSource source); }
}
