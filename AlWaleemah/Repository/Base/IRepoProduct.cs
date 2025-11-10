using AlWaleemah.Models;

namespace AlWaleemah.Repository.Base
{
    public interface IRepoProduct:IRepository<Product>
    {

        IEnumerable<Product> FindAllproducts();

        Product FindByIdproduct(int id);
        Product FindByUIdproduct(string uid);

    }
}
