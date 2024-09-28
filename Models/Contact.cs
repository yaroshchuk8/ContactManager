using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ContactManager.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        public bool Married { get; set; }

        [Phone]
        public string Phone { get; set; }

        [Range(0, double.MaxValue)]
        [Precision(18, 2)]
        public decimal Salary { get; set; }
    }
}
