﻿using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.IService
{
    public interface IStudentGroupService
    {
        public List<StudentGroup> GetAll();
    }
}
