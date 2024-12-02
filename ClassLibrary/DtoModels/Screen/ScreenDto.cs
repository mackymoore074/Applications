using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.DtoModels.Screen
{
    public class ScreenDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DepartmentId { get; set; }
        public int LocationId { get; set; }
        public bool IsOnline { get; set; } 
        public string StatusMessage { get; set; }
        public string ScreenType { get; set; } 
        public DateTime DateCreated { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
