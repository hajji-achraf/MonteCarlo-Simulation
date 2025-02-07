using Microsoft.AspNetCore.Mvc;
using MonteCarlo_Simulation.Models;

namespace MonteCarlo_Simulation.Controllers
{
    public class ContactController : Controller
    {
        private readonly IEmailService _emailService;
        private readonly ILogger<ContactController> _logger;

        public ContactController(IEmailService emailService, ILogger<ContactController> logger)
        {
            _emailService = emailService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Send(ContactViewModel model)
        {
            if (!ModelState.IsValid)
                return View("Index", model);

            try
            {
                var emailBody = BuildEmailBody(model);
                var success = await _emailService.SendEmailAsync(
                    "contact@votreapp.com",
                    $"Nouveau message de {model.Name}",
                    emailBody
                );

                if (success)
                {
                    TempData["SuccessMessage"] = "Votre message a été envoyé avec succès!";
                    return RedirectToAction("Index");
                }

                ModelState.AddModelError("", "Une erreur est survenue lors de l'envoi du message.");
                return View("Index", model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erreur lors de l'envoi du message de contact");
                ModelState.AddModelError("", "Une erreur inattendue s'est produite.");
                return View("Index", model);
            }
        }

        private string BuildEmailBody(ContactViewModel model)
        {
            return $"Nom: {model.Name}\nEmail: {model.Email}\nMessage: {model.Message}";
        }
    }
}
