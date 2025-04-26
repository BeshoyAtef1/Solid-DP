namespace WebApplication1.ViewModels
{
    public class CustomerViewModel
    {
        public Guid GID { get; set; }
        public int ID { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public DateTime Birthdate { get; set; }
        public decimal Balance { get; set; }

        public string Country { get; set; }
        public string Governorate { get; set; }
    }
}
