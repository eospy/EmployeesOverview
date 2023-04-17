using EmployeesOverview.Core;
using EmployeesOverview.DataControl;
using EmployeesOverview.MVVM.Model;
using EmployeesOverview.MVVM.View;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesOverview.MVVM.ViewModel
{
    public class EmployeesViewModel: ViewModelBase
    {
        DatabaseContext db;
        public RelayCommand AddEmployeeCommand { get; set; }
        public RelayCommand OpenDepartmentsCommand { get; set; }
        public RelayCommand OpenSerializationCommand { get; set; }
        public RelayCommand SaveChangesCommand { get; set; }
        private string _nameTextBox;
        private string _surnameTextBox;
        private string _positionTextBox;
        private string _salaryTextBox;

        private Department _selectedDepartment;
        private Employee _selectedEmployee;
        private ObservableCollection<Employee> _employees;
        private ObservableCollection<Department> _departments;
        public EmployeesViewModel()
        {
            db = App.GetDb();
            _departments = GetDepartments();
            _employees = GetEmployees();
            AddEmployeeCommand = new RelayCommand(o => AddEmployee());
            SaveChangesCommand = new RelayCommand(o => SaveChanges());
            OpenDepartmentsCommand = new RelayCommand(o => OpenDepartments());
            OpenSerializationCommand = new RelayCommand(o => OpenSerialization());
        }
        private void AddEmployee()
        {
            if (int.TryParse(_salaryTextBox,out int salary))
            {
                Employee employee = new(_nameTextBox, _surnameTextBox, _positionTextBox, salary)
                {
                    Department = SelectedDepartment
                };
                db.Employees.Add(employee);
                Employees.Add(employee);
                db.SaveChanges();
            }
           
        }
        private void SaveChanges()
        {
            var employee=db.Employees.Find(_selectedEmployee.Id);
            int salary;
            employee.Salary = _selectedEmployee.Salary;
            employee.Position = _selectedEmployee.Position;
            SelectedEmployee = employee;
            db.SaveChanges();

        }

        private void OpenSerialization()
        {
            SerializationView view = new();
            view.Show();
        }
        private void OpenDepartments()
        {
            DepartmentView view = new();
            view.Show();
        }
        public string NameTextBox
        {
            get => _nameTextBox;
            set=>SetProperty(ref _nameTextBox, value);
        }
        public string SurnameTextBox
        {
            get => _surnameTextBox;
            set=>SetProperty(ref _surnameTextBox,value);
        }
        public string PositionTextBox
        {
            get => _positionTextBox;
            set => SetProperty(ref _positionTextBox, value);
        }
        public string SalaryTextBox
        {
            get => _salaryTextBox;
            set => SetProperty(ref _salaryTextBox, value);
        }
        public Department SelectedDepartment
        {
            get=> _selectedDepartment;
            set=> SetProperty(ref _selectedDepartment, value);
        }
        public Employee SelectedEmployee
        {
            get => _selectedEmployee;
            set
            {
                SetProperty(ref _selectedEmployee, value);
            } 
        }
        public ObservableCollection<Employee> Employees
        {
            get => _employees;
            set => SetProperty(ref _employees, value);
        }
        public ObservableCollection<Department> Departments
        {
            get => _departments;
            set=>SetProperty(ref _departments, value);
        }
        
        public ObservableCollection<Department> GetDepartments()
        {
            var data = new ObservableCollection<Department>();
            foreach(var d in db.Departments)
            {
                data.Add(d);
            }
            return data;
        }
        private ObservableCollection<Employee> GetEmployees()
        {
            var data =new ObservableCollection<Employee>();
            foreach (var e in db.Employees)
            {
                data.Add(e);
            }
            return data;
        }
    }
}
