using NosTrinks.Domain;
using NosTrinks.Domain.ViewModel;
using System.Collections.Generic;

namespace NosTrinks.Interface.Repository
{
    public interface IUserRepository
    {
        User GetUserById(int userId);
        ICollection<User> GetAllActiveUsers();
        User CheckUSer(string email);
        void AddUser(User user);
        void DeleteUser(User user);
        void AddUserRole(UserRole userRole);
        ICollection<UserDispoViewModel> GetDisponibilitie();
        UserDisponibility GetDisponibilityById(int userId);
        void CreateDisponibility(UserDisponibility userDisponibility);
        void UpdateDisponibilitie(UserDisponibility userdisp);

        ICollection<Role> GetAllRole();
    }
}
