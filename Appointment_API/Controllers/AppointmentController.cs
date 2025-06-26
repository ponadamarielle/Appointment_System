using AppointmentCommon;
using Microsoft.AspNetCore.Mvc;

namespace Appointment_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        AppointmentBusinessLogic.AppointmentProcess appointmentProcess = new AppointmentBusinessLogic.AppointmentProcess();

        [HttpPost("add")]
        public void AddAppointment(Appointment request)
        {
            bool valid = appointmentProcess.ValidateAppointmentDate(request.Date);

            if (valid)
            {
                appointmentProcess.AddAppointment(request.Name, request.MobileNumber, request.Email, request.Date, request.Time, request.Service);
            }
        }

        [HttpGet("validate_date")]
        public bool ValidateAppointmentDate(DateOnly date)
        {
            return appointmentProcess.ValidateAppointmentDate(date);
        }

        [HttpGet("validate_id")]
        public bool ValidateAppointmentId(int appointmentId)
        {
            return appointmentProcess.ValidateAppointmentId(appointmentId);
        }

        [HttpPatch("cancellation")]
        public bool RequestCancellation(int appointmentId)
        {
            var cancellation = appointmentProcess.RequestCancellation(appointmentId);
            return cancellation;
        }

        [HttpGet("validate_cancellation")]
        public bool ValidateCancellation(int appointmentId)
        {
            return appointmentProcess.ValidateCancellation(appointmentId);
        }

        [HttpPatch("reschedule")]
        public bool RequestReschedule(int appointmentId, DateOnly newDate, TimeOnly newTime)
        {
            var reschedule = appointmentProcess.RequestReschedule(appointmentId, newDate, newTime);
            return reschedule;
        }

        [HttpGet("validate_reschedule")]
        public bool ValidateReschedule(int appointmentId)
        {
            return appointmentProcess.ValidateReschedule(appointmentId);
        }

        [HttpPost("login")]
        public bool ValidateLogin(string username, string password)
        {
            return appointmentProcess.ValidateLogin(username, password);
        }

        [HttpGet("generate_id")]
        public int GenerateAppointmentId()
        {
            return appointmentProcess.GenerateAppointmentId();
        }
    }
}