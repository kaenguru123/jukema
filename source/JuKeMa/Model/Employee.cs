using System;

namespace JuKeMa.Model
{
    class Employee
    {
        public Employee(
                            string ntuser = default(string),
                            string name = default(string),
                            string address = default(string),
                            DateTime hireDate = default(DateTime),
                            DateTime birthday = default(DateTime),
                            string department = default(string)
                        )
        {
            this.NTUser = ntuser;
            this.Name = name;
            this.Address = address;
            this.HireDate = hireDate;
            this.Birthday = birthday;
            this.Department = department;
        }

        public string NTUser { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime Birthday { get; set; }
        public string Department { get; set; }
    }
}
