using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_DenisaBriciu.Data;
using Proiect_DenisaBriciu.Models;

namespace Proiect_DenisaBriciu.Pages.Cars
{
    public class IndexModel : PageModel
    {
        private readonly Proiect_DenisaBriciu.Data.Proiect_DenisaBriciuContext _context;

        public IndexModel(Proiect_DenisaBriciu.Data.Proiect_DenisaBriciuContext context)
        {
            _context = context;
        }

        public IList<Car> Car { get; set; }
        public string CurrentFilter { get; set; }
        public string PriceSort { get; set; }
        public CarData CarD { get; set; }
        public int CarID { get; set; }
        public int CategoryID { get; set; }
        public async Task OnGetAsync(int? id, int? categoryID, string sortOrder, string searchString)
        {
            CarD = new CarData();
            PriceSort = String.IsNullOrEmpty(sortOrder) ? "price_desc" : "";
            CurrentFilter = searchString;
            CarD.Cars = await _context.Car
            .Include(b => b.Brand)
            .Include(b => b.CarCategories)
            .ThenInclude(b => b.Category)
            .AsNoTracking()
            .OrderBy(b => b.Name)
            .ToListAsync();
            if (!String.IsNullOrEmpty(searchString))
            {
                CarD.Cars = CarD.Cars.Where(s => s.Brand.BrandName.Contains(searchString));


              
            }
                if (id != null)
            {
                CarID = id.Value;
                Car car = CarD.Cars
                .Where(i => i.ID == id.Value).Single();
                CarD.Categories = car.CarCategories.Select(s => s.Category);
            }
            switch (sortOrder)
            {
                case "price_desc":
                    CarD.Cars = CarD.Cars.OrderByDescending(s =>
                     s.Price);
                    break;

            }
        }
    }
}
