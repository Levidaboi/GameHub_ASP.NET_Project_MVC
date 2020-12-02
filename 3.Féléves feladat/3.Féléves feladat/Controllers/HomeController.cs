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

        public IActionResult GenerateData()
        {
            User u = new User() { Name = "Róland", Age = 21 };
            u.UserId = Guid.NewGuid().ToString();
            userLogic.AddNewUser(u);

            Game g = new Game() { Name = "Serious Sam", UserId = u.UserId, Rating = 2, GameTime = 30 };
            g.GameId = Guid.NewGuid().ToString();
            gameLogic.AddGame(g);

            Achievement a = new Achievement() { Name = "Kitoltad " , achiLevel = AchiLevel.gold ,GameId = g.GameId };
            a.AchiId = Guid.NewGuid().ToString();
            achiLogic.AddAchi(a);


            User u2 = new User() { Name = "Levike", Age = 17 };
            u2.UserId = Guid.NewGuid().ToString();
            userLogic.AddNewUser(u2);

            Game g2 = new Game() { Name = "Cyberpunk 2077", UserId = u2.UserId, Rating = 5, GameTime = 150 };
            g2.GameId = Guid.NewGuid().ToString();
            gameLogic.AddGame(g2);

            Achievement a2 = new Achievement() { Name = "Hit nélkül", achiLevel = AchiLevel.silver, GameId = g2.GameId };
            a2.AchiId = Guid.NewGuid().ToString();
            achiLogic.AddAchi(a2);


            Game g3 = new Game() { Name = "Red Dead Redemption 2", UserId = u2.UserId, Rating = 5, GameTime = 80 };
            g3.GameId = Guid.NewGuid().ToString();
            gameLogic.AddGame(g3);

            Achievement a3 = new Achievement() { Name = "Semmit Nem csinaltal ", achiLevel = AchiLevel.bronze, GameId = g2.GameId };
            a3.AchiId = Guid.NewGuid().ToString();
            achiLogic.AddAchi(a3);

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

            return View(nameof(ListAllGames), gameLogic.GetAllGames());

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

        public IActionResult Statistics()
        {



            return View();
        }



    }
}
