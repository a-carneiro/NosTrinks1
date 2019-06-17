using NosTrinks.Context.ContextApi;
using NosTrinks.Domain;
using NosTrinks.Interface.Repository;
using NosTrinks.Interface.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace NosTrinks.Service
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly NosTrinksWebApiContext _context;
        public RoleService(IRoleRepository roleRepository, NosTrinksWebApiContext context)
        {
            this._roleRepository = roleRepository;
            this._context = context;
        }

        public Role GetRoleById(int Id)
        {
            if (Id == 0)
                throw new Exception("O Id da role não pode ser zero");

            return _roleRepository.GetRoleById(Id);
        }
    }
}
