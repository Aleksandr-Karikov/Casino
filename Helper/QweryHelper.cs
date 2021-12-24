using System;
using System.Collections.Generic;
using System.Text;

namespace Casino.Helper
{
    public static class QweryHelper
    {
        public static readonly string ConnectionString = System.Configuration.ConfigurationManager.
    ConnectionStrings["Casino"].ConnectionString;
        public static string GetUserQwery(int? Id)
        {
            return $"SELECT Id,Login,Balance FROM [User] Where Id={Id}";
        }
        public static string GetUserQwery(string login)
        {
            return $"SELECT Id,Login,Balance FROM [User] Where Login='{login}'";
        }
        public static string GetUserQwery(string login, string password)
        {
            return $"SELECT Id,Login,Balance FROM [User] Where Login='{login}' and Password='{password}'";
        }
        public static string SetUserQwery(string login,string password)
        {
            return $"Insert into [User] (Login,Password,Balance) Values ('{login}', '{password}',0)";
        }
        public static string AddBalanceQwery(int balance)
        {
            return $"Update [User] Set Balance+={balance}";
        }
        public static string SetBalanceQwery(int balance)
        {
            return $"Update [User] Set Balance={balance}";
        }
    }
}
