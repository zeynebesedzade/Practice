using System.ComponentModel.Design;
using Practice.Exceptions;
using Practice.Models;

namespace Practice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Nece appointment elave edek? ");
            int capacity = int.Parse(Console.ReadLine());
            Hospital hospital = new Hospital(capacity);
            int no = 1;

            
                Console.WriteLine("\n1. Appointment yarat");
                Console.WriteLine("2. Appointment-i bitir");
                Console.WriteLine("3. Bütün appointment-lere bax");
                Console.WriteLine("4. Bu heftedeki appointment-lere bax");
                Console.WriteLine("5. Bugünkü appointment-lere bax");
                Console.WriteLine("6. Bitmemiş appointmentlere bax");
                Console.WriteLine("7. Çıx");
                Console.Write("Seçim: ");
                string secim = Console.ReadLine();

                try
                {
                    if (secim == "1")
                    {
                        Console.Write("Xestenin adı: ");
                        string patientName = Console.ReadLine();

                        Console.Write("Xestenin soyadı: ");
                        string patientSurname = Console.ReadLine();

                        Console.Write("Hekimin adı: ");
                        string doctorName = Console.ReadLine();

                        Console.Write("Hekimin soyadı: ");
                        string doctorSurname = Console.ReadLine();

                        Console.Write("Başlama tarixi ve saatı (mes: 2025-04-10 14:00): ");
                        DateTime startDate = DateTime.Parse(Console.ReadLine());

                        Console.Write("Bitme tarixi ve saatı (mes: 2025-04-10 14:30): ");
                        DateTime endDate = DateTime.Parse(Console.ReadLine());

                        string fullPatientName = patientName + " " + patientSurname;
                        string fullDoctorName = doctorName + " " + doctorSurname;

                        Appointment a = new Appointment(no++, fullPatientName, fullDoctorName, startDate, endDate);
                        hospital.AddAppointment(a);
                    }
                    else if (secim == "2")
                    {
                        Console.Write("Appointment No: ");
                        int n = int.Parse(Console.ReadLine());
                        hospital.EndAppointment(n);
                    }
                    else if (secim == "3")
                    {
                        var appointments = hospital.GetAllAppointments();
                        if (appointments.Length > 0)
                        {
                            foreach (var appointment in appointments)
                            {
                                Console.WriteLine($"Appointment No: {appointment.No}, Patient: {appointment.Patient}, Doctor: {appointment.Doctor}");
                            }
                        }
                    }
                    else if (secim == "4")
                    {
                        var weeklyAppointments = hospital.GetWeeklyAppointments();
                        if (weeklyAppointments.Length > 0)
                        {
                            foreach (var appointment in weeklyAppointments)
                            {
                                Console.WriteLine($"Appointment No: {appointment.No}, Patient: {appointment.Patient}, Doctor: {appointment.Doctor}");
                            }
                        }
                    }
                    else if (secim == "5")
                    {
                        var todaysAppointments = hospital.GetTodaysAppointments();
                        if (todaysAppointments.Length > 0)
                        {
                            foreach (var appointment in todaysAppointments)
                            {
                                Console.WriteLine($"Appointment No: {appointment.No}, Patient: {appointment.Patient}, Doctor: {appointment.Doctor}");
                            }
                        }
                    }
                    else if (secim == "6")
                    {
                        var continuingAppointments = hospital.GetAllContinuingAppointments();
                        if (continuingAppointments.Length > 0)
                        {
                            foreach (var appointment in continuingAppointments)
                            {
                                Console.WriteLine($"Appointment No: {appointment.No}, Patient: {appointment.Patient}, Doctor: {appointment.Doctor}");
                            }
                        }
                    }
                else if (secim == "7")
                {
                    Console.WriteLine("Proqram bitdi.");
                }
                else
                {
                    Console.WriteLine("Yanlış seçim.");
                }
            }
                catch (NotFoundException ex)
                {
                    Console.WriteLine("Xeta: " + ex.Message);
                }
                catch
                {
                    Console.WriteLine("Naməlum xəta baş verdi.");
                }
            }
        }
    }

    

