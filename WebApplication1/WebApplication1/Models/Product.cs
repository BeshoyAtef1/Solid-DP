using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("Products")]
    public class Product : BaseModel
    {
        public string Name { get; set; }
        public double UnitPrice { get; set; }
        public double MaxDiscount { get; set; }

        public Category Category { get; set; }
    }
}
