using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using AppointmentCommon;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AppointmentDataLogic
{
    public class AppointmentDataProcess
    {
        private static List<Appointment> appointments = new List<Appointment>();
        private static List<string> messages = new List<string>();
        private static int appointmentId = 0;

        public static bool AddAppointment(int appointmentId, string name, string mobileNum, DateOnly date, TimeOnly time, string service)
        {
            Appointment newAppointment = new Appointment(appointmentId, name, mobileNum, date, time, service);
            appointments.Add(newAppointment);

            string appointmentMessage = $"{DateTime.Now} : {name} has scheduled an appointment.\n";
            messages.Add(appointmentMessage);

            return true;
        }

        public static bool Cancellation(int appointmentId)
        {
            Appointment appointment = GetAppointmentId(appointmentId);

            appointment.Status = Status.CancelRequested;

            string cancellationMessage = $"{DateTime.Now} : {appointment.Name} has requested to cancel the appointment.\n";
            messages.Add(cancellationMessage);

            return true;

        }

        public static bool Reschedule(int appointmentId, DateOnly newDate, TimeOnly newTime)
        {

            Appointment appointment = GetAppointmentId(appointmentId);

            DateTime newRequestedDateTime = newDate.ToDateTime(newTime);

            appointment.NewRequestedDateTime = newRequestedDateTime;

            appointment.Status = Status.RescheduleRequested;

            string rescheduleMessage = $"{DateTime.Now} : {appointment.Name} has requested to reschedule the appointment.\n Requested new date and time: {newRequestedDateTime}";
            messages.Add(rescheduleMessage);

            return true;
        }

        public static Appointment GetAppointmentId(int id)
        {
            foreach (var appointment in appointments)
            {
                if (appointment.Id == id)
                {
                    return appointment;
                }
            }
            return null;
        }

        public static List<Appointment> AllAppointments()
        {
            return appointments;
        }

        public static List<string> AllMessages()
        {
            return messages;
        }

        public static Status GetAppointmentStatus(int appointmentId)
        {
            var appointment = GetAppointmentId(appointmentId);

            if (appointment != null)
            {
                return appointment.Status;
            }

            return Status.Unknown;
        }

        public static bool UpdateStatus(int appointmentId, Status newStatus)
        {
            var appointment = GetAppointmentId(appointmentId);

            if (appointment == null)
            {
                return false;
            }

            appointment.Status = newStatus;

            return true;
        }

        public static int GenerateAppointmentId()
        {
            appointmentId++;
            return appointmentId;
        }

        public static Appointment SearchAppointmentName(string name)
        {
            foreach (var appointment in appointments)
            {
                if (appointment.Name.ToLower().Contains(name.ToLower()))
                {
                    return appointment;
                }
            }
            return null;
            {

            }
        }

    }
}
