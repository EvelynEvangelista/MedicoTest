using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MedicoApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddPatient()
        {
            ViewData["Message"] = "Add New Patient";

            return View();
        }

        public IActionResult EditPatient()
        {
            ViewData["Message"] = "Edit Patient";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
