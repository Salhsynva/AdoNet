using AdoNet.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace AdoNet.Sql
{
    public class SqlUserData
    {
        public void AddUser(User user)
        {
            using (SqlConnection sqlCon = new SqlConnection(Sql.SqlServer))
            {
                string query = $"INSERT INTO Users (Fullname,Email) VALUES ('{user.Fullname}','{user.Email}')";
                sqlCon.Open();
                SqlCommand sqlCommand = new SqlCommand(query, sqlCon);
                sqlCommand.ExecuteNonQuery();
            }
        }
        public void DeleteUserById(int id)
        {
            using (SqlConnection sqlCon = new SqlConnection(Sql.SqlServer))
            {
                string query = $"DELETE FROM Users WHERE Id = @id";
                sqlCon.Open();
                SqlCommand sqlCommand = new SqlCommand(query, sqlCon);
                sqlCommand.Parameters.AddWithValue("@id", id);
                sqlCommand.ExecuteNonQuery();
            }
        }
        public List<User> GetUsers()
        {
            List<User> users = new List<User>();
            using (SqlConnection sqlCon = new SqlConnection(Sql.SqlServer))
            {
                string query = $"SELECT * FROM Users";
                sqlCon.Open();
                using (SqlCommand sqlCommand = new SqlCommand(query, sqlCon))
                {
                    SqlDataReader dr = sqlCommand.ExecuteReader();

                    while (dr.Read())
                    {
                        User user = new User()
                        {
                            Id = dr.GetInt32(0),
                            Fullname = dr.GetString(1),
                            Email = dr.GetString(2)
                        };
                        users.Add(user);
                    }
                }
            }
            return users;

        }


    }
}
