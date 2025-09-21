using AlWaleemah.Models;

namespace AlWaleemah.Repository.Base
{
    public interface IRepoCategory : IRepository<Category>

    {
        Category FindByUIdCategory(string uid);


    }
}
