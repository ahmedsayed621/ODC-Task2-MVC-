using ODC_Task2__MVC_.Models;
using ODC_Task2__MVC_.ViewModel;
using System.Linq.Expressions;

namespace ODC_Task2__MVC_.Data.IServices
{
    public interface IEmpService
    {

        Employee Update(Employee emp);
        Task<bool> SaveAllAsync();
       
        Employee GetById(int id);
        IEnumerable<Employee> Get();
        Employee Create(Employee emp);
        Employee Delete(Employee obj);
    }
}
