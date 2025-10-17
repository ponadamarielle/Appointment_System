using AppointmentCommon;
using AppointmentDataLogic;

namespace AppointmentBusinessLogic
{
    public class AdminProcess
    {
        AppointmentDataProcess appointmentDataProcess = new AppointmentDataProcess();

        public string SearchAppointmentName(string name)
        {
            List<Appointment> appointments = appointmentDataProcess.GetAppointmentByName(name);

            if (appointments != null && appointments.Count > 0)
            {
                string result = "";

                foreach (var appointment in appointments)
                {
                    string details = $"{appointment.Id} | {appointment.Name} | {appointment.MobileNumber} | {appointment.Email} |" +
                                     $"{appointment.Date} | {appointment.Time} | {appointment.Service} | {appointment.Status}";

                    result = details + "\n";
                }

                return result;
            }

            return null;
        }

        public List<Appointment> GetAllAppointments()
        {
            return appointmentDataProcess.GetAllAppointments();
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

        public bool IsValidStatus(string status)
        {
            return Enum.TryParse(status, true, out Status _);
        }

        public bool UpdateAppointmentStatus(int appointmentId, string status, out string updatedStatus)
        {
            AppointmentProcess appointmentProcess = new AppointmentProcess();

            updatedStatus = null;

            if (!Enum.TryParse(status, true, out Status newStatus))
                return false;

            if (!appointmentProcess.ValidateAppointmentId(appointmentId))
                return false;

            if (!ValidateStatus(appointmentId, newStatus))
                return false;

            //confirm reschedule 
            var appointment = appointmentDataProcess.GetAppointmentById(appointmentId);

            if (appointment.Status == Status.RescheduleRequested && newStatus == Status.Rescheduled)
            {
                appointment.Status = newStatus;
            }

            //update status
            if (appointmentDataProcess.UpdateAppointmentStatus(appointmentId, newStatus))
            {
                updatedStatus = newStatus.ToString();
                return true;
            }
            return false;

        }
    }
    }


