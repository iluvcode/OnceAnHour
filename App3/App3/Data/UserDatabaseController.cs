using System;
using System.Collections.Generic;
using System.Text;
using App3.Models;
using SQLite.Net;
using Xamarin.Forms;

namespace App3.Data
{
     public class UserDatabaseController
    {
        public object locker = new object();

        SQLiteConnection database;

        public UserDatabaseController()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();
            database.CreateTable<User>();
        }

        public User GetUser(string phoneNumber)
        {
            lock (locker)
            {
                if (database.Table<User>().Count() == 0)
                {
                    return null;
                }
                else
                {
                    return database.Table<User>().Where(a => a.PhoneNumber == phoneNumber).FirstOrDefault();
                }
            }
        }

        public int SaveUser(User user)
        {
            lock (locker)
            {
                var userInfo = GetUser(user.PhoneNumber);

                if (userInfo != null)
                {
                    userInfo.Country = user.Country;
                    userInfo.State = user.State;
                    userInfo.City = user.City;
                    userInfo.AgeGroup = user.AgeGroup;

                    database.Update(userInfo);
                    return userInfo.Id;
                }
                else
                {
                    return database.Insert(user);
                }
            }
        }
    }
}
