namespace EmployeesOverview.MVVM.Model
{
    public class Office
    {
        public int Id { get; set; }
        public int Roomnumber { get; set; }
        public string Name { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; } = null!;
        public Office(int roomnumber,string name)
        {
            Roomnumber = roomnumber;
            Name = name;
        }
    }
}
