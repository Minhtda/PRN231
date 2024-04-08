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
    public class MemberService : IMemberService
    {
        IMemberRepository _repo;

        public MemberService(IMemberRepository repo)
        {
            _repo = repo;
        }

        public Member? Login(string username, string password)
        {
            var user = GetAll();

            if (user != null)
            {
                var result = (from u in user where u.Email == username && u.Password == password select u).FirstOrDefault();
                if (result != null) return result;
            }
            return null;
        }
        private List<Member> GetAll()
        {
            return _repo.GetAll();
        }
    }
}