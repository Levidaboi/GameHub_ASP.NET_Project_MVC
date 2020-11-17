using Repository;
using System;
using Models;
using System.Linq;



namespace ClassLibrary1
{
    public class UserLogic
    {
        UserRepo userrepo;

        public UserLogic(UserRepo userrepo)
        {
            this.userrepo = userrepo;
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


    }
}
