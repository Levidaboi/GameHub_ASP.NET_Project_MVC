using Logic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiApp.Controllers
{
    [Authorize(Roles = "Customer,Admin")]
    [ApiController]
    [Route("User")]
    public class UserController : ControllerBase
    {
        UserLogic logic;

        public UserController(UserLogic logic)
        {
            this.logic = logic;
        }

        [HttpDelete("{uid}")]
        public void DeleteUser(string uid)
        {
            logic.DeleteUser(uid);

        }

        [HttpGet("{uid}")]
        public User GetUser(string uid)
        {
            return logic.GetUser(uid);
        }

        [HttpGet]
        public IEnumerable<User> GetUsers(string uid)
        {
            return logic.GetUsers();
        }


        [HttpPost]
        public void AddUser([FromBody] User item)
        {
            logic.AddNewUser(item);
        }

        [HttpPut("{uid}")]
        public IActionResult UpdateUser(string uid ,[FromBody] User item)
        {

            try
            {
                logic.UpdateUser(uid, item);
                return Ok();
            }
            catch (Exception e )
            {

                return StatusCode(400,$"Bad Request error : {e}");
            }
              
                
          
        }

    }
}
