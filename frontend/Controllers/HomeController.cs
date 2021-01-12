using frontend.Models;
using frontend.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace frontend.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BugSystemClient _bugsSystemClient;

        public HomeController(ILogger<HomeController> logger, BugSystemClient bugsSystemClient)
        {
            _logger = logger;
            _bugsSystemClient = bugsSystemClient;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _bugsSystemClient.GetBugs();
            ViewBag.bugs = result; 
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
