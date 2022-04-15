using Lab3_4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace Lab3_4.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
      
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {

            List<sinhviens> sv = JsonConvert.DeserializeObject<List<sinhviens>>(System.IO.File.ReadAllText(@"C:\HOCFPT\KI_5\NET104\cuonglvph13705_NET104\Lab3_4\Data.json"));
            nhieusinhvien nhieusinhvien = new nhieusinhvien(sv);
            //ViewBag.nhieusinhvien = nhieusinhvien;
            //ViewData["NSV"]=nhieusinhvien;
            return View(nhieusinhvien);
        }

        public IActionResult Privacy()
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
