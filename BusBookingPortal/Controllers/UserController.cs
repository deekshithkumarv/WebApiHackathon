using BusBookingPortal.dbaccess;
using BusBookingPortal.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BusBookingPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserRepository repository = new UserRepository();
        [HttpGet]
        public ActionResult GetBus()
        {
            return Ok(repository.Get());
        }
        [HttpPost]
        public IActionResult CreateBus(UserTable input)
        {
            repository.Create(input);
            return Ok("Successfully Added The Bus");
        }
        [HttpPut]
        public IActionResult UpdateBus(UserTable input)
        {
            repository.Update(input);
            return Ok("Updated the bus");

        }
        [HttpDelete]
        public IActionResult delete(UserTable input)
        {
            repository.Delete(input);
            return Ok("deleted a bus");
        }
    }
}
