using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginSession.Core.Application.ViewModels.Users
{
    public class SaveUserViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe colocar un nombre")]
        [DataType(DataType.Text)]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Debe colocar un apellido")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Debe de colocar el nombre de usuario")]
        [DataType(DataType.Text)]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "Debe de colocar una contraseña")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Compare(nameof(Password), ErrorMessage = "Las contraseña deben coincidir")]
        [Required(ErrorMessage = "Debe de confirmar la contraseña")]
        [DataType(DataType.Password)]
        public string? ConfirnPassword { get; set; }

        [Required(ErrorMessage = "Debe de colocar un correo electrónico")]
        [EmailAddress(ErrorMessage = "Debe de colocar un correo electrónico válido")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Debe de colocar un número de teléfono")]
        public double Phone { get; set; }
    }
}
