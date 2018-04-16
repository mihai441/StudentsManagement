using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStudentsManagement.Models;
using Microsoft.AspNetCore.Identity;

namespace WebStudentsManagement.Controllers
{
    public class HomeController : Controller
    {
        SignInManager<ApplicationUser> signInManager;
        public HomeController(
            SignInManager<ApplicationUser> signInManager)
        {
            this.signInManager = signInManager;
        }

        public IActionResult Index()
        {
            IActionResult retView = null;
            if (signInManager.IsSignedIn(User))
            {
                retView = View("Home");
            }
            else
            {
                retView = RedirectToAction("Login", "Account");
            }
            return retView;
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
