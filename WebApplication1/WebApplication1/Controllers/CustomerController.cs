using Microsoft.AspNetCore.Mvc;
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
        public CustomerController()
        {
        }

        [HttpGet]
        public IEnumerable<CustomerViewModel> GetAll()
        {
            CustomerFakeDataService fakeDataService = new CustomerFakeDataService();

            return fakeDataService.Generate();

        }
    }
}