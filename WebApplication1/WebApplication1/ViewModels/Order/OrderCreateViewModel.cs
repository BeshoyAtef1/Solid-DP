namespace WebApplication1.ViewModels.Order
{
    public class OrderCreateViewModel
    {
        public DateTime Date { get; set; }
        public int CustimerID { get; set; }

        public ICollection<OrderDetailCreateViewModel> Details { get; set; }
    }
}
