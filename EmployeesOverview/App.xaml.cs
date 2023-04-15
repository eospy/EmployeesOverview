using EmployeesOverview.DataControl;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace EmployeesOverview
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static DatabaseContext _db;
        public App()
        {
            _db= new DatabaseContext();
        }
        public static DatabaseContext GetDb() => _db;
    }   
}
