using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarBookingApp.Data;
using CarBookingApp.Repositories.Contracts;

namespace CarBookingApp.Pages.Makes
{
    public class DetailsModel : PageModel
    {
        private readonly IGenericRepository<Make> _repository;

        public DetailsModel(IGenericRepository<Make> repository)
        {
            this._repository = repository;
        }

        public Make Make { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Make = await _repository.Get(id.Value);

            if (Make == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
