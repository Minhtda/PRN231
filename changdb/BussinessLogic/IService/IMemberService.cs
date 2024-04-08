using Enities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.IService
{
    public interface IMemberService
    {
        public Member? Login(string username, string password);
    }
}
