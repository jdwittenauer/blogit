﻿using System.Web.Mvc;
using BlogIt.Domain.Interfaces;
using BlogIt.Domain.Entities;
using BlogIt.Web.Controllers.Shared;
using BlogIt.Web.Models.Shared;

namespace BlogIt.Web.Controllers
{
    /// <summary>
    /// Home controller.
    /// </summary>
    public class HomeController : BaseController
    {
        /// <summary>
        /// Cover view.
        /// </summary>
        public ViewResult Cover()
        {
            return View();
        }

        /// <summary>
        /// Index view.
        /// </summary>
        public ViewResult Index()
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

            return View(new BaseViewModel());
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

            return View(new BaseViewModel());
        }

        /// <summary>
        /// Chat view.
        /// </summary>
        public ViewResult Chat()
        {
            return View(new BaseViewModel());
        }

        /// <summary>
        /// Theme view.
        /// </summary>
        public ViewResult Theme()
        {
            return View(new BaseViewModel());
        }

        /// <summary>
        /// Grid view.
        /// </summary>
        public ViewResult Grid()
        {
            return View(new BaseViewModel());
        }

        /// <summary>
        /// Side nav view.
        /// </summary>
        public ViewResult SideNav()
        {
            return View(new BaseViewModel());
        }

        /// <summary>
        /// Reactive extensions view.
        /// </summary>
        public ViewResult Reactive()
        {
            return View(new BaseViewModel());
        }

        /// <summary>
        /// WinJS view.
        /// </summary>
        public ViewResult WinJS()
        {
            return View(new BaseViewModel());
        }

        /// <summary>
        /// D3 view.
        /// </summary>
        public ViewResult D3()
        {
            return View(new BaseViewModel());
        }

        /// <summary>
        /// Custom view.
        /// </summary>
        public ViewResult Custom()
        {
            return View(new BaseViewModel());
        }

        /// <summary>
        /// Glass view.
        /// </summary>
        public ViewResult Glass()
        {
            return View();
        }

        /// <summary>
        /// Shape view.
        /// </summary>
        public ViewResult Shape()
        {
            return View();
        }
    }
}