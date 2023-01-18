using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_DenisaBriciu.Data;
using Proiect_DenisaBriciu.Models;
using Proiect_DenisaBriciu.Models.ViewModels;

namespace Proiect_DenisaBriciu.Pages.Brands
{
    public class IndexModel : PageModel
    {
        private readonly Proiect_DenisaBriciu.Data.Proiect_DenisaBriciuContext _context;

        public IndexModel(Proiect_DenisaBriciu.Data.Proiect_DenisaBriciuContext context)
        {
            _context = context;
        }

        public IList<Brand> Brand { get;set; } 
        public BrandIndexData BrandData { get; set; }
        public int BrandID { get; set; }
        public int CarID { get; set; }
        public async Task OnGetAsync(int? id, int? carID)
        {
            BrandData = new BrandIndexData();
            BrandData.Brands = await _context.Brand
            .Include(i => i.Cars)
            .ToListAsync();
            if (id != null)
            {
                BrandID = id.Value;
                Brand brand = BrandData.Brands
                .Where(i => i.ID == id.Value).Single();
                BrandData.Cars = brand.Cars;
            }

        }
           
    }
}
