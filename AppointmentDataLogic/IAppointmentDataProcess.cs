using AppointmentCommon;

namespace AppointmentDataLogic
{
    interface IAppointmentDataProcess
    {
        public bool AddAppointment(int appointmentId, string name, string mobileNum, string email, DateOnly date, TimeOnly time, string service);
        public bool CancelAppointment(int appointmentId);
        public bool RescheduleAppointment(int appointmentId, DateOnly newDate, TimeOnly newTime);
        public bool UpdateAppointmentStatus(int appointmentId, Status newStatus);
        public Appointment GetAppointmentById(int id);
        public List<Appointment> GetAllAppointments();
        public List<string> GetAllMessages();
        public Status GetAppointmentStatus(int appointmentId);
        public List<Appointment> GetAppointmentByName(string name);
        public int GenerateAppointmentId();
        public void ConfirmReschedule(Appointment appointment);

    }
}
