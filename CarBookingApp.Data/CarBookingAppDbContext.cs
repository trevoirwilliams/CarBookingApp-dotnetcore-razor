using Microsoft.EntityFrameworkCore;

namespace CarBookingApp.Data
{
    public class CarBookingAppDbContext : DbContext
    {
        public CarBookingAppDbContext(DbContextOptions<CarBookingAppDbContext> options) : base(options)
        {

        }

        public DbSet<Car> Cars { get; set; }
    }
}
