using NosTrinks.Context.ContextApi;
using NosTrinks.Domain;
using NosTrinks.Domain.ViewModel;
using NosTrinks.Interface.Repository;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace NosTrinks.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly NosTrinksWebApiContext _context;

        public UserRepository(NosTrinksWebApiContext context)
        {
            _context = context;

        }

        public User GetUserById(int userId)
        {
            return this._context.Users.FirstOrDefault(x => x.Id == userId);
        }

        public ICollection<User> GetAllActiveUsers()
        {
            return this._context.Users.Where(x => x.IsActive).ToList();
        }

        public User CheckUSer(string email)
        {
            return this._context.Users.FirstOrDefault(x => x.IsActive && x.Email.Equals(email));
        }

        public void AddUser(User user)
        {
            this._context.Users.Add(user);
        }

        public void DeleteUser(User user)
        {
            this._context.Users.Update(user);
        }

        public void AddUserRole(UserRole userRole)
        {
            this._context.UserRoles.Add(userRole);
        }

        public UserDisponibility GetDisponibilityById(int userId)
        {
            return this._context.UserDisponibilities.FirstOrDefault(x => x.UserId == userId);
        }

        public void CreateDisponibility(UserDisponibility userDisponibility)
        {
            this._context.UserDisponibilities.Add(userDisponibility);
        }

        public void UpdateDisponibilitie(UserDisponibility userdisp)
        {
            this._context.UserDisponibilities.Update(userdisp);
        }


        public ICollection<UserDispoViewModel> GetDisponibilitie()
        {
            List<UserDispoViewModel> userDisponibilityList = new List<UserDispoViewModel>();

            var teste = from u in _context.Users
                        join ud in _context.UserDisponibilities on u.Id equals ud.UserId into set
                        from disp in set.DefaultIfEmpty()
                        where u.IsAdmin == false && u.IsActive == true
                        select new
                        {
                            UserId = u.Id,
                            Name = u.Name,
                            IsAvailable = disp.IsAvailable
                        };

            foreach (var item in teste)
            {
                userDisponibilityList.Add(new UserDispoViewModel
                {
                    UserId = item.UserId,
                    IsAvailable = item.IsAvailable == null ? true : item.IsAvailable,
                    Name = item.Name
                });
            }

            return userDisponibilityList;
        }

        public ICollection<Role> GetAllRole()
        {
            return this._context.Roles.ToList();
        }
    }
}
