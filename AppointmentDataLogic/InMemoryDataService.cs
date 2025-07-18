﻿using AppointmentCommon;

namespace AppointmentDataLogic
{
    public class InMemoryDataService : IAppointmentDataProcess
    {
        List<Appointment> appointments = new List<Appointment>();
        List<string> messages = new List<string>();
        private int appointmentId = 3;

        public InMemoryDataService()
        {
            CreateBooking();
            CreateMessage();
        }

        private void CreateBooking()
        {
            appointments.Add(new Appointment
            {
                Id = 1,
                Name = "Jasmin Deyro",
                MobileNumber = "09156784962",
                Email = "jsmndyr@gmail.com",
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(-1)),
                Time = TimeOnly.Parse("4:00 PM"),
                Service = "Laser Treatment",
                Status = Status.Completed
            });

            appointments.Add(new Appointment
            {
                Id = 2,
                Name = "Marielle Ponada",
                MobileNumber = "09126578654",
                Email = "marielleponada@gmail.com",
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(2)),
                Time = TimeOnly.Parse("9:00 AM"),
                Service = "Facial Treatment",
                Status = Status.Confirmed
            });

            appointments.Add(new Appointment
            {
                Id = 3,
                Name = "Hecil Gesite",
                MobileNumber = "09634535621",
                Email = "heysill@gmail.com",
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(5)),
                Time = TimeOnly.Parse("1:00 PM"),
                Service = "Whitening Peel",
                Status = Status.Pending
            });

        }

        private void CreateMessage()
        {
            messages.Add($"{DateTime.Now.AddDays(-2).AddHours(2).ToString("MM-dd-yyyy hh:mm tt")} : Jasmin Deyro has scheduled an appointment.\n");
            messages.Add($"{DateTime.Now.ToString("MM-dd-yyyy hh:mm tt")} : Marielle Ponada has scheduled an appointment.\n");
            messages.Add($"{DateTime.Now.AddHours(4).ToString("MM-dd-yyyy hh:mm tt")} : Hecil Gesite has scheduled an appointment.\n");
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

            appointments.Add(newAppointment);

            string appointmentMessage = $"{DateTime.Now.ToString("yyyy-MM-dd hh:mm tt")} : {name} has scheduled an appointment.\n";
            messages.Add(appointmentMessage);

            return true;
        }

        public bool CancelAppointment(int appointmentId)
        {
            Appointment appointment = GetAppointmentById(appointmentId);

            if (appointment == null)
            {
                return false;
            }

            appointment.Status = Status.CancelRequested;

            string cancellationMessage = $"{DateTime.Now.ToString("yyyy-MM-dd hh:mm tt")} : {appointment.Name} has requested to cancel the appointment.\n";
            messages.Add(cancellationMessage);

            return true;
        }

        public List<Appointment> GetAllAppointments()
        {
            return appointments;
        }

        public List<string> GetAllMessages()
        {
            return messages;
        }

        public Appointment GetAppointmentById(int id)
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

        public List<Appointment> GetAppointmentByName(string name)
        {
            List<Appointment> results = new List<Appointment>();

            foreach (var appointment in appointments)
            {
                if (appointment.Name.ToLower().Contains(name.ToLower()))
                {
                    results.Add(appointment);
                }
            }

            return results;
        }

        public Status GetAppointmentStatus(int appointmentId)
        {
            var appointment = GetAppointmentById(appointmentId);

            if (appointment != null)
            {
                return appointment.Status;
            }

            return Status.Unknown;
        }

        public bool RescheduleAppointment(int appointmentId, DateOnly newDate, TimeOnly newTime)
        {
            Appointment appointment = GetAppointmentById(appointmentId);

            if (appointment == null)
            {
                return false;
            }

            DateTime newRequestedDateTime = newDate.ToDateTime(newTime);

            appointment.NewRequestedDateTime = newRequestedDateTime;

            appointment.Status = Status.RescheduleRequested;

            string rescheduleMessage = $"{DateTime.Now:yyyy-MM-dd h:mm tt} : {appointment.Name} has requested to reschedule the appointment.\nRequested new date and time: {newRequestedDateTime:M/d/yyyy h:mm tt}";
            messages.Add(rescheduleMessage);

            return true;
        }

        public bool UpdateAppointmentStatus(int appointmentId, Status newStatus)
        {
            var appointment = GetAppointmentById(appointmentId);

            if (appointment == null)
            {
                return false;
            }

            appointment.Status = newStatus;

            return true;
        }

        public int GenerateAppointmentId()
        {
            appointmentId++;
            return appointmentId;
        }

        public void ConfirmReschedule(Appointment appointment)
        {
            if (appointment.NewRequestedDateTime.HasValue)
            {
                appointment.Date = DateOnly.FromDateTime(appointment.NewRequestedDateTime.Value);
                appointment.Time = TimeOnly.FromDateTime(appointment.NewRequestedDateTime.Value);
                appointment.NewRequestedDateTime = null;
            }
        }
    }
}
