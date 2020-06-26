using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AMMiniProject.Models;
using Service.Module;
using Model.Subdomains;
using Model.DTO;
using Microsoft.AspNetCore.Mvc.ModelBinding;

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

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Index(IndexViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        return RedirectToAction("index");
        //    }
        //    return View(model);
        //}


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        //buat dptin idnya
        //public async Task<IActionResult> Verify(string? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var compare = alumniService.GetAlumnis().Equals(id);
        //    if (compare == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(compare);
        //}


        //buat ngeverifikasi
        //[HttpPost, ActionName("Verify")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Verify(string id, [Bind("ExternalSystemId")] Model.DTO.AlumniDTO alumniDTO)
        //{
        //    string externalSystemId = alumniDTO.ExternalSystemId;
        //    if (id != externalSystemId)
        //    {
        //        Console.WriteLine("invalid");
        //        return NotFound();
        //    }
        //    else
        //    {
        //        externalSystemId = id;
        //        Console.WriteLine("hello");
        //    }
        //    return View();
        //}

        [HttpPost, ActionName("Verify")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Verify(IndexViewModel model, Model.DTO.AlumniDTO alumniDTO)
        {
            var externalSystemId = alumniService.GetAlumniById(model.ExternalSystemId);
            bool flage = true;
            string TanggalLahirDB = externalSystemId.AdminData.TanggalLahir.ToString("dd-MM-yyyy");
            string TanggalLahirModel = model.TanggalLhr.ToString("dd-MM-yyyy");
            string TanggalLulusDB = externalSystemId.AdminData.TanggalLulus.ToString("dd-MM-yyyy");
            string TanggalLulusModel = model.TanggalLls.ToString("dd-MM-yyyy");
            if (externalSystemId.AdminData == null)
            {
                Console.WriteLine("invalid");
                return NotFound();
            }
            else
            {
                Console.WriteLine("hello");
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
                    return RedirectToAction("Index");
                }
                //if (ModelState.IsValid)
                //{
                //return RedirectToAction("index");
                //}
            }
            return View("Index");
        }
    }
}
