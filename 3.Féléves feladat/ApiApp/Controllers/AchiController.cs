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
    [Route("Achi")]
    public class AchiController
    {
        AchiLogic logic;

        public AchiController(AchiLogic logic)
        {
            this.logic = logic;
        }

        [HttpDelete("{uid}")]
        public void DeleteAchi(string uid)
        {
            logic.DeleteAchi(uid);
        }

        [HttpGet("{uid}")]
        public Achievement GetAchievement(string uid)
        {
            return logic.GetAchievement(uid);
        }

        [HttpGet]
        public IEnumerable<Achievement> GetAchievements(string uid)
        {
            return logic.GetAchievements();
        }



        [HttpPost()]
        public void AddAchievement([FromBody] Achievement item)
        {
            item.AchiId = Guid.NewGuid().ToString();
            logic.AddAchi(item);
        }

        [HttpPut("{uid}")]
        public void UpdateAchievement(string uid, [FromBody] Achievement item)
        {
            logic.UpdateAchi(uid, item);
        }

    }
}
