using AutoMapper;
using AutoMapper.QueryableExtensions;
using System.Linq.Expressions;
using WebApplication1.Data.Repositories;
using WebApplication1.Models;
using WebApplication1.ViewModels.Categories;

namespace WebApplication1.Services
{
    public class CategoryService
    {
        IGeneralRepository<Category> _repository;
        // IGeneralRepository<Product> _productRepository;
        //ProductService _productService;
        public CategoryService()//ProductService productService)
        {
            _repository = new GeneralRepository<Category>();
           // _productService = productService;
           // _productRepository = new GeneralRepository<Product>();
        }

        //public async Task Add(CategoryCreateViewModel viewModel)
        //{
        //    var category = new Category { Name = viewModel.Name };
        //    _repository.Add(category);

        //    await _repository.SaveChangesAsync();
        //}

        public void Update(CategoryEditViewModel viewModel)
        {
            var category = viewModel.Map<Category>();
            _repository.Update(category);
        }

        public async Task Remove(int id)
        {
            _repository.Remove(id);

            await _repository.SaveChangesAsync();

          //  _productService.RemoveByCategoryID(id);

            //var products = _productRepository.Get(p => p.CategoryID == id);

            //foreach (var product in products)
            //{
            //    _productRepository.Remove(product.ID);
            //}
            
        }

        public CategoryEditViewModel GetEditable(int id)
        {
            return _repository.Get(x => x.ID == id)
                .ProjectTo<CategoryEditViewModel>()
                .FirstOrDefault();
        }

        //public CategoryViewModel GetByName(string name)
        //{
        //    return _repository.Get(x => x.Name.Contains(name))
        //        .Select(c => new CategoryViewModel
        //        { 
        //            ID = c.ID,
        //            Name = c.Name
        //        }).FirstOrDefault();
        //}

        public IEnumerable<CategoryViewModel> GetAll()
        {
            //return _repository.GetAll()
            //    .Select(c => new CategoryViewModel
            //    {
            //        ID = c.ID,
            //        Name = c.Name,
            //    });

            return _repository.GetAll()
                .ProjectTo<CategoryViewModel>()
                .ToList();
        }

        public CategoryViewModel GetByID(int id)
        {
            return _repository.Get(c => c.ID == id)
                .Select(c => new CategoryViewModel
                {
                    ID = c.ID,
                    Name = c.Name
                }).FirstOrDefault();
        }
    }
}
