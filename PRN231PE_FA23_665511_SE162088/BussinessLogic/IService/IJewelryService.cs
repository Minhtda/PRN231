using Enities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.IService
{
    public interface IJewelryService
    {
        public List<SilverJewelry> GetAll();
        public bool Add(SilverJewelry student);
        public bool Update(SilverJewelry student);
        public bool Delete(string id);
        public SilverJewelry GetById(string id);
        public List<SilverJewelry> GetByParameter(string SilverJewelryName, decimal metalWeight);
    }
}
