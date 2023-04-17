using System;

namespace EmployeesOverview.DataControl
{
    public class DepartmentData
    {

        public class Rootobject
        {
            public Class1[] Property1 { get; set; }
        }

        public class Class1
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Address { get; set; }
            public Employee[] Employees { get; set; }
            public Office[] Offices { get; set; }
        }

        public class Employee
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Surname { get; set; }
            public string Position { get; set; }
            public int Salary { get; set; }
            public int DepartmentId { get; set; }
        }

        public class Office
        {
            public int Id { get; set; }
            public int Roomnumber { get; set; }
            public string Name { get; set; }
            public int DepartmentId { get; set; }
        }

    }
}
