using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Data.Repositories;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CategoryController : ControllerBase
    {
        CategoryService _service;

        public CategoryController()
        {
            _service = new CategoryService();
        }

        [HttpGet]
        public IEnumerable<Category> GetAll()
        {
            return _service.GetAll();

        }

        public Category GetByName(string name)
        {
            return _service.GetByName(name);
        }
    }
}