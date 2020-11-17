using Data;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class AchievementRepo : IRepo<Achievement>
    {
        UserDbContext db = new UserDbContext();

        public void Add(Achievement item)
        {
            
            db.Achievements.Add(item);
            Save();
        }

        public IQueryable<Achievement> AllItem()
        {
           return db.Achievements.AsQueryable();
        }

        public void Delete(Achievement item)
        {
             db.Achievements.Remove(item);
            Save();
        }

        public void Delete(string uid)
        {
            Achievement item = Read(uid);
            db.Achievements.Remove(item);
            Save();
        }

        public Achievement Read(string uid)
        {
            Achievement item = (from x in db.Achievements
                               where x.AchiId == uid 
                               select x).FirstOrDefault();
            return item;
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(string oldid, Achievement newitem)
        {
            Achievement olditem = Read(oldid);
            olditem.Name = newitem.Name;
            olditem.achiLevel = newitem.achiLevel;

            Save();
        }
    }
}
