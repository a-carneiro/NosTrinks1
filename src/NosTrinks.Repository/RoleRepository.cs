using NosTrinks.Context.ContextApi;
using NosTrinks.Domain;
using NosTrinks.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NosTrinks.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly NosTrinksWebApiContext _context;

        public RoleRepository(NosTrinksWebApiContext context)
        {
            _context = context;
        }

        public Role GetRoleById(int Id)
        {
            return _context.Roles.FirstOrDefault(x => x.Id == Id);
        }
    }
}
