using System.Linq.Expressions;
using WebApplication1.Models;

namespace WebApplication1.Data.Repositories
{
    public class GeneralRepository<T> : IGeneralRepository<T> where T : BaseModel
    {
        Context _context;

        public GeneralRepository() 
        { 
            _context = new Context();
        }

        public void Add(T category)
        {
            _context.Set<T>().Add(category);
        }

        public void Update(T category)
        {

        }
        
        public void Remove(int id)
        {

        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression);
        }

        public T GetByID(int id)
        {
            return Get(x => x.ID == id).FirstOrDefault();
        }
    }
}
