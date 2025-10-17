using AppointmentCommon;

namespace AppointmentDataLogic
{
    public class InMemoryDataService : IAppointmentDataProcess
    {
        List<Appointment> appointments = new List<Appointment>();

        private int appointmentId = 3;

        public InMemoryDataService()
        {
            CreateBooking();
        }

        private void CreateBooking()
        {
            appointments.Add(new Appointment
            {
                Id = 1,
                Name = "Jasmin Deyro",
                MobileNumber = "09156784962",
                Email = "jsmndyr@gmail.com",
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(-1)),
                Time = TimeOnly.Parse("4:00 PM"),
                Service = "Laser Treatment",
                Status = Status.Completed
            });

            appointments.Add(new Appointment
            {
                Id = 2,
                Name = "Marielle Ponada",
                MobileNumber = "09126578654",
                Email = "marielleponada@gmail.com",
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(2)),
                Time = TimeOnly.Parse("9:00 AM"),
                Service = "Facial Treatment",
                Status = Status.Confirmed
            });

            appointments.Add(new Appointment
            {
                Id = 3,
                Name = "Hecil Gesite",
                MobileNumber = "09634535621",
                Email = "heysill@gmail.com",
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(5)),
                Time = TimeOnly.Parse("1:00 PM"),
                Service = "Whitening Peel",
                Status = Status.Pending
            });

        }

        public bool AddAppointment(int appointmentId, string name, string mobileNum, string email, DateOnly date, TimeOnly time, string service)
        {
            Appointment newAppointment = new Appointment
            {
                Id = appointmentId,
                Name = name,
                MobileNumber = mobileNum,
                Email = email,
                Date = date,
                Time = time,
                Service = service,
                Status = Status.Pending
            };

            appointments.Add(newAppointment);

            return true;
        }

        public bool CancelAppointment(int appointmentId, string email)
        {
            Appointment appointment = GetAppointmentById(appointmentId);

            if (appointment == null)
            {
                return false;
            }

            //check email
            if (!appointment.Email.Equals(email, StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            appointment.Status = Status.CancelRequested;

            return true;
        }

        public List<Appointment> GetAllAppointments()
        {
            return appointments;
        }

        public Appointment GetAppointmentById(int id)
        {
            foreach (var appointment in appointments)
            {
                if (appointment.Id == id)
                {
                    return appointment;
                }
            }
            return null;
        }

        public List<Appointment> GetAppointmentByName(string name)
        {
            List<Appointment> results = new List<Appointment>();

            foreach (var appointment in appointments)
            {
                if (appointment.Name.ToLower().Contains(name.ToLower()))
                {
                    results.Add(appointment);
                }
            }

            return results;
        }

        public Status GetAppointmentStatus(int appointmentId)
        {
            var appointment = GetAppointmentById(appointmentId);

            if (appointment != null)
            {
                return appointment.Status;
            }

            return Status.Unknown;
        }

        public bool RescheduleAppointment(int appointmentId, string email, DateOnly newDate, TimeOnly newTime)
        {
            Appointment appointment = GetAppointmentById(appointmentId);

            if (appointment == null)
            {
                return false;
            }

            //check email
            if (!appointment.Email.Equals(email, StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            appointment.Date = newDate;
            appointment.Time = newTime;
            appointment.Status = Status.RescheduleRequested;

            return true;
        }

        public bool UpdateAppointmentStatus(int appointmentId, Status newStatus)
        {
            var appointment = GetAppointmentById(appointmentId);

            if (appointment == null)
            {
                return false;
            }

            appointment.Status = newStatus;

            return true;
        }

        public int GenerateAppointmentId()
        {
            appointmentId++;
            return appointmentId;
        }
    }
}
