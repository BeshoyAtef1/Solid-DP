using System.Linq.Expressions;
using WebApplication1.Models;

namespace WebApplication1.Data.Repositories
{
    public interface IGeneralRepository<T> where T : BaseModel
    {
        void Add(T category);
        void Update(T category);
        void Remove(int id);
        T GetByID(int id);
        IQueryable<T> GetAll();
        IQueryable<T> Get(Expression<Func<T, bool>> expression);
    }
}
