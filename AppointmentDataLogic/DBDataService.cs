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

            sqlConnection.Open();

            apptinsertCommand.ExecuteNonQuery();

            sqlConnection.Close();
            return true;
        }

        public bool CancelAppointment(int appointmentId, string email)
        {
            var appointment = GetAppointmentById(appointmentId);
            if (appointment == null)
            {
                return false;
            }

            //check email
            if (!appointment.Email.Equals(email, StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            //appoinment
            var updateStatement = $"UPDATE tbl_appointments SET status = @Status WHERE id = @Id";

            SqlCommand updateCommand = new SqlCommand(updateStatement, sqlConnection);

            updateCommand.Parameters.AddWithValue("@Status", Status.CancelRequested.ToString());
            updateCommand.Parameters.AddWithValue("@Id", appointmentId);

            sqlConnection.Open();

            updateCommand.ExecuteNonQuery();

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
            string selectStatement = "SELECT Id, Name, MobileNumber, Email, Date, Time, Service, Status FROM tbl_appointments";

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
                };
                appointments.Add(appointment);

            }

            sqlConnection.Close();
            return appointments;
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

        public bool RescheduleAppointment(int appointmentId, string email, DateOnly newDate, TimeOnly newTime)
        {
            var appointment = GetAppointmentById(appointmentId);
            if (appointment == null)
            {
                return false;
            }

            //check email
            if (!appointment.Email.Equals(email, StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            //appoinment
            DateTime newRequestedDateTime = newDate.ToDateTime(newTime);

            var updateStatement = "UPDATE tbl_appointments SET date = @Date, time = @Time, status = @Status WHERE id = @Id";

            SqlCommand updateCommand = new SqlCommand(updateStatement, sqlConnection);

            updateCommand.Parameters.AddWithValue("@Date", newDate.ToDateTime(new TimeOnly(0, 0)));
            updateCommand.Parameters.AddWithValue("@Time", newTime.ToTimeSpan());                
            updateCommand.Parameters.AddWithValue("@Status", Status.RescheduleRequested.ToString());
            updateCommand.Parameters.AddWithValue("@Id", appointmentId);

            sqlConnection.Open();

            updateCommand.ExecuteNonQuery();

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
    }
}
