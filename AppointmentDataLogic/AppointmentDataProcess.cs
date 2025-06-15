using AppointmentCommon;

namespace AppointmentDataLogic
{
    public class AppointmentDataProcess
    {
        //static IAppointmentDataProcess appointmentDataProcess = new InMemoryDataService();
        //static IAppointmentDataProcess appointmentDataProcess = new TextFileDataService();
        //static IAppointmentDataProcess appointmentDataProcess = new JsonFileDataService();
        static IAppointmentDataProcess appointmentDataProcess = new DBDataService();

        public void AddAppointment(int appointmentId, string name, string mobileNum, string email, DateOnly date, TimeOnly time, string service)
        {
            appointmentDataProcess.AddAppointment(appointmentId, name, mobileNum, email, date, time, service);
        }

        public bool CancelAppointment(int appointmentId)
        {
            return appointmentDataProcess.CancelAppointment(appointmentId);
        }

        public void ConfirmReschedule(Appointment appointment)
        {
            appointmentDataProcess.ConfirmReschedule(appointment);
        }

        public int GenerateAppointmentId()
        {
            return appointmentDataProcess.GenerateAppointmentId();
        }

        public List<Appointment> GetAllAppointments()
        {
            return appointmentDataProcess.GetAllAppointments();
        }

        public List<string> GetAllMessages()
        {
            return appointmentDataProcess.GetAllMessages();
        }

        public Appointment GetAppointmentById(int id)
        {
            return appointmentDataProcess.GetAppointmentById(id);
        }

        public List<Appointment> GetAppointmentByName(string name)
        {
            return appointmentDataProcess.GetAppointmentByName(name);
        }

        public Status GetAppointmentStatus(int appointmentId)
        {
            return appointmentDataProcess.GetAppointmentStatus(appointmentId);
        }

        public bool RescheduleAppointmen(int appointmentId, DateOnly newDate, TimeOnly newTime)
        {
            return appointmentDataProcess.RescheduleAppointment(appointmentId, newDate, newTime);
        }

        public bool UpdateAppointmentStatus(int appointmentId, Status newStatus)
        {
            return appointmentDataProcess.UpdateAppointmentStatus(appointmentId, newStatus);
        }

        


    }
}
