using BusWebAPI;
using Microsoft.EntityFrameworkCore;
namespace BusWebAPI.DbContext
{
    public class ApplicationDbContext : Microsoft.EntityFrameworkCore.DbContext
    {

        public DbSet<busbooking> busbook { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;Database=Bus");
        }

    }
}
