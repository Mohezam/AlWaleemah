using AlWaleemah.Models;
using Microsoft.EntityFrameworkCore.Storage;

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

        ICartItemRepository CartItemsRepository { get; }
       // IProductRepository ProductsRepository { get; }
        IOrderRepository OrdersRepository { get; }

        Task<int> SaveChangesAsync();


        Task<IDbContextTransaction> BeginTransactionAsync();

        void Save(); 
    }
}
