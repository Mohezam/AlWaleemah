using AlWaleemah.Data;
using AlWaleemah.Models;
using AlWaleemah.Repository.Base;

namespace AlWaleemah.Repository
{
    public class RepoCategory : MainRepository<Category>, IRepoCategory
    {
        private readonly Applicationdbcontext _context;
        public RepoCategory(Applicationdbcontext context) : base(context)
        {
            _context = context;
        }

        public Category FindByUIdCategory(string uid)
        {
            Category Category = _context.Categories.FirstOrDefault(c => c.uid == uid);
            return Category;

        }
    }
}
