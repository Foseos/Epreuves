using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

namespace Cybersécu.Models
{
    public class LoginModel
    {

        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Adresse email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Le {0} doit contenir au moins {2} caractères.", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Display(Name = "Mot de passe")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmez le mot de passe")]
        [Compare("Password", ErrorMessage = "Le mot de passe et la confirmation ne correspondent pas.")]
        public string ConfirmPassword { get; set; }


        [Display(Name = "J'accepte les conditions d'utilisation")]
        public bool TermsAndConditions { get; set; }

    }

}
