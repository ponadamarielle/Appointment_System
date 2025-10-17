using AppointmentCommon;
using System.Globalization;
using System.Text.Json;

namespace AppointmentDataLogic
{
    public class JsonFileDataService : IAppointmentDataProcess
    {
        string appointmentJsonFilePath = "appointments.json";
        List<Appointment> appointments = new List<Appointment>();

        private int appointmentId = 0;

        public JsonFileDataService()
        {
            ReadAppointmentsData();
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

        private void WriteJsonDataToFile()
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            options.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());

            string apptJsonString = JsonSerializer.Serialize(appointments, options);
            File.WriteAllText(appointmentJsonFilePath, apptJsonString);
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

            WriteJsonDataToFile();
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

            WriteJsonDataToFile();
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
