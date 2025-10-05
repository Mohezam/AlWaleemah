using AlWaleemah.Data;
using AlWaleemah.Models;
using AlWaleemah.Repository.Base;

namespace AlWaleemah.Repository
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly Applicationdbcontext _context;

        public UnitOfWork(Applicationdbcontext context)
        {
            _context = context;
            Products = new RepoProduct(_context);
            Categories = new MainRepository<Category>(_context);
            Employees    = new RepoEmployee(_context);
            Permission = new MainRepository<Permission>(_context);
            RepoCategory = new RepoCategory(_context);
            Employee = new MainRepository<Employee>(_context);

        }

        public IRepoProduct Products { get; }

        public IRepository<Category> Categories { get; }
        public IRepository<Permission> Permission { get; }

        //public IRepository<Employee> Employees { get; }
        public IRepoEmployee Employees { get; }

        public IRepoCategory RepoCategory { get; }

        public IRepository<Employee> Employee { get; }




        public void Save()
        {
            _context.SaveChanges();
        }

    }
}
