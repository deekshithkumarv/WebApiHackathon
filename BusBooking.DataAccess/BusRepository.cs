using BusBooking.DataAccess.Entities;
//using BusBookingPortal.DataAccess.Entities;

namespace BusBookingPortal.DataAccess
{
    public class BusRepository
    {
           private readonly BusDBBContext dbContext;

        public BusRepository()
        {
                 this.dbContext = new BusDBBContext();
        }

        public async Task Create(Bu bus)
        {
            await this.dbContext.buses.AddAsync(bus);
            await dbContext.SaveChangesAsync();
        }

        public List<Bu> GetBus()
        {
            return dbContext.buses.ToList();
        }

        public List<Bu> GetAvailableBus()
        {
            return dbContext.buses.Where(b => b.IsAvailableForBooking == true).ToList();
        }

        public async Task BusBook(int busId, int numberOfSeats)
        {
            var bus = await GetById(busId);
            if (bus != null)
            {
                if (bus.IsAvailableForBooking == true)
                {
                    if (bus.Seats >= numberOfSeats)
                        bus.Seats = bus.Seats - numberOfSeats;
                    dbContext.SaveChanges();
                       
                }
            }
        }

        public async Task<Bu> GetById(int busId)
        {
            var bus = await dbContext.buses.FindAsync(busId);
            return bus;
        }
        public async Task Delete(int busId)
        {
            var bus = await GetById(busId);
            if (bus != null)
            {
                dbContext.buses.Remove(bus);
                dbContext.SaveChanges();
            }
        }

        public async Task Update(Bu bus)
        {
            var existingBus = dbContext.buses.Where(b => b.Id == bus.Id).FirstOrDefault();
            if (existingBus != null)
            {   existingBus.Id=bus.Id;
                existingBus.Type = bus.Type;
                existingBus.IsAvailableForBooking = bus.IsAvailableForBooking;
                existingBus.Seats = bus.Seats;
                await this.dbContext.SaveChangesAsync();
            }
        }
    }
}