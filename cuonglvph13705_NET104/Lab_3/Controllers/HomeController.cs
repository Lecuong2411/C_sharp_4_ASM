using Lab_3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Lab_3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public List<Cntt> _cntts;   
        public IActionResult Index()
        {
            _cntts = new List<Cntt>()
            {
                new Cntt(){Name="Thiết Kế đồ họa", Image= "/images/b1.jpg"},
                   new Cntt(){Name="Lập trình máy tính- Thiết bị di động", Image= "/images/b2.jpg"},
                      new Cntt(){Name="Thiết kế wwebsite", Image= "/images/b3.jpg"},
                         new Cntt(){Name="CNTT - Ứng dụng phần mềm", Image= "/images/b4.jpg"},

            };
            ViewData["CNTT"] = _cntts;
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
