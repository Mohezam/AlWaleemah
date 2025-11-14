using AlWaleemah.Models;

namespace AlWaleemah.Repository.Base
{
    public interface IProductRepository
    {
        void Update(Product product);
        void UpdateRange(IEnumerable<Product> products);
    }
}
