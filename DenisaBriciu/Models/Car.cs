using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;
using System.Xml.Linq;

namespace Proiect_DenisaBriciu.Models
{
    public class Car
    {
        public int ID { get; set; }
        [Display(Name = "Car Name")]
        public string Name { get; set; }

        [Column(TypeName = "decimal(6, 2)")]
        public decimal Price { get; set; }

        [Display(Name = "Manufacturing Date")]
        [DataType(DataType.Date)]
        public DateTime ManufacturingYear { get; set; }
        public int? BrandID { get; set; }
        public Brand? Brand{ get; set; }
        [Display(Name = "Specifications")]
        public ICollection<CarCategory>? CarCategories { get; set; }
    }
}
