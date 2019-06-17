using NosTrinks.Domain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace NosTrinks.ProcessApi.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsActive { get; set; }

        public static UserViewModel ToViewModel(User user)
        {
            return new UserViewModel
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                IsActive = user.IsActive,
                IsAdmin = user.IsAdmin
            };
        }

        public static ICollection<UserViewModel> ToViewModels(ICollection<User> users)
        {
            var usersViewModels = new List<UserViewModel>();

            foreach (var user in users)
            {
                usersViewModels.Add(
                    new UserViewModel
                    {
                        Id = user.Id,
                        Name = user.Name,
                        Email = user.Email,
                        IsActive = user.IsActive,
                        IsAdmin = user.IsAdmin
                    }
                );
            }
            return usersViewModels;
        }
    }
}
