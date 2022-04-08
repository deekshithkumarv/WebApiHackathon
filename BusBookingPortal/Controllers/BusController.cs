using BusBookingPortal.dbaccess;
using BusBookingPortal.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BusBookingPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusController : Controller
    {
        private BusRepository repository = new BusRepository();
        [HttpGet]
        public ActionResult GetBus()
        {
            return Ok(repository.Get());
        }
        [HttpPost]
        public IActionResult CreateBus(Bu input)
        {
            repository.Create(input);
            return Ok("Successfully Added The Bus");
        }
        [HttpPut]
        public IActionResult UpdateBus(Bu input)
        {
            repository.Update(input);
            return Ok("Updated the bus");

        }
        [HttpDelete]
        public IActionResult delete(Bu input)
        {
            repository.Delete(input);
            return Ok("deleted a bus");
        }
        
    } 
}
