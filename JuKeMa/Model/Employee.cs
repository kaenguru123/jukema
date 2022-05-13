using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuKeMa.Model
{
    class Employee
    {
        public string NTUser { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime Birthday { get; set; }

        public Department Department { get; set; }
    }

    class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
