using NosTrinks.Context.ContextApi;
using NosTrinks.Domain;
using NosTrinks.Domain.ViewModel;
using NosTrinks.Interface.Repository;
using NosTrinks.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NosTrinks.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleService _roleService;

        private readonly NosTrinksWebApiContext _context;

        public UserService(IUserRepository userRepository, IRoleService roleService, NosTrinksWebApiContext context)
        {
            this._userRepository = userRepository;
            this._roleService = roleService;
            this._context = context;

        }

        public User GetUserById(int userId)
        {
            return _userRepository.GetUserById(userId);
        }

        public ICollection<User> GetAllActiveUsers(int userId)
        {
            return _userRepository.GetAllActiveUsers();
        }

        public void AddUser(User user, int roleId)
        {
            var role = _roleService.GetRoleById(roleId);

            if (role == null)
                throw new Exception("Role não encontrada");

            var oldUser = _userRepository.CheckUSer(user.Email);

            if (oldUser != null)
                throw new Exception("já existe esse usuário");

            _userRepository.AddUser(user);
            _context.SaveChanges();
        }

        public ICollection<User> GetAllActiveUsers()
        {
            return _userRepository.GetAllActiveUsers();
        }

        public void DeleteUser(int id)
        {
            var user = _userRepository.GetUserById(id);
            if (user == null)
                throw new Exception();
            user.IsActive = false;

            _userRepository.DeleteUser(user);

            this._context.SaveChanges();
        }

        public ICollection<UserDispoViewModel> UserDisponibilities()
        {
            var usersDispo = this._userRepository.GetDisponibilitie();

            return usersDispo;
        }

        public UserDisponibility GetDisponibilityById(int userId)
        {
            return this._userRepository.GetDisponibilityById(userId);
        }

        public void ManageDisponibilitie(int userId, bool isAvailable)
        {
            var currentScenary = _userRepository.GetDisponibilityById(userId);

            if (currentScenary == null)
            {
                UserDisponibility userDisponibility = new UserDisponibility
                {
                    IsAvailable = isAvailable,
                    UserId = userId
                };

                _userRepository.CreateDisponibility(userDisponibility);
                _context.SaveChanges();
            }
            else
            {
                currentScenary.IsAvailable = isAvailable;
                _userRepository.UpdateDisponibilitie(currentScenary);
                _context.SaveChanges();
            }

        }

        public void CreateDisponibility(UserDisponibility userDisponibility)
        {
            this._userRepository.CreateDisponibility(userDisponibility);
        }

        public void UpdateDisponibilitie(UserDisponibility userdisp)
        {
            this._userRepository.UpdateDisponibilitie(userdisp);
        }

        public ICollection<Role> GetAllRole()
        {
            return _userRepository.GetAllRole();
        }
    }
}
