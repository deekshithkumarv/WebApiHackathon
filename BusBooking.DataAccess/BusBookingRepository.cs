using System.Collections.Generic;
using System.Threading.Tasks;
using BusBooking.DataAccess.Entities;
using System.Linq;
namespace BusBooking.DataAccess
{
    public class BusBookingRepository
    {
        private readonly BusBookingContext dbContext;
        public BusBookingRepository()
        {
            this.dbContext = new BusBookingContext();
        }

        public async Task Create(BusBooking.DataAccess.Entities.BusBooking toy)
        {
            dbContext.BusBookings.Add(toy);
            await dbContext.SaveChangesAsync();
           
        }

        public List<BusBooking.DataAccess.Entities.BusBooking> GetBusList()
        {
            return dbContext.BusBookings.ToList();
        }

        public List<BusBooking.DataAccess.Entities.BusBooking> GetAvailable()
        {
            return dbContext.BusBookings.Where(h => h.IsAvailableBooking == 1).ToList();
        }

        public async Task<BusBooking.DataAccess.Entities.BusBooking> GetById(int Number)
        {
            return await dbContext.BusBookings.FindAsync(Number);
        }

        public async Task<string> Update(BusBooking.DataAccess.Entities.BusBooking booking)
        {
            var existingBus = dbContext.BusBookings.Where(b => b.Number == booking.Number).FirstOrDefault();
            if (existingBus != null)
            {
                if (existingBus.IsAvailableBooking == 1)
                {
                    existingBus.Seats -= 1;
                    await this.dbContext.SaveChangesAsync();
                    return "Bus Booked";
                }

                else return "Bus Not Booked";


            }
            else return "Bus Not Found";
        }

       

        public async Task UpdateBusDetail(BusBooking.DataAccess.Entities.BusBooking bus)
        {
            var existingBus = dbContext.BusBookings.Where(b => b.Number == bus.Number).FirstOrDefault();
            if (existingBus != null)
            {
                existingBus.Name = bus.Name;
                existingBus.Seats = bus.Seats;
                existingBus.Type = bus.Type;
                await this.dbContext.SaveChangesAsync();
            }
        }
        public async Task Delete(int Number)
        {
            var bus = await GetById(Number);

            if (bus != null)
            {
                dbContext.BusBookings.Remove(bus);
                await this.dbContext.SaveChangesAsync();
            }
        }
    }
}

