using Project1;
using System.Windows;
namespace Project1
{
    public partial class InfWindow : Window
    {
        public Employee Employee { get; private set; }
        public InfWindow(Employee employee)
        {
            InitializeComponent();
            Employee = employee;
            DataContext = Employee;
        }

        void Accept_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}