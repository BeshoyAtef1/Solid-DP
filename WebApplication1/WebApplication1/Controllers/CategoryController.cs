using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Data.Repositories;
using WebApplication1.Models;
using WebApplication1.Services;
using WebApplication1.ViewModels;
using WebApplication1.ViewModels.Categories;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CategoryController : ControllerBase
    {
        CategoryService _service;
        ProductService _productService;
        ILogger<CategoryController> _logger;

        public CategoryController(CategoryService service,
            ProductService productService,
            ILogger<CategoryController> logger)
        {
            _service = service;
            _productService = productService;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<CategoryViewModel> GetAll()
        {
            return _service.GetAll();

        }

        [HttpGet]
        public ResponseViewModel<CategoryViewModel> GetByName(string name)
        {
            var category = _service.GetByName(name);

            _logger.LogWarning($"This is a warning test");
            _logger.LogError($"This is an error test");

            return ResponseViewModel<CategoryViewModel>.Success(category);
            
        }

        [HttpPost]
        public void Add(CategoryCreateViewModel viewModel)
        {
            _service.Add(viewModel);
        }

        [HttpDelete]
        public void Remove(int categorID)
        {
            _service.Remove(categorID);

            _productService.Remove(categorID);
        }
    }
}