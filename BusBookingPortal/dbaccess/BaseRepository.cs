using BusBookingPortal.Entities;

namespace BusBookingPortal.dbaccess
{
    public class BaseRepository<T>where T : class
    {
        protected BusBookingPortalContext dbcontext = new BusBookingPortalContext();
        public List<T> Get()
        {
            return dbcontext.Set<T>().ToList();
        }
        public void Create(T input)
        {
            dbcontext.Add<T>(input);
            dbcontext.SaveChanges();
        }
        public void Update(T input)
        {
            var dbentity = dbcontext.Find<T>(input);
            if (dbcontext.Find<T>(input) != null)
                throw new Exception("Bus not found");
            else
                dbentity = input;
            dbcontext.SaveChanges();
        }
        public void Delete(T input)
        {
            dbcontext.Remove<T>(input);
            dbcontext.SaveChanges();
        }

    }
}
