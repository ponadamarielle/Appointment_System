namespace AppointmentCommon
{
    public class Appointment
    {
            public int Id { get; set; }
            public string Name { get; set; }
            public string MobileNumber { get; set; }
            public DateOnly Date { get; set; }
            public TimeOnly Time { get; set; }
            public string Service { get; set; }
            public Status Status { get; set; }
            public DateTime? NewRequestedDateTime { get; set; }

    }

    }
