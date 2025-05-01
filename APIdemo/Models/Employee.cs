using System.ComponentModel.DataAnnotations;

namespace APIdemo.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Email {  get; set; }

        public int DepartmentId { get; set; }

        public Department? Department { get; set; }
    }
}
