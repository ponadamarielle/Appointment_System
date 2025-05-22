using AppointmentDataLogic;
using AppointmentCommon;

namespace AppointmentBusinessLogic
{
    public class AppointmentProcess
    {
        AppointmentDataProcess appointmentDataProcess = new AppointmentDataProcess();

        public void AddAppointment(int appointmentId, string name, string mobileNum, DateOnly date, TimeOnly time, string service)
        {
            int newId = appointmentDataProcess.GenerateAppointmentId();
            appointmentDataProcess.AddAppointment(appointmentId, name, mobileNum, date, time, service);
        }
        public static bool ValidateAppointmentDate(DateOnly date)
        {
            DateOnly today = DateOnly.FromDateTime(DateTime.Today);

            if (date >= today)
            {
                return true;
            }
            return false;
        }
        public bool ValidateAppointmentId(int appointmentId)
        {
            return appointmentDataProcess.GetAppointmentId(appointmentId) != null;
        }

        public bool RequestCancellation(int appointmentId)
        {
            var appointment = appointmentDataProcess.GetAppointmentId(appointmentId);

            if (appointment == null)
            {
                return false;
            }

            if (!ValidateCancellation(appointmentId))
            {
                return false;
            }

            return appointmentDataProcess.Cancellation(appointmentId);
        }

        public bool ValidateCancellation(int appointmentId)
        {
            Status status = appointmentDataProcess.GetAppointmentStatus(appointmentId);

            return status != Status.Cancelled && status != Status.Completed;
        }

        public bool RequestReschedule(int appointmentId, DateOnly newDate, TimeOnly newTime)
        {
            var appointment = appointmentDataProcess.GetAppointmentId(appointmentId);

            if (appointment == null)
            {
                return false;
            }

            if (!ValidateReschedule(appointmentId))
            {
                return false;
            }

            return appointmentDataProcess.Reschedule(appointmentId, newDate, newTime);
        }

        public bool ValidateReschedule(int appointmentId)
        {
            Status status = appointmentDataProcess.GetAppointmentStatus(appointmentId);

            return status != Status.Cancelled && status != Status.Completed && status != Status.Rescheduled && status != Status.CancelRequested;
        }

        public static bool ValidateLogin(string username, string password)
        {
            return username == "admin" && password == "admin123";
        }

        public int GenerateAppointmentId()
        {
            return appointmentDataProcess.GenerateAppointmentId();
        }
    }

    }
