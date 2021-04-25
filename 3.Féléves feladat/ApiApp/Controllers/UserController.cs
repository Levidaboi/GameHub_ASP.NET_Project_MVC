using Logic;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiApp.Controllers
{
    [ApiController]
    [Route("{controller}")]
    public class UserController
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

        [HttpGet()]
        public IEnumerable<User> GetUsers(string uid)
        {
            return logic.GetUsers();
        }

        
        [HttpPost()]
        public void AddUser([FromBody] User item)
        {
            logic.AddNewUser(item);
        }

        [HttpPut("{oldid}")]
        public void UpdateUser(string uid ,[FromBody] User item)
        {
            logic.UpdateUser(uid , item);
        }

    }
}
