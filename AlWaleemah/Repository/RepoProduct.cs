using AlWaleemah.Data;
using AlWaleemah.Models;
using AlWaleemah.Repository.Base;
using Microsoft.EntityFrameworkCore;

namespace AlWaleemah.Repository
{
    public class RepoProduct : MainRepository<Product>, IRepoProduct
    {


        private readonly Applicationdbcontext _context;
        public RepoProduct(Applicationdbcontext context) : base(context)
        {
            _context = context;
        }


        public IEnumerable<Product> FindAllproducts()
        {
            IEnumerable<Product> products = _context.Products.Include(e => e.Category).AsNoTracking().ToList();
            return products;
        }

        public Product FindByIdproduct(int id)
        {
            Product product = _context.Products.Include(e => e.Category).AsNoTracking().FirstOrDefault(p => p.Id == id);
            return product;
        }

        public Product FindByUIdproduct(string uid)
        {
            Product product = _context.Products.FirstOrDefault(c => c.Uid == uid);
            return product;

        }
    }
}
