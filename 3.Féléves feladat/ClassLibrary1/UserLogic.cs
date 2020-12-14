using Repository;
using System;
using Models;
using System.Linq;



namespace Logic
{
    public class UserLogic
    {
        IRepo<User> userrepo;
<<<<<<< HEAD
        IRepo<Game> gameRepo;
=======
        GameRepo gameRepo;
>>>>>>> 09da38a31b159e65db16033487fa64937466ae29
        GameLogic gameLogic;
        IRepo<Achievement> AchievementRepo;

<<<<<<< HEAD
        public UserLogic(IRepo<User> userrepo)
        {
            this.userrepo = userrepo;
        }
        
        public UserLogic(IRepo<User> userrepo , GameLogic gameLogic, IRepo<Game> gameRepo,IRepo<Achievement> AchievementRepo)
=======
        public UserLogic(IRepo<User> ur)
        {
            this.userrepo = ur;
        }

        public UserLogic(IRepo<User> userrepo , GameLogic gameLogic, GameRepo gameRepo, AchievementRepo AchievementRepo)
>>>>>>> 09da38a31b159e65db16033487fa64937466ae29
        {
            this.userrepo = userrepo;
            this.gameLogic = gameLogic;
            this.gameRepo = gameRepo;
            this.AchievementRepo = AchievementRepo;

        }

        public void AddNewUser(User u)
        {
            userrepo.Add(u);
        }

        public void DeleteUser(string uid)
        {
            userrepo.Delete(uid);
        }

        public IQueryable<User> GetUsers()
        {
           return userrepo.AllItem();
        }

        public User GetUser(string uid)
        {
            return userrepo.Read(uid);
        }

        public void UpdateUser(string oldid, User newitem)
        {
            

            userrepo.Update(oldid, newitem);
        }


        public int GetGameCount(string userid)
        {
            int i = (from x in GetUser(userid).GameLibrary
                     select x).Count();


            return i;
        }

        public int GetGameTime(string userid)
        {
            int i = (from x in GetUser(userid).GameLibrary
                     select x.GameTime).Sum();


            return i;
        }

        public int GetAchiPoints(string userid)
        {
            User u = GetUser(userid);
            int i = 0;
            
                    
            foreach (var game in u.GameLibrary)
            {
                Game g =  gameLogic.GetGame(game.GameId);
                i += gameLogic.GetAchiPoints(game.GameId);
            }
                  
            return i;
        }

        public string GetBestGamer()
        {
            var q = (from x in userrepo.AllItem().ToList()
                     join y in gameRepo.AllItem().ToList() on x.UserId equals y.UserId
                     join z in gameRepo.AllItem().ToList() on y.GameId equals z.GameId
                     group x by x.Name into g
                     select new
                     {
                         Name = g.Key,
                         points = g.SelectMany(x => x.GameLibrary).SelectMany(y => y.Achievements).Sum(z => (int)z.achiLevel)
                     }).OrderByDescending(x => x.points).FirstOrDefault();
                        


           return q.Name;


        }

        public string GetLifelessGamer()
        {
            var q = (from x in userrepo.AllItem().ToList()
                     join y in gameRepo.AllItem().ToList() on x.UserId equals y.UserId
                     group x by x.Name into g
                     select new
                     {
                         name = g.Key,
                         time = g.SelectMany(x => x.GameLibrary).Sum(y => y.GameTime)

                     }).OrderByDescending(x => x.time).FirstOrDefault();


            return q.name;

        }


        public string GetRichestGamer()
        {
            var q = (from x in userrepo.AllItem().ToList()
                    select new
                    {
                        name = x.Name ,
                        GameCount = x.GameLibrary.Count
                    }).OrderByDescending(x => x.GameCount).FirstOrDefault();

            return q.name;
        }

    }
}
