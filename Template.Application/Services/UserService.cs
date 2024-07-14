using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Application.Interfaces;
using Template.Application.ViewModels;
using Template.Domain.Entities;
using Template.Domain.Interfaces;

namespace Template.Application.Services
{
    public class UserService: IUserService
    {

        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public List<UserViewModel> Get()
        {
            List<UserViewModel> _userViewModels = new List<UserViewModel>();

            IEnumerable<User> _users = this.userRepository.GetAll();
            
            foreach (var item in _users)
                _userViewModels.Add(new UserViewModel { Id = item.Id, Email = item.Email, Name = item.Name});

            return _userViewModels;
        }

        public bool Post(UserViewModel userViewModel)
        {
            // converte a viewModel para um objeto de entidade a fim de salvar no DB
            User _user = new User
            {
                Id = userViewModel.Id,
                Name = userViewModel.Name,
                Email = userViewModel.Email
                // demais campos são gerados através do ModelBuilderExtentions/ApplyGlobalConfigurations()
            };

            this.userRepository.Create(_user);

            return true;
        }
    }
}
