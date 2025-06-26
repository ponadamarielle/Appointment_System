using AppointmentBusinessLogic;

namespace Appointment_Desktop
{
    public partial class Admin : Form
    {
        private Form homeForm;
        public Admin(Form home)
        {
            InitializeComponent();
            Load += Admin_Load;
            homeForm = home;
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            AdminProcess adminProcess = new AdminProcess();

            //get all appointments
            var appointments = adminProcess.GetAllAppointments();

            appointments.Sort((first, second) => second.Id.CompareTo(first.Id));

            dgv_appointments.AutoGenerateColumns = false;
            column_id.DataPropertyName = "Id";
            column_name.DataPropertyName = "Name";
            column_mobileNum.DataPropertyName = "MobileNumber";
            column_email.DataPropertyName = "Email";
            column_date.DataPropertyName = "Date";
            column_time.DataPropertyName = "Time";
            column_service.DataPropertyName = "Service";
            column_status.DataPropertyName = "Status";
            column_newRequestedDT.DataPropertyName = "NewRequestedDateTime";

            dgv_appointments.DataSource = appointments;

            // get all messages
            var messages = adminProcess.GetAllMessages();

            listView_messages.Clear();

            listView_messages.Columns.Add("", 1200);

            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, 70);
            listView_messages.SmallImageList = imgList;

            foreach (var msg in messages)
            {
                listView_messages.Items.Insert(0, new ListViewItem(msg));
            }

            listView_messages.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to logout?", "Logout Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                homeForm.Show();
                Close();
            }
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            var name = txtbox_search.Text;

            AdminProcess adminProcess = new AdminProcess();
            string appointmentInfo = adminProcess.SearchAppointmentName(name);

            listview_results.Clear();

            listview_results.Columns.Add("", 1000);

            if (appointmentInfo != null)
            {
                string[] lines = appointmentInfo.Split('\n');

                foreach (string line in lines)
                {
                    if (line.Trim() != "")
                    {
                        listview_results.Items.Add(new ListViewItem(line));
                        listview_results.Items.Add(new ListViewItem(""));
                    }
                }
            }
            else
            {
                listview_results.Items.Add(new ListViewItem("No appointment found."));
            }


            listview_results.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            listview_results.Clear();
            txtbox_search.Clear();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            var appointmentId = int.Parse(txtbox_id.Text);

            AppointmentProcess appointmentProcess = new AppointmentProcess();

            //check appointment id
            if (!appointmentProcess.ValidateAppointmentId(appointmentId))
            {
                MessageBox.Show("Invalid Appointment ID.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //check cmb status
            if (cmb_status.SelectedIndex == 0)
            {
                MessageBox.Show("Please select a status.", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var input = cmb_status.Text;

            //update status
            AdminProcess adminProcess = new AdminProcess();
            bool update = adminProcess.UpdateAppointmentStatus(appointmentId, input, out string updatedStatus);

            if (update)
            {
                MessageBox.Show($"Appointment ID {appointmentId} status updated to {updatedStatus}.", "Update Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtbox_id.Clear();
                cmb_status.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("Appointment ID not found or status update not allowed.", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}


