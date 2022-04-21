using AdoNet.Model;
using AdoNet.Sql;
using System;
using System.Data.SqlClient;

namespace AdoNet
{
    class Program
    {
        
        static void Main(string[] args)
        {
            string answer;
            SqlData sqlData = new SqlData();
            SqlUserData sqlUserData = new SqlUserData();
            SqlReservationData sqlReservData = new SqlReservationData();
            do
            {
                Console.WriteLine("======MENU======");
                Console.WriteLine("1. Stadion elave et\n2.Stadionları göster\n3.Verilmiş id - li stadionu göster\n4.Verilmiş id - li stadionu sil\n5.İstifadeçi elave et\n6.İstifadeçileri göster\n7.Rezervasiya yarat\n8.Rezervasiyalari goster\n9.Verilmiş id - li stadionun rezervasiyalarını göster\n0.Proqramdan cix");
                Console.WriteLine("seciminizi edin:");
                answer = Console.ReadLine();
                switch (answer)
                {
                    case "1":
                        Console.WriteLine("stadionun adini daxil edin: ");
                        string name = Console.ReadLine();
                        Console.WriteLine("stadionun saatliq qiymetini daxil edin: ");
                        decimal hourlyPrice = GetDecimal();
                        Console.WriteLine("stadionun capacity'sini daxil edin: ");
                        int capacity = GetInt();
                        Stadion stadion = new Stadion()
                        {
                            Name = name,
                            HourlyPrice = hourlyPrice,
                            Capacity = capacity
                        };
                        sqlData.AddStadion(stadion);
                        break;
                    case "2":
                        foreach (var item in sqlData.GetStadions())
                        {
                            Console.WriteLine(item.Id + " " + item.Name + " "+ item.Capacity + " " + item.HourlyPrice);
                        } 
                        break;
                    case "3":
                        Console.WriteLine("id daxil edin: ");
                        int id = GetInt();
                        var result = sqlData.GetStadionById(id);
                        result.ShowInfo();
                        break;
                    case "4":
                        Console.WriteLine("id daxil edin: ");
                        int deleteid = GetInt();
                        sqlData.DeleteStadionById(deleteid);
                        break;
                    case "5":
                        Console.WriteLine("userin adini ve soyadini daxil edin: ");
                        string fullname = Console.ReadLine();
                        Console.WriteLine("userin emailini daxil edin: ");
                        string email = Console.ReadLine();
                        User user = new User()
                        {
                            Fullname = fullname,
                            Email = email
                        };
                        sqlUserData.AddUser(user);
                        break;
                    case "6":
                        foreach (var item in sqlUserData.GetUsers())
                        {
                            item.ShowInfo();
                        }
                        break;
                    case "7":
                        Console.WriteLine("reservasiyanin baslama saatini daxil edin: ");
                        DateTime startDate = GetDatetime();
                        Console.WriteLine("reservasiyanin bitme saatini daxil edin: ");
                        DateTime endDate = GetDatetime();
                        Console.WriteLine("stadionId daxil edin: ");
                        int stadionId = GetStadionId();
                        Console.WriteLine("userId daxil edin: ");
                        int userId = GetUserId();
                        Reservation reservation = new Reservation()
                        {
                            StadionId = stadionId,
                            UserId = userId,
                            StartDate = startDate,
                            EndDate = endDate
                        };
                        sqlReservData.AddReservation(reservation);
                        break;
                    case "8":
                        foreach (var item in sqlReservData.GetReservation())
                        {
                            item.ShowInfo();
                        }
                        break;
                    case "9":
                        break;
                    case "0":
                        Console.WriteLine("program bitdi");
                        break;
                    default:
                        Console.WriteLine("menuda bele secim yoxdur");
                        break;
                }
            } while (answer != "0");
        }

        static decimal GetDecimal()
        {
            string decStr = Console.ReadLine();
            decimal dec;
            while (!decimal.TryParse(decStr,out dec))
            {
                Console.WriteLine("eded daxil edin");
                decStr = Console.ReadLine();
            }
            return dec;
        }
        static int GetInt()
        {
            string intStr = Console.ReadLine();
            int number;
            while (!int.TryParse(intStr, out number))
            {
                Console.WriteLine("eded daxil edin");
                intStr = Console.ReadLine();
            }
            return number;
        }
        static DateTime GetDatetime()
        {
            string dateTimeStr = Console.ReadLine();
            DateTime date;
            while (!DateTime.TryParse(dateTimeStr, out date))
            {
                Console.WriteLine("tarix daxil edin");
                dateTimeStr = Console.ReadLine();
            }
            return date;
        }
        static int GetStadionId()
        {
            int id = GetInt();
            while (!Reservation.CheckStadionId(id))
            {
                Console.WriteLine("duzgun eded daxil edin!");
                id = GetInt();
            }
            return id;
        }
        static int GetUserId()
        {
            int id = GetInt();
            while (!Reservation.CheckUserId(id))
            {
                Console.WriteLine("duzgun eded daxil edin!");
                id = GetInt();
            }
            return id;
        }
    }
}
