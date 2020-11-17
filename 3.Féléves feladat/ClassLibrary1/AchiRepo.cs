using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;
using Repository;

namespace Logic
{
    public class AchiLogic
    {
        AchievementRepo achiRepo;

        public AchiLogic(AchievementRepo achiRepo)
        {
            this.achiRepo = achiRepo;
        }

        public void AddAchi(Achievement a)
        {
            achiRepo.Add(a);
        }

        public void DeleteAchi(Achievement a)
        {
            achiRepo.Delete(a);
        }

        public IQueryable<Achievement> GetAchievements()
        {
            return achiRepo.AllItem();
        
        }

        public Achievement GetAchievement(string achiId)
        {
            return achiRepo.Read(achiId);
        }


        public void UpdateAchi(string oldid, Achievement newitem)
        {
            achiRepo.Update(oldid, newitem);
         
        }

    }
}
