using System.ComponentModel.DataAnnotations;

namespace Contact_Manager.Models
{
    public class UpdateContact
    {
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public bool Married { get; set; }
        [Required]
        public string Phone { get; set; } = null!;
        [Required]
        [Range(0, 100000)]
        public decimal Salary { get; set; }
    }
}
