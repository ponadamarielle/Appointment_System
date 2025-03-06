using System;
using System.Collections;

namespace AppointmentSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> appointments = new List<string>();
            List<int> cancelledAppointment = new List<int>();

            Console.WriteLine("Welcome to Aesthetic Clinic!\n");

            string[] services = new string[]
            {
                "* Whitening Peel",
                "* Facial Treatment",
                "* Chemical Peeling",
                "* Facial Focusing Acne",
                "* Laser Treatment\n"
            };

            Console.WriteLine("Available Services");

            foreach (var service in services)
            {
                Console.WriteLine(service);
            }

            Boolean bl = true;

            while (bl)
            {
                string[] actions = new string[]
                {
                    "[1] Book Appointment",
                    "[2] View Appointments",
                    "[3] Cancel Appointment",
                    "[4] Exit\n"
                };

                foreach (var action in actions)
                {
                    Console.WriteLine(action);
                }
                Console.Write("Enter Action: ");
                int userAction = Convert.ToInt16(Console.ReadLine());

                switch (userAction)
                {
                    case 1:
                        Console.Write("Enter Name: ");
                        string name = Console.ReadLine();

                        Console.Write("Enter Appointment Date (YYYY-MM-DD): ");
                        string date = Console.ReadLine();

                        Console.Write("Enter Appointment Time (HH:MM AM/PM): ");
                        string time = Console.ReadLine();

                        Console.Write("Enter Service: ");
                        string service = Console.ReadLine();

                        appointments.Add(name + " - " + date + " - " + time + " - " + service);
                        Console.WriteLine("Appointment Booked Successfully!\n");
                        break;

                    case 2:
                        if (appointments.Count == 0)
                        {
                            Console.WriteLine("No scheduled appointments.\n");
                            break;
                        }

                        Console.WriteLine("Scheduled Appointments: ");
                        for (int a = 0; a < appointments.Count; a++)
                        {
                            Console.WriteLine(a + 1 + ". " + appointments[a]);
                        }
                        Console.WriteLine("\n");
                        break;

                    case 3:
                        if (appointments.Count == 0)
                        {
                            Console.WriteLine("There are no appointments to cancel\n");
                            break;
                        }

                        Console.WriteLine("Scheduled Appointments: ");
                        cancelledAppointment.Clear();

                        int indexNum = 1;
                        for (int a = 0; a < appointments.Count; a++)
                        {
                            if (!appointments[a].Contains("[CANCELLED]"))
                            {
                                cancelledAppointment.Add(a);
                                Console.WriteLine(indexNum + ". " + appointments[a]);
                                indexNum++;
                            }
                        }
                        Console.WriteLine("");

                        Console.Write("Enter Appointment number: ");
                        int appointmentNum = Convert.ToInt16(Console.ReadLine());

                        if (appointmentNum >= 1 && appointmentNum <= cancelledAppointment.Count)
                        {
                            int index = cancelledAppointment[appointmentNum - 1];
                            appointments[index] += "[CANCELLED]";
                            Console.WriteLine("Appointment has been successfully cancelled.\n");
                        }
                        break;

                    case 4:
                        Console.WriteLine("THANK YOU");
                        bl = false;
                        break;
                }
            }


        }

    }
}

