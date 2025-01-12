namespace Contact_Manager.Models
{
    public class UpdateContact
    {
        public string Name { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public bool Married { get; set; }
        public string Phone { get; set; } = null!;
        public decimal Salary { get; set; }
    }
}
