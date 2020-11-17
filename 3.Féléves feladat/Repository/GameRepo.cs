using Data;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
     public  class GameRepo : IRepo<Game>
    {
        UserDbContext db = new UserDbContext();
        public void Add(Game item)
        {
            db.Games.Add(item);
            Save();
        }

        public IQueryable<Game> AllItem()
        {
            return db.Games.AsQueryable() ;
        }

        public void Delete(Game item)
        {
            db.Games.Remove(item);
            Save();
        }

        public void Delete(string uid)
        {
            Game item = Read(uid);
            db.Games.Remove(item);
            Save();
        }

        public Game Read(string uid)
        {
            Game item = (from x in db.Games
                        where x.Id == uid
                        select x).FirstOrDefault();
            return item;
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(string oldid, Game newitem)
        {
            Game olditem = Read(oldid);
            olditem.Name = newitem.Name;
            olditem.Genre = newitem.Genre;
            olditem.GameTime = newitem.GameTime;
            olditem.Rating = newitem.Rating;
            olditem.Achievements.Clear();

            foreach (var item in newitem.Achievements)
            {
                olditem.Achievements.Add(item);
            }

            Save();
        }
    }
}
