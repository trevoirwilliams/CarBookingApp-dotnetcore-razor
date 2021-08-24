using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarBookingApp.Data;

namespace CarBookingApp.Pages.Cars
{
    public class IndexModel : PageModel
    {
        private readonly CarBookingApp.Data.CarBookingAppDbContext _context;

        public IndexModel(CarBookingApp.Data.CarBookingAppDbContext context)
        {
            _context = context;
        }

        public IList<Car> Cars { get;set; }

        public async Task OnGetAsync()
        {
            Cars = await _context.Cars.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int? carid)
        {
            if (carid == null)
            {
                return NotFound();
            }

            var car = await _context.Cars.FindAsync(carid);

            if (car != null)
            {
                _context.Cars.Remove(car);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage();
        }
    }
}
