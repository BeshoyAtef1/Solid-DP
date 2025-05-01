using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using WebApplication1.Data;
using WebApplication1.Data.Repositories;
using WebApplication1.Models;
using WebApplication1.Services;
using WebApplication1.ViewModels;
using WebApplication1.ViewModels.Categories;
using WebApplication1.ViewModels.Products;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CustomerController : ControllerBase
    {
        IMemoryCache _memoryCache;
        public CustomerController(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        [HttpGet]
        public IEnumerable<CustomerViewModel> GetAll()
        {
            CustomerFakeDataService fakeDataService = new CustomerFakeDataService();
            IEnumerable<CustomerViewModel> customers;

            _memoryCache.TryGetValue("customers", out customers);

            if (customers is null)
            {
                customers = fakeDataService.Generate();
                _memoryCache.Set("customers", customers, TimeSpan.FromHours(1));
            }

            var item = _memoryCache.GetOrCreate("test", entry => "hello");

            return customers;
        }
    }
}