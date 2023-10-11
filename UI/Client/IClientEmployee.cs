using API.Models;

namespace UI.Client
{
    public interface IClientEmployee
    {
        public Task<IEnumerable<Employee>> GetAll();
        public Task<Employee> GetById(int Id);
        public Task<string> AddEdit(Employee emp);
    }
}
