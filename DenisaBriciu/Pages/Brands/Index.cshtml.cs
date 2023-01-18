using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_DenisaBriciu.Data;
using Proiect_DenisaBriciu.Models;

namespace Proiect_DenisaBriciu.Pages.Brands
{
    public class IndexModel : PageModel
    {
        private readonly Proiect_DenisaBriciu.Data.Proiect_DenisaBriciuContext _context;

        public IndexModel(Proiect_DenisaBriciu.Data.Proiect_DenisaBriciuContext context)
        {
            _context = context;
        }

        public IList<Brand> Brand { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Brand != null)
            {
                Brand = await _context.Brand.ToListAsync();
            }
        }
    }
}
