using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proiect_DenisaBriciu.Data;
using Proiect_DenisaBriciu.Models;

namespace Proiect_DenisaBriciu.Pages.Members
{
    public class CreateModel : PageModel
    {
        private readonly Proiect_DenisaBriciu.Data.Proiect_DenisaBriciuContext _context;

        public CreateModel(Proiect_DenisaBriciu.Data.Proiect_DenisaBriciuContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Member Member { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Member.Add(Member);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
