namespace WebApplication1.Models
{
    public class Category : BaseModel
    {
        public Category() 
        {
            Products = new List<Product>();
        }

        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
