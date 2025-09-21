using AlWaleemah.Data;
using AlWaleemah.Models;
using AlWaleemah.Repository.Base;

namespace AlWaleemah.Repository
{
    public class RepoEmployee : MainRepository<Employee>, IRepoEmployee
    {
        
        
            private readonly Applicationdbcontext _context;
            public RepoEmployee(Applicationdbcontext context) : base(context)
            {
                _context = context;
            }


            public Employee Login(string username, string password)
            {
                var emp = _context.Employees.FirstOrDefault(e => e.Username == username && e.Password == password);
                return emp;
            }

            public IEnumerable<Employee> FindAllEmployee()
            {
                return _context.Employees.ToList().Where(e => !e.IsDelete);
            }


            //public IEnumerable<Employee> FindAllEmployee()
            //{
            //    return _context.Employees.ToList().Where(e => !e.IsDelete);
            //}


        
    }
}
