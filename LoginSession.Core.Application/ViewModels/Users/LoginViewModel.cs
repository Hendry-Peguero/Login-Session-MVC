using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginSession.Core.Application.ViewModels.Users
{
    public class LoginViewModel
    {

        [Required(ErrorMessage = "Debe de colocar el nombre de usuario")]
        [DataType(DataType.Text)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Debe de colocar una contraseña")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
