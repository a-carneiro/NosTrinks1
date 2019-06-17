using NosTrinks.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace NosTrinks.Interface.Service
{
    public interface IRoleService
    {
        Role GetRoleById(int Id);
    }
}
