using AdoNet.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace AdoNet.Sql
{
    public class SqlData
    {
        public void AddStadion(Stadion stadion)
        {
            using (SqlConnection sqlCon = new SqlConnection(Sql.SqlServer))
            {
                string query = $"INSERT INTO Stadions (Name,HourPrice,Capacity) VALUES ('{stadion.Name}',{stadion.HourlyPrice},{stadion.Capacity})";
                sqlCon.Open();
                SqlCommand sqlCommand = new SqlCommand(query, sqlCon);
                sqlCommand.ExecuteNonQuery();
            }
        }
        public void DeleteStadionById(int id)
        {
            using (SqlConnection sqlCon = new SqlConnection(Sql.SqlServer))
            {
                string query = $"DELETE FROM Stadions WHERE Id = @id";
                sqlCon.Open();
                SqlCommand sqlCommand = new SqlCommand(query, sqlCon);
                sqlCommand.Parameters.AddWithValue("@id", id);
                sqlCommand.ExecuteNonQuery();
            }
        }
        public Stadion GetStadionById(int id)
        {
            Stadion stadion = null;
            using (SqlConnection sqlCon = new SqlConnection(Sql.SqlServer))
            {
                string query = $"SELECT * FROM Stadions WHERE Id = @id";
                sqlCon.Open();
                SqlCommand sqlCommand = new SqlCommand(query, sqlCon);
                sqlCommand.Parameters.AddWithValue("@id", id);
                using (SqlDataReader dr = sqlCommand.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        stadion = new Stadion
                        {
                            Id = dr.GetInt32(0),
                            Name = dr.GetString(1),
                            HourlyPrice = dr.GetDecimal(2),
                            Capacity = dr.GetInt32(3)
                        };
                    }
                }
            }
            return stadion;
        }
        public List<Stadion> GetStadions()
        {
            List<Stadion> stadions = new List<Stadion>();
            using (SqlConnection sqlCon = new SqlConnection(Sql.SqlServer))
            {
                string query = $"SELECT * FROM Stadions";
                sqlCon.Open();
                using (SqlCommand sqlCommand = new SqlCommand(query, sqlCon))
                {
                    SqlDataReader dr = sqlCommand.ExecuteReader();
                    
                    while (dr.Read())
                    {
                        Stadion stadion = new Stadion()
                        {
                            Id = dr.GetInt32(0),
                            Name = dr.GetString(1),
                            HourlyPrice = dr.GetDecimal(2),
                            Capacity = dr.GetInt32(3)
                        };
                        stadions.Add(stadion);
                    }
                }
            }
            return stadions;
        }
        

    }
}
