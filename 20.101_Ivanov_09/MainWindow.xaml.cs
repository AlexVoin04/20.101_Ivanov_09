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
            
            var result = Helper.GetContext().Teachers.ToList();//список учителей
            result = result.OrderBy(x => x.LastName).ToList();
            
            LoadData.ItemsSource = result;//вывод списка учителей
        }


        private void btn_search_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var result = Helper.GetContext().Teachers.ToList();//получение списка учителей
                result = result.Where(x => x.Speciality.Title == "09.02.07 Информационные системы и программирование").ToList();//поиск по специальности
                result = result.OrderBy(x => x.LastName).ToList();//сортировка
                if (result.ToList().Count > 0)//проверка на наличие записи
                {
                    LoadData.ItemsSource = null;
                    LoadData.ItemsSource = result.ToList();
                }
                else
                {
                    MessageBox.Show("Результат поиска отсутствует!");
                }
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
            
        }
    }
}
