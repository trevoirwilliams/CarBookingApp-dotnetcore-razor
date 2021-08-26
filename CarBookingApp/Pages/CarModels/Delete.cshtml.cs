using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarBookingApp.Data;

namespace CarBookingApp.Pages.CarModels
{
    public class DeleteModel : PageModel
    {
        private readonly CarBookingApp.Data.CarBookingAppDbContext _context;

        public DeleteModel(CarBookingApp.Data.CarBookingAppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CarModel CarModel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CarModel = await _context.CarModels.FirstOrDefaultAsync(m => m.Id == id);

            if (CarModel == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CarModel = await _context.CarModels.FindAsync(id);

            if (CarModel != null)
            {
                _context.CarModels.Remove(CarModel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
