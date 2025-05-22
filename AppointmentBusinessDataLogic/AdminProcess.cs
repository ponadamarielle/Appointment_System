using AppointmentCommon;
using AppointmentDataLogic;

namespace AppointmentBusinessLogic
{
    public class AdminProcess
    {
        AppointmentDataProcess appointmentDataProcess = new AppointmentDataProcess();

        public string SearchAppointmentName(string name)
        {
            Appointment appointment = appointmentDataProcess.GetAppointmentName(name);

            if(appointment != null)
            {
                return GetAppointmentDetails(appointment);
            }
            return null;
        }

        public string GetAppointmentDetails(Appointment appointment)
        {
            string details = $"{appointment.Id} | {appointment.Name} | {appointment.MobileNumber} | " +
                             $"{appointment.Date} | {appointment.Time} | {appointment.Service} | {appointment.Status}";

            if (appointment.NewRequestedDateTime.HasValue)
            {
                details += $" | New Date&Time: {appointment.NewRequestedDateTime.Value}";
            }

            return details;
        }

        public List<Appointment> GetAllAppointments()
        {
            return appointmentDataProcess.GetAllAppointments();
        }

        public List<string> GetAllMessages()
        {
            return appointmentDataProcess.GetAllMessages();
        }

        public bool ValidateStatus(int appointmentId, Status newStatus)
        {
            Status currentStatus = appointmentDataProcess.GetAppointmentStatus(appointmentId);

            switch (currentStatus)
            {
                case Status.Completed:
                case Status.Cancelled:
                    return false;

                case Status.Rescheduled:
                    return newStatus == Status.Cancelled || newStatus == Status.Completed;

                case Status.CancelRequested:
                    return newStatus == Status.Cancelled;

                case Status.RescheduleRequested:
                    return newStatus == Status.Rescheduled;

                case Status.Confirmed:
                    return newStatus == Status.Cancelled || newStatus == Status.Completed;
                case Status.Pending:
                    return newStatus == Status.Confirmed;

                default:

                    return false;
            }
        }

        public bool ValidateAppointmentId(int appointmentId)
        {
            return appointmentDataProcess.GetAppointmentId(appointmentId) != null;
        }

        public bool IsValidStatus(string status)
        {
            return Enum.TryParse(status, true, out Status _);
        }

        public bool UpdateAppointmentStatus(int appointmentId, string status, out string updatedStatus)
        {
            updatedStatus = null;

            if (!Enum.TryParse(status, true, out Status newStatus))
                return false;

            if (!ValidateAppointmentId(appointmentId))
                return false;

            if (!ValidateStatus(appointmentId, newStatus))
                return false;

            if (appointmentDataProcess.UpdateStatus(appointmentId, newStatus))
            {
                updatedStatus = newStatus.ToString();
                return true;
            }
            return false;

        }
    }
    }


