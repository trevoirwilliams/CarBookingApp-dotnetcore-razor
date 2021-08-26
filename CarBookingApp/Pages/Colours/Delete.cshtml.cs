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
    public class DeleteModel : PageModel
    {
        private readonly CarBookingApp.Data.CarBookingAppDbContext _context;

        public DeleteModel(CarBookingApp.Data.CarBookingAppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Colour = await _context.Colours.FindAsync(id);

            if (Colour != null)
            {
                _context.Colours.Remove(Colour);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
