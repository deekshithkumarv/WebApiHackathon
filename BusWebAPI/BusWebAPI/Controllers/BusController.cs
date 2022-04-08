using Microsoft.AspNetCore.Mvc;
using BusWebAPI.DbContext;

namespace BusWebAPI.Controllers
{

    [ApiController]
    [Route("[Controller]")]

    public class BusController : ControllerBase
    {
        ApplicationDbContext dbContext = new ApplicationDbContext();

        [HttpGet]
        [Route("GetBus")]

        public List<busbooking> GetBus()
        {
            return dbContext.busbook.ToList();
        }


        [HttpGet]
        [Route("GetBus/{id}")]

        public ActionResult Getbus(int id)
        {
            try
            {
                var bus = dbContext.busbook.Where(s => s.id == id ).FirstOrDefault();
                return Ok(bus);
            }
            catch (Exception ex)
            {
                return BadRequest($"Data not entered,Please enter valid details");
            }
        }


        [HttpPost]
        [Route("AddBus")]
        public ActionResult AddBus(busbooking busadd)
        {
            try
            {
                dbContext.busbook.Add(busadd);
                dbContext.SaveChanges();
                return Ok(busadd.id);
            }
            catch (Exception ex)
            {
                return BadRequest($"Enter valid Data");
            }

        }

        [HttpPut]
        [Route("update")]
        public ActionResult update(int id,busbooking bus)
        {
            try
            {
                var item = dbContext.busbook.Where(x => x.id == id).FirstOrDefault();
                item.Name = bus.Name;
                item.Bus_No = bus.Bus_No;
                item.seats = bus.seats;
                dbContext.Update(item);
                dbContext.SaveChanges();
                return Ok(item);
            }
            catch (Exception ex)
            {
                return BadRequest($"Enter valid data to update");
            }
        }


        [HttpDelete]
        [Route("delete")]

        public ActionResult delete(int id)
        {
            var del = dbContext.busbook.Where(q => q.id == id).FirstOrDefault();
            dbContext.Remove(del);
            dbContext.SaveChanges();
            return Ok(del);
        }

    }
}
