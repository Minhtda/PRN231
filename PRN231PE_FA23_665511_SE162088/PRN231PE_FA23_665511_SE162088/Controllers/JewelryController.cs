using BussinessLogic.IService;
using ControllerAPI.Enum;
using Enities.IRepository;
using Enities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace PRN231PE_FA23_665511_SE162088.Controllers
{
    [Route("api/jewelry")]
    [ApiController]
    [Authorize(Roles = EnumClass.RoleNames.Admin)]
    public class JewelryController : Controller
    {
        IJewelryService _jewelry;

        public JewelryController(IJewelryService jewelry)
        {
            _jewelry = jewelry;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var result = _jewelry.GetAll();
            if (result.Any()) return Ok(result);
            return NoContent();
        }
        [HttpGet("{id}")]
        public IActionResult GetByid(string id)
        {
            var result = _jewelry.GetById(id);
            if (result != null) return Ok(result);
            return BadRequest("Don't exist in DB");
        }
        [HttpGet("search")]
        [AllowAnonymous]
        public IActionResult GetByQuery(string SilverJewelryName, decimal metalWeight)
        {
            var result = _jewelry.GetByParameter(SilverJewelryName, metalWeight);
            if (result != null) return Ok(result);
            return BadRequest("Don't exist in DB");
        }
        [HttpPost]
        public IActionResult Post(SilverJewelry silverJewelry)
        {
            var result = _jewelry.Add(silverJewelry);
            if (result) return Ok("Add successful!");
            return BadRequest("Add failed!");
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var result = _jewelry.Delete(id);
            if (result) return Ok("Delete successful!");
            return BadRequest("Delete failed!");
        }
        [HttpPut]
        public IActionResult Put(SilverJewelry silverJewelry)
        {
            var result = _jewelry.Update(silverJewelry);
            if (result) return Ok("Update successful!");
            return BadRequest("Update failed!");
        }
    }
}
