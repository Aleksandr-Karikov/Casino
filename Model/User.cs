using Casino.Helper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Casino.Model
{
    class User
    {
        public string Login { get; set; }
        public int? Id { get; set; }
        public int? Balance { get; set; }
        public async Task Register(string login,string password)
        {
            using (SqlConnection connection = new SqlConnection(QweryHelper.ConnectionString))
            {
                connection.Open();
                SqlCommand checkLoginCommand = new SqlCommand(QweryHelper.GetUserQwery(login), connection);
                SqlDataReader reader = await checkLoginCommand.ExecuteReaderAsync();
                if (reader.HasRows)
                {
                    throw new Exception("Пользователь с таким логином уже существует");
                }
                SqlCommand setUserCommand = new SqlCommand(QweryHelper.SetUserQwery(login,password), connection);
                await setUserCommand.ExecuteNonQueryAsync();
                
            }
        }

        public async Task LoginUser(string login, string password)
        {
            using (SqlConnection connection = new SqlConnection(QweryHelper.ConnectionString))
            {
                connection.Open();
                SqlCommand checkLoginCommand = new SqlCommand(QweryHelper.GetUserQwery(login,password), connection);
                SqlDataReader reader = await checkLoginCommand.ExecuteReaderAsync();
                if (!reader.HasRows)
                {
                    throw new Exception("Такого пользователя не существует");
                }
                while (reader.Read())
                {
                    Id = reader.GetInt32(0);
                    Login = reader.GetString(1);
                    Balance = reader.GetInt32(2);
                }
            }
        }
        public async Task AddBalance(int balance)
        {
            using (SqlConnection connection = new SqlConnection(QweryHelper.ConnectionString))
            {
                connection.Open();
                SqlCommand SetBalance = new SqlCommand(QweryHelper.AddBalanceQwery(balance), connection);
                await SetBalance.ExecuteNonQueryAsync();

            }
        }
        public async Task SetBalance(int balance)
        {
            using (SqlConnection connection = new SqlConnection(QweryHelper.ConnectionString))
            {
                connection.Open();
                SqlCommand SetBalance = new SqlCommand(QweryHelper.SetBalanceQwery(balance), connection);
                await SetBalance.ExecuteNonQueryAsync();

            }
        }
        public async Task UpdateDatas()
        {
            if (Id == null)
            {
                throw new Exception("Что пошло не так");
            }
            using (SqlConnection connection = new SqlConnection(QweryHelper.ConnectionString))
            {
                connection.Open();
                SqlCommand GetDatasCommand = new SqlCommand(QweryHelper.GetUserQwery(Id), connection);
                SqlDataReader reader = await GetDatasCommand.ExecuteReaderAsync();
                if (!reader.HasRows)
                {
                    throw new Exception("Что-то пошло не так");
                }
                while (reader.Read())
                {
                    Id = reader.GetInt32(0);
                    Login = reader.GetString(1);
                    Balance = reader.GetInt32(2);
                }
            }
        }
    }
}
