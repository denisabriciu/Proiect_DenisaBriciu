using System.Security.Policy;

namespace Proiect_DenisaBriciu.Models.ViewModels
{
    public class BrandIndexData
    {
        public IEnumerable<Brand> Brands { get; set; }
        public IEnumerable<Car> Cars { get; set; }

    }
}
