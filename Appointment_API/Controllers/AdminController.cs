using AppointmentCommon;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Appointment_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        AppointmentBusinessLogic.AdminProcess adminProcess = new AppointmentBusinessLogic.AdminProcess();

        [HttpGet("appointments")]
        public IEnumerable<Appointment> GetAppointments()
        {
            var appointments = adminProcess.GetAllAppointments();

            return appointments;
        }

        [HttpGet("messages")]
        public IEnumerable<string> GetMessages()
        {
            var messages = adminProcess.GetAllMessages();

            return messages;
        }

        [HttpGet("search")]
        public string SearchAppointmentName(string name)
        {
            return adminProcess.SearchAppointmentName(name);
        }

        [HttpGet("validate_status")]
        public bool ValidateStatus(int appointmentId, string newStatus)
        {
            if (Enum.TryParse(newStatus, true, out Status status))
            {
                return adminProcess.ValidateStatus(appointmentId, status);
            }

            return false;
        }

        [HttpGet("is_valid")]
        public bool IsValidStatus(string status)
        {
            return adminProcess.IsValidStatus(status);
        }

        [HttpPatch("update_status")]
        public bool UpdateStatus(int appointmentId, string status)
        {
            string updatedStatus;

            return adminProcess.UpdateAppointmentStatus(appointmentId, status, out updatedStatus);
        }

    }
}
