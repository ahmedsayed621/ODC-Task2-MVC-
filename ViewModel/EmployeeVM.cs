using System.ComponentModel.DataAnnotations;

namespace ODC_Task2__MVC_.ViewModel
{
    public class EmployeeVM
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string JobTitle { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }
    }
}
