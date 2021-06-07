using Models;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class UserRepo : IRepo<User>
    {
        UserDbContext db = new UserDbContext();
        public void Add(User item)
        {
            db.Gamers.Add(item);
            Save();
        }

        public void Delete(User item)
        {
            db.Gamers.Remove(item);
            Save();
        }

        public void Delete(string id)
        {
            User item = Read(id);
            db.Gamers.Remove(item);
            Save();
            
        }

        public User Read(string uid)
        {
            User item = (from x in db.Gamers
                         where x.UserId == uid
                         select x).FirstOrDefault();
            return item;
        }

        public IQueryable<User> AllItem()
        {
            return db.Gamers.AsQueryable();
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(string oldid, User newitem)
        {
            User olduser = Read(oldid);

            olduser.Name = newitem.Name;
            olduser.Age = newitem.Age;
            
            Save();
        }

        public IQueryable<User> Read()
        {
            throw new NotImplementedException();
        }




    }
}
