using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarBookingApp.Data;

namespace CarBookingApp.Pages.Colours
{
    public class DetailsModel : PageModel
    {
        private readonly CarBookingApp.Data.CarBookingAppDbContext _context;

        public DetailsModel(CarBookingApp.Data.CarBookingAppDbContext context)
        {
            _context = context;
        }

        public Colour Colour { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Colour = await _context.Colours.FirstOrDefaultAsync(m => m.Id == id);

            if (Colour == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
