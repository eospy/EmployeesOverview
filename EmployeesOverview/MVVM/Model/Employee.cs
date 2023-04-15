namespace EmployeesOverview.MVVM.Model
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Position { get; set; }
        public int Salary { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; } = null!;
        public Employee(string name, string surname, string position, int salary)
        {
            Name = name;
            Surname = surname;
            Position = position;
            Salary = salary;
        }
    }
}
