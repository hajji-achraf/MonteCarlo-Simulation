using System.ComponentModel.DataAnnotations;

namespace MonteCarlo_Simulation.Models
{
    public class ContactViewModel
    {
        [Required(ErrorMessage = "Le nom est requis")]
        [Display(Name = "Nom complet")]
        public string Name { get; set; }

        [Required(ErrorMessage = "L'email est requis")]
        [EmailAddress(ErrorMessage = "Format d'email invalide")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Le message est requis")]
        [MinLength(10, ErrorMessage = "Le message doit contenir au moins 10 caractères")]
        [Display(Name = "Message")]
        public string Message { get; set; }
    }
}
