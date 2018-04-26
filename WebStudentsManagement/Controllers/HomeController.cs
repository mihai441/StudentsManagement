using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStudentsManagement.Models;
using Microsoft.AspNetCore.Identity;
using StudentsManagement.Domain;
using StudentsManagement.Core.Shared;

namespace WebStudentsManagement.Controllers
{
    public class HomeController : Controller
    {
        IBusinessLayer _businessLogic;
        IAuthentication _auth;
        public HomeController(
            IBusinessLayer businessLayer,
            IAuthentication auth)
        {
            _businessLogic = businessLayer;
            _auth = auth;
        }

        public IActionResult Index()
        {
            IActionResult retView = null;
            if (_auth.IsUserSignedIn(User))
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
            return View(new ErrorViewModel { RequestId = System.Diagnostics.Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
