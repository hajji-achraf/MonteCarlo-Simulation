using Microsoft.AspNetCore.Mvc;
using MonteCarlo_Simulation.Models;

namespace MonteCarlo_Simulation.Controllers
{
    public class MarchesAleatoiresController : Controller
    {
        private readonly MarchesAléatoires _marchesAleatoires;

        public MarchesAleatoiresController()
        {
            _marchesAleatoires = new MarchesAléatoires();
        }

        [HttpPost]
        public IActionResult GenerateTrajectory([FromBody] SimulationRequest request)
        {
            var trajectory = _marchesAleatoires.GenerateTrajectory2D(request.Steps);
            return Json(trajectory);
        }
    }

    public class SimulationRequest
    {
        public int Steps { get; set; }
    }
}