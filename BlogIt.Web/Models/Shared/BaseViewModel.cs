namespace BlogIt.Web.Models.Shared
{
    /// <summary>
    /// View model base class.
    /// </summary>
    public class BaseViewModel
    {
        public SharedContext SharedContext { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public BaseViewModel() { }
    }
}