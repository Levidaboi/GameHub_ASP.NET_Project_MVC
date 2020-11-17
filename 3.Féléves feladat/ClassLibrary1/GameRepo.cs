using Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic
{
    public class GameLogic
    {
        GameRepo gameRepo;

        public GameLogic (GameRepo gameRepo)
        {
            this.gameRepo = gameRepo;
        }

        public void AddGame(Game game)
        {
            gameRepo.Add(game);

        }

        public void DeleteGame(Game game)
        {
            gameRepo.Delete(game);

        }

        public IQueryable<Game> GetAllTeam()
        {
            return gameRepo.AllItem();
        }

        public Game GetGame(string gameid)
        {
            return gameRepo.Read(gameid);
        }

        public void UpdateTeam(string oldid, Game newitem)
        {
            gameRepo.Update(oldid,newitem);
        }

    }
}
