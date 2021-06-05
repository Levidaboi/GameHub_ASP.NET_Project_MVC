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
    [Route("Edit")]
    public class EditController : ControllerBase
    {
        UserLogic userLogic;
        GameLogic gameLogic;
        AchiLogic achiLogic;
        public EditController(UserLogic ulogic, GameLogic glogic, AchiLogic alogic)
        {
            this.userLogic = ulogic;
            this.gameLogic = glogic;
            this.achiLogic = alogic;
        }


        [HttpGet]
        public void FillDb()
        {
            User u = new User() { Name = "Blobbo", Age = 21 };

            userLogic.AddNewUser(u);

            Game g = new Game() { Name = "Serious Sam 4", Genre = "Shooter", UserId = u.UserId, Rating = 2, GameTime = 30 };

            gameLogic.AddGame(g);

            Game g9 = new Game() { Name = "League of legends", Genre = "MOBA", UserId = u.UserId, Rating = 1, GameTime = 1400 };

            gameLogic.AddGame(g9);

            Achievement a = new Achievement() { Name = "Kitoltad", achiLevel = AchiLevel.gold, GameId = g.GameId };

            achiLogic.AddAchi(a);


            Achievement a5 = new Achievement() { Name = "Saltiest boi in the west", achiLevel = AchiLevel.gold, GameId = g.GameId };

            achiLogic.AddAchi(a5);



            //u2

            User u2 = new User() { Name = "LewiTT", Age = 17 };

            userLogic.AddNewUser(u2);

            Game g2 = new Game() { Name = "Cyberpunk 2077", Genre = "RPG", UserId = u2.UserId, Rating = 5, GameTime = 150 };

            gameLogic.AddGame(g2);

            Game g6 = new Game() { Name = "Csé gó", Genre = "Shooter", UserId = u2.UserId, Rating = 5, GameTime = 5420 };

            gameLogic.AddGame(g6);

            Achievement a2 = new Achievement() { Name = "Hit nélkül", achiLevel = AchiLevel.silver, GameId = g2.GameId };

            achiLogic.AddAchi(a2);


            Game g3 = new Game() { Name = "Red Dead Redemption 2", Genre = "Adventure", UserId = u2.UserId, Rating = 5, GameTime = 80 };

            gameLogic.AddGame(g3);

            Achievement a3 = new Achievement() { Name = "Semmit Nem csinaltal", achiLevel = AchiLevel.bronze, GameId = g2.GameId };

            achiLogic.AddAchi(a3);

            Game g12 = new Game() { Name = "Rocket league", Genre = "Racing", UserId = u2.UserId, Rating = 5, GameTime = 850 };

            gameLogic.AddGame(g12);



            //u3


            User u3 = new User() { Name = "Pleb", Age = 29 };

            userLogic.AddNewUser(u3);

            Game g4 = new Game() { Name = "Csé gó", Genre = "Shooter", UserId = u3.UserId, Rating = 5, GameTime = 3200 };

            gameLogic.AddGame(g4);

            Game g11 = new Game() { Name = "Rocket league", Genre = "Racing", UserId = u3.UserId, Rating = 5, GameTime = 950 };

            gameLogic.AddGame(g11);

            Game g15 = new Game() { Name = "Tankos gem", Genre = "MMO", UserId = u3.UserId, Rating = 5, GameTime = 2500 };

            gameLogic.AddGame(g15);


            //u4 

            User u4 = new User() { Name = "rtk", Age = 21 };

            userLogic.AddNewUser(u4);

            Game g5 = new Game() { Name = "Csé gó", Genre = "Shooter", UserId = u4.UserId, Rating = 5, GameTime = 3800 };

            gameLogic.AddGame(g5);

            Achievement a4 = new Achievement() { Name = "Global Elite ", achiLevel = AchiLevel.gold, GameId = g5.GameId };

            achiLogic.AddAchi(a4);


            //u5

            User u5 = new User() { Name = "Viperov", Age = 21 };

            userLogic.AddNewUser(u5);

            Game g7 = new Game() { Name = "Csé gó", Genre = "Shooter", UserId = u5.UserId, Rating = 5, GameTime = 2300 };

            gameLogic.AddGame(g7);

            Game g13 = new Game() { Name = "Dota", Genre = "Moba", UserId = u5.UserId, Rating = 5, GameTime = 3000 };

            gameLogic.AddGame(g13);




            //u6
            User u6 = new User() { Name = "xxxnorbi", Age = 21 };

            userLogic.AddNewUser(u6);

            Game g8 = new Game() { Name = "Csé gó", Genre = "Shooter", UserId = u6.UserId, Rating = 5, GameTime = 1200 };

            gameLogic.AddGame(g8);

            Game g10 = new Game() { Name = "Rocket league", Genre = "Racing", UserId = u6.UserId, Rating = 5, GameTime = 950 };

            gameLogic.AddGame(g10);



            //7
            User u7 = new User() { Name = "Rachman", Age = 21 };

            userLogic.AddNewUser(u7);

            Game g14 = new Game() { Name = "Csé gó", Genre = "Shooter", UserId = u7.UserId, Rating = 5, GameTime = 1200 };

            gameLogic.AddGame(g14);

        }
    }
}
