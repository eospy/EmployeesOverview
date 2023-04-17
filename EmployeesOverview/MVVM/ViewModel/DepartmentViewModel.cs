using EmployeesOverview.Core;
using EmployeesOverview.DataControl;
using EmployeesOverview.MVVM.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EmployeesOverview.MVVM.ViewModel
{
    public class DepartmentViewModel : ViewModelBase
    {
        DatabaseContext db;
        public RelayCommand DeleteEmployeeCommand { get; set; }
        public RelayCommand DeleteOfficeCommand { get; set; }
        public RelayCommand SaveChangesCommand { get; set; }
        public RelayCommand CancelChangesCommand { get; set; }
        public RelayCommand AddDepartmentCommand { get; set; }
        public RelayCommand AddEmployeeCommand { get; set; }
        public RelayCommand AddOfficeCommand { get; set; }

        private string _depNameTextBox;
        private string _depAddressTextBox;

        private string _nameTextBox;
        private string _surnameTextBox;
        private string _positionTextBox;
        private string _salaryTextBox;
        private string _roomNumberTextBox;
        private string _officeNameTextBox;

        private Department _selectedDepartment;
        private Office _selectedOffice;
        private Employee _selectedEmployee;
        private List<Office> _officesToRemove { get; set; }
        private List<Employee> _employeesToRemove { get; set; }
        private ObservableCollection<Department> _departments;

        public DepartmentViewModel()
        {
            db = App.GetDb();
            _departments = GetDepartments();
            DeleteEmployeeCommand = new RelayCommand(o => DeleteEmployee());
            DeleteOfficeCommand = new RelayCommand(o => DeleteOffice());
            SaveChangesCommand = new RelayCommand(o => SaveChanges());
            CancelChangesCommand = new RelayCommand(o => CancelChanges());
            AddDepartmentCommand = new RelayCommand(o => AddDepartment());
            AddEmployeeCommand = new RelayCommand(o => AddEmployee());
            AddOfficeCommand = new RelayCommand(o => AddOffice());
            _officesToRemove = new List<Office>();
            _employeesToRemove = new List<Employee>();
        }
        private void DeleteEmployee()
        {
            if (_selectedEmployee != null)
            {
                _employeesToRemove.Add(_selectedEmployee);
                _selectedDepartment.Employees.Remove(_selectedEmployee);
            }
        }
        private void SaveChanges()
        {
            foreach (var e in _employeesToRemove)
            {
                _selectedDepartment.Employees.Remove(e);
            }
            foreach (var o in _officesToRemove)
            {
                _selectedDepartment.Offices.Remove(o);
            }
            _employeesToRemove.Clear();
            _officesToRemove.Clear();
            var department = db.Departments.Find(_selectedDepartment.Id);
            department = _selectedDepartment;
            db.SaveChanges();
        }
        private void CancelChanges()
        {
            foreach (var e in _employeesToRemove)
            {
                _selectedDepartment.Employees.Add(e);
            }
            foreach (var o in _officesToRemove)
            {
                _selectedDepartment.Offices.Add(o);
            }
        }
        private void DeleteOffice()
        {
            if (_selectedOffice != null)
            {
                _officesToRemove.Add(_selectedOffice);
                _selectedDepartment.Offices.Remove(_selectedOffice);
            }
        }
        private void AddEmployee()
        {
            if (int.TryParse(_salaryTextBox, out int salary))
            {
                Employee employee = new(_nameTextBox, _surnameTextBox, _positionTextBox, salary)
                {
                    Department = SelectedDepartment
                };
                _selectedDepartment.Employees.Add(employee);
                var department = db.Departments.Find(_selectedDepartment.Id);
                department = _selectedDepartment;
                db.SaveChanges();
            }

        }
        private void AddOffice()
        {
            if (int.TryParse(_roomNumberTextBox, out int roomnumber))
            {
                Office office = new Office(roomnumber, _officeNameTextBox);
                office.Department= _selectedDepartment;
                _selectedDepartment.Offices.Add(office);
                var department = db.Departments.Find(_selectedDepartment.Id);
                department = _selectedDepartment;
                db.SaveChanges();
            }
                
        }
        private void AddDepartment()
        {
            Department department = new(_depNameTextBox, _depAddressTextBox);
            db.Departments.Add(department);
            Departments.Add(department);
            db.SaveChanges();
        }
        public ObservableCollection<Department> GetDepartments()
        {
            var offices = db.Offices.ToList();
            var data = new ObservableCollection<Department>();
            foreach (var d in db.Departments)
            {
                data.Add(d);
            }
            
            return data;
        }
        public string DepNameTextBox
        {
            get => _depNameTextBox;
            set => SetProperty(ref _depNameTextBox, value);
        }
        public string RoomNumberTextBox
        {
            get => _roomNumberTextBox;
            set => SetProperty(ref _roomNumberTextBox, value);
        }
        public string OfficeNameTextBox 
        {
            get => _officeNameTextBox;
            set => SetProperty(ref _officeNameTextBox, value);
        }
        public string DepAddressTextBox
        {
            get => _depAddressTextBox;
            set => SetProperty(ref _depAddressTextBox, value);
        }
        public string NameTextBox
        {
            get => _nameTextBox;
            set => SetProperty(ref _nameTextBox, value);
        }
        public string SurnameTextBox
        {
            get => _surnameTextBox;
            set => SetProperty(ref _surnameTextBox, value);
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
            get => _selectedDepartment;
            set =>SetProperty(ref _selectedDepartment, value);
        }
        public Office SelectedOffice
        {
            get => _selectedOffice;
            set => SetProperty(ref _selectedOffice, value);
        }
        public Employee SelectedEmployee
        {
            get => _selectedEmployee;
            set=> SetProperty(ref _selectedEmployee, value);
        }
        public ObservableCollection<Department> Departments
        {
            get => _departments;
            set => SetProperty(ref _departments, value);
        }
    }
}
