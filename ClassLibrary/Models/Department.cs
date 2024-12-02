using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ClassLibrary.Models
{
    public class Department
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } // Department name (e.g., "Mental Health", "Bliss")

        public string Description { get; set; } // Description of the department
        public DateTime DateCreated { get; set; }
        public int AgencyId { get; set; } // The agency this department belongs to  
        public Agency Agency { get; set; } // The agency this department belongs to
        public List<Admin> Admins { get; set; } = new List<Admin>(); // Admins linked to this department
        public List<Screen> Screens { get; set; } = new List<Screen>(); // Screens in the department
        public List<Employee> Employees { get; set; } = new List<Employee>(); // Employees in the department
        // Many-to-many relationship with NewsItems
        public ICollection<NewsItemDepartment> NewsItemDepartments { get; set; }

        public Department()
        {
            NewsItemDepartments = new List<NewsItemDepartment>();
        }
        public int LocationId { get; set; } // Foreign key to Location
        public Location Locations { get; set; } // Navigation property for Location


    }

}
