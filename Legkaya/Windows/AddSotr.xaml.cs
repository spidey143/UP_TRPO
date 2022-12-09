using Legkaya.models;
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
using System.Windows.Shapes;
using Legkaya.Windows;

namespace Legkaya
{
    /// <summary>
    /// Логика взаимодействия для ADD_SOTR.xaml
    /// </summary>
    public partial class AddSotrRWindow : Window
    {
        public Sotrudnik Sotrudnik { get; private set; }
        public AddSotrRWindow(Sotrudnik sotrudnik)
        {
            InitializeComponent();
            Sotrudnik = sotrudnik;
            DataContext = Sotrudnik;
        }

        void Accept_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
