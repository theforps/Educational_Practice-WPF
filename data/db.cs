using educational_practice.models;
using System;
using System.Collections.Generic;

namespace educational_practice.data
{
    public class db
    {
        public static int counter = 0;
        public static int idOfUser;

        public static List<User> users = new List<User>
        {
            new User()
            {
                Id = ++counter,
                Login = "admin",
                Password = "admin",
                Email = "admin@admin.ru",
                Name = "admin",
                Roles = Roles.MANAGER.ToString()
            },

            new User()
            {
                Id = ++counter,
                Login = "user",
                Password = "user",
                Email = "user@user.ru",
                Name = "user",
                Roles = Roles.USER.ToString()
            },

            new User()
            {
                Id = ++counter,
                Login = "executor",
                Password = "executor",
                Email = "executor@executor.ru",
                Name = "executor",
                Roles = Roles.EXECUTOR.ToString()
            },

        };

        public static List<string> faults = new List<string>() 
        { 
            "Брак", 
            "Короткое замыкание", 
            "Износ" 
        };

        public static List<Order> orders = new List<Order>
        {
            new Order()
            {
                Id = 0,
                Model = "Телефон",
                Description = "Не делает Алё",
                Type = "Сломалась трубка",
                Status = "В ожидании",
                date = DateTime.Now,
                idUser = 2,
                idExecuter = 2
            }
        };
    }
}
