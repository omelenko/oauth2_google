using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using oauth2_google.Models;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace oauth2_google.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IStringLocalizer<HomeController> _localizer;

        public HomeController(ILogger<HomeController> logger, IStringLocalizer<HomeController> localizer)
        {
            _logger = logger;
            _localizer = localizer;
        }

        public IActionResult Index()
        {
            ViewData["Greeting"] = _localizer["Greeting"];
            ViewData["Greeting1"] = _localizer["Greeting1"];
            ViewData["Greeting2"] = _localizer["Greeting2"];
            ViewData["Home"] = _localizer["Home"];
            ViewData["Login"] = _localizer["Login"];
            ViewData["Register"] = _localizer["Register"];
            ViewData["Privacy"] = _localizer["Privacy"];
            ViewData["Privacy1"] = _localizer["Privacy1"];
            ViewData["Hello"] = _localizer["Hello"];
            ViewData["Logout"] = _localizer["Logout"];
            ViewData["Privacy2"] = _localizer["Privacy2"];
            /*ViewData[""] = _localizer[""];
            ViewData[""] = _localizer[""];
            ViewData[""] = _localizer[""];*/
            return View();
        }

        public IActionResult Privacy()
        {
            ViewData["Greeting"] = _localizer["Greeting"];
            ViewData["Greeting1"] = _localizer["Greeting1"];
            ViewData["Greeting2"] = _localizer["Greeting2"];
            ViewData["Home"] = _localizer["Home"];
            ViewData["Login"] = _localizer["Login"];
            ViewData["Register"] = _localizer["Register"];
            ViewData["Privacy"] = _localizer["Privacy"];
            ViewData["Privacy1"] = _localizer["Privacy1"];
            ViewData["Hello"] = _localizer["Hello"];
            ViewData["Logout"] = _localizer["Logout"];
            ViewData["Privacy2"] = _localizer["Privacy2"];
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
