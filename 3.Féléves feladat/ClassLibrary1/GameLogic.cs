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
        IRepo<Game> gameRepo;
        
        
        public GameLogic (IRepo<Game> gameRepo)
        {
            this.gameRepo = gameRepo;
        }

        public void AddGame(Game game)
        {
            gameRepo.Add(game);
            gameRepo.Save();
        }

        public void DeleteGame(string id)
        {
            Game g = GetGame(id);
            gameRepo.Delete(g);

        }

        public IQueryable<Game> GetAllGames()
        {
            return gameRepo.AllItem();
        }
       

        public Game GetGame(string gameid)
        {
            return gameRepo.Read(gameid);
        }

        public void UpdateGame(string oldid, Game newitem)
        {
            gameRepo.Update(oldid,newitem);
        }

        public int SumGameTime()
        {
            List<Game> games = gameRepo.AllItem().ToList();
            int gameTimeSum = (from x in games
                        select x.GameTime).Sum();
           
            return gameTimeSum;
        }

        public int GetAchiPoints(string GameId)
        {
            int achiPoints = 0;
            Game g = GetGame(GameId);

            achiPoints = (from x in g.Achievements
                          select (int)x.achiLevel).Sum();

            return achiPoints;
        }

    }
}
