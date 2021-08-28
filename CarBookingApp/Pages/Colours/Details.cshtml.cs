using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarBookingApp.Data;
using CarBookingApp.Repositories.Contracts;

namespace CarBookingApp.Pages.Colours
{
    public class DetailsModel : PageModel
    {
        private readonly IGenericRepository<Colour> _repository;

        public DetailsModel(IGenericRepository<Colour> repository)
        {
            this._repository = repository;
        }

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
    }
}
