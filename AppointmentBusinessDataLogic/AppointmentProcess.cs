using AppointmentDataLogic;
using AppointmentCommon;

namespace AppointmentBusinessLogic
{
    public class AppointmentProcess
    {
        AppointmentDataProcess appointmentDataProcess = new AppointmentDataProcess();

        public void AddAppointment(string name, string mobileNum, string email, DateOnly date, TimeOnly time, string service)
        {
            int newId = appointmentDataProcess.GenerateAppointmentId();
            appointmentDataProcess.AddAppointment(newId, name, mobileNum, email, date, time, service);

            EmailService emailService = new EmailService();
            string subject = "New Appointment Booked";
            string body = $"A new appointment has been booked by {name}.\nContact: {mobileNum}, {email}\nService: {service}\nDate & Time: {date} at {time}.";

            emailService.SendEmailToAdmin(name, email, subject, body);
        }
        public bool ValidateAppointmentDate(DateOnly date)
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
            return appointmentDataProcess.GetAppointmentById(appointmentId) != null;
        }

        public bool RequestCancellation(int appointmentId, string email)
        {
            var appointment = appointmentDataProcess.GetAppointmentById(appointmentId);

            if (appointment == null)
            {
                return false;
            }

            if (!ValidateCancellation(appointmentId))
            {
                return false;
            }

            bool result = appointmentDataProcess.CancelAppointment(appointmentId, email);

            if (result)
            {
                EmailService emailService = new EmailService();
                string subject = "Appointment Cancellation Request";
                string body = $"{DateTime.Now:yyyy-MM-dd hh:mm tt} : {appointment.Name} has requested to cancel the appointment.\n";

                emailService.SendEmailToAdmin(appointment.Name, email, subject, body);
            }

            return result;
        }

        public bool ValidateCancellation(int appointmentId)
        {
            Status status = appointmentDataProcess.GetAppointmentStatus(appointmentId);

            return status != Status.Cancelled && status != Status.Completed;
        }

        public bool RequestReschedule(int appointmentId, string email, DateOnly newDate, TimeOnly newTime)
        {
            var appointment = appointmentDataProcess.GetAppointmentById(appointmentId);

            if (appointment == null)
            {
                return false;
            }

            if (!ValidateReschedule(appointmentId))
            {
                return false;
            }

            bool result = appointmentDataProcess.RescheduleAppointment(appointmentId, email,newDate, newTime);

            if (result)
            {
                EmailService emailService = new EmailService();
                string subject = "Appointment Reschedule Request";

                DateTime newRequestedDateTime = newDate.ToDateTime(newTime);
                string body = $"{DateTime.Now:yyyy-MM-dd h:mm tt} : {appointment.Name} has requested to reschedule the appointment.\nRequested new date and time: {newRequestedDateTime:M/d/yyyy h:mm tt}";

                emailService.SendEmailToAdmin(appointment.Name, email, subject, body);
            }

            return result;
        }

        public bool ValidateReschedule(int appointmentId)
        {
            Status status = appointmentDataProcess.GetAppointmentStatus(appointmentId);

            return status != Status.Cancelled && status != Status.Completed && status != Status.Rescheduled && status != Status.CancelRequested;
        }

        public bool ValidateLogin(string username, string password)
        {
            return username == "admin" && password == "admin123";
        }

        public int GenerateAppointmentId()
        {
            return appointmentDataProcess.GenerateAppointmentId();
        }
    }

    }
