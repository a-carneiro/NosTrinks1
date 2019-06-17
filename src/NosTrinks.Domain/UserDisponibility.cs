using System;
using System.Collections.Generic;
using System.Text;

namespace NosTrinks.Domain
{
    public class UserDisponibility
    {

        public int Id { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public bool? IsAvailable { get; set; }
    }
}
