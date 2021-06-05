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
    [Route("Game")]
    public class GameController
    {
        GameLogic logic;

        public GameController(GameLogic logic)
        {
            this.logic = logic;
        }

       


        [HttpDelete("{uid}")]
        public void DeleteGame(string uid)
        {
            logic.DeleteGame(uid);
           
        }

        [HttpGet("{uid}")]
        public Game GetGame(string uid)
        {
            return logic.GetGame(uid);
        }

        [HttpGet]
        public IEnumerable<Game> GetGames(string uid)
        {
            return logic.GetAllGames();
        }


        [HttpPost]
        public void AddGame([FromBody] Game item)
        {
            item.GameId = Guid.NewGuid().ToString();
            logic.AddGame(item);
        }

        [HttpPut("{oldid}")]
        public void UpdateGame(string uid, [FromBody] Game item)
        {
            
            logic.UpdateGame(uid, item);
        }

    }
}
