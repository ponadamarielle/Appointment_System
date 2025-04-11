using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppointmentCommon;
using AppointmentDataLogic;

namespace AppointmentBusinessLogic
{
    public class AdminProcess
    {

        public static Appointment SearchAppointmentName(string name)
        {
            return AppointmentDataProcess.SearchAppointmentName(name);
        }

        public static string GetAppointmentDetails(Appointment appointment)
        {
            string details = $"{appointment.Id} | {appointment.Name} | {appointment.MobileNumber} | " +
                             $"{appointment.Date} | {appointment.Time} | {appointment.Service} | {appointment.Status}";

            if (appointment.NewRequestedDateTime.HasValue)
            {
                details += $" | New Date&Time: {appointment.NewRequestedDateTime.Value}";
            }

            return details;
        }

        public static List<Appointment> GetAllAppointments()
        {
            return AppointmentDataProcess.AllAppointments();
        }

        public static List<string> GetAllMessages()
        {
            return AppointmentDataProcess.AllMessages();
        }

        public static bool SetAppointmentStatus(int appointmentId, Status newStatus)
        {
            if (!ValidateStatus(appointmentId))
            {
                return false;
            }

            return AppointmentDataProcess.UpdateStatus(appointmentId, newStatus);
        }

        public static bool ValidateStatus(int appointmentId)
        {
            Status status = AppointmentDataProcess.GetAppointmentStatus(appointmentId);

            return status != Status.Cancelled && status != Status.Completed;
        }
    }
}

