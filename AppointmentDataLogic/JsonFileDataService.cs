using AppointmentCommon;
using System.Text.Json;

namespace AppointmentDataLogic
{
    public class JsonFileDataService : IAppointmentDataProcess
    {
        string appointmentJsonFilePath = "appointments.json";
        string messageJsonFilePath = "messages.json";
        List<Appointment> appointments = new List<Appointment>();
        List<string> messages = new List<string>();
        private int appointmentId = 0;

        public JsonFileDataService()
        {
            ReadAppointmentsData();
            ReadMessagesData();
        }

        private void ReadAppointmentsData()
        {
            string jsonText = File.ReadAllText(appointmentJsonFilePath);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            options.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());

            appointments = JsonSerializer.Deserialize<List<Appointment>>(jsonText, options);
        }

        private void ReadMessagesData()
        {
            string jsonText = File.ReadAllText(messageJsonFilePath);

            messages = JsonSerializer.Deserialize<List<string>>(jsonText,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );
        }

        private void WriteJsonDataToFile()
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            options.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());

            string apptJsonString = JsonSerializer.Serialize(appointments, options);
            File.WriteAllText(appointmentJsonFilePath, apptJsonString);


            string messageJsonString = JsonSerializer.Serialize(messages, new JsonSerializerOptions
            { WriteIndented = true });

            File.WriteAllText(messageJsonFilePath, messageJsonString);
        }

        public bool AddAppointment(int appointmentId, string name, string mobileNum, DateOnly date, TimeOnly time, string service)
        {
            Appointment newAppointment = new Appointment
            {
                Id = appointmentId,
                Name = name,
                MobileNumber = mobileNum,
                Date = date,
                Time = time,
                Service = service,
                Status = Status.Pending
            };

            appointments.Add(newAppointment);

            string appointmentMessage = $"{DateTime.Now.ToString("yyyy-MM-dd hh:mm tt")} : {name} has scheduled an appointment.\n";
            messages.Add(appointmentMessage);

            WriteJsonDataToFile();
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

            WriteJsonDataToFile();
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

            WriteJsonDataToFile();
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
            WriteJsonDataToFile();

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
