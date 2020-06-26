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
            indexViewModel.alumniDTO = alumniService.GetAlumnis();
            indexViewModel.alumniAja = alumniService.GetAlumniById("2220174759");
            return View(indexViewModel);
        }

        [HttpPost]
        public IActionResult Index(IndexViewModel model)
        {
            if(ModelState.IsValid == true)
            {
                var externalSystemId = alumniService.GetAlumniById(model.ExternalSystemID);
                bool flage = true;
               
                if (externalSystemId.AdminData == null)
                {
                    return RedirectToAction("Invalid");
                }
                else
                {
                    string TanggalLahirDB = externalSystemId.AdminData.TanggalLahir.ToString("dd-MM-yyyy");
                    string TanggalLahirModel = model.Tgl_Lahir.GetValueOrDefault().ToString("dd-MM-yyyy");
                    string TanggalLulusDB = externalSystemId.AdminData.TanggalLulus.ToString("dd-MM-yyyy");
                    string TanggalLulusModel = model.Tgl_Lulus.GetValueOrDefault().ToString("dd-MM-yyyy");
                    if (!externalSystemId.AdminData.NoIjazah.Equals(model.NoIjazah))
                    {
                        flage = false;
                    }
                    if (!TanggalLahirDB.Equals(TanggalLahirModel))
                    {
                        flage = false;
                    }
                    if (!TanggalLulusDB.Equals(TanggalLulusModel))
                    {
                        flage = false;
                    }
                    if (flage)
                    {
                        return RedirectToAction("Valid");
                    }
                }
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
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
