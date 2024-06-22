using LoginSession.Core.Application.Helpes;
using LoginSession.Core.Application.Interfaces.IRespositories;
using LoginSession.Core.Application.ViewModels.Users;
using LoginSession.Core.Domain.Entities;
using LoginSession.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginSession.Infrastructure.Persistence.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly ApplicationContext _dbContext;

        public UserRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task AddAsync(User entity)
        {
            entity.Password = PasswordEncryptation.ComputeSha256Hash(entity.Password);
            await base.AddAsync(entity);
        }

        public async Task<User> LoginAsync(LoginViewModel loginVm)
        {
            string passwordEncrypy = PasswordEncryptation.ComputeSha256Hash(loginVm.Password);
            User user = await _dbContext.Set<User>()
                .FirstOrDefaultAsync(user => user.UserName == loginVm.UserName && user.Password == passwordEncrypy);
            return user;
        }
    }
}