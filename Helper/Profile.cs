using AutoMapper;
using ODC_Task2__MVC_.Models;
using ODC_Task2__MVC_.Static;
using ODC_Task2__MVC_.ViewModel;

namespace ODC_Task2__MVC_.Helper
{
    public class DomainProfile: Profile
    {
        public DomainProfile()
        {
            CreateMap<Employee,EmployeeVM>().ForMember(
                dest=>dest.Age,opt=>opt.MapFrom(src=>src.DateOfBirth.CalculateAge()));
            CreateMap<EmployeeVM, Employee>();

        }
    }
}
