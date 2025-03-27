using System;
using System.Collections;
using AppointmentBusinessDataLogic;

namespace AppointmentSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("=== Welcome to Aesthetic Clinic! ===\n");
            DisplayServices();

            DisplayActions();
            int action = GetUserInput();


            while (action != 4)
            {

                switch (action)
                {
                    case 1:
                        BookAppointment();
                        break;

                    case 2:
                        ViewAppointments();
                        break;

                    case 3:
                        CancelAppointment();
                        break;

                    case 4:
                        Console.WriteLine("EXIT\n");
                        break;
                    default:
                        Console.WriteLine("INVALID. Please enter between 1-4 only.");
                        break;
                }
                DisplayActions();
                action = GetUserInput();
            }


        }
        static void DisplayServices()
        {
            string[] services = new string[]
            {
                "* Whitening Peel",
                "* Facial Treatment",
                "* Chemical Peeling",
                "* Facial Focusing Acne",
                "* Laser Treatment\n"};

            Console.WriteLine("=== Available Services ====");

            foreach (var service in services)
            {
                Console.WriteLine(service);
            }
        }

        static void DisplayActions()
        {
            string[] actions = new string[]
                {
                    "[1] Book Appointment",
                    "[2] View Appointments",
                    "[3] Cancel Appointment",
                    "[4] Exit"
                };

            Console.WriteLine("---------------------------");

            foreach (var action in actions)
            {
                Console.WriteLine(action);
            }

            Console.WriteLine("---------------------------");
        }

        static int GetUserInput()
        {
            Console.Write("\nEnter Action: ");
            int action = Convert.ToInt16(Console.ReadLine());

            return action;
        }

        static void BookAppointment()
        {
            Console.WriteLine("---------------------------");

            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Appointment Date (YYYY-MM-DD): ");
            string date = Console.ReadLine();

            Console.Write("Enter Appointment Time (HH:MM AM/PM): ");
            string time = Console.ReadLine();

            Console.Write("Enter Service: ");
            string service = Console.ReadLine();

            AppointmentProcess.AddAppointment(name, date, time, service);
            Console.WriteLine("Appointment Booked Successfully!\n");
        }

        static void ViewAppointments()
        {
            Console.WriteLine("---------------------------");

            if (AppointmentProcess.appointments.Count == 0)
            {
                Console.WriteLine("No scheduled appointments.\n");
                return;
            }

            Console.WriteLine("=== Scheduled Appointments: ===");
            for (int a = 0; a < AppointmentProcess.appointments.Count; a++)
            {
                Console.WriteLine(a + 1 + ". " + AppointmentProcess.appointments[a]);
            }
            Console.WriteLine("");
        }

        static void CancelAppointment()
        {
            Console.WriteLine("---------------------------");

            AppointmentProcess.ClearAvailableAppointments();

            DisplayAvailableAppointments();

            if (AppointmentProcess.availableAppointments.Count == 0)
            {
                Console.WriteLine("There are no available appointments to cancel.\n");
            }
            else
            {
                Console.Write("Enter appointment number to cancel: ");
                int appointmentNum = Convert.ToInt16(Console.ReadLine());

                if (AppointmentProcess.MarkAsCancelled(appointmentNum))
                {
                    Console.WriteLine("Appointment has been successfully cancelled.\n");
                }
                else
                {
                    Console.WriteLine("INVALID. Please enter a valid appointment number.\n");
                }
            }
        }

        static void DisplayAvailableAppointments()
        {

            int indexNum = 1;

            for (int a = 0; a < AppointmentProcess.appointments.Count; a++)
            {
                if (AppointmentProcess.AddAvailableAppointment(a))
                {
                    Console.WriteLine(indexNum + ". " + AppointmentProcess.appointments[a]);
                    indexNum++;
                }
            }

            Console.WriteLine("");
        }

    }
}

