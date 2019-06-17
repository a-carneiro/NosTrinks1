using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NosTrinks.Domain;
using NosTrinks.Interface.Service;
using NosTrinks.ProcessApi.ViewModels;

namespace NosTrinks.ProcessApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IUserService _userService;
        public ValuesController(IUserService userService)
        {
            _userService = userService;
        }

        // GET api/values
        [HttpGet]
        public IActionResult GetAllActiveUsers()
        {
            try
            {
                var users = _userService.GetAllActiveUsers();
                return base.Ok(UserViewModel.ToViewModels(users));
            }
            catch (Exception ex)
            {
                return base.BadRequest(ex.Message);
            }
        }

        // GET api/values/diponibility
        [HttpGet("diponibility")]
        public IActionResult GetAllDisponibility()
        {
            try
            {
                var users = _userService.UserDisponibilities();
                return base.Ok(users);
            }
            catch (Exception ex)
            {
                return base.BadRequest(ex.Message);
            }
        }

        [HttpGet("getRoles")]
        public IActionResult GetRoles()
        {
            try
            {
                var roles = _userService.GetAllRole();
                return base.Ok(roles);
            }
            catch (Exception ex)
            {
                return base.BadRequest(ex.Message);
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            try
            {
                var user = _userService.GetUserById(id);
                return base.Ok(UserViewModel.ToViewModel(user));
            }
            catch (Exception ex)
            {
                return base.BadRequest(ex.Message);
            }
        }

        // POST api/values
        [HttpPost]
        public IActionResult AddUsers([FromBody] AddUserViewModel userViewModel)
        {
            try
            {
                if (userViewModel == null)
                {
                    throw new Exception("Preencha todos os campos");

                }
                _userService.AddUser(userViewModel.ToUser(), userViewModel.RoleId);

                return base.Ok();
            }
            catch (Exception ex)
            {
                return base.BadRequest(ex);
            }
        }

        // POST api/values
        [HttpPost("managedisponibility")]
        public IActionResult ManageDisponibility([FromBody] AddUnavailable addUnavailable)
        {
            try
            {
                _userService.ManageDisponibilitie(addUnavailable.UserId, addUnavailable.IsAvailable);
                return base.Ok();
            }
            catch (Exception ex)
            {

                return base.BadRequest(ex.Message);
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void PutUser(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                _userService.DeleteUser(id);

                return base.Ok();
            }
            catch (Exception ex)
            {
                return base.BadRequest(ex.Message);
            }
        }
    }
}
