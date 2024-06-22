using LoginSession.Core.Application.Interfaces.IRespositories;
using LoginSession.Core.Application.Interfaces.IServices;
using LoginSession.Core.Application.ViewModels.Users;
using LoginSession.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LoginSession.Core.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        //login
        public async Task<UserViewModel> Login(LoginViewModel loginVm)
        {
            User user = await _userRepository.LoginAsync(loginVm);

            if(user == null) 
            {
                return null;
            }

            UserViewModel userVm = new();
            userVm.Name = user.Name;
            userVm.LastName = user.LastName;
            userVm.UserName = user.UserName;
            userVm.Password = user.Password;
            userVm.Email = user.Email;
            userVm.Phone = user.Phone;

            return userVm;
        }

        // Implementación del método Add
        public async Task Add(SaveUserViewModel vm)
        {
            User user = new()
            {
                Name = vm.Name,
                LastName = vm.LastName,
                UserName = vm.UserName,
                Password = vm.Password,
                Email = vm.Email,
                Phone = vm.Phone
            };

            await _userRepository.AddAsync(user);
        }

        // Implementación del método Update
        public async Task Update(SaveUserViewModel vm)
        {
            var user = await _userRepository.GetByIdAsync(vm.Id);
            if (user != null)
            {
                user.Name = vm.Name;
                user.LastName = vm.LastName;
                user.UserName = vm.UserName;
                user.Password = vm.Password;
                user.Email = vm.Email;
                user.Phone = vm.Phone;

                await _userRepository.UpdateAsync(user);
            }
        }

        // Implementación del método Delete
        public async Task Delete(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user != null)
            {
                await _userRepository.DeleteAsync(user);
            }
        }

        // Implementación del método GetByIdSaveViewModel
        public async Task<SaveUserViewModel> GetByIdSaveViewModel(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null) return null;

            SaveUserViewModel vm = new()
            {
                Id = user.Id,
                Name = user.Name,
                LastName = user.LastName,
                UserName = user.UserName,
                Password = user.Password,
                Email = user.Email,
                Phone = user.Phone
            };

            return vm;
        }

        // Implementación del método GetAllViewModel
        public async Task<List<UserViewModel>> GetAllViewModel()
        {
            var users = await _userRepository.GetAllAsync();
            return users.Select(user => new UserViewModel
            {
                Id = user.Id,
                Name = user.Name,
                LastName = user.LastName,
                UserName = user.UserName,
                Email = user.Email,
                Phone = user.Phone
            }).ToList();
        }
    }
}