using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;
using System.Reflection;
using AppointmentDataLogic;
using AppointmentCommon;

namespace AppointmentBusinessLogic
{
    public class AppointmentProcess
    {
        public static bool AddAppointment(int appointmentId, string name, string mobileNum, DateOnly date, TimeOnly time, string service)
        {
            return AppointmentDataProcess.AddAppointment(appointmentId, name, mobileNum, date, time, service);
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

        public static bool ValidateAppointmentId(int appointmentId)
        {
            return AppointmentDataProcess.GetAppointmentId(appointmentId) != null;
        }

        public static bool RequestCancellation(int appointmentId)
        {
            var appointment = AppointmentDataProcess.GetAppointmentId(appointmentId);

            if (appointment == null)
            {
                return false;
            }

            if (!ValidateCancellation(appointmentId))
            {
                return false;
            }

            return AppointmentDataProcess.Cancellation(appointmentId);
        }

        public static bool ValidateCancellation(int appointmentId)
        {
            Status status = AppointmentDataProcess.GetAppointmentStatus(appointmentId);

            return status != Status.Cancelled && status != Status.Completed && status != Status.Pending;
        }

        public static bool RequestReschedule(int appointmentId, DateOnly newDate, TimeOnly newTime)
        {
            var appointment = AppointmentDataProcess.GetAppointmentId(appointmentId);

            if (appointment == null)
            {
                return false;
            }

            if (!ValidateReschedule(appointmentId))
            {
                return false;
            }

            return AppointmentDataProcess.Reschedule(appointmentId, newDate, newTime);
        }

        public static bool ValidateReschedule(int appointmentId)
        {
            Status status = AppointmentDataProcess.GetAppointmentStatus(appointmentId);

            return status != Status.Cancelled && status != Status.Completed && status != Status.Rescheduled && status != Status.Pending && status != Status.CancelRequested;
        }

        public static int GenerateAppointmentId()
        {
            return AppointmentDataProcess.GenerateAppointmentId();
        }

        public static bool ValidateLogin(string username, string password)
        {
            return username == "admin" && password == "admin123";
        }
        }

    }
