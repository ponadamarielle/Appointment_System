using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        public Appointment(int id, string name, string mobile, DateOnly date, TimeOnly time, string service)
        {
            Id = id;
            Name = name;
            MobileNumber = mobile;
            Date = date;
            Time = time;
            Service = service;
            Status = Status.Pending;
            NewRequestedDateTime = null;
        }
    }

    }
