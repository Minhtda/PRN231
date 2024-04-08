using Enities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.IService
{
    public interface IBranchAccountService
    {
        public BranchAccount? Login(string username, string password);
    }
}
