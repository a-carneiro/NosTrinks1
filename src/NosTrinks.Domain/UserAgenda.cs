using System;
using System.Collections.Generic;
using System.Text;

namespace NosTrinks.Domain
{
    public class UserAgenda
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public int ServiceId { get; set; }
        public Service Service { get; set; }

    }
}
