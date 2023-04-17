using EmployeesOverview.Core;
using EmployeesOverview.DataControl;
using EmployeesOverview.MVVM.Model;
using Microsoft.Win32;
using Newtonsoft.Json;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using System.Windows;

namespace EmployeesOverview.MVVM.ViewModel
{
    public class SerializationViewModel:ViewModelBase
    {
        DatabaseContext db;
        public RelayCommand GetDepartmentsListCommand { get; set; }
        public RelayCommand SaveFileCommand { get; set; }
        public RelayCommand DownloadFileCommand { get; set; }
        private string _departmentsList;
        public SerializationViewModel()
        {
            db = App.GetDb();
            GetDepartmentsListCommand = new RelayCommand(o=>GetDepartments());
            SaveFileCommand = new RelayCommand(o => SaveFile());
            DownloadFileCommand = new RelayCommand(o => DownloadFile());
        }
        private void GetDepartments()
        {
            DepartmentsList = GetList();
        }
        private string GetList()
        {
            var offices = db.Offices.ToList();
            var departments = db.Departments;
            string list= JsonConvert.SerializeObject(departments, Formatting.Indented, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return list;
        }
        private void SaveFile()
        {
            string filetext = DepartmentsList ?? GetList();
            SaveFileDialog dialog = new()
            {
                Filter = "Text Files(*.txt)|*.txt|All(*.*)|*"
            };
            if (dialog.ShowDialog() == true)
            {
                 File.WriteAllText(dialog.FileName, filetext);
            }
        }
        private void DownloadFile()
        {
            OpenFileDialog dialog = new()
            {
                Filter = "Text Files(*.txt)|*.txt|All(*.*)|*"
            };
            if (dialog.ShowDialog() == true)
            {
                string filename = dialog.FileName;
                string fileText=File.ReadAllText(filename);
                try
                {
                    var root = Deserialize<DepartmentData.Class1>(fileText);
                    db.Database.EnsureDeleted();
                    db.Database.EnsureCreated();
                    foreach(var d in root)
                    {
                        Department department = new(d.Name, d.Address);
                        db.Departments.Add(department);
                        foreach(var e in d.Employees)
                        {
                            Employee employee = new(e.Name, e.Surname, e.Position, e.Salary);
                            employee.Department = department;
                            db.Employees.Add(employee);
                        }
                        foreach(var o in d.Offices)
                        {
                            Office office = new Office(o.Roomnumber, o.Name);
                            office.Department = department;
                            db.Offices.Add(office);
                        }
                    }
                    db.SaveChanges();
                }
                catch (Exception) { MessageBox.Show("Ошибка десериализации файла"); }
            }
        }
        public static List<T> Deserialize<T>(string SerializedJSONString)
        {
            return JsonConvert.DeserializeObject<List<T>>(SerializedJSONString);
        }
        public string DepartmentsList
        {
            get => _departmentsList;
            set=>SetProperty(ref _departmentsList, value);
        }
    }
}
