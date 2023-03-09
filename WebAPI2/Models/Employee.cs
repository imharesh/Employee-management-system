using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI2.Models
{
    public class Employee
    {
        //  1.  EmployeeId 
        public int EmployeeId { get; set; }

        //  2.  Name with validation  

        [Required]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Only string values are allowed")]
        [MaxLength(30, ErrorMessage = "Name cannot be more than 30 character")]
        public string Name { get; set; }

        //  3.  Age with validation 

        [Range(21, 100, ErrorMessage = "Age must be between 21 and 100")]
        public int Age { get; set; }

        //  4. Salary with Validation , Not allowed to string

        [RegularExpression("^[0-9]+$", ErrorMessage = "Only digits are allowed")]
        public double Salary { get; set; }

        // 5 . ForeignKey relation  
        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }
    }
}
