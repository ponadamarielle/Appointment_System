using AppointmentCommon;

namespace AppointmentDataLogic
{
    public class TextFileDataService : IAppointmentDataProcess
    {
        string appointmentFilePath = "appointments.txt";
        List<Appointment> appointments = new List<Appointment>();

        private int appointmentId = 0;

        public TextFileDataService()
        {
            GetDataFromFile();
        }

        private void GetDataFromFile()
        {
            var lines = File.ReadAllLines(appointmentFilePath);

            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;

                var parts = line.Split('|');

                appointments.Add(new Appointment
                {
                    Id = int.Parse(parts[0]),
                    Name = parts[1],
                    MobileNumber = parts[2],
                    Email = parts[3],
                    Date = DateOnly.Parse(parts[4]),
                    Time = TimeOnly.Parse(parts[5]),
                    Service = parts[6],
                    Status = Enum.Parse<Status>(parts[7]),

                });
            }
        }

        private void WriteDataToFile()
        {
            var appointmentLines = new string[appointments.Count];

            for (int i = 0; i < appointments.Count; i++)
            {
                appointmentLines[i] = $"{appointments[i].Id}|{appointments[i].Name}|{appointments[i].MobileNumber}|{appointments[i].Email}|" +
                                      $"{appointments[i].Date}|{appointments[i].Time}|{appointments[i].Service}|{appointments[i].Status}";
            }

            File.WriteAllLines(appointmentFilePath, appointmentLines);
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

            WriteDataToFile();
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

            WriteDataToFile();
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

            WriteDataToFile();
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
            WriteDataToFile();

            return true;
        }

        public int GenerateAppointmentId()
        {
            int id = 0;
            foreach (var appointment in appointments)
            {
                if (appointment.Id > id)
                {
                    id = appointment.Id;
                }
            }

            appointmentId = id + 1;
            return appointmentId;
        }
    }
}
