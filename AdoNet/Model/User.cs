using System;
using System.Collections.Generic;
using System.Text;

namespace AdoNet.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }

        public void ShowInfo()
        {
            Console.WriteLine($"id: {Id} - ad soyad: {Fullname} - email: {Email}");
        }
    }
}
