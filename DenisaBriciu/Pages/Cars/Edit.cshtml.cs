using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proiect_DenisaBriciu.Data;
using Proiect_DenisaBriciu.Models;

namespace Proiect_DenisaBriciu.Pages.Cars
{
    public class EditModel : CarCategoriesPageModel
    {
        private readonly Proiect_DenisaBriciu.Data.Proiect_DenisaBriciuContext _context;

        public EditModel(Proiect_DenisaBriciu.Data.Proiect_DenisaBriciuContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Car Car { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Car == null)
            {
                return NotFound();
            }

            var car =  await _context.Car
           
            .Include(b => b.Brand)
            .Include(b => b.CarCategories).ThenInclude(b => b.Category)
             .AsNoTracking()
             .FirstOrDefaultAsync(m => m.ID == id);
            if (car == null)
            {
                return NotFound();
            }
            PopulateAssignedCategoryData(_context, Car);
            Car = car;
            ViewData["BrandID"] = new SelectList(_context.Set<Brand>(), "ID","BrandName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var carToUpdate = await _context.Car
            .Include(i => i.Brand)
            .Include(i => i.CarCategories)
            .ThenInclude(i => i.Category)
            .FirstOrDefaultAsync(s => s.ID == id);
            if (carToUpdate == null)
            {
                return NotFound();
            }
            
            if (await TryUpdateModelAsync<Car>(
           carToUpdate,
            "Car",
            i => i.Name, i => i.Price,
            i => i.ManufacturingYear, i => i.BrandID))
            {
                UpdateBookCategories(_context, selectedCategories, carToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
           
            UpdateBookCategories(_context, selectedCategories, carToUpdate);
            PopulateAssignedCategoryData(_context, carToUpdate);
            return Page();
        }
        private bool CarExists(int id)
        {
            return _context.Car.Any(e => e.ID == id);
        }
    }
}


    

