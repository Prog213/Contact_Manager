using System.Threading;
using System.Xml.Linq;

namespace Contact_Manager.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public bool Married { get; set; }
        public string Phone { get; set; } = null!;
        public decimal Salary { get; set; }
    }
}
