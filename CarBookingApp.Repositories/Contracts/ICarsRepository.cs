using CarBookingApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookingApp.Repositories.Contracts
{
    public interface ICarsRepository : IGenericRepository<Car>
    {
        Task<Car> GetCarWithDetails(int id);
        Task<bool> IsLicencePlateExists(string plateNumber);
        Task<List<Car>> GetCarsWithDetails();
    }
}
