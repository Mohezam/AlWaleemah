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
            //Permissions = new MainRepository<Permission>(_context);
            RepoCategory = new RepoCategory(_context);

        }

        public IRepoProduct Products { get; }

        public IRepository<Category> Categories { get; }
        //public IRepository<Permission> Permissions { get; }

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
