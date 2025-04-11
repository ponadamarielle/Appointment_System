using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentCommon
{
    public enum Status
    {
        Pending,
        Confirmed,
        Cancelled,
        Rescheduled,
        Completed,
        RescheduleRequested,
        CancelRequested,
        Unknown
    }
}
