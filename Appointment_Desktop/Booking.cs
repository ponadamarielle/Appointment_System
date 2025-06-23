using AppointmentBusinessLogic;

namespace Appointment_Desktop
{
    public partial class Booking : Form
    {
        bool selectedDate = false;
        public Booking()
        {
            InitializeComponent();
        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (!selectedDate)
            {
                dtp_date.CustomFormat = "yyyy-MM-dd";
                selectedDate = true;
            }
        }

        private void btn_book_Click(object sender, EventArgs e)
        {
            AppointmentProcess appointmentProcess = new AppointmentProcess();

            var name = txtbox_name.Text;
            var mobileNum = txtbox_mobileNum.Text;
            var email = txtbox_email.Text;

            //check dtp_date
            if (!selectedDate)
            {
                MessageBox.Show("Please select a date.", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //validate date
            var date = DateOnly.FromDateTime(dtp_date.Value.Date);
            if (!appointmentProcess.ValidateAppointmentDate(date))
            {
                MessageBox.Show("[Please enter a valid date]", "INVALID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var time = TimeOnly.FromDateTime(dtp_time.Value);

            //check cmb_service
            if (cmb_service.SelectedIndex == 0)
            {
                MessageBox.Show("Please select a service.", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var service = cmb_service.SelectedItem.ToString();

            int appointmentId = appointmentProcess.GenerateAppointmentId();

            appointmentProcess.AddAppointment(name, mobileNum, email, date, time, service);
            MessageBox.Show($"Appointment Booked Successfully! Your appointment ID is {appointmentId}", "Booking Confirmed", MessageBoxButtons.OK, MessageBoxIcon.Information);

            txtbox_name.Clear();
            txtbox_mobileNum.Clear();
            txtbox_email.Clear();

            dtp_date.CustomFormat = " ";
            selectedDate = false;

            dtp_time.Format = DateTimePickerFormat.Custom;
            dtp_time.CustomFormat = "hh:mm tt";
            dtp_time.Value = DateTime.Now;

            cmb_service.SelectedIndex = 0;

        }
    }
}
