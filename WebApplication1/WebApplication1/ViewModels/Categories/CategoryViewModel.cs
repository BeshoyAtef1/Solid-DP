using WebApplication1.ViewModels.Products;

namespace WebApplication1.ViewModels.Categories
{
    public class CategoryViewModel
    {
        public CategoryViewModel() 
        {
          //  Products = new List<ProductViewModel>();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }

        //public IEnumerable<ProductViewModel> Products { get; set; }
    }
}
