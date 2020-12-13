using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Logic;
using Models;

namespace _3.Féléves_feladat.Controllers
{
    public class HomeController : Controller
    {
        UserLogic userLogic;
        GameLogic gameLogic;
        AchiLogic achiLogic;

        public HomeController(UserLogic userLogic, GameLogic gameLogic, AchiLogic achiLogic)
        {
            this.userLogic = userLogic;
            this.gameLogic = gameLogic;
            this.achiLogic = achiLogic;
        }

        public IActionResult Index()
        {
             return View(gameLogic.SumGameTime());
        }

        public IActionResult Statistics()
        {
            List<Stat> stats = new List<Stat>();
            foreach (var user in userLogic.GetUsers().ToList())
            {
                Stat s = new Stat();
                s.PlayerName = user.Name;
                s.GameCount = userLogic.GetGameCount(user.UserId);
                s.GameTime = userLogic.GetGameTime(user.UserId);
                s.AchiPoints = userLogic.GetAchiPoints(user.UserId);

                stats.Add(s);
            }

            return View(stats);
        }



        public IActionResult SpecificStats()
        {
            Stat2 stat = new Stat2();


            stat.BestGamer = userLogic.GetBestGamer();
            stat.LifelessGamer = userLogic.GetLifelessGamer();
            stat.RichestGamer = userLogic.GetRichestGamer();


            return View(stat);
        }


