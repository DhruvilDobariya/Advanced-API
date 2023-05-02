using JWTLearn.Models;
using System.Collections.Generic;

namespace JWTLearn.Data
{
    public class DbContext
    {
        public List<User> GetUsers()
        {
            return new List<User>()
            {
                new User () { Id = 1, UserName = "Dhruvil Dobariya", Password = "Dhruvil@123", Role = "Admin"},
                new User () { Id = 2, UserName = "Dhaval Dobariya", Password = "Dhaval@123", Role = "NormalUser"},
                new User () { Id = 3, UserName = "Dhruv Rathod", Password = "Dhruv@123", Role = "NormalUser"},
                new User () { Id = 4, UserName = "Jenil Vasoya", Password = "Jenil@123", Role = "NormalUser"},
                new User () { Id = 5, UserName = "Bhargav Vachhani", Password = "Bhargav@123", Role = "Admin"}
            };
        }
    }
}