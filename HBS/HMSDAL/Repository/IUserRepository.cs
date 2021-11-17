using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HMSDAL.Repository
{
   public interface IUserRepository
    {
        bool IsUserExists(string userName, string password);
    }
}
