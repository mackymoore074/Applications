using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ClassLibrary.Models
{
    public class Agency
    {
        public Agency()
        {
            // Initialize the collections for Departments, Locations, Admins, and NewsItems
            Departments = new List<Department>();
            Locations = new List<Location>();
            Admins = new List<Admin>();
            Screen = new List<Screen>();

            // Initialize NewsItemAgencies (for many-to-many relationship) instead of NewsItems directly
            NewsItemAgencies = new List<NewsItemAgency>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<Department> Departments { get; set; }
        public ICollection<Screen> Screen { get; set; }
        public ICollection<Location> Locations { get; set; }
        public ICollection<Admin> Admins { get; set; }
        public ICollection<NewsItemAgency> NewsItemAgencies { get; set; }
        public DateTime DateCreated { get; internal set; }
    }
}
