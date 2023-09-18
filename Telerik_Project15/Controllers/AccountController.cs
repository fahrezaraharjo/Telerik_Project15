using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Telerik_Project15.Models;

namespace Telerik_Project15.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]


        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Check user credentials and perform authentication here
                bool isAuthenticated = AuthenticateUser(model.Username, model.Password);

                if (isAuthenticated)
                {
                    // Redirect to the home page after successful login
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username or password.");
                }
            }

            // If authentication fails or ModelState is invalid, return the login view
            return View("Index");
        }

        private bool AuthenticateUser(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}