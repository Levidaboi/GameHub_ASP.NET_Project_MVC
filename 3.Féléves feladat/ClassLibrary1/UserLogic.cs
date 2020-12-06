using Repository;
using System;
using Models;
using System.Linq;



namespace Logic
{
    public class UserLogic
    {
        UserRepo userrepo;
        GameLogic gameLogic;

        public UserLogic(UserRepo userrepo , GameLogic gameLogic)
        {
            this.userrepo = userrepo;
            this.gameLogic = gameLogic;
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


    }
}
