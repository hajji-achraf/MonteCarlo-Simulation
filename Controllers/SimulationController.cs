using Microsoft.AspNetCore.Mvc;
using MonteCarlo_Simulation.Models;

namespace MonteCarlo_Simulation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SimulationController : ControllerBase
    {
        // Endpoint pour générer une loi uniforme
        [HttpGet("loi-uniforme")]
        public IActionResult GetLoiUniforme(double a, double b, int n)
        {
            var resultats = SimulationLois.LoiUniforme(a, b, n);
            return Ok(resultats);
        }

        // Endpoint pour générer une loi exponentielle
        [HttpGet("loi-exponentielle")]
        public IActionResult GetLoiExponentielle(double lambda, int n)
        {
            var resultats = SimulationLois.LoiExponentielle(lambda, n);
            return Ok(resultats);
        }

        // Endpoint pour générer une loi de Cauchy
        [HttpGet("loi-cauchy")]
        public IActionResult GetLoiCauchy(double c, int n)
        {
            var resultats = SimulationLois.LoiCauchy(c, n);
            return Ok(resultats);
        }

        // Endpoint pour générer une loi de Bernoulli
        [HttpGet("loi-bernoulli")]
        public IActionResult GetLoiBernoulli(double p, int n)
        {
            var resultats = SimulationLois.LoiBernoulli(p, n);
            return Ok(resultats);
        }

        // Endpoint pour générer une loi normale N(0, 1)
        [HttpGet("loi-normale")]
        public IActionResult GetLoiNormale(int mu , int sigma , int n)
        {
            var resultats = SimulationLois.LoiNormale( mu,sigma,n);
            return Ok(resultats);
        }


     
    }
}
