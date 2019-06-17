using NosTrinks.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace NosTrinks.Interface.Repository
{
    public interface IRoleRepository
    {
        Role GetRoleById(int Id);
    }
}
