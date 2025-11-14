using AlWaleemah.Data;
using AlWaleemah.Models;
using AlWaleemah.Repository.Base;

namespace AlWaleemah.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly Applicationdbcontext _db;
        public ProductRepository(Applicationdbcontext db) => _db = db;

        public void Update(Product product) => _db.Products.Update(product);

        public void UpdateRange(IEnumerable<Product> products) => _db.Products.UpdateRange(products);
    }
}
