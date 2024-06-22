using LoginSession.Core.Application.ViewModels.Users;
using LoginSession.Core.Domain.Entities;

namespace LoginSession.Core.Application.Interfaces.IRespositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> LoginAsync(LoginViewModel loginVm);
    }
}
