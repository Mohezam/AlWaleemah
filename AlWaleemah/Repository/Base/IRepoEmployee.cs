using AlWaleemah.Models;

namespace AlWaleemah.Repository.Base
{
    public interface IRepoEmployee : IRepository<Employee>
    {

        Employee Login(string username, string password);

        IEnumerable<Employee> FindAllEmployee();


    }
}
