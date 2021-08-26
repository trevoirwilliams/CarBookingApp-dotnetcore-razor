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
    public class IndexModel : PageModel
    {
        private readonly CarBookingApp.Data.CarBookingAppDbContext _context;

        public IndexModel(CarBookingApp.Data.CarBookingAppDbContext context)
        {
            _context = context;
        }

        public IList<Colour> Colour { get;set; }

        public async Task OnGetAsync()
        {
            Colour = await _context.Colours.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int? recordid)
        {
            if (recordid == null)
            {
                return NotFound();
            }

            var colour = await _context.Colours.FindAsync(recordid);

            if (colour != null)
            {
                _context.Colours.Remove(colour);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage();
        }

    }
}
