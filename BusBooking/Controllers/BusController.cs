
using BusBooking.DataAccess.Entities;
using BusBookingPortal.DataAccess;
//using BusBookingPortal.DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BusBookingPortal.Controllers
{
    [Route("api/[Controller]")]

    public class BusController : Controller
    {
        private readonly BusRepository busRepository;
        public BusController()
        {
            this.busRepository = new BusRepository();
        }

        [HttpGet("GetBus")]
        public List<Bu> GetBus()
        {
            return busRepository.GetBus();
        }

        [HttpGet("GetAvailableBus")]
        public List<Bu> GetAvailableBus()
        {
            return busRepository.GetAvailableBus();
        }

        [HttpPost("AddBus")]
        public async Task<IActionResult> CreateBus(String Name, int Number, String Type, int Seats, bool IsAvailableForBooking)
        {
            Bu buses = new Bu();
            buses.Name = Name;
            buses.Number = Number;
            buses.Type = Type;
            buses.Seats = Seats;
            buses.IsAvailableForBooking = IsAvailableForBooking;
            await busRepository.Create(buses);
            return Ok();
        }

        [HttpDelete("Remove")]
        public async Task<IActionResult> Delete(int busId)
        {
            await busRepository.Delete(busId);
            return Ok();
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(int Id, String Type, int Seats, bool IsAvailableForBooking)
        {
            await busRepository.Update(new Bu
            {
                Id = Id,
            Type = Type,
            Seats = Seats,
            IsAvailableForBooking = IsAvailableForBooking
        });
            return Ok();
        }

        [HttpPut("SeatBooking")]
        public async Task<IActionResult> BusSeatUpdate(int busId,int NumberOfSeats)
        {
            await busRepository.BusBook(busId,NumberOfSeats);

            return Ok();
        }
    }
}
