using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using Newtonsoft.Json;


namespace DayPlanner.Classes
{
    /*
     * Домашнее задание по предмету программирование
     * Тема задания была выбрана из предложенных,
     * а именно "Personal scheduler application"
     * Выполнил Сметанин Антон группа 1909
     */
    public class Main
    {

        public List<User> Users = new List<User>();
        public List<Task> TaskArray = new List<Task>();
        public Main()
        {
            try
            {
                ReadData();
            }
            catch
            {
                CreateFirstData();
                SaveData();
            }

        }
        //метод отвечающий за получения списка пользователей
        public List<User> GetUsers()
        {
            return Users;
        }

        //метод отвечающий за сохранение данных в файл 
        private void SaveList<T>(string fileName, List<T> data)
        {
            using (var sw = new StreamWriter(fileName))
            {
                using (var jsonWriter = new JsonTextWriter(sw))
                {
                    var serializer = new JsonSerializer()
                    {
                        Formatting = Formatting.Indented
                    };
                    serializer.Serialize(jsonWriter, data);
                }
            }
        }

        // Метод отвечающий за чтение данных из файлов
        private List<T> ReadList<T>(string fileName)
        {
            using (var sr = new StreamReader(fileName))
            {
                using (var jsonReader = new JsonTextReader(sr))
                {
                    var serializer = new JsonSerializer();
                    return serializer.Deserialize<List<T>>(jsonReader);
                }
            }
        }
        //метод отвечающий за инициализацию чтения данных
        private void ReadData()
        {
            TaskArray = ReadList<Task>("tasks.json");
            Users = ReadList<User>("users.json");
        }
        //метод отвечающий за инициализацию сохранения данных
        public void SaveData()
        {
            SaveList("users.json", Users);
            SaveList("tasks.json", TaskArray);
        }

        private void CreateFirstData()
        {
            Users = new List<User>
            {
                new User
                {
                    FirstName = "Admin",
                    LastName = "Admin",
                    Login = "root",
                    Password = "toor",
                    Tasks = new List<Task>()
                }
            };
            TaskArray = new List<Task>
            {
                new Task{
                    Name = "test",
                    properties = new Properties{Description = "Test task",
                        startTime = new DateTime(2020,1,13),
                        endTime = new DateTime(2020,1,14)}
                }
            };
            Users[0].Tasks.Add(TaskArray[0]);

        }
    }

}
