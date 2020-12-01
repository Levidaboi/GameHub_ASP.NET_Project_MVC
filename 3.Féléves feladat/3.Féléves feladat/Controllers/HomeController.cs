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
            return View();
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
            u.GameLibrary.Add(g);

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

    }
}
