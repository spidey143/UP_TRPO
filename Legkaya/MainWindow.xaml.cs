using System;
using System.Collections.Generic;
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

namespace Legkaya
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void STAFF_Click(object sender, RoutedEventArgs e)
        {
            FRAME.Content = new STAFF();

        }

        private void ECO_Click(object sender, RoutedEventArgs e)
        {
            FRAME.Content = new ECO();
        }

        private void PLANS_Click(object sender, RoutedEventArgs e)
        {
            FRAME.Content = new PLANS();
        }

        private void ZAVOD_Click(object sender, RoutedEventArgs e)
        {
            FRAME.Content = new ZAVOD();
        }
    }
}
