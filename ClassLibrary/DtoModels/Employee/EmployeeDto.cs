using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections.Generic;

namespace ClassLibrary.DtoModels.Employee
{
    public class EmployeeDto
    {
        public int Id { get; set; } // Employee's unique identifier

        public string FirstName { get; set; } // Employee's first name

        public string LastName { get; set; } // Employee's last name

        public string Email { get; set; } // Employee's email address

        public DateTime DateCreated { get; set; } // Date when the employee was created

        public string AdminName { get; set; } // Name of the admin who created the employee

        public List<string> DepartmentNames { get; set; } // Names of the departments the employee is associated with
    }
}
