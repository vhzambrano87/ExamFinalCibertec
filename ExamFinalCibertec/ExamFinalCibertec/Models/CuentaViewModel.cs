using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ExamFinalCibertec.Models
{
    public class EliminarViewModel
    {
        [Display(Name = "Nombre de Usuario")]
        public string NombreUsuario { get; set; }
    }
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [Display(Name = "Recuerdame?")]
        public bool Recuerdame { get; set; }
    }

    public class RegistrarViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "La {0} debe ser almenos de {2} caracteres de longitud.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar contraseña")]
        [Compare("Password", ErrorMessage = "La contraseña y la confirmación de la contraseña no son iguales.")]
        public string ConfirmaPassword { get; set; }
    }

    public class ReiniciarPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "La {0} debe ser almenos de {2} caracteres de longitud.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirma contraseña")]
        [Compare("Password", ErrorMessage = "La contraseña y la confirmación de la contraseña no son iguales.")]
        public string ConfirmPassword { get; set; }

        public string Codigo { get; set; }
    }

    public class RecuperarPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
