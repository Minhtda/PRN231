using Enities.IRepository;
using Enities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enities.Repository
{
    public class JewelryRepository : GenericRepository<SilverJewelry>, IJewelryReposioty
    {
        public SilverJewelry2023DbContext _context;
        public JewelryRepository(SilverJewelry2023DbContext context) : base(context)
        {
            _context = context;
        }
    }
}