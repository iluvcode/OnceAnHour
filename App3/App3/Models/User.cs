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

        [NotNull]
        public long PhoneNumber { get; set; }     
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string AgeGroup { get; set; }

        public User()
        {

        }

        public User(long phoneNumber,  string city, string state, string country, string ageGroup)
        {
            PhoneNumber = phoneNumber;
            City = city;
            State = state;
            Country = country;
            AgeGroup = ageGroup;
        }

        public User(long phoneNumber)
        {
            PhoneNumber = phoneNumber;
        }
               

        public bool CheckInformation()
        {
            if (string.IsNullOrEmpty(City) && string.IsNullOrEmpty(State) && string.IsNullOrEmpty(Country) && string.IsNullOrEmpty(AgeGroup))
                return false;

            return true;
        }
    }
}
