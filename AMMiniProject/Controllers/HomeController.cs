using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AMMiniProject.Models;
using Service.Module;

namespace AMMiniProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IAlumniService alumniService;
        public HomeController(ILogger<HomeController> logger, IAlumniService alumniService)
        {
            _logger = logger;
            this.alumniService = alumniService;
        }

        public IActionResult Index()
        {
            IndexViewModel indexViewModel = new IndexViewModel();
            
            return View(indexViewModel);
        }

        [HttpPost]
        public IActionResult Index(IndexViewModel model)
        {
            if(ModelState.IsValid == true)
            {
                //write code here
            }
            
            IndexViewModel indexViewModel = new IndexViewModel();

            return View(model);
        }

        public IActionResult Invalid()
        {
            return View();
        }

        public IActionResult Valid()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
