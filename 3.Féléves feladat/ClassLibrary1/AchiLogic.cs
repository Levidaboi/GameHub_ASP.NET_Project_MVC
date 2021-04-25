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
        IRepo<Achievement> achiRepo;

        public AchiLogic(IRepo<Achievement> achiRepo)
        {
            this.achiRepo = achiRepo;
        }

        public void AddAchi(Achievement a)
        {
            achiRepo.Add(a);
           
        }

        public void DeleteAchi(string uid)
        {


            achiRepo.Delete(uid);
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
