using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Models;

public class Hospital 
{
    private Appointment[] Appointments;
    private int appointmentCount = 0;

    public Hospital(int capacity)
    {
        Appointments = new Appointment[capacity];
    }

    public void AddAppointment(Appointment appointment)
    {
        if (appointmentCount < Appointments.Length)
        {
            Appointments[appointmentCount] = appointment;
            appointmentCount++;
            Console.WriteLine("Appointment uğurla elave olundu.");
        }
        else
        {
            Console.WriteLine("Daha çox appointment elave etmek üçün yer yoxdur.");
        }
    }

    public void EndAppointment(int appointmentNo)
    {
        bool found = false;
        for (int i = 0; i < appointmentCount; i++)
        {
            if (Appointments[i].No == appointmentNo)
            {
                found = true;
                if (Appointments[i].EndDate == null)
                {
                    Appointments[i].EndDate = DateTime.Now;
                    Console.WriteLine($"Appointment {appointmentNo} bitdi, bitmə vaxtı: {Appointments[i].EndDate}.");
                }
                else
                {
                    Console.WriteLine($"Appointment {appointmentNo} artıq bitmişdir.");
                }
                break;
            }
        }
        if (!found)
        {
            Console.WriteLine($"Appointment {appointmentNo} tapılmadı.");
        }
    }

    public Appointment GetAppointment(int appointmentNo)
    {
        for (int i = 0; i < appointmentCount; i++)
        {
            if (Appointments[i].No == appointmentNo)
            {
                return Appointments[i];
            }
        }
        return null;
    }

    public Appointment[] GetAllAppointments()
    {
        if (appointmentCount == 0)
        {
            Console.WriteLine("Heç bir appointment yoxdur.");
            return new Appointment[0];
        }

        Appointment[] result = new Appointment[0]; 
        for (int i = 0; i < appointmentCount; i++)
        {
            Array.Resize(ref result, result.Length + 1);
            result[i] = Appointments[i]; 
        }
        return result;
    }

    public Appointment[] GetWeeklyAppointments()
    {
        DateTime startOfWeek = DateTime.Now.AddDays(-(int)DateTime.Now.DayOfWeek);
        DateTime endOfWeek = startOfWeek.AddDays(7);

        Appointment[] weeklyAppointments = new Appointment[0];
        int index = 0;

        for (int i = 0; i < appointmentCount; i++)
        {
            if (Appointments[i].StartDate >= startOfWeek && Appointments[i].StartDate < endOfWeek)
            {
                Array.Resize(ref weeklyAppointments, weeklyAppointments.Length + 1);
                weeklyAppointments[index] = Appointments[i];
                index++;
            }
        }
        if (weeklyAppointments.Length == 0)
        {
            Console.WriteLine("Bu hefteye aid appointment yoxdur.");
        }
        return weeklyAppointments;
    }

    public Appointment[] GetTodaysAppointments()
    {
        DateTime startOfDay = DateTime.Today;
        DateTime endOfDay = DateTime.Today.AddHours(23).AddMinutes(59).AddSeconds(59).AddMilliseconds(999);

        Appointment[] todaysAppointments = new Appointment[0];
        int index = 0;

        for (int i = 0; i < appointmentCount; i++)
        {
            if (Appointments[i].StartDate >= startOfDay && Appointments[i].StartDate <= endOfDay)
            {
                Array.Resize(ref todaysAppointments, todaysAppointments.Length + 1);
                todaysAppointments[index] = Appointments[i];
                index++;
            }
        }
        if (todaysAppointments.Length == 0)
        {
            Console.WriteLine("Bugünkü appointment yoxdur.");
        }
        return todaysAppointments;
    }

    public Appointment[] GetAllContinuingAppointments()
    {
        Appointment[] continuingAppointments = new Appointment[0];
        int index = 0;

        for (int i = 0; i < appointmentCount; i++)
        {
            if (Appointments[i].EndDate == null)
            {
                Array.Resize(ref continuingAppointments, continuingAppointments.Length + 1);
                continuingAppointments[index] = Appointments[i];
                index++;
            }
        }
        if (continuingAppointments.Length == 0)
        {
            Console.WriteLine("Bitmemiş appointment yoxdur.");
        }
        return continuingAppointments;
    }
}


    




