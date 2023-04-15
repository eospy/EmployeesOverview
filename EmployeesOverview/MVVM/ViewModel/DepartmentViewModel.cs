using EmployeesOverview.Core;
using EmployeesOverview.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesOverview.MVVM.ViewModel
{
    public class DepartmentViewModel:ViewModelBase
    {
        private Department _selectedDepartment;
        private ObservableCollection<Department> _departments;
        public DepartmentViewModel()
        {
            _departments=GetDepartments();
        }
        public ObservableCollection<Department> GetDepartments()
        {
            var db = App.GetDb();
            var data = new ObservableCollection<Department>();
            foreach (var d in db.Departments)
            {
                data.Add(d);
            }
            return data;
        }
        public Department SelectedDepartment
        {
            get => _selectedDepartment;
            set 
            {
                SetProperty(ref _selectedDepartment, value);
            } 
        }
        public ObservableCollection<Department> Departments
        {
            get => _departments;
            set => SetProperty(ref _departments, value);
        }
    }
}
