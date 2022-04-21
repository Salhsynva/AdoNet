using AdoNet.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace AdoNet.Sql
{
    public class SqlReservationData
    {
        public void AddReservation(Reservation reservation)
        {
            using (SqlConnection sqlCon = new SqlConnection(Sql.SqlServer))
            {
                sqlCon.Open();
                string query = $"INSERT INTO Reservations VALUES (StadionId,UserId,StartDate,EndDate) ({reservation.StadionId}, {reservation.UserId}, {reservation.StartDate}, {reservation.EndDate})";
                SqlCommand sqlCommand = new SqlCommand(query, sqlCon);
                sqlCommand.ExecuteNonQuery();
            }
        }

        public List<Reservation> GetReservation()
        {
            List<Reservation> reservations = new List<Reservation>();
            using (SqlConnection sqlCon = new SqlConnection(Sql.SqlServer))
            {
                string query = "SELECT * FROM Reservations";
                sqlCon.Open();
                SqlCommand sqlCommand = new SqlCommand(query, sqlCon);
                using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        Reservation reservation = new Reservation()
                        {
                            Id = dataReader.GetInt32(0),
                            StadionId = dataReader.GetInt32(1),
                            UserId = dataReader.GetInt32(2),
                            StartDate = dataReader.GetDateTime(3),
                            EndDate = dataReader.GetDateTime(4),
                        };
                        reservations.Add(reservation);
                    }
                }
            }
            return reservations;
        }



    }
}
