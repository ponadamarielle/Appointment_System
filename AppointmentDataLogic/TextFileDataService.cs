using AppointmentCommon;

namespace AppointmentDataLogic
{
    public class TextFileDataService : IAppointmentDataProcess
    {
        string appointmentFilePath = "appointments.txt";
        string messageFilePath = "messages.txt";
        List<Appointment> appointments = new List<Appointment>();
        List<string> messages = new List<string>();
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

            messages = File.ReadAllLines(messageFilePath).ToList();
        }

        private void WriteDataToFile()
        {
            var appointmentLines = new string[appointments.Count];

            for (int i = 0; i < appointments.Count; i++)
            {
                appointmentLines[i] = $"{appointments[i].Id}|{appointments[i].Name}|{appointments[i].MobileNumber}|{appointments[i].Email}|" +
                $"{appointments[i].Date}|{appointments[i].Time}|{appointments[i].Service}|{appointments[i].Status}" +
                $"{(appointments[i].Status == Status.RescheduleRequested && appointments[i].NewRequestedDateTime.HasValue ? 
                $"|New Date & Time: {appointments[i].NewRequestedDateTime.Value:MM/dd/yyyy hh:mm tt}" : "")}";
            }

            File.WriteAllLines(appointmentFilePath, appointmentLines);

            File.WriteAllLines(messageFilePath, messages);
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

            string appointmentMessage = $"{DateTime.Now.ToString("yyyy-MM-dd hh:mm tt")} : {name} has scheduled an appointment.\n";
            messages.Add(appointmentMessage);

            WriteDataToFile();
            return true;
        }

        public bool CancelAppointment(int appointmentId)
        {
            Appointment appointment = GetAppointmentById(appointmentId);

            if (appointment == null)
            {
                return false;
            }

            appointment.Status = Status.CancelRequested;

            string cancellationMessage = $"{DateTime.Now.ToString("yyyy-MM-dd hh:mm tt")} : {appointment.Name} has requested to cancel the appointment.\n";
            messages.Add(cancellationMessage);

            WriteDataToFile();
            return true;
        }

        public List<Appointment> GetAllAppointments()
        {
            return appointments;
        }

        public List<string> GetAllMessages()
        {
            return messages;
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

        public bool RescheduleAppointment(int appointmentId, DateOnly newDate, TimeOnly newTime)
        {
            Appointment appointment = GetAppointmentById(appointmentId);

            if (appointment == null)
            {
                return false;
            }

            DateTime newRequestedDateTime = newDate.ToDateTime(newTime);

            appointment.NewRequestedDateTime = newRequestedDateTime;

            appointment.Status = Status.RescheduleRequested;

            string rescheduleMessage = $"{DateTime.Now.ToString("yyyy-MM-dd hh:mm tt")} : {appointment.Name} has requested to reschedule the appointment.\n Requested new date and time: {newRequestedDateTime}";
            messages.Add(rescheduleMessage);

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

        public void ConfirmReschedule(Appointment appointment)
        {
            if (appointment.NewRequestedDateTime.HasValue)
            {
                appointment.Date = DateOnly.FromDateTime(appointment.NewRequestedDateTime.Value);
                appointment.Time = TimeOnly.FromDateTime(appointment.NewRequestedDateTime.Value);
                appointment.NewRequestedDateTime = null;
            }
        }
    }
}
