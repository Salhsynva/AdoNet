using System;
using System.Collections.Generic;
using System.Text;

namespace AdoNet.Model
{
    public class Stadion
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal HourlyPrice { get; set; }
        public int Capacity { get; set; }

        public void ShowInfo()
        {
            Console.WriteLine(Id + " " + Name + " " + Capacity + " " + HourlyPrice);

        }

    }
}
