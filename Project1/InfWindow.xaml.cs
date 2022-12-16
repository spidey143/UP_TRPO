using Project1;
using System.Windows;
namespace Project1
{
    public partial class InfWindow : Window
    {
        public User User { get; private set; }
        public InfWindow(User user)
        {
            InitializeComponent();
            User = user;
            DataContext = User;
        }

        void Accept_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}