using Microsoft.Data.Sql;
using Microsoft.Data.SqlClient;
using AppointmentCommon;

namespace AppointmentDataLogic
{
    class DBDataService : IAppointmentDataProcess
    {
        static string connectionString
        = "Data Source =DESKTOP-OJUG82T\\SQLEXPRESS; Initial Catalog = db_appointments; Integrated Security = True; TrustServerCertificate=True;";

        static SqlConnection sqlConnection;


        public DBDataService()
        {
            sqlConnection = new SqlConnection(connectionString);
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

            //appointment
            var apptInsertStatement = "INSERT INTO tbl_appointments (id, name, mobileNumber, email, date, time, service, status) " +
                "VALUES (@Id, @Name, @MobileNum, @Email, @Date, @Time, @Service, @Status)";

            SqlCommand apptinsertCommand = new SqlCommand(apptInsertStatement, sqlConnection);

            apptinsertCommand.Parameters.AddWithValue("@Id", newAppointment.Id);
            apptinsertCommand.Parameters.AddWithValue("@Name", newAppointment.Name);
            apptinsertCommand.Parameters.AddWithValue("@MobileNum", newAppointment.MobileNumber);
            apptinsertCommand.Parameters.AddWithValue("@Email", newAppointment.Email);
            apptinsertCommand.Parameters.AddWithValue("@Date", newAppointment.Date);
            apptinsertCommand.Parameters.AddWithValue("@Time", newAppointment.Time);
            apptinsertCommand.Parameters.AddWithValue("@Service", newAppointment.Service);
            apptinsertCommand.Parameters.AddWithValue("@Status", newAppointment.Status.ToString());

            //message
            string appointmentMessage = $"{DateTime.Now.ToString("yyyy-MM-dd hh:mm tt")} : {name} has scheduled an appointment.\n";
            string messageInsertStatement = "INSERT INTO tbl_messages VALUES (@Message)";

            SqlCommand messageInsertCommand = new SqlCommand(messageInsertStatement, sqlConnection);

            messageInsertCommand.Parameters.AddWithValue("@Message", appointmentMessage);

            sqlConnection.Open();

            apptinsertCommand.ExecuteNonQuery();
            messageInsertCommand.ExecuteNonQuery();

            sqlConnection.Close();
            return true;
        }

        public bool CancelAppointment(int appointmentId)
        {
            var appointment = GetAppointmentById(appointmentId);
            if (appointment == null)
            {
                return false;
            }

            //appoinment
            var updateStatement = $"UPDATE tbl_appointments SET status = @Status WHERE id = @Id";

            SqlCommand updateCommand = new SqlCommand(updateStatement, sqlConnection);

            updateCommand.Parameters.AddWithValue("@Status", Status.CancelRequested.ToString());
            updateCommand.Parameters.AddWithValue("@Id", appointmentId);

            //messages
            string cancellationMessage = $"{DateTime.Now.ToString("yyyy-MM-dd hh:mm tt")} : {appointment.Name} has requested to cancel the appointment.\n";
            string messageInsertStatement = "INSERT INTO tbl_messages VALUES (@Message)";

            SqlCommand messageInsertCommand = new SqlCommand(messageInsertStatement, sqlConnection);

            messageInsertCommand.Parameters.AddWithValue("@Message", cancellationMessage);

            sqlConnection.Open();

            updateCommand.ExecuteNonQuery();
            messageInsertCommand.ExecuteNonQuery();

            sqlConnection.Close();
            return true;
        }

        public int GenerateAppointmentId()
        {
            string query = "SELECT ISNULL(MAX(Id), 0) + 1 FROM tbl_appointments";

            SqlCommand command = new SqlCommand(query, sqlConnection);

            sqlConnection.Open();

            int newId = (int)command.ExecuteScalar();

            sqlConnection.Close();
            return newId;     
        }
        public List<Appointment> GetAllAppointments()
        {
            string selectStatement = "SELECT Id, Name, MobileNumber, Email, Date, Time, Service, Status, NewRequestedDateTime FROM tbl_appointments";

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
                    Email = reader["Email"].ToString(),
                    Date = DateOnly.FromDateTime(Convert.ToDateTime(reader["Date"])),
                    Time = TimeOnly.FromTimeSpan((TimeSpan)reader["Time"]),
                    Service = reader["Service"].ToString(),
                    Status = Enum.Parse<Status>(reader["Status"].ToString()),
                    NewRequestedDateTime = reader["newRequestedDateTime"] == DBNull.Value
                    ? null
                    : Convert.ToDateTime(reader["newRequestedDateTime"])
                };
                appointments.Add(appointment);

            }

