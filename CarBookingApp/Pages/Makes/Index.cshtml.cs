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
    public class IndexModel : PageModel
    {
        private readonly IGenericRepository<Make> _repository;

        public IndexModel(IGenericRepository<Make> repository)
        {
            this._repository = repository;
        }

        public IList<Make> Makes { get;set; }

        public async Task OnGetAsync()
        {
            Makes = await _repository.GetAll();
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
