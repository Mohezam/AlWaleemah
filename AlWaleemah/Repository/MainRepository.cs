using AlWaleemah.Data;
using AlWaleemah.Repository.Base;

namespace AlWaleemah.Repository
{
    public class MainRepository<T> : IRepository<T> where T : class
    {
        private readonly Applicationdbcontext _context;
        public MainRepository(Applicationdbcontext context)
        {
            _context = context;
        }


        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {

            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public IEnumerable<T> FindAll()
        {
            return _context.Set<T>().ToList();
        }

        public T FindById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
        }




    }
}
