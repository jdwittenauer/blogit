namespace BlogIt.Web.Framework
{
    /// <summary>
    /// Implementation of a generic object mapping service that is a wrapper for AutoMapper.
    /// </summary>
    public class MappingService : IMappingService
    {
        /// <summary>
        /// Execute a mapping from the source object to the new destination object
        /// </summary>
        /// <typeparam name="TSrc">Source type</typeparam>
        /// <typeparam name="TDest">Destination type</typeparam>
        /// <param name="source">Source object</param>
        /// <returns>Destination object</returns>
        public TDest Map<TSrc, TDest>(TSrc source) where TDest : class, new()
        {
            return AutoMapper.Mapper.Map<TSrc, TDest>(source);
        }
    }
}