        public IActionResult GenerateData()
        {
            // u1
            User u = new User() { Name = "Blobbo", Age = 21 };
            u.UserId = Guid.NewGuid().ToString();
            userLogic.AddNewUser(u);

            Game g = new Game() { Name = "Serious Sam 4",Genre = "Shooter", UserId = u.UserId, Rating = 2, GameTime = 30 };
            g.GameId = Guid.NewGuid().ToString();
            gameLogic.AddGame(g);

            Game g9 = new Game() { Name = "League of legends", Genre = "MOBA", UserId = u.UserId, Rating = 1, GameTime = 1400 };
            g9.GameId = Guid.NewGuid().ToString();
            gameLogic.AddGame(g9);

            Achievement a = new Achievement() { Name = "Kitoltad ", achiLevel = AchiLevel.gold, GameId = g.GameId };
            a.AchiId = Guid.NewGuid().ToString();
            achiLogic.AddAchi(a);


            Achievement a5 = new Achievement() { Name = "Saltiest boi in the west" , achiLevel = AchiLevel.gold ,GameId = g.GameId };
            a5.AchiId = Guid.NewGuid().ToString();
            achiLogic.AddAchi(a5);



            //u2

            User u2 = new User() { Name = "LewiTT", Age = 17 };
            u2.UserId = Guid.NewGuid().ToString();
            userLogic.AddNewUser(u2);

            Game g2 = new Game() { Name = "Cyberpunk 2077",Genre = "RPG", UserId = u2.UserId, Rating = 5, GameTime = 150 };
            g2.GameId = Guid.NewGuid().ToString();
            gameLogic.AddGame(g2);

            Game g6 = new Game() { Name = "Csé gó", Genre = "Shooter", UserId = u2.UserId, Rating = 5, GameTime = 5420 };
            g6.GameId = Guid.NewGuid().ToString();
            gameLogic.AddGame(g6);

            Achievement a2 = new Achievement() { Name = "Hit nélkül", achiLevel = AchiLevel.silver, GameId = g2.GameId };
            a2.AchiId = Guid.NewGuid().ToString();
            achiLogic.AddAchi(a2);


            Game g3 = new Game() { Name = "Red Dead Redemption 2",Genre = "Adventure", UserId = u2.UserId, Rating = 5, GameTime = 80 };
            g3.GameId = Guid.NewGuid().ToString();
            gameLogic.AddGame(g3);

            Achievement a3 = new Achievement() { Name = "Semmit Nem csinaltal ", achiLevel = AchiLevel.bronze, GameId = g2.GameId };
            a3.AchiId = Guid.NewGuid().ToString();
            achiLogic.AddAchi(a3);

            Game g12 = new Game() { Name = "Rocket league", Genre = "Racing", UserId = u2.UserId, Rating = 5, GameTime = 850 };
            g12.GameId = Guid.NewGuid().ToString();
            gameLogic.AddGame(g12);



            //u3


            User u3 = new User() { Name = "Pleb", Age = 29 };
            u3.UserId = Guid.NewGuid().ToString();
            userLogic.AddNewUser(u3);

            Game g4 = new Game() { Name = "Csé gó", Genre = "Shooter", UserId = u3.UserId, Rating = 5, GameTime = 3200 };
            g4.GameId = Guid.NewGuid().ToString();
            gameLogic.AddGame(g4);

            Game g11 = new Game() { Name = "Rocket league", Genre = "Racing", UserId = u3.UserId, Rating = 5, GameTime = 950 };
            g11.GameId = Guid.NewGuid().ToString();
            gameLogic.AddGame(g11);

            Game g15 = new Game() { Name = "Tankos gem", Genre = "MMO", UserId = u3.UserId, Rating = 5, GameTime = 2500 };
            g15.GameId = Guid.NewGuid().ToString();
            gameLogic.AddGame(g15);


            //u4 

            User u4 = new User() { Name = "rtk", Age = 21 };
            u4.UserId = Guid.NewGuid().ToString();
            userLogic.AddNewUser(u4);

            Game g5 = new Game() { Name = "Csé gó", Genre = "Shooter", UserId = u4.UserId, Rating = 5, GameTime = 3800 };
            g5.GameId = Guid.NewGuid().ToString();
            gameLogic.AddGame(g5);

            Achievement a4 = new Achievement() { Name = "Global Elite ", achiLevel = AchiLevel.gold, GameId = g5.GameId };
            a4.AchiId = Guid.NewGuid().ToString();
            achiLogic.AddAchi(a4);


            //u5

            User u5 = new User() { Name = "Viperov", Age = 21 };
            u5.UserId = Guid.NewGuid().ToString();
            userLogic.AddNewUser(u5);

            Game g7 = new Game() { Name = "Csé gó", Genre = "Shooter", UserId = u5.UserId, Rating = 5, GameTime = 2300 };
            g7.GameId = Guid.NewGuid().ToString();
            gameLogic.AddGame(g7);

            Game g13 = new Game() { Name = "Dota", Genre = "Moba", UserId = u5.UserId, Rating = 5, GameTime = 3000 };
            g13.GameId = Guid.NewGuid().ToString();
            gameLogic.AddGame(g13);




            //u6
            User u6 = new User() { Name = "xxxnorbi", Age = 21 };
            u6.UserId = Guid.NewGuid().ToString();
            userLogic.AddNewUser(u6);

            Game g8 = new Game() { Name = "Csé gó", Genre = "Shooter", UserId = u6.UserId, Rating = 5, GameTime = 1200 };
            g8.GameId = Guid.NewGuid().ToString();
            gameLogic.AddGame(g8);

            Game g10 = new Game() { Name = "Rocket league", Genre = "Racing", UserId = u6.UserId, Rating = 5, GameTime = 950 };
            g10.GameId = Guid.NewGuid().ToString();
            gameLogic.AddGame(g10);



            //7
            User u7 = new User() { Name = "Rachman", Age = 21 };
            u7.UserId = Guid.NewGuid().ToString();
            userLogic.AddNewUser(u7);

            Game g14 = new Game() { Name = "Csé gó", Genre = "Shooter", UserId = u7.UserId, Rating = 5, GameTime = 1200 };
            g14.GameId = Guid.NewGuid().ToString();
            gameLogic.AddGame(g14);



            return  RedirectToAction(nameof(Index));

        }
        

        //USER


