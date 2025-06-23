using AppointmentBusinessLogic;

namespace Appointment_Desktop
{
    public partial class RequestForm : Form
    {
        bool selectedDate = false;
        public RequestForm()
        {
            InitializeComponent();
        }

        private void cmb_request_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_request.SelectedItem.ToString() == "Reschedule Appointment")
            {
                lbl_newDate.Visible = true;
                dtp_newDate.Visible = true;
                lbl_newTime.Visible = true;
                dtp_newTime.Visible = true;
            }
            else
            {
                lbl_newDate.Visible = false;
                dtp_newDate.Visible = false;
                lbl_newTime.Visible = false;
                dtp_newTime.Visible = false;
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_submit_Click(object sender, EventArgs e)
        {
            var id = int.Parse(txtbox_id.Text);

            AppointmentProcess appointmentProcess = new AppointmentProcess();

            //check id
            if (!appointmentProcess.ValidateAppointmentId(id))
            {
                MessageBox.Show("Invalid Appointment ID. Please try again.", "Invalid ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //check cmb_request
            if (cmb_request.SelectedIndex == -1 || cmb_request.SelectedIndex == 0)
            {
                MessageBox.Show("Please select a request type.", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //cancel
            if (cmb_request.SelectedIndex == 1)
            {

                if (appointmentProcess.RequestCancellation(id))
                {
                    MessageBox.Show("Cancellation request submitted. The staff will review it.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtbox_id.Clear();
                    cmb_request.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("Appointment not found or already cancelled.", "Reschedule Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            //reschedule
            else if (cmb_request.SelectedIndex == 2)
            {
                var newDate = DateOnly.FromDateTime(dtp_newDate.Value.Date);
                if (!AppointmentProcess.ValidateAppointmentDate(newDate))
                {
                    MessageBox.Show("[Please enter a valid date]", "INVALID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var newTime = TimeOnly.FromDateTime(dtp_newTime.Value);

                if (appointmentProcess.RequestReschedule(id, newDate, newTime))
                {
                    MessageBox.Show("Reschedule request submitted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtbox_id.Clear();
                    cmb_request.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("Unable to request reschedule. Appointment ID might be invalid or status doesn't allow rescheduling.", "Reschedule Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dtp_newDate_ValueChanged(object sender, EventArgs e)
        {
            if (!selectedDate)
            {
                dtp_newDate.Format = DateTimePickerFormat.Custom;
                dtp_newDate.CustomFormat = "yyyy-MM-dd";
                selectedDate = true;
            }
        }
    }
}
