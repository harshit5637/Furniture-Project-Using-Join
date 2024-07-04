using FurnitureData.Furniture_Data;
using FurnitureModel.Model;
using FurnitureServices.Implementation;
using FurnitureServices.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Furniture_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FurnitureController : ControllerBase
    {
        private readonly IFurniture_Services _services;

        public FurnitureController(IFurniture_Services services)
        {
            _services = services;
        }

        [HttpPost]
        public IActionResult AddFurniture(Furniture_Model Model)
        {
            var HM = _services.AddFurniture(Model);
            return Ok(HM);
        }

        [HttpDelete]
        public IActionResult DeleteById(int id)
        {
            _services.DeleteBy(id);
            return Ok("deleted");
        }

        [HttpPut("{id}")]
        public IActionResult PutFurni(Furniture_Model model)
        {
            var harshit = _services.Updatejoin(model);
            return Ok(harshit);
        }


        [HttpPost("delete-multiple")]
        public IActionResult DeleteMultiple([FromBody] List<int> ids)
        {
            _services.DeleteMultiple(ids);
            return Ok("deleted");
        }
































        //[HttpDelete("deleteAll")]
        //public IActionResult DeleteFurniture()
        //{
        //    try
        //    {
        //        _services.DeleteAll();
        //        return Ok("All Restaurant deleted successfully.");
        //    }
        //    catch (Exception ex)
        //    {
        //        // Log the exception or handle it as needed
        //        return StatusCode(500, $"An error occurred: {ex.Message}");
        //    }
        //}

        //[HttpGet("id")]
        //public IActionResult GetEmployeebyId(int id)
        //{
        //    var employee = _services.GetFurnitureById(id);
        //    return Ok(employee);

        //}

        //[HttpGet]

        //public IActionResult GetFurniture()
        //{
        //    var shit = _services.GetFurniture();
        //    return Ok(shit);

        //}

        //[HttpPut("{id}")]
        //public IActionResult PutFurni(int id, FurnitureTableEntity tur)
        //{
        //    var harshit = _services.PutFurniture(id, tur);
        //    return Ok(harshit);
        //}



    }
}
