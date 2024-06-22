using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginSession.Core.Application.ViewModels.Users
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public double Phone { get; set; }
    }
}
