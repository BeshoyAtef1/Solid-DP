using System.Linq.Expressions;
using WebApplication1.Data.Repositories;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class CategoryService
    {
        IGeneralRepository<Category> _repository;

        public CategoryService()
        {
            _repository = new GeneralRepository<Category>();
        }

        public void Add(Category category)
        {
            _repository.Add(category);
        }

        public void Update(Category category)
        {

        }

        public void Remove(int id)
        {

        }

        public Category GetByName(string name)
        {
            return _repository.Get(x => x.Name.Contains(name))
                .FirstOrDefault();
        }

        public IEnumerable<Category> GetAll()
        {
            return _repository.GetAll();
        }

        public Category GetByID(int id)
        {
            return _repository.GetByID(id);
        }
    }
}
