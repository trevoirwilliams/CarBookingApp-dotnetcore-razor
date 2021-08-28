using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarBookingApp.Data;
using CarBookingApp.Repositories.Contracts;

namespace CarBookingApp.Pages.CarModels
{
    public class IndexModel : PageModel
    {
        private readonly IGenericRepository<CarModel> _repository;

        public IndexModel(IGenericRepository<CarModel> repository)
        {
            this._repository = repository;
        }

        public IList<CarModel> CarModel { get;set; }

        public async Task OnGetAsync()
        {
            CarModel = await _repository.GetAll();
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
