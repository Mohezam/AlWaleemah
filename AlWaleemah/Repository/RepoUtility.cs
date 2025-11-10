using AlWaleemah.Data;
using AlWaleemah.Models;
using AlWaleemah.Repository.Base;

namespace AlWaleemah.Repository
{
    public class RepoUtility : MainRepository<Utility>, IRepoUtilities
    {
        private readonly Applicationdbcontext _context;

        public RepoUtility(Applicationdbcontext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Utility> GetByType(UtilityType type)
        {
            return _context.Utilities
                .Where(u => u.Type == type && u.IsActive)
                .OrderBy(u => u.Name)
                .ToList();
        }

        public IEnumerable<Utility> GetByCategory(string category)
        {
            return _context.Utilities
                .Where(u => u.Category == category && u.IsActive)
                .OrderBy(u => u.Name)
                .ToList();
        }

        public IEnumerable<Utility> GetActiveUtilities()
        {
            return _context.Utilities
                .Where(u => u.IsActive)
                .OrderBy(u => u.Type)
                .ThenBy(u => u.Name)
                .ToList();
        }

        public IEnumerable<string> GetCategories()
        {
            return _context.Utilities
                .Where(u => u.IsActive && !string.IsNullOrEmpty(u.Category))
                .Select(u => u.Category)
                .Distinct()
                .OrderBy(c => c)
                .ToList();
        }

    }
}
