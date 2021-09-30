using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetFilRougeGroupeVert_MVC.Controllers
{
    public class SignController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
