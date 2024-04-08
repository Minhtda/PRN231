using BussinessLogic.IService;
using Enities.IRepository;
using Enities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Service
{
    public class BranchAccountService : IBranchAccountService
    {
        IBranchAccountRepository _repo;

        public BranchAccountService(IBranchAccountRepository repo)
        {
            _repo = repo;
        }

        public BranchAccount? Login(string username, string password)
        {
            var user = GetAll();

            if (user != null)
            {
                var result = (from u in user where u.EmailAddress == username && u.AccountPassword == password select u).FirstOrDefault();
                if (result != null) return result;
            }
            return null;
        }
        private List<BranchAccount> GetAll()
        {
            return _repo.GetAll().ToList();
        }
    }
}
