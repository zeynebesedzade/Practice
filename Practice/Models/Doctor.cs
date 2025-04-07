using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Models
{
    public class Doctor
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public Doctor(int id, string name, string surname)
        {
            Name = name;
            Surname = surname;
        }
    }
}
