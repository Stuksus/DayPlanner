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
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public Main mainLogin = new Main();
        public LoginWindow()
        {
            InitializeComponent();
            
        }
        // метод отвечающий за авторизацию пользователя и активацию главного окна
        private void SignIn(object sender, RoutedEventArgs e)
        {
            int flag = 0;
            User currentUser = new User();
            string current_login = LoginSpace.Text;
            string current_password = PasswordSpace.Password;
            foreach(User user in mainLogin.GetUsers())
            {
                if (user.Password == current_password & user.Login == current_login)
                {
                    flag = 1;
                    currentUser = user;
                }
                        
            }

            if (flag == 1)
            {
                MainWindow mainWindow = new MainWindow(currentUser);
                mainWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Пароль или Логин неверны");

            }

        }
        // метод отвечающий за активацию окна регистрации
        private void SignUp(object sender, RoutedEventArgs e)
        {
            Registration registration = new Registration();
            registration.Show();
            this.Close();
        }
    }
}
