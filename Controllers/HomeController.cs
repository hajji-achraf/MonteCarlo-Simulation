using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MonteCarlo_Simulation.Models;

namespace MonteCarlo_Simulation.Controllers
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
            return View();
        }

        public IActionResult Documentation()
        {
            return View();
        }

        public IActionResult SimulationDesLois()
        {
            return View();
        }

        public IActionResult BrownianMotion()
        {
            return View();
        }
        public IActionResult GeometricBrownianMotion()
        {
            return View();
        }

        public IActionResult MarchesAléatoires()
        {
            return View();
        }

        public IActionResult MarkovChain()
        {
            return View();
        }

        public IActionResult PricingOptions()
        {
            return View();
        }




        public IActionResult Contact()
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
