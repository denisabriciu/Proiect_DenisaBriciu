namespace Proiect_DenisaBriciu.Models
{
    public class Brand
    {
        public int ID { get; set; }
        public string BrandName { get; set; }
        public ICollection<Car>? Cars { get; set; } 
    }
}
