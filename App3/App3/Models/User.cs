using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace App3.Models
{
    public class User
    {
        [PrimaryKey]
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public string FullName { get; set; }

        public string City { get; set; }
        public string State { get; set; }

        public string Country { get; set; }

        public string AgeGroup { get; set; }

        public User()
        {

        }

        public User(string username, string password, string confirmPassword, string fullname, string city, string state, string country, string ageGroup)
        {
            Username = username;
            Password = password;
            ConfirmPassword = confirmPassword;
            FullName = fullname;
            City = city;
            State = state;
            Country = country;
            AgeGroup = ageGroup;
        }

        public bool CheckIfPasswordMatches()
        {
            if (Password.Equals(ConfirmPassword))
                return true;

            return false;
        }

        public bool CheckInformation()
        {
            if (string.IsNullOrEmpty(Username) && string.IsNullOrEmpty(Password) && string.IsNullOrEmpty(FullName) && string.IsNullOrEmpty(City) && string.IsNullOrEmpty(State) && string.IsNullOrEmpty(Country) && string.IsNullOrEmpty(AgeGroup))
                return false;

            return true;
        }
    }
}
