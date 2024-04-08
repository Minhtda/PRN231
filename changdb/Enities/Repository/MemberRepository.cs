using Enities.IRepository;
using Enities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enities.Repository
{
    public class MemberRepository : GenericRepository<Member>, IMemberRepository
    {
        public MemberRepository(FstoreDbContext context) : base(context)
        {
        }
    }
}
