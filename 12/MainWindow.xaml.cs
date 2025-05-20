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

namespace _12
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<ToDo> TodoItems;
        public MainWindow()
        {

            InitializeComponent();
            TodoItems = new List<ToDo>
            {
                new ToDo("Зdas", new DateTime(2024, 1, 15), "asd"),
                new ToDo("asd", new DateTime(2024, 1, 12), "Мdas"),
                new ToDo("sda", new DateTime(2024, 1, 20), "asd")
            };
            descriptionToDo.Text = "Описания нет";
            dateToDo.SelectedDate = new DateTime(2024, 1, 10);


            listToDo.ItemsSource = TodoItems;


            listToDo.ItemsSource = null;
            listToDo.ItemsSource = TodoItems;

        }
        private void AddItem(object sender, RoutedEventArgs e)
        {
            string title = titleToDo.Text;
            DateTime date = (DateTime)dateToDo.SelectedDate;
            string description = descriptionToDo.Text;
            if (string.IsNullOrWhiteSpace(title))
            {
                MessageBox.Show("Введите название дела");
                return;
            }


            TodoItems.Add(new ToDo(title, date, description));

            listToDo.Items.Refresh();

            titleToDo.Text = null;
            dateToDo.SelectedDate = DateTime.Now;
            descriptionToDo.Text = "Описания нет";

            listToDo.ItemsSource = null;
            listToDo.ItemsSource = TodoItems;
        }
        private void KillItem(object sender, RoutedEventArgs e)
        {
            ToDo selectedToDo = listToDo.SelectedItem as ToDo;
            if (selectedToDo == null)
            {
                MessageBox.Show("Выберите дело для удаления");
                return;
            }

            TodoItems.Remove(selectedToDo);

            listToDo.ItemsSource = null;
            listToDo.ItemsSource = TodoItems;
        }
        private void CheckBox_Changed(object sender, RoutedEventArgs e)
        {
            if (groupBoxToDo == null) return;
            CheckBox checkBox = sender as CheckBox;
            if (checkBox != null)
            {
                if (checkBox.IsChecked == true)
                {
                    groupBoxToDo.Visibility = Visibility.Visible; 
                }
                else
                {
                    groupBoxToDo.Visibility = Visibility.Collapsed;
                }

            }

        }
    }
}
