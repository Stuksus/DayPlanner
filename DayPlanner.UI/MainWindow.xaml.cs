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
using DayPlanner.Classes;
using Newtonsoft.Json.Serialization;


namespace DayPlanner.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public User currentUser;
        //Конструктор в котором инициализируются элементы, а так же подтягиваются все задачи пользователя
        public MainWindow(User user)
        {
            InitializeComponent();
            currentUser = user;
            Title.Text = "Hello," + currentUser.FirstName + "!";
            foreach (Classes.Task one in currentUser.Tasks)
            {
                List.Items.Add(one);
            }

        }
        //Меод отвечающий за выход из учетной записи и возвращению к окну авторизации
        private void LoginOut(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
           
        }
        // метод отвечающий за добавление нового задания
        public void AddTask(object sender, RoutedEventArgs e)
        {
            PropertiesWindow newProp = new PropertiesWindow(currentUser);
            newProp.Show();
            
        }
        //Обновляет текущего юзера на другого или на того же, но подтягивая нвые данные из файлов
        public User UpdateUser(User user)
        {
            User newUser = null;
            Main newMain = new Main();
            foreach(User one in newMain.GetUsers())
            {
                if (one.Password == currentUser.Password & one.Login == currentUser.Login)
                {
                    newUser = one;
                }
            }
            return newUser;
        }
        // Метод отвечающий за обновления списка задач, необходим, чтобы обновить список после применения метода AddTask
        public void UpdateAndAddTask()
        {
            List.Items.Clear();
            currentUser = UpdateUser(currentUser);

            foreach (Classes.Task one in currentUser.Tasks)
            {
                List.Items.Add(one);
            }
        }

        public void ShowTasks(object sender, RoutedEventArgs e) => UpdateAndAddTask();

        //Метод отвечающий за удаление выбранной задачи
        public void DeleteTask(object sender, RoutedEventArgs e)
        {
            var task = (List.SelectedItem as Classes.Task);
            Main newMain = new Main();
            List<User> AllUser = newMain.GetUsers();
            int iterUser = 0;
            foreach (User one in AllUser)
            {
                
                if (one.Password == currentUser.Password & one.Login == currentUser.Login)
                {
                    int iter = 0;
                    foreach (Classes.Task task1 in one.Tasks)
                    {
                        
                        if (task1.Name == task.Name & task1.properties.Description == task.properties.Description)
                        {
                            newMain.Users[iterUser].Tasks.Remove(task1);
                            newMain.SaveData();
                            UpdateAndAddTask();
                            break;
                        }
                        iter += 1;
                    }
                }
                iterUser += 1;
            }




        }
    }
}
