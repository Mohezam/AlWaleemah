using AlWaleemah.Models;

namespace AlWaleemah.Repository.Base
{
    public interface IUnitOfWork
    {
        IRepoProduct Products { get; }

        IRepoEmployee Employees { get; }
        IRepoCategory RepoCategory { get; }

        IRepository<Category> Categories { get; }

        IRepository<Employee> Employee { get; }

        IRepository<Permission> Permission { get; }

        IRepoUtilities Utilities { get; }

        void Save(); 
    }
}
