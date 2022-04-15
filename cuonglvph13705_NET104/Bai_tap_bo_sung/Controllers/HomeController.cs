using Bai_tap_bo_sung.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Bai_tap_bo_sung.Models;
using Newtonsoft.Json;

namespace Bai_tap_bo_sung.Controllers
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
            List<SinhVien> sv = JsonConvert.DeserializeObject<List<SinhVien>>(System.IO.File.ReadAllText(@"C:\HOCFPT\KI_5\NET104\cuonglvph13705_NET104\Bai_tap_bo_sung\data.json"));
            ViewData["SV"] = sv;
            return View();
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
