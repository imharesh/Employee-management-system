using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI2.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }

        // Department Name with length validation 

        [Required]
        [MaxLength(50, ErrorMessage = "Name cannot be more than 50 character")]
        public string DepartmentName { get; set; }


    }
}
