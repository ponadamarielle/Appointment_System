using AppointmentBusinessLogic;

namespace AppointmentSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("=== Welcome to Aesthetic Clinic! ===\n");
            DisplayServices();

            int userAction;

            do
            {
                DisplayActions();
                userAction = GetUserInput();

                switch (userAction)
                {
                    case 1:
                        BookAppointment();
                        break;

                    case 2:
                        CancelAppointment();
                        break;

                    case 3:
                        RescheduleAppointment();
                        break;

                    case 4:
                        LoginAsAdmin();
                        break;
                    case 5:
                        Console.WriteLine("EXIT\n");
                        break;
                    default:
                        Console.WriteLine("INVALID. Please enter between 1-5 only.");
                        break;
                }
            }
            while (userAction != 5);
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
                    "[2] Cancel Appointment",
                    "[3] Reschedule Appointment",
                    "[4] Login as Admin",
                    "[5] Exit"
                };

            Console.WriteLine("---------------------------");

            foreach (var action in actions)
            {
                Console.WriteLine(action);
            }

            Console.WriteLine("---------------------------");
        }

        public static int GetUserInput()
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

            Console.Write("Enter Mobile Number: ");
            string mobileNum = Console.ReadLine();

            Console.Write("Enter Email: ");
            string email = Console.ReadLine();

            DateOnly date;

            while (true)
            {
                Console.Write("Enter preferred date (yyyy-MM-dd): ");
                date = DateOnly.Parse(Console.ReadLine());

                if (AppointmentProcess.ValidateAppointmentDate(date))
                {
                    Console.WriteLine("[Valid Date]");
                    break;
                }
                else
                {
                    Console.WriteLine("[Invalid. Please enter a valid date]");
                }
            }

            Console.Write("Enter preferred time (HH:MM AM/PM): ");
            TimeOnly time = TimeOnly.Parse(Console.ReadLine());

            Console.Write("Enter Service: ");
            string service = Console.ReadLine();

            AppointmentProcess appointmentProcess = new AppointmentProcess();

            int appointmentId = appointmentProcess.GenerateAppointmentId();

            appointmentProcess.AddAppointment(appointmentId, name, mobileNum, email, date, time, service);
            Console.WriteLine($"Appointment Booked Successfully! Your appointment ID is {appointmentId}\n");
        }

        static void CancelAppointment()
        {
            Console.WriteLine("---------------------------");
            Console.WriteLine("=== Request Appointment Cancellation ===");

            Console.Write("Enter Appointment ID to cancel: ");
            int appointmentId = Convert.ToInt32(Console.ReadLine());

            AppointmentProcess appointmentProcess = new AppointmentProcess();

            if (appointmentProcess.RequestCancellation(appointmentId))
            {
                Console.WriteLine("Cancellation request submitted. The staff will review it.\n");
            }
            else
            {
                Console.WriteLine("Appointment not found or already cancelled.\n");
            }
        }

        static void RescheduleAppointment()
        {
            Console.WriteLine("---------------------------");
            Console.WriteLine("=== Request Appointment Reschedule ===");

            Console.Write("Enter Appointment ID: ");
            int appointmentId = Convert.ToInt32(Console.ReadLine());

            AppointmentProcess appointmentProcess = new AppointmentProcess();

            if (!appointmentProcess.ValidateAppointmentId(appointmentId))
            {
                Console.WriteLine("Invalid Appointment ID. Please try again.\n");
                return;
            }

            DateOnly date;

            while (true)
            {
                Console.Write("Enter Appointment Date (yyyy-MM-dd): ");
                date = DateOnly.Parse(Console.ReadLine());

                if (AppointmentProcess.ValidateAppointmentDate(date))
                {
                    Console.WriteLine("[Valid Date]");
                    break;
                }
                else
                {
                    Console.WriteLine("[Invalid. Please enter a valid date]");
                }
            }

            Console.Write("Enter new appointment time (HH:MM): ");
            TimeOnly newTime = TimeOnly.Parse(Console.ReadLine());

            if (appointmentProcess.RequestReschedule(appointmentId, date, newTime))
            {
                Console.WriteLine("Reschedule request submitted. The staff will review it.\n");
            }
            else
            {
                Console.WriteLine("Unable to request reschedule. Appointment ID might be invalid or status doesn't allow rescheduling.\n");
            }
        }

        static void LoginAsAdmin()
        {
            Console.WriteLine("=== LOGIN ===");

            Console.Write("Username: ");
            string username = Console.ReadLine();

            Console.Write("Password: ");
            string password = Console.ReadLine();

            if (AppointmentProcess.ValidateLogin(username, password))
            {
                Console.WriteLine("Login Successful!\n");
                Admin.HandleAdminActions();
            }
            else
            {
                Console.WriteLine("Invalid username & password\n");
            }
        }       
        }
    }