            sqlConnection.Close();
            return appointments;
        }

        public List<string> GetAllMessages()
        {
            string selectStatement = "SELECT Messages FROM tbl_messages";

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
            string query = "SELECT * FROM tbl_appointments WHERE id = @Id";

            SqlCommand command = new SqlCommand(query, sqlConnection);
            
            command.Parameters.AddWithValue("@Id", id);

            sqlConnection.Open();
            SqlDataReader reader = command.ExecuteReader();
            
                if (reader.Read())
                {
                    Appointment appointment = new Appointment
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Name = reader["Name"].ToString(),
                        MobileNumber = reader["MobileNumber"].ToString(),
                        Email = reader["Email"].ToString(),
                        Date = DateOnly.FromDateTime(Convert.ToDateTime(reader["Date"])),
                        Time = TimeOnly.FromTimeSpan((TimeSpan)reader["Time"]),
                        Service = reader["Service"].ToString(),
                        Status = Enum.Parse<Status>(reader["Status"].ToString()),
                        NewRequestedDateTime = reader["newRequestedDateTime"] == DBNull.Value ? null : (DateTime?)reader["newRequestedDateTime"]
                    };

                    sqlConnection.Close();
                    return appointment;
                }

            sqlConnection.Close();
            return null;
        }

        public List<Appointment> GetAppointmentByName(string name)
        {
            List<Appointment> results = new List<Appointment>();

            string query = "SELECT * FROM tbl_appointments WHERE LOWER(name) = LOWER(@Name)";
            SqlCommand command = new SqlCommand(query, sqlConnection);
            command.Parameters.AddWithValue("@Name", name);

            sqlConnection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                results.Add(new Appointment
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Name = reader["Name"].ToString(),
                    MobileNumber = reader["MobileNumber"].ToString(),
                    Email = reader["Email"].ToString(),
                    Date = DateOnly.FromDateTime(Convert.ToDateTime(reader["Date"])),
                    Time = TimeOnly.FromTimeSpan((TimeSpan)reader["Time"]),
                    Service = reader["Service"].ToString(),
                    Status = Enum.Parse<Status>(reader["Status"].ToString()),
                    NewRequestedDateTime = reader["newRequestedDateTime"] == DBNull.Value
                    ? null
                    : Convert.ToDateTime(reader["newRequestedDateTime"])
                });
            }

            sqlConnection.Close();
            return results;
        }

        public Status GetAppointmentStatus(int appointmentId)
        {

            var appointment = GetAppointmentById(appointmentId);
            if (appointment != null)
            {
                return appointment.Status;
            }

            string query = "SELECT status FROM tbl_appointments WHERE id = @Id";

            SqlCommand command = new SqlCommand(query, sqlConnection);
            command.Parameters.AddWithValue("@Id", appointmentId);

            sqlConnection.Open();
            var result = command.ExecuteScalar();
            sqlConnection.Close();

            return Status.Unknown;
        }

        public bool RescheduleAppointment(int appointmentId, DateOnly newDate, TimeOnly newTime)
        {
            var appointment = GetAppointmentById(appointmentId);
            if (appointment == null)
            {
                return false;
            }

            DateTime newRequestedDateTime = newDate.ToDateTime(newTime);

            //appoinment
            var updateStatement = $"UPDATE tbl_appointments SET newRequestedDateTime = @NewDateTime, status = @Status WHERE id = @Id";

            SqlCommand updateCommand = new SqlCommand(updateStatement, sqlConnection);

            updateCommand.Parameters.AddWithValue("@NewDateTime", newRequestedDateTime);
            updateCommand.Parameters.AddWithValue("@Status", Status.RescheduleRequested.ToString());
            updateCommand.Parameters.AddWithValue("@Id", appointmentId);

            //messages
            string rescheduleMessage = $"{DateTime.Now.ToString("yyyy-MM-dd hh:mm tt")} : {appointment.Name} has requested to reschedule the appointment.\n Requested new date and time: {newRequestedDateTime}";
            string messageInsertStatement = "INSERT INTO tbl_messages VALUES (@Message)";

            SqlCommand messageInsertCommand = new SqlCommand(messageInsertStatement, sqlConnection);

            messageInsertCommand.Parameters.AddWithValue("@Message", rescheduleMessage);

            sqlConnection.Open();

            updateCommand.ExecuteNonQuery();
            messageInsertCommand.ExecuteNonQuery();

            sqlConnection.Close();
            return true;
        }

        public bool UpdateAppointmentStatus(int appointmentId, Status newStatus)
        {
            var appointment = GetAppointmentById(appointmentId);
            if (appointment == null)
            {
                return false;
            }

            string updateStatement = "UPDATE tbl_appointments SET status = @Status WHERE id = @Id";

            SqlCommand updateCommand = new SqlCommand(updateStatement, sqlConnection);
            updateCommand.Parameters.AddWithValue("@Status", newStatus.ToString());
            updateCommand.Parameters.AddWithValue("@Id", appointmentId);

            sqlConnection.Open();
            updateCommand.ExecuteNonQuery();
            sqlConnection.Close();

            return true;
        }

        public void ConfirmReschedule(Appointment appointment)
        {
            string updateStatement = "UPDATE tbl_appointments SET date = @NewDate, time = @NewTime, newRequestedDateTime = NULL, status = @Status WHERE id = @Id";

            SqlCommand updateCommand = new SqlCommand(updateStatement, sqlConnection);
            updateCommand.Parameters.AddWithValue("@NewDate", appointment.Date);
            updateCommand.Parameters.AddWithValue("@NewTime", appointment.Time);
            updateCommand.Parameters.AddWithValue("@Status", appointment.Status);
            updateCommand.Parameters.AddWithValue("@Id", appointment.Id);

            sqlConnection.Open();
            updateCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }
    }
}
