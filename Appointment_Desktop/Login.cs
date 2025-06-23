using AppointmentBusinessLogic;

namespace Appointment_Desktop
{
    public partial class Login : Form
    {
        private Form homeForm;
        public Login(Form home)
        {
            InitializeComponent();
            homeForm = home;
        }

        private void txtbox_login_Click(object sender, EventArgs e)
        {
            AppointmentProcess appointmentProcess = new AppointmentProcess();

            var username = txtbox_username.Text;
            var password = txtbox_pass.Text;

            if (appointmentProcess.ValidateLogin(username, password))
            {
                MessageBox.Show("Login Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Admin admin = new Admin(homeForm);
                admin.Show();

                Hide();
                homeForm.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username & password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
    }
}
