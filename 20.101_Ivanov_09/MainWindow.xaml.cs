using _20._101_Ivanov_09.Classes;
using _20._101_Ivanov_09.Entity;
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

namespace _20._101_Ivanov_09
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var role = from rol in Helper.GetContext().Role select new { rol.IdRole, rol.Title};

            var query =
            from teacher in Helper.GetContext().Teachers
            orderby teacher.LastName
            
            select new { teacher.LastName, teacher.FirstName, teacher.Patronymic, teacher.Email, teacher.IdStatusTeachers, teacher.IdRole, teacher.IdSpeciality };
            //var result = Helper.GetContext().Teachers.ToList();
            //result = result.OrderBy(x => x.LastName).ToList();
            //join rol in Helper.GetContext().Role on ro
            LoadData.ItemsSource = query.ToList();
        }

        private void UpdateData()
        {
            

        }

        private void btn_search_Click(object sender, RoutedEventArgs e)
        {
            var query =
            from teacher in Helper.GetContext().Teachers
            where teacher.IdSpeciality == 1
            orderby teacher.LastName
            select new { teacher.LastName, teacher.FirstName, teacher.Patronymic, teacher.Email, teacher.IdStatusTeachers, teacher.IdRole, teacher.IdSpeciality };
            //var result = Helper.GetContext().Teachers.ToList();
            //result = result.Where(x => x.Speciality.Title == "09.02.07 Информационные системы и программирование").ToList();
            if (query.ToList().Count > 0)
            {
                LoadData.ItemsSource = null;
                LoadData.ItemsSource = query.ToList();
            }
            else
            {
                MessageBox.Show("Результат поиска отсутствует!");
            }
            
        }
    }
}
