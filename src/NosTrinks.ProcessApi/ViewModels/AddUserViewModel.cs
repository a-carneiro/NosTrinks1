using NosTrinks.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NosTrinks.ProcessApi.ViewModels
{
    public class AddUserViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsActive { get; set; }

        public int RoleId { get; set; }

        public User ToUser()
        {
            return new User() {
                Name = this.Name,
                Email = this.Email,
                Password = this.Password,
                IsActive = this.IsActive,
                IsAdmin = this.IsAdmin
            };
        }
    }
}
