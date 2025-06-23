using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Appointment_Desktop
{
    public partial class frm_home : Form
    {
        public frm_home()
        {
            InitializeComponent();
        }

        private void btn_book_Click(object sender, EventArgs e)
        {
            Booking book = new Booking();
            book.Show();
        }

        private void linkLabel_submit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RequestForm requestForm = new RequestForm();
            requestForm.Show();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            Login login = new Login(this);
            login.Show();
        }
    }
}
