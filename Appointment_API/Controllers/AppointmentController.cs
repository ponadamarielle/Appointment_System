using AppointmentCommon;
using Microsoft.AspNetCore.Mvc;

namespace Appointment_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly AppointmentBusinessLogic.AppointmentProcess _appointmentProcess;

        public AppointmentController(AppointmentBusinessLogic.AppointmentProcess appointmentProcess)
        {
            _appointmentProcess = appointmentProcess;
        }

        [HttpPost("add")]
        public void AddAppointment(Appointment request)
        {
            bool valid = _appointmentProcess.ValidateAppointmentDate(request.Date);

            if (valid)
            {
                _appointmentProcess.AddAppointment(request.Name, request.MobileNumber, request.Email, request.Date, request.Time, request.Service);
            }
        }

        [HttpGet("validate_date")]
        public bool ValidateAppointmentDate(DateOnly date)
        {
            return _appointmentProcess.ValidateAppointmentDate(date);
        }

        [HttpGet("validate_id")]
        public bool ValidateAppointmentId(int appointmentId)
        {
            return _appointmentProcess.ValidateAppointmentId(appointmentId);
        }

        [HttpPatch("cancellation")]
        public bool RequestCancellation(int appointmentId, string email)
        {
            var cancellation = _appointmentProcess.RequestCancellation(appointmentId, email);
            return cancellation;
        }

        [HttpGet("validate_cancellation")]
        public bool ValidateCancellation(int appointmentId)
        {
            return _appointmentProcess.ValidateCancellation(appointmentId);
        }

        [HttpPatch("reschedule")]
        public bool RequestReschedule(int appointmentId, string email, DateOnly newDate, TimeOnly newTime)
        {
            var reschedule = _appointmentProcess.RequestReschedule(appointmentId, email, newDate, newTime);
            return reschedule;
        }

        [HttpGet("validate_reschedule")]
        public bool ValidateReschedule(int appointmentId)
        {
            return _appointmentProcess.ValidateReschedule(appointmentId);
        }

        [HttpPost("login")]
        public bool ValidateLogin(string username, string password)
        {
            return _appointmentProcess.ValidateLogin(username, password);
        }

        [HttpGet("generate_id")]
        public int GenerateAppointmentId()
        {
            return _appointmentProcess.GenerateAppointmentId();
        }
    }
}