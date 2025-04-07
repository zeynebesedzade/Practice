using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Models
{
    public class Appointment
    {
        public int No { get; set; }            
        public string Patient { get; set; }     
        public string Doctor { get; set; }      
        public DateTime StartDate { get; set; } 
        public DateTime EndDate { get; set; }

        public Appointment(int no, string patient, string doctor, DateTime startDate, DateTime endDate)
        {
            No = no;
            Patient = patient;
            Doctor = doctor;
            StartDate = startDate;
            EndDate = endDate;
        
        }
        
    }
}
