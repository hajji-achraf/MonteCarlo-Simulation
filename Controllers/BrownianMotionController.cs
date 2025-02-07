using Microsoft.AspNetCore.Mvc;
using MonteCarlo_Simulation.Models;

namespace MonteCarlo_Simulation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrownianMotionController : ControllerBase
    {
        // Méthode GET pour la simulation du mouvement brownien
        [HttpGet("Simuler")]
        public IActionResult Simuler(double drift, double volatility, int simulations, int steps, double deltaT)
        {
            // Création de l'objet BrownianMotion avec les paramètres reçus
            var brownianMotion = new BrownianMotion(deltaT, drift, volatility);

            // Génération des trajectoires de Brownian motion
            var trajectories = brownianMotion.GenerateMultipleTrajectories(simulations, steps);

            // Retourner les trajectoires sous forme de JSON
            return Ok(trajectories);
        }

    }
}
