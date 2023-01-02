using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ODC_Task2__MVC_.Data.IServices;
using ODC_Task2__MVC_.Models;
using ODC_Task2__MVC_.ViewModel;

namespace ODC_Task2__MVC_.Data.Services
{
    public class EmpService:IEmpService
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;
        public EmpService(IMapper mapper, AppDbContext context) {
            _mapper = mapper;
            _context = context;
        }

        public Employee Create(Employee emp)
        {
            
            
           _context.Add(emp);
            
           _context.SaveChanges();

            return _context.employees.OrderBy(a => a.Id).LastOrDefault();
           
            
        }

        public Employee Delete(Employee obj)
        {
            _context.employees.Remove(obj);
            _context.SaveChanges();

            return obj;
        }

        

        public Employee GetById(int id)
        {
            var data = _context.employees.Where(a => a.Id == id).FirstOrDefault();
            return data;
        }

        

        public Task<bool> SaveAllAsync()
        {
            throw new NotImplementedException();
        }

        public Employee Update(Employee emp)
        {
            _context.Entry(emp).State = EntityState.Modified;
            _context.SaveChanges();

            return _context.employees.Find(emp.Id);
        }

        public IEnumerable<Employee> Get()
        {
            IQueryable<Employee> data = GetEmployees();
            return data;
        }




        private IQueryable<Employee> GetEmployees()
        {
            return _context.employees.Select(a => a);
        }
    }
}
