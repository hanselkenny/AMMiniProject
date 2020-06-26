using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AMMiniProject.Controllers
{
    public class ValidController : Controller
    {
        public IActionResult Download()
        {
            return View();
        }
    }
}
