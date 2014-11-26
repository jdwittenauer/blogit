namespace BlogIt.Web.Framework
{
    /// <summary>
    /// Interface for a generic object mapping service.
    /// </summary>
    public interface IMappingService
    {
        TDest Map<TSrc, TDest>(TSrc source) where TDest : class, new();
    }
}
