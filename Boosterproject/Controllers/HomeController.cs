using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Boosterproject.Models;
using Microsoft.AspNetCore.Mvc;

namespace Boosterproject.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        public IActionResult Xss() {              
            return View(new XssModel());
        }

        [HttpPost]
        public IActionResult Xss(XssModel viewModel) {
            return View(viewModel);
        }

        public IActionResult Clickjacking(){
            return View();
        }

         [HttpPost]
         public IActionResult Clickjacking(string value){
            return View("ClickjackingClicked");
        }
    }
}
