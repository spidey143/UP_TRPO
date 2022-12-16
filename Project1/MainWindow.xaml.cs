using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DocumentFormat.OpenXml.Drawing.Charts;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;

namespace Project1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ApplicationContext db = new ApplicationContext();
        public MainWindow()
        {
            InitializeComponent();

            Loaded += MainWindow_Loaded;
        }

        // при загрузке окна
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // гарантируем, что база данных создана
            db.Database.EnsureCreated();
            // загружаем данные из БД
            db.Employees.Load();
            // и устанавливаем данные в качестве контекста
            DataContext = db.Employees.Local.ToObservableCollection();
        }

        // добавление
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            EmployeeWindow EmployeeWindow= new EmployeeWindow(new Employee());
            if (EmployeeWindow.ShowDialog() == true)
            {
                Employee Employee = EmployeeWindow.Employee;
                db.Employees.Add(Employee);
                db.SaveChanges();
            }
        }
        // редактирование
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            // получаем выделенный объект
            Employee? employee = employeesList.SelectedItem as Employee;
            // если ни одного объекта не выделено, выходим
            if (employee is null) return;

            EmployeeWindow EmployeeWindow = new EmployeeWindow(new Employee
            {
                Id = employee.Id,
                PersonalId = employee.Id,
                LastName = employee.LastName,
                Name = employee.Name,
                Patronymic = employee.Patronymic,
                DateBirth = employee.DateBirth,
                Phone = employee.Phone,
                Department = employee.Department,
            });

            if (EmployeeWindow.ShowDialog() == true)
            {
                // получаем измененный объект
                employee = db.Employees.Find(EmployeeWindow.Employee.Id);
                if (employee != null)
                {
                    employee.PersonalId = EmployeeWindow.Employee.PersonalId;
                    employee.LastName = EmployeeWindow.Employee.LastName;
                    employee.Name = EmployeeWindow.Employee.Name;
                    employee.Patronymic = EmployeeWindow.Employee.Patronymic;
                    employee.DateBirth = EmployeeWindow.Employee.DateBirth;
                    employee.Phone = EmployeeWindow.Employee.Phone;
                    employee.Department = EmployeeWindow.Employee.Department;
                    db.SaveChanges();
                    employeesList.Items.Refresh();
                }
            }
        }
        //подробнее
        private void Inf_Click(object sender, RoutedEventArgs e)
        {
            // получаем выделенный объект
            Employee? employee = employeesList.SelectedItem as Employee;
            // если ни одного объекта не выделено, выходим
            if (employee is null) return;

            InfWindow InfWindow = new InfWindow(employee);
            if (InfWindow.ShowDialog() == true)
            {
                employee = db.Employees.Find(InfWindow.Employee.Id);
                if (employee != null)
                {
                    employeesList.Items.Refresh();
                }
            }
        }

        // удаление
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            // получаем выделенный объект
            Employee? employee = employeesList.SelectedItem as Employee;
            // если ни одного объекта не выделено, выходим
            if (employee is null) return;
            db.Employees.Remove(employee);
            db.SaveChanges();
        }

        private void ExcelImport_Click(object sender, RoutedEventArgs e)
        {
            Excel excel = new Excel(db.Employees);
        }
        private void Jason_export_Click(object sender, RoutedEventArgs e)
        {
            JasOn jason = new JasOn(db.Employees);
        }
    }
}