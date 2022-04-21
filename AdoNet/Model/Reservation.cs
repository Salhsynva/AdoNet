using AdoNet.Sql;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdoNet.Model
{
    public class Reservation
    {
        int _stadionId;
        int _userId;
        public int Id { get; set; }
        public int StadionId { get => _stadionId; set { if (CheckStadionId(value)) _stadionId = value; } }
        public int UserId { get => _userId; set { if (CheckUserId(value)) _userId = value; } }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public static bool CheckStadionId(int id)
        {
            SqlData sqlData = new SqlData();
            if (sqlData.GetStadions().Exists(x => x.Id == id))
            {
                return true;
            }
            return false;
        }
        public static bool CheckUserId(int id)
        {
            SqlUserData sqluserData = new SqlUserData();
            if (sqluserData.GetUsers().Exists(x => x.Id == id))
            {
                return true;
            }
            return false;
        }
        public void ShowInfo()
        {
            Console.WriteLine($"id: {Id} - userId: {UserId} - stadionId: {StadionId} - startdate: {StartDate} - enddate: {EndDate}");
        }

    }
}
