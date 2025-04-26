namespace WebApplication1.ViewModels.Products
{
    public class ProductViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string BrandName { get; set; }

        public double UnitPrice { get; set; }
        public double MaxDiscount { get; set; }

        public string CategoryName { get; set; }
    }
}
