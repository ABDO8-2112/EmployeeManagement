using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementWeb.Models
{
    public class EmployeeModel
    {
        [Display(Name = "Employee ID")]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "First name is required")]
        [StringLength(50)]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [StringLength(50)]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Position")]
        public string Position { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Salary must be positive")]
        [Display(Name = "Salary")]
        public decimal Salary { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Hiring Date")]
        public DateTime DateHired { get; set; } = DateTime.Now;
    }
}
