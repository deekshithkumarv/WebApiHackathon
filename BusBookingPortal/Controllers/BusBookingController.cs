using BusBooking.DataAccess;
using BusBookingPortal.Models;
using Microsoft.AspNetCore.Mvc;

namespace BusBookingPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusBookingController : Controller
    {
        private readonly BusBookingRepo busDbConnection;

        public BusBookingController()
        {
            busDbConnection = new BusBookingRepo();
        }

        [HttpPost("AddNewBus")]
        public int AddNewBus(BusModel newBus)
        {
            int id = busDbConnection.AddBus(new BusBooking.DataAccess.Entities.BusBooking
            {
                Name = newBus.Name,
                Number = newBus.Number,
                IsAvailable = newBus.IsAvailable,
                Seats = newBus.Seats,
                Type = newBus.Type,
            });
            return id;
        }

        [HttpGet("GetAllBus")]
        public IEnumerable<BusInfoModel> GetAllBus()
        {
            return busDbConnection.GetAllBus().Select(a => new BusInfoModel
            {
                Id =a.Id,
                Name = a.Name,
                Number = a.Number,
                Seats = (int)a.Seats,
                Type = a.Type,
                IsAvailable = (a.IsAvailable == 1) ? "Available" : "Not Available"

            });

        }

        [HttpGet("GetAvailableBus")]
        public IEnumerable<BusInfoModel> GetAvailableBus()
        {
            var result = busDbConnection.GetAllBus().Select(a => new BusInfoModel
            {
                Id = a.Id,
                Name = a.Name,
                Number = a.Number,
                Seats = (int)a.Seats,
                Type = a.Type,
                IsAvailable = (a.IsAvailable == 1) ? "Available" : "Not Available"

            });

            return result.Where(a => a.IsAvailable == "Available" && a.Seats>0);
        }

        [HttpPut("UpdateBusDetails")]
        public ActionResult  UpdateBusDetails(int id, BusBooking.DataAccess.Entities.BusBooking bus)
        {
            int response = busDbConnection.Update(id, bus);
            if(response == 0)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpPut("BookBusSeat")]
        public ActionResult BookBusSeat( int id, int noOfSeats)
        {
            var result = busDbConnection.BookSeat(id, noOfSeats);
            if(result == 0)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpDelete("DeleteBus")]
        public ActionResult DeleteBus(int id)
        {
            var response = busDbConnection.DeleteBus(id);

            if (response == 0)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
