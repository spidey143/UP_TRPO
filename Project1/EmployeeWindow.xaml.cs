using Project1;
using System.Windows;
using System;

namespace Project1
{
    public partial class EmployeeWindow : Window
    {
        public Employee Employee { get; private set; }
        public EmployeeWindow(Employee employee)
        {
            InitializeComponent();
            Employee = employee;
            DataContext = Employee;
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(Employee.LastName)
                || String.IsNullOrEmpty(Employee.Name)
                || String.IsNullOrEmpty(Employee.Patronymic)
                || String.IsNullOrEmpty(Employee.Phone)
                || String.IsNullOrEmpty(Employee.Department)
                || String.IsNullOrEmpty(Employee.DateBirth))
            {
                MessageBox.Show("Не все поля заполнены!", "Ошибка"); return;
            }
            DialogResult = true;
        }
    }
}