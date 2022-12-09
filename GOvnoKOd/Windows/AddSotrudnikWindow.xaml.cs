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
using GOvnoKOd.Models;


namespace GOvnoKOd.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddSotrudnikWindow.xaml
    /// </summary>
        public partial class AddSotrudnikWindow : Window
        {
            public Sotrudnik Sotrudnik { get; private set; }
            public AddSotrudnikWindow(Sotrudnik sotrudnik)
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
