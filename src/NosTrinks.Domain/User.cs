using System;
using System.Collections.Generic;
using System.Text;

namespace NosTrinks.Domain
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public bool IsAdmin { get; set; }

        public bool IsActive { get; set; }

    }
}
