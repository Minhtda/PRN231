﻿using BusinessLogic.IService;
using BusinessLogic.Token;
using ControllerAPI.Enum;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControllerAPI.Controllers
{
    [Route("api/students")]
    [ApiController]
  [Authorize(Roles = EnumClass.RoleNames.Staff)]
    public class StudentControllers : ControllerBase
    {
        IStudentService _student;

        public StudentControllers(IStudentService student)
        {
            _student = student;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var result = _student.GetAll();
            if(result.Any()) return Ok(result);
            return NoContent();
        }
        [HttpGet("{id}")]
        public IActionResult GetByid(int id)
        {
            var result = _student.GetStudentById(id);
            if (result != null) return Ok(result);
            return BadRequest("Student don't exist in DB");
        }
        [HttpGet("search")]
        public IActionResult GetByQuery(int groupId, DateTime minBirthdate, DateTime maxBirthdate)
        {
            var result = _student.GetStudentByParameter(groupId,minBirthdate,maxBirthdate);
            if (result.Any()) return Ok(result);
            return BadRequest("Student don't exist in DB");
        }
        [HttpPost]
        public IActionResult Post(Student student)
        {
            var result= _student.AddStudent(student);
            if (result) return Ok("Add Student successful!");
            return BadRequest("Add Student failed!");
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _student.DeleteStudent(id);
            if (result) return Ok("Delete Student successful!");
            return BadRequest("Delete Student failed!");
        }
        [HttpPut]
        public IActionResult Put(Student student)
        {
            var result = _student.UpdateStudent(student);
            if (result) return Ok("Update successful!");
            return BadRequest("Update failed!");
        }
    }
}
