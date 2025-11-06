using AppointmentBusinessLogic;
using Microsoft.Extensions.Configuration;

namespace AppointmentSystem
{
    public class Admin
    {
        private static IConfiguration configuration;

        public static void HandleAdminActions()
        {
            int action;

            do
            {
                DisplayAdminMenu();
                action = Program.GetUserInput();

                switch (action)
                {
                    case 1:
                        ViewAllAppointments();
                        break;
                    case 2:
                        SearchAppointment();
                        break;
                    case 3:
                        UpdateAppointmentStatus();
                        break;
                    case 4:
                        Console.WriteLine("Logout!");
                        break;
                    default:
                        Console.WriteLine("INVALID. Please enter between 1-4 only.\n");
                        break;
                }
            }
            while (action != 4);
        }
        static void DisplayAdminMenu()
        {
            string[] menu = new string[]
            {
                "[1] View All Appointments",
                "[2] Search Appointments",
                "[3] Update Appointment Status",
                "[4] Logout"
            };

            Console.WriteLine("=== Admin Menu ====");

            foreach (var m in menu)
            {
                Console.WriteLine(m);
            }
        }

        static void ViewAllAppointments()
        {
            Console.WriteLine("---------------------------");

            AdminProcess adminProcess = new AdminProcess();
            var appointments = adminProcess.GetAllAppointments();

            if (appointments.Count == 0)
            {
                Console.WriteLine("No scheduled appointments.\n");
                return;
            }

            Console.WriteLine("=== All Appointments: ===");

            foreach (var appointment in appointments)
            {
                string details = $"{appointment.Id} - {appointment.Name} - {appointment.MobileNumber} - {appointment.Email} - " +
                                 $"{appointment.Date} - {appointment.Time} - {appointment.Service} - {appointment.Status}";

                Console.WriteLine(details);
            }

            Console.WriteLine("");
        }


        static void SearchAppointment()
        {
            Console.WriteLine("---------------------------");

            Console.Write("Enter client name to search: ");
            string name = Console.ReadLine();

            Console.WriteLine("=== Search Results ===");

            AdminProcess adminProcess = new AdminProcess();
            string appointmentInfo = adminProcess.SearchAppointmentName(name);

            if (appointmentInfo != null)
            {
                Console.WriteLine(appointmentInfo);
            }
            else
            {
                Console.WriteLine("No appointments found.\n");
            }

            Console.WriteLine("");
        }

        static void UpdateAppointmentStatus()
        {
            Console.Write("\nEnter the appointment ID to update its status:");
            int appointmentId = Convert.ToInt32(Console.ReadLine());

            EmailService emailService = new EmailService(configuration);
            AppointmentProcess appointmentProcess = new AppointmentProcess(emailService);
            if (!appointmentProcess.ValidateAppointmentId(appointmentId))
            {
                Console.WriteLine("Invalid Appointment ID. Please try again.\n");
                return;
            }

            Console.WriteLine("Enter new status for appointment (Confirmed, Rescheduled, Cancelled, Completed):");
            string input = Console.ReadLine();

            AdminProcess adminProcess = new AdminProcess();
            if(!adminProcess.IsValidStatus(input))
            {
                Console.WriteLine("Invalid status input.Please enter a valid status(Confirmed, Rescheduled, Cancelled, Completed).\n");
                return;
            }

            bool update = adminProcess.UpdateAppointmentStatus(appointmentId, input, out string updatedStatus);

            if(update)
            {
                Console.WriteLine($"Appointment ID {appointmentId} status updated to {updatedStatus}.\n");
            }
            else
            {
                Console.WriteLine("Appointment ID not found or status update not allowed.\n");
            }
        }

    }
}
