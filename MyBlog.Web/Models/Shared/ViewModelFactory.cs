using System.Web;

namespace MyBlog.Web.Models.Shared
{
    /// <summary>
    /// View model factory class.
    /// </summary>
    public class ViewModelFactory : IViewModelFactory
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public ViewModelFactory() { }

        /// <summary>
        /// Instantiate a new view model.
        /// </summary>
        /// <typeparam name="T">View model type</typeparam>
        /// <returns>Instantiated view model</returns>
        public T Create<T>() where T : SharedContext, new()
        {
            var model = new T();
            return model;
        }
    }
}