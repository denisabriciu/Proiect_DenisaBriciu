﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proiect_DenisaBriciu.Data;
using Proiect_DenisaBriciu.Models;

namespace Proiect_DenisaBriciu.Pages.Brands
{
    public class EditModel : PageModel
    {
        private readonly Proiect_DenisaBriciu.Data.Proiect_DenisaBriciuContext _context;

        public EditModel(Proiect_DenisaBriciu.Data.Proiect_DenisaBriciuContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Brand Brand { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Brand == null)
            {
                return NotFound();
            }

            var brand =  await _context.Brand.FirstOrDefaultAsync(m => m.ID == id);
            if (brand == null)
            {
                return NotFound();
            }
            Brand = brand;
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

            _context.Attach(Brand).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BrandExists(Brand.ID))
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

        private bool BrandExists(int id)
        {
          return _context.Brand.Any(e => e.ID == id);
        }
    }
}
