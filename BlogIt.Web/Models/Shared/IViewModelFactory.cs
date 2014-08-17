namespace BlogIt.Web.Models.Shared
{
    /// <summary>
    /// View model factory interface.
    /// </summary>
    public interface IViewModelFactory
    {
        T Create<T>() where T : SharedContext, new();
    }
}
