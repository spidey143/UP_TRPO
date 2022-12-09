using GOvnoKOd.Windows;
using Microsoft.EntityFrameworkCore;
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
using GOvnoKOd.Models;


namespace GOvnoKOd
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
            db.Sotrudniks.Load();
            // и устанавливаем данные в качестве контекста
            DataContext = db.Sotrudniks.Local.ToObservableCollection();
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            AddSotrudnikWindow AddSotrudnikWindow = new AddSotrudnikWindow(new Sotrudnik());
            if (AddSotrudnikWindow.ShowDialog() == true)
            {
                Sotrudnik Sotrudnik = AddSotrudnikWindow.Sotrudnik;
                db.Sotrudniks.Add(Sotrudnik);
                db.SaveChanges();
            }
        }
        // редактирование
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            // получаем выделенный объект
            Sotrudnik? sotrudnik = usersList.SelectedItem as Sotrudnik;
            // если ни одного объекта не выделено, выходим
            if (sotrudnik is null) return;

            AddSotrudnikWindow AddSotrudnikWindow = new AddSotrudnikWindow(new Sotrudnik
            {
                Id = sotrudnik.Id,
                Personal_Id = sotrudnik.Personal_Id,
                Last_name = sotrudnik.Last_name,
                First_name = sotrudnik.First_name,
                Patronymic = sotrudnik.Patronymic,
                Date_of_birth = sotrudnik.Date_of_birth,
                Phone = sotrudnik.Phone,
                Department = sotrudnik.Department,

            });

            if (AddSotrudnikWindow.ShowDialog() == true)
            {
                // получаем измененный объект
                sotrudnik = db.Sotrudniks.Find(AddSotrudnikWindow.Sotrudnik.Id);
                if (sotrudnik != null)
                {
                    sotrudnik.Personal_Id = AddSotrudnikWindow.Sotrudnik.Personal_Id;
                    sotrudnik.Last_name = AddSotrudnikWindow.Sotrudnik.Last_name;
                    sotrudnik.First_name = AddSotrudnikWindow.Sotrudnik.First_name;
                    sotrudnik.Patronymic = AddSotrudnikWindow.Sotrudnik.Patronymic;
                    sotrudnik.Date_of_birth = AddSotrudnikWindow.Sotrudnik.Date_of_birth;
                    sotrudnik.Phone = AddSotrudnikWindow.Sotrudnik.Phone;
                    sotrudnik.Department = AddSotrudnikWindow.Sotrudnik.Department;

                    db.SaveChanges();
                    usersList.Items.Refresh();
                }
            }
        }
        // удаление
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            // получаем выделенный объект
            Sotrudnik? sotrudnik = usersList.SelectedItem as Sotrudnik;
            // если ни одного объекта не выделено, выходим
            if (sotrudnik is null) return;
            db.Sotrudniks.Remove(sotrudnik);
            db.SaveChanges();
        }

    }
}
