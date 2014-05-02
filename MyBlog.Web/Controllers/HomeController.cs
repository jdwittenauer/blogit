using System.Web.Mvc;
using MyBlog.Domain.Interfaces;
using MyBlog.Domain.Entities;

namespace MyBlog.Web.Controllers
{
    /// <summary>
    /// Home controller.
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Index view.
        /// </summary>
        public ActionResult Index()
        {
            if (TempData.ContainsKey("authorID"))
            {
                ViewBag.AuthorID = TempData["authorID"];
                ViewBag.AuthorName = TempData["authorName"];
            }
            else
            {
                ViewBag.AuthorID = string.Empty;
                ViewBag.AuthorName = string.Empty;
            }

            return View();
        }

        /// <summary>
        /// Login view.
        /// </summary>
        public ActionResult Login(string authorName)
        {
            if (authorName != null && authorName.Length > 0)
            {
                var repository = DependencyResolver.Current.GetService<IAuthorRepository>();
                var author = repository.GetByName(authorName);

                if (author == null)
                {
                    author = new Author();
                    author.Name = authorName;
                    author.Age = 0;
                    author.City = "Unknown";
                    author.State = "Unknown";

                    author = repository.Insert(author);
                }

                TempData["authorID"] = author.ID;
                TempData["authorName"] = author.Name;
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        /// <summary>
        /// Cover view.
        /// </summary>
        public ActionResult Cover()
        {
            return View();
        }

        /// <summary>
        /// Theme view.
        /// </summary>
        public ActionResult Theme()
        {
            return View();
        }

        /// <summary>
        /// Jumbotron view.
        /// </summary>
        public ActionResult Jumbotron()
        {
            return View();
        }

        /// <summary>
        /// Dashboard view.
        /// </summary>
        public ActionResult Dashboard()
        {
            return View();
        }
    }
}