using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Data.Repositories;
using WebApplication1.Models;
using WebApplication1.Services;
using WebApplication1.ViewModels.Categories;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CategoryController : ControllerBase
    {
        CategoryService _service;

        public CategoryController(CategoryService service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<CategoryViewModel> GetAll()
        {
            return _service.GetAll();

        }

        [HttpGet]
        public CategoryViewModel GetByName(string name)
        {
            return _service.GetByName(name);
        }

        [HttpPost]
        public void Add(CategoryCreateViewModel viewModel)
        {
            _service.Add(viewModel);
        }
    }
}