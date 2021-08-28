using CarBookingApp.Data;
using CarBookingApp.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookingApp.Repositories.Repositories
{
    public class CarsRepository : GenericRepository<Car>, ICarsRepository
    {
        private readonly CarBookingAppDbContext _context;

        public CarsRepository(CarBookingAppDbContext context) : base(context)
        {
            this._context = context;
        }

        public async Task<List<Car>> GetCarsWithDetails()
        {
            return await _context.Cars
                .Include(q => q.Make)
                .Include(q => q.CarModel)
                .Include(q => q.Colour)
                .ToListAsync();
        }

        public async Task<Car> GetCarWithDetails(int id)
        {
            return await _context.Cars
                .Include(q => q.Make)
                .Include(q => q.CarModel)
                .Include(q => q.Colour)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<bool> IsLicencePlateExists(string plateNumber)
        {
            return await _context.Cars.AnyAsync(q => q.LicensePlateNumber.ToLower().Trim() == plateNumber.ToLower().Trim());
        }
    }
}
