using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarBookingApp.Data;
using CarBookingApp.Repositories.Contracts;

namespace CarBookingApp.Pages.Colours
{
    public class EditModel : PageModel
    {
        private readonly IGenericRepository<Colour> _repository;

        public EditModel(IGenericRepository<Colour> repository)
        {
            this._repository = repository;
        }

        [BindProperty]
        public Colour Colour { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Colour = await _repository.Get(id.Value);

            if (Colour == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                await _repository.Update(Colour);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await ColourExistsAsync(Colour.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private async Task<bool> ColourExistsAsync(int id)
        {
            return await _repository.Exists(id);
        }
    }
}
