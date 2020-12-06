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
            int gameTimeSum = 0;
            foreach (var game in games)
            {
                gameTimeSum += game.GameTime;
            }

            return gameTimeSum;
        }

        public int GetAchiPoints(string GameId)
        {
            int achiPoints = 0;
            Game g = GetGame(GameId);
            foreach (var achi in g.Achievements)
            {
                if (achi.achiLevel == AchiLevel.bronze)
                {
                    achiPoints += 10;
                }
                else if (achi.achiLevel == AchiLevel.silver)
                {
                    achiPoints +=  20;
                }
                else
                {
                    achiPoints += 30;
                }
            }

            return achiPoints;
        }

    }
}
