using CarBookingApp.Data.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarBookingApp.Data
{
    public class CarBookingAppDbContext : IdentityDbContext<ApplicationUser>
    {
        public CarBookingAppDbContext(DbContextOptions<CarBookingAppDbContext> options) : base(options)
        {

        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Make> Makes { get; set; }
        public DbSet<CarModel> CarModels { get; set; }
        public DbSet<Colour> Colours { get; set; }
    }
}
