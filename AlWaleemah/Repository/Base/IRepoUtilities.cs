using AlWaleemah.Models;

namespace AlWaleemah.Repository.Base
{
    public interface IRepoUtilities : IRepository<Utility>
    {
        IEnumerable<Utility> GetByType(UtilityType type);
        IEnumerable<Utility> GetByCategory(string category);
        IEnumerable<Utility> GetActiveUtilities();
        IEnumerable<string> GetCategories();

    }
}
