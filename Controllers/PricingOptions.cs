using Microsoft.AspNetCore.Mvc;
using MonteCarlo_Simulation.Models;

namespace MonteCarlo_Simulation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OptionsController : ControllerBase
    {
        [HttpPost("Calculate")]
        public ActionResult<OptionResult> Calculate([FromBody] PricingOptions options)
        {
            try
            {
                // Calcul des prix avec la classe PricingOptions
                options.CalculatePrices();

                // Construction du résultat
                var result = new OptionResult
                {
                    BlackScholesPrice = options.BlackScholesPrice,
                    MonteCarloPrice = options.MonteCarloPrice
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erreur lors du calcul : {ex.Message}");
            }
        }
    }

    // Classe pour le résultat retourné au frontend
    public class OptionResult
    {
        public double BlackScholesPrice { get; set; }
        public double MonteCarloPrice { get; set; }
    }
}