        [HttpGet]
        public IActionResult AddUser()
        {

            return View();
        }

        [HttpPost]
        public IActionResult AddUser(User u)
        {
            u.UserId = Guid.NewGuid().ToString();
            userLogic.AddNewUser(u);
            return RedirectToAction(nameof(ListUsers));
        }


        public IActionResult DeleteUser(string id)
        {
            userLogic.DeleteUser(id);
            return RedirectToAction(nameof(ListUsers));

        }


        public IActionResult ListUsers()
        {
            return View(userLogic.GetUsers()); ;
        }

        public IActionResult EditUser(string id)
        {

            return View(userLogic.GetUser(id));
        }

         [HttpPost]
        public IActionResult EditUser(User u)
        {
            userLogic.UpdateUser(u.UserId,u);


            return View(nameof(ListUsers), userLogic.GetUsers());
        }



        //GAME
        [HttpGet]

        public IActionResult AddGame(string id)
        {
            return View(nameof(AddGame), id);

        }


        [HttpPost]
        public IActionResult AddGame(Game g)
        {
            User u = userLogic.GetUser(g.UserId);
            g.GameId = Guid.NewGuid().ToString();
            gameLogic.AddGame(g);

            return View(nameof(ListGames), u.GameLibrary);
        }





        public IActionResult ListAllGames()
        {
            List<Game> games = gameLogic.GetAllGames().ToList();
            foreach (var game in games)
            {
              game.PlayerName =   userLogic.GetUser(game.UserId).Name;
            }
            return View(nameof(ListAllGames), games);

        }

        public IActionResult ListGames(string Id)
        {
            User u = userLogic.GetUser(Id);

            return View(u.GameLibrary.AsQueryable());



        }


        public IActionResult DeleteGame(string Id)
        {

            
            Game g = gameLogic.GetGame(Id);
            
            gameLogic.DeleteGame(Id);


           return View(nameof(ListGames),userLogic.GetUser(g.UserId).GameLibrary);
        }


        public IActionResult DeleteGameFromAllGames(string Id)
        {


            Game g = gameLogic.GetGame(Id);

            gameLogic.DeleteGame(Id);


            return View(nameof(ListGames), gameLogic.GetAllGames()) ;
        }

        public IActionResult EditGame(string id)
        {

            return View(gameLogic.GetGame(id));
        }




        [HttpPost]
        public IActionResult EditGame(Game g)
        {
            gameLogic.UpdateGame(g.GameId,g);

          
            return View(nameof(ListGames), userLogic.GetUser(g.UserId).GameLibrary);
        }

        //Achievement

        public IActionResult AddAchievement(string Id)
        {
            return View(nameof(AddAchievement),Id);
        }

        [HttpPost]
        public IActionResult AddAchievement(Achievement a)
        {
            Game g = gameLogic.GetGame(a.GameId);
            a.AchiId = Guid.NewGuid().ToString();
            achiLogic.AddAchi(a);


            return View(nameof(ListAchi), g.Achievements);

        }


        public IActionResult ListAchi(string Id)
        {
           
            
            
            return View(nameof(ListAchi), gameLogic.GetGame(Id).Achievements);
        }

        public IActionResult ListAchievements()
        {
             return View(nameof(ListAchi),achiLogic.GetAchievements());
        }


        public IActionResult DeleteAchi(string id)
        {
            Achievement a = achiLogic.GetAchievement(id);
            achiLogic.DeleteAchi(a);
            return View(nameof(ListAchi), gameLogic.GetGame(a.GameId).Achievements);
        }

        public IActionResult EditAchi(string id)
        {

            return View(achiLogic.GetAchievement(id));
        }

        [HttpPost]
        public IActionResult EditAchi(Achievement a)
        {
            achiLogic.UpdateAchi(a.AchiId, a);

            
            return View(nameof(ListAchi), gameLogic.GetGame(a.GameId).Achievements);
        }


        //Statisztika 

        


    }
}
