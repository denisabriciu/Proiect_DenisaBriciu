using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Proiect_DenisaBriciu.Models
{
    public class Brand
    {
        public int ID { get; set; }
        [Display(Name = "Brand Name")]
        public string BrandName { get; set; }
        public ICollection<Car>? Cars { get; set; } 
    }
}
