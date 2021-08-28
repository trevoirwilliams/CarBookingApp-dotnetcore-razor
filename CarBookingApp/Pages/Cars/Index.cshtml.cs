using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarBookingApp.Data;
using CarBookingApp.Repositories.Contracts;
using Microsoft.AspNetCore.Authorization;

namespace CarBookingApp.Pages.Cars
{
    public class IndexModel : PageModel
    {
        private readonly ICarsRepository _repository;

        public IndexModel(ICarsRepository repository)
        {
            this._repository = repository;
        }

        public IList<Car> Cars { get;set; }

        public async Task OnGetAsync()
        {
            Cars = await _repository.GetCarsWithDetails();
        }

        public async Task<IActionResult> OnPostDelete(int? recordid)
        {
            if (recordid == null)
            {
                return NotFound();
            }

            await _repository.Delete(recordid.Value);

            return RedirectToPage();
        }
    }
}
