using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;

namespace AppointmentBusinessDataLogic
{
    class AppointmentProcess
    {
        public static List<string> appointments = new List<string>();
        public static List<int> availableAppointments = new List<int>();

        public static void AddAppointment(string name, string date, string time, string service)
        {
            appointments.Add(name + " - " + date + " - " + time + " - " + service);
        }

        public static void ClearAvailableAppointments()
        {
            availableAppointments.Clear();
        }

        public static bool MarkAsCancelled(int appointmentNum)
        {
            if (appointmentNum >= 1 && appointmentNum <= availableAppointments.Count)
            {
                int index = availableAppointments[appointmentNum - 1];
                appointments[index] += " [CANCELLED]";
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool AddAvailableAppointment(int a)
        {
            if (!appointments[a].Contains("[CANCELLED]"))
            {
                availableAppointments.Add(a);
                return true;
            }
            return false;
            
        }


    }
}
