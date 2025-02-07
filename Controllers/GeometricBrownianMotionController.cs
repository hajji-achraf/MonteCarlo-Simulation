using Microsoft.AspNetCore.Mvc;
using MonteCarlo_Simulation.Models;

namespace MonteCarlo_Simulation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeometricBrownianMotionController : Controller
    {
        [HttpGet("Simuler")]
        public IActionResult Simuler(
            [FromQuery] double drift,
            [FromQuery] double volatility,
            [FromQuery] int simulations = 10,
            [FromQuery] int steps = 100,
            [FromQuery] double deltaT = 1,
            [FromQuery] double initialPrice = 1)
        {
            // Validation des paramètres
            if (volatility < 0 || simulations <= 0 || steps <= 0 || deltaT <= 0)
            {
                return BadRequest("Paramètres invalides");
            }

            var brownianMotion = new GeometricBrownianMotion(deltaT, drift, Math.Abs(volatility));
            var trajectories = brownianMotion.SimulateMultiplePaths(initialPrice, steps, simulations);

            return Ok(trajectories);
        }
    }
}