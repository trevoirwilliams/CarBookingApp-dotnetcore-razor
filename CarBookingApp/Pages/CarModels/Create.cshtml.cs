using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CarBookingApp.Data;
using Microsoft.EntityFrameworkCore;
using CarBookingApp.Repositories.Contracts;

namespace CarBookingApp.Pages.CarModels
{
    public class CreateModel : PageModel
    {
        private readonly IGenericRepository<CarModel> _carModelrepository;
        private readonly IGenericRepository<Make> _makesRepository;

        public CreateModel(IGenericRepository<CarModel> carModelrepository, IGenericRepository<Make> makesRepository )
        {
            this._carModelrepository = carModelrepository;
            this._makesRepository = makesRepository;
        }

        public async Task<IActionResult> OnGet()
        {
            await LoadInitialData();
            return Page();
        }

        [BindProperty]
        public CarModel CarModel { get; set; }
        public SelectList Makes { get; private set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                await LoadInitialData();
                return Page();
            }

            await _carModelrepository.Insert(CarModel);

            return RedirectToPage("./Index");
        }

        private async Task LoadInitialData()
        {
            Makes = new SelectList(await _makesRepository.GetAll(), "Id", "Name");
        }
    }
}
