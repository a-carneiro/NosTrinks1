using NosTrinks.Domain;
using NosTrinks.Domain.ViewModel;
using System.Collections.Generic;

namespace NosTrinks.Interface.Service
{
    public interface IUserService
    {
        User GetUserById(int userId);
        ICollection<User> GetAllActiveUsers();
        void AddUser(User user, int roleId);
        void DeleteUser(int id);
        ICollection<UserDispoViewModel> UserDisponibilities();
        UserDisponibility GetDisponibilityById(int userId);
        void CreateDisponibility(UserDisponibility userDisponibility);
        void UpdateDisponibilitie(UserDisponibility userdisp);
        void ManageDisponibilitie(int userId, bool isAvailable);
        ICollection<Role> GetAllRole();
    }
}
