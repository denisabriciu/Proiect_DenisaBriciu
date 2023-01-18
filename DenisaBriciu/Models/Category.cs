using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Proiect_DenisaBriciu.Models
{
    public class Category
    {
        public int ID { get; set; }
        [Display(Name = "Specifications")]
        public string CategoryName { get; set; }
        
        public ICollection<CarCategory>? CarCategories { get; set; }
    }
}
