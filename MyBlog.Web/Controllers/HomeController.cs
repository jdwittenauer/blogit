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
            if (TempData.ContainsKey("userID"))
            {
                ViewBag.UserID = TempData["userID"];
                ViewBag.UserName = TempData["userName"];
            }
            else
            {
                ViewBag.UserID = string.Empty;
                ViewBag.UserName = string.Empty;
            }

            return View();
        }

        /// <summary>
        /// Login view.
        /// </summary>
        public ActionResult Login(string userName)
        {
            if (userName != null && userName.Length > 0)
            {
                var repository = DependencyResolver.Current.GetService<IAuthorRepository>();
                var author = repository.GetByName(userName);

                if (author == null)
                {
                    author = new Author();
                    author.Name = userName;
                    author.Age = 0;
                    author.City = "Unknown";
                    author.State = "Unknown";

                    author = repository.Insert(author);
                }

                TempData["userID"] = author.ID;
                TempData["userName"] = author.Name;

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