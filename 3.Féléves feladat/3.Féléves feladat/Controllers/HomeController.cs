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

        [HttpGet]
        public IActionResult AddUser()
        {

            return View();
        }

        [HttpPost]
        public IActionResult AddUser(User u)
        {
            u.Id = Guid.NewGuid().ToString();
            userLogic.AddNewUser(u);
            return RedirectToAction(nameof(List));
        }

        public IActionResult List()
        {
            return View(userLogic.GetUsers());
        }

    }
}
