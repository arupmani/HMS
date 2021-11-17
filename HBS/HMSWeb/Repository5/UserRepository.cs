using HMSWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HMSWeb.Repository
{
    public class UserRepository : IUserRepository
    {
        HMSContext db;
        public UserRepository(HMSContext _db)
        {
            db = _db;
        }

        public bool IsUserExists(string userName, string password)
        {
            bool returnValue= false;
           if(db !=null)
            {
                if (db.AppUser.Where(u => u.UserName == userName && u.Password == password).Any())
                    returnValue = true;
            }
            return returnValue;
        }
    }
}
