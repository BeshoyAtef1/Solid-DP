using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using WebApplication1.CQRS.Categories;
using WebApplication1.CQRS.Categories.Commands;
using WebApplication1.CQRS.Categorys.Command;
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
        IDistributedCache _distributedCache;
        IMediator _mediator;

        public CategoryController(CategoryService service,
            ProductService productService,
            ILogger<CategoryController> logger,
            IDistributedCache distributedCache,
            IMediator mediator)
        {
            _service = service;
            _productService = productService;
            _logger = logger;
            _distributedCache = distributedCache;
            _mediator = mediator;
        }

        [HttpGet]
        public IEnumerable<CategoryViewModel> GetAll()
        {
            return _service.GetAll();

        }

        [HttpGet]
        public async Task<ResponseViewModel<CategoryViewModel>> GetByName(string name)
        {
            //var category = _service.GetByName(name);

            //_logger.LogWarning($"This is a warning test");
            //_logger.LogError($"This is an error test");

            var category = await _mediator.Send(new GetCategoryByNameQuery { Name = name });

            return ResponseViewModel<CategoryViewModel>.Success(category);
            
        }

        [HttpPost]
        public async void Add(CategoryCreateViewModel viewModel)
        {
            //_service.Add(viewModel);

            await _mediator.Send(new AddCategoryCommand { Name = viewModel.Name });

            _distributedCache.SetString(viewModel.Name, System.Text.Json.JsonSerializer.Serialize(viewModel),
                new DistributedCacheEntryOptions
                {
                    AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(60),
                    //AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(),
                    SlidingExpiration = TimeSpan.FromMinutes(10) 
                });
        }

        [HttpDelete]
        public async void Remove(int categorID)
        {
            //_service.Remove(categorID);

            //_productService.Remove(categorID);

            await _mediator.Send(new RemoveCategoryOrchestrator { Id = categorID });

        }
    }
}