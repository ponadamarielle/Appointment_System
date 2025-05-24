using Microsoft.Data.Sql;
using Microsoft.Data.SqlClient;
using AppointmentCommon;

namespace AppointmentDataLogic
{
    class DBDataService : IAppointmentDataProcess
    {
        static string connectionString
        = "Data Source =DESKTOP-QEOOSNU\\MSSQLSERVER01; Initial Catalog = appointments; Integrated Security = True; TrustServerCertificate=True;";

        static SqlConnection sqlConnection;


        public DBDataService()
        {
            sqlConnection = new SqlConnection(connectionString);
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

            var apptInsertStatement = "INSERT INTO appointments VALUES (@Id, @Name, @MobileNum, @Date, @Time, @Service, @Status)";

            SqlCommand apptinsertCommand = new SqlCommand(apptInsertStatement, sqlConnection);

            apptinsertCommand.Parameters.AddWithValue("@Id", newAppointment.Id);
            apptinsertCommand.Parameters.AddWithValue("@Name", newAppointment.Name);
            apptinsertCommand.Parameters.AddWithValue("@MobileNum", newAppointment.MobileNumber);
            apptinsertCommand.Parameters.AddWithValue("@Date", newAppointment.Date);
            apptinsertCommand.Parameters.AddWithValue("@Time", newAppointment.Time);
            apptinsertCommand.Parameters.AddWithValue("@Service", newAppointment.Service);
            apptinsertCommand.Parameters.AddWithValue("@Status", newAppointment.Status.ToString());
            sqlConnection.Open();

            apptinsertCommand.ExecuteNonQuery();

            sqlConnection.Close();
            return true;
        }

        public bool CancelAppointment(int appointmentId)
        {
            throw new NotImplementedException();
        }

        public int GenerateAppointmentId()
        {
            string query = "SELECT ISNULL(MAX(Id), 0) + 1 FROM appointments";

            using (SqlCommand command = new SqlCommand(query, sqlConnection))
            {
                sqlConnection.Open();
                int newId = (int)command.ExecuteScalar();
                sqlConnection.Close();
                return newId;
            }
        }
        public List<Appointment> GetAllAppointments()
        {
            string selectStatement = "SELECT Id, Name, MobileNumber, Date, Time, Service, Status FROM appointments";

            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);

            sqlConnection.Open();

            SqlDataReader reader = selectCommand.ExecuteReader();

            var appointments = new List<Appointment>();

            while (reader.Read())
            {
                Appointment appointment = new Appointment
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Name = reader["Name"].ToString(),
                    MobileNumber = reader["MobileNumber"].ToString(),
                    Date = DateOnly.FromDateTime(Convert.ToDateTime(reader["Date"])),
                    Time = TimeOnly.FromTimeSpan((TimeSpan)reader["Time"]),
                    Service = reader["Service"].ToString(),
                    Status = Enum.Parse<Status>(reader["Status"].ToString())
                };
                appointments.Add(appointment);

            }

            sqlConnection.Close();
            return appointments;
        }

        public List<string> GetAllMessages()
        {
            string selectStatement = "SELECT Messages FROM messages";

            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);

            sqlConnection.Open();

            SqlDataReader reader = selectCommand.ExecuteReader();

            var messages = new List<string>();

            while (reader.Read())
            {
                string message = reader["Messages"].ToString();
                messages.Add(message);
            }

            sqlConnection.Close();
            return messages;
        }


        public Appointment GetAppointmentById(int id)
        {
            throw new NotImplementedException();
        }

        public Appointment GetAppointmentByName(string name)
        {
            throw new NotImplementedException();
        }

        public Status GetAppointmentStatus(int appointmentId)
        {
            throw new NotImplementedException();
        }

        public bool RescheduleAppointment(int appointmentId, DateOnly newDate, TimeOnly newTime)
        {
            throw new NotImplementedException();
        }

        public bool UpdateAppointmentStatus(int appointmentId, Status newStatus)
        {
            throw new NotImplementedException();
        }
    }
}
