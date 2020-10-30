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
    /// Логика взаимодействия для PropertiesWindow.xaml
    /// </summary>
    public partial class PropertiesWindow : Window
    {
        private User CurUser;
        private Main newMain = new Main();
        public PropertiesWindow(User user)
        {
            InitializeComponent();
            CurUser = user;
        }
        //метод отвечающий за создание задачи после заполненния полей
        public void AddTask(object sender, RoutedEventArgs e)
        {
            Task NewTask = new Task()
            {
                Name = NameSpace.Text,
                properties = new Properties()
                {
                    Description = DescriptionSpace.Text,
                    startTime = (DateTime)StartDate.SelectedDate,
                    endTime = (DateTime)EndDate.SelectedDate,
                }
            };
            foreach (User one in newMain.GetUsers())
            {
                if (one.Password == CurUser.Password  & one.Login == CurUser.Login)
                {
                    one.Tasks.Add(NewTask);
                }
            }
            newMain.SaveData();
            this.Close();

        }
    }
}
