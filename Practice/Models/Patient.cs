using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Models
{
    public class Patient
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }

        public Patient(int id, string name, string surname)
        {
            Name = name;
            Surname = surname;
        }
    }
}

