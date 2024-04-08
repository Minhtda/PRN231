using BussinessLogic.IService;
using Enities.IRepository;
using Enities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace BussinessLogic.Service
{
    public class JewelryService : IJewelryService
    {
        IJewelryReposioty _repo;

        public JewelryService(IJewelryReposioty repo)
        {
            _repo = repo;
        }

        public bool Add(SilverJewelry silverJewelry)
        {
            var m_add = new SilverJewelry();
            m_add.SilverJewelryId = silverJewelry.SilverJewelryId;
            m_add.SilverJewelryName = silverJewelry.SilverJewelryName;
            m_add.CreatedDate = DateTime.Now;
            m_add.CategoryId = silverJewelry.CategoryId;
            m_add.MetalWeight = silverJewelry.MetalWeight;
            m_add.SilverJewelryDescription = silverJewelry.SilverJewelryDescription;
            m_add.Price = silverJewelry.Price;
            m_add.ProductionYear = silverJewelry.ProductionYear;
            _repo.Add(m_add);
            var result = _repo.Save();
            if (result > 0) return true;
            return false;
        }

        public bool Delete(string id)
        {
            var student = GetById(id);
            if (student != null)
            {
                _repo.Delete(student);
                var result = _repo.Save();
                if (result > 0) return true;
            }
            return false;
        }

        public List<SilverJewelry> GetAll()
        {
            return _repo.GetAll().ToList();
        }

        public SilverJewelry GetById(string id)
        {
            return _repo.GetById(id);
        }

        public List<SilverJewelry> GetByParameter(string SilverJewelryName, decimal metalWeight)
        {
            var student = GetAll();
            var result = (from s in student where s.SilverJewelryName.Contains(SilverJewelryName)  && s.MetalWeight == metalWeight select s).ToList();
            if (result.Any()) return result;
            return null;
        }

        public bool Update(SilverJewelry silverJewelry)
        {
            var m_update = GetById(silverJewelry.SilverJewelryId);
            if (m_update != null)
            {
                m_update.SilverJewelryName = silverJewelry.SilverJewelryName;
                m_update.CreatedDate = silverJewelry.CreatedDate;
                m_update.CategoryId = silverJewelry.CategoryId;
                m_update.MetalWeight = silverJewelry.MetalWeight;
                m_update.SilverJewelryDescription = silverJewelry.SilverJewelryDescription;
                m_update.Price = silverJewelry.Price;
                m_update.ProductionYear = silverJewelry.ProductionYear;
                _repo.Update(m_update);
                var result = _repo.Save();
                if (result > 0) return true;
            }
            return false;
        }
    }
}
