using Bogus;
using WebApplication1.ViewModels;

namespace WebApplication1.Services
{
    public class CustomerFakeDataService
    {
        Faker<CustomerViewModel> _faker;

        public CustomerFakeDataService()
        {
            _faker = new Faker<CustomerViewModel>()
                .RuleFor(c => c.GID, f => f.Random.Guid())
                .RuleFor(c => c.ID, f => f.IndexFaker + 1)
                .RuleFor(c => c.Name, f => f.Name.FullName())
                .RuleFor(c => c.Mobile, f => f.Phone.Random.Digits(12, 0, 9).ToString())
                .RuleFor(c => c.Birthdate, f => f.Date.Between(new DateTime(1990, 1, 1), new DateTime(2020, 1, 1)))
                .RuleFor(c => c.Country, f => f.Address.Country())
                .RuleFor(c => c.Governorate, f => f.Address.City())
                .RuleFor(c => c.Balance, f => f.Finance.Amount());
        }

        public IEnumerable<CustomerViewModel> Generate()
        {
            //return _faker.Generate(50);

            //return _faker.GenerateForever();

            return _faker.GenerateLazy(50);
        }
    }
}
