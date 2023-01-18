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
    public class EditModel : PageModel
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

            var car =  await _context.Car.FirstOrDefaultAsync(m => m.ID == id);
            if (car == null)
            {
                return NotFound();
            }
            Car = car;
            ViewData["BrandID"] = new SelectList(_context.Set<Brand>(), "ID","BrandName");
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

            _context.Attach(Car).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarExists(Car.ID))
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

        private bool CarExists(int id)
        {
          return _context.Car.Any(e => e.ID == id);
        }
    }
}
