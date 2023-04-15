using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeesOverview.MVVM.Model
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public List<Employee> Employees { get;}=new List<Employee>();
        public List<Office> Offices { get;} =new List<Office>();
        public Department(string name,string address)
        {
            Name = name;
            Address = address;
        }
    }
}
