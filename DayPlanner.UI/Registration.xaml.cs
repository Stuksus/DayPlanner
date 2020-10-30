using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DayPlanner.Classes;

namespace DayPlanner.UI
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
        }
        //метод регестриующий нового пользователя
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            User NewUser = new User
            {
                FirstName = FirstNameSpace.Text,
                LastName = LastNameSpace.Text,
                Login = LoginSpace.Text,
                Password = PasswordSpace.Password,
                Tasks = new List<Task>()

            };
            Main main = new Main();
            main.Users.Add(NewUser);
            main.SaveData();
            MainWindow mainWindow = new MainWindow(NewUser);
            mainWindow.Show();
            this.Close();
        }
    }
}
