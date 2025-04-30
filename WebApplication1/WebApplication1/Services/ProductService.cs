using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebApplication1.Data.Repositories;
using WebApplication1.Models;
using WebApplication1.ViewModels.Categories;
using WebApplication1.ViewModels.Products;

namespace WebApplication1.Services
{
    public class ProductService
    {
        IGeneralRepository<Product> _repository;
        
        public ProductService()
        {
            _repository = new GeneralRepository<Product>();
        }

        public IEnumerable<ProductViewModel> GetAll()
        {
            return _repository.GetAll()
                .ProjectTo<ProductViewModel>()
                .ToList();
        }

        public ProductViewModel GetByID(int id)
        {
            return _repository.Get(c => c.ID == id)
                .ProjectTo<ProductViewModel>()
                .FirstOrDefault();
        }

        public IEnumerable<ProductViewModel> GetByPrice(double price)
        {
            return _repository.Get(p => p.UnitPrice >= price)
                .ProjectTo<ProductViewModel>()
                .ToList();
        }

        public void Remove(int id)
        {
            _repository.Remove(id);
        }

        public async Task RemoveByCategoryID(int categoryID)
        {
            var products = _repository.Get(p => p.CategoryID == categoryID);

            foreach (var product in products)
            {
                Remove(product.ID);
            }

            await _repository.SaveChangesAsync();
        }

    }
}
