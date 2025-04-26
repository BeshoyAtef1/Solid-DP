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
        public CategoryService()
        {
            _repository = new GeneralRepository<Category>();
        }

        public void Add(CategoryCreateViewModel viewModel)
        {
            var category = new Category { Name = viewModel.Name };
            _repository.Add(category);
        }

        public void Update(CategoryEditViewModel viewModel)
        {
            var category = viewModel.Map<Category>();
            _repository.Update(category);
        }

        public void Remove(int id)
        {

        }

        public CategoryEditViewModel GetEditable(int id)
        {
            return _repository.Get(x => x.ID == id)
                .ProjectTo<CategoryEditViewModel>()
                .FirstOrDefault();
        }

        public CategoryViewModel GetByName(string name)
        {
            return _repository.Get(x => x.Name.Contains(name))
                .Select(c => new CategoryViewModel
                { 
                    ID = c.ID,
                    Name = c.Name
                }).FirstOrDefault();
        }

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
