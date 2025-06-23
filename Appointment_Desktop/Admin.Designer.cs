using System.Windows.Forms;

namespace Appointment_Desktop
{
    partial class Admin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            tabControl = new TabControl();
            tab_appointments = new TabPage();
            dgv_appointments = new DataGridView();
            column_id = new DataGridViewTextBoxColumn();
            column_name = new DataGridViewTextBoxColumn();
            column_mobileNum = new DataGridViewTextBoxColumn();
            column_email = new DataGridViewTextBoxColumn();
            column_date = new DataGridViewTextBoxColumn();
            column_time = new DataGridViewTextBoxColumn();
            column_service = new DataGridViewTextBoxColumn();
            column_status = new DataGridViewTextBoxColumn();
            column_newRequestedDT = new DataGridViewTextBoxColumn();
            pic_logo = new PictureBox();
            lbl_appointments = new Label();
            tab_messages = new TabPage();
            listView_messages = new ListView();
            pic_message = new PictureBox();
            pic_logo1 = new PictureBox();
            lbl_messages = new Label();
            tab_manage = new TabPage();
            btnLogout = new Button();
            btn_update = new Button();
            cmb_status = new ComboBox();
            lbl_status = new Label();
            txtbox_id = new TextBox();
            lbl_id = new Label();
            lbl_update = new Label();
            panel_results = new Panel();
            listview_results = new ListView();
            btn_clear = new Button();
            pic_results = new PictureBox();
            lbl_results = new Label();
            btn_search = new Button();
            txtbox_search = new TextBox();
            lbl_search = new Label();
            pic_logo2 = new PictureBox();
            tabControl.SuspendLayout();
            tab_appointments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_appointments).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pic_logo).BeginInit();
            tab_messages.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pic_message).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pic_logo1).BeginInit();
            tab_manage.SuspendLayout();
            panel_results.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pic_results).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pic_logo2).BeginInit();
            SuspendLayout();
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tab_appointments);
            tabControl.Controls.Add(tab_messages);
            tabControl.Controls.Add(tab_manage);
            tabControl.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tabControl.ItemSize = new Size(280, 35);
            tabControl.Location = new Point(-4, -5);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(1190, 823);
            tabControl.SizeMode = TabSizeMode.Fixed;
            tabControl.TabIndex = 0;
            // 
            // tab_appointments
            // 
            tab_appointments.BackColor = Color.FromArgb(250, 252, 252);
            tab_appointments.BorderStyle = BorderStyle.FixedSingle;
            tab_appointments.Controls.Add(dgv_appointments);
            tab_appointments.Controls.Add(pic_logo);
            tab_appointments.Controls.Add(lbl_appointments);
            tab_appointments.Font = new Font("Century Gothic", 13.2000008F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tab_appointments.ForeColor = Color.FromArgb(58, 58, 58);
            tab_appointments.Location = new Point(4, 39);
            tab_appointments.Name = "tab_appointments";
            tab_appointments.Padding = new Padding(3);
            tab_appointments.Size = new Size(1182, 780);
            tab_appointments.TabIndex = 0;
            tab_appointments.Text = "Appointments";
            // 
            // dgv_appointments
            // 
            dgv_appointments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv_appointments.BackgroundColor = Color.FromArgb(250, 252, 252);
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(127, 176, 205);
            dataGridViewCellStyle1.Font = new Font("Century Gothic", 13.2000008F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(250, 252, 252);
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgv_appointments.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgv_appointments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_appointments.Columns.AddRange(new DataGridViewColumn[] { column_id, column_name, column_mobileNum, column_email, column_date, column_time, column_service, column_status, column_newRequestedDT });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(250, 252, 252);
            dataGridViewCellStyle2.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(58, 58, 58);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(250, 252, 252);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(58, 58, 58);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgv_appointments.DefaultCellStyle = dataGridViewCellStyle2;
            dgv_appointments.EnableHeadersVisualStyles = false;
            dgv_appointments.Location = new Point(31, 136);
            dgv_appointments.Name = "dgv_appointments";
            dgv_appointments.RowHeadersVisible = false;
            dgv_appointments.RowHeadersWidth = 51;
            dgv_appointments.Size = new Size(1119, 600);
            dgv_appointments.TabIndex = 2;
            // 
            // column_id
            // 
            column_id.HeaderText = "ID";
            column_id.MinimumWidth = 6;
            column_id.Name = "column_id";
            column_id.Width = 63;
            // 
            // column_name
            // 
            column_name.HeaderText = "Name";
            column_name.MinimumWidth = 6;
            column_name.Name = "column_name";
            column_name.Width = 110;
            // 
            // column_mobileNum
            // 
            column_mobileNum.HeaderText = "Mobile Number";
            column_mobileNum.MinimumWidth = 6;
            column_mobileNum.Name = "column_mobileNum";
            column_mobileNum.Width = 196;
            // 
            // column_email
            // 
            column_email.HeaderText = "Email";
            column_email.MinimumWidth = 6;
            column_email.Name = "column_email";
            column_email.Width = 102;
            // 
            // column_date
            // 
            column_date.HeaderText = "Date";
            column_date.MinimumWidth = 6;
            column_date.Name = "column_date";
            column_date.Width = 94;
            // 
            // column_time
            // 
            column_time.HeaderText = "Time";
            column_time.MinimumWidth = 6;
            column_time.Name = "column_time";
            column_time.Width = 94;
            // 
            // column_service
            // 
            column_service.HeaderText = "Service";
            column_service.MinimumWidth = 6;
            column_service.Name = "column_service";
            column_service.Width = 124;
            // 
            // column_status
            // 
            column_status.HeaderText = "Status";
            column_status.MinimumWidth = 6;
            column_status.Name = "column_status";
            column_status.Width = 106;
            // 
            // column_newRequestedDT
            // 
            column_newRequestedDT.HeaderText = "New Requested Date & Time";
            column_newRequestedDT.MinimumWidth = 6;
            column_newRequestedDT.Name = "column_newRequestedDT";
            column_newRequestedDT.Width = 250;
            // 
            // pic_logo
            // 
            pic_logo.Image = Properties.Resources.logo;
            pic_logo.Location = new Point(1016, 2);
            pic_logo.Name = "pic_logo";
            pic_logo.Size = new Size(134, 131);
            pic_logo.SizeMode = PictureBoxSizeMode.Zoom;
            pic_logo.TabIndex = 1;
            pic_logo.TabStop = false;
            // 
            // lbl_appointments
            // 
            lbl_appointments.AutoSize = true;
            lbl_appointments.Font = new Font("Century Gothic", 30F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_appointments.ForeColor = Color.FromArgb(127, 176, 205);
            lbl_appointments.Location = new Point(31, 40);
            lbl_appointments.Name = "lbl_appointments";
            lbl_appointments.Size = new Size(482, 59);
            lbl_appointments.TabIndex = 0;
            lbl_appointments.Text = "ALL APPOINTMENTS";
            // 
            // tab_messages
            // 
            tab_messages.BackColor = Color.FromArgb(250, 252, 252);
            tab_messages.BorderStyle = BorderStyle.FixedSingle;
            tab_messages.Controls.Add(listView_messages);
            tab_messages.Controls.Add(pic_message);
            tab_messages.Controls.Add(pic_logo1);
            tab_messages.Controls.Add(lbl_messages);
            tab_messages.ForeColor = Color.FromArgb(58, 58, 58);
            tab_messages.Location = new Point(4, 39);
            tab_messages.Name = "tab_messages";
            tab_messages.Padding = new Padding(3);
            tab_messages.Size = new Size(1182, 780);
            tab_messages.TabIndex = 1;
            tab_messages.Text = "Messages";
            // 
            // listView_messages
            // 
            listView_messages.BackColor = Color.FromArgb(250, 252, 252);
            listView_messages.Font = new Font("Century Gothic", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            listView_messages.ForeColor = Color.FromArgb(58, 58, 58);
            listView_messages.FullRowSelect = true;
            listView_messages.GridLines = true;
            listView_messages.HeaderStyle = ColumnHeaderStyle.None;
            listView_messages.Location = new Point(30, 139);
            listView_messages.MultiSelect = false;
            listView_messages.Name = "listView_messages";
            listView_messages.Size = new Size(1119, 597);
            listView_messages.TabIndex = 17;
            listView_messages.UseCompatibleStateImageBehavior = false;
            listView_messages.View = View.Details;
            // 
            // pic_message
            // 
            pic_message.Image = Properties.Resources.email__1_;
            pic_message.Location = new Point(30, 47);
            pic_message.Name = "pic_message";
            pic_message.Size = new Size(77, 62);
            pic_message.SizeMode = PictureBoxSizeMode.Zoom;
            pic_message.TabIndex = 3;
            pic_message.TabStop = false;
            // 
            // pic_logo1
            // 
            pic_logo1.Image = Properties.Resources.logo;
            pic_logo1.Location = new Point(1015, 2);
            pic_logo1.Name = "pic_logo1";
            pic_logo1.Size = new Size(134, 131);
            pic_logo1.SizeMode = PictureBoxSizeMode.Zoom;
            pic_logo1.TabIndex = 2;
            pic_logo1.TabStop = false;
            // 
            // lbl_messages
            // 
            lbl_messages.AutoSize = true;
            lbl_messages.Font = new Font("Century Gothic", 30F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_messages.ForeColor = Color.FromArgb(127, 176, 205);
            lbl_messages.Location = new Point(128, 50);
            lbl_messages.Name = "lbl_messages";
            lbl_messages.Size = new Size(279, 59);
            lbl_messages.TabIndex = 1;
            lbl_messages.Text = "MESSAGES";
            // 
            // tab_manage
            // 
            tab_manage.BackColor = Color.FromArgb(250, 252, 252);
            tab_manage.BorderStyle = BorderStyle.FixedSingle;
            tab_manage.Controls.Add(btnLogout);
            tab_manage.Controls.Add(btn_update);
            tab_manage.Controls.Add(cmb_status);
            tab_manage.Controls.Add(lbl_status);
            tab_manage.Controls.Add(txtbox_id);
            tab_manage.Controls.Add(lbl_id);
            tab_manage.Controls.Add(lbl_update);
            tab_manage.Controls.Add(panel_results);
            tab_manage.Controls.Add(btn_search);
            tab_manage.Controls.Add(txtbox_search);
            tab_manage.Controls.Add(lbl_search);
            tab_manage.Controls.Add(pic_logo2);
            tab_manage.Font = new Font("Century Gothic", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tab_manage.ForeColor = Color.FromArgb(58, 58, 58);
            tab_manage.Location = new Point(4, 39);
            tab_manage.Name = "tab_manage";
            tab_manage.Size = new Size(1182, 780);
            tab_manage.TabIndex = 2;
            tab_manage.Text = "Manage Appointments";
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.FromArgb(127, 176, 205);
            btnLogout.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogout.ForeColor = Color.FromArgb(250, 252, 252);
            btnLogout.Location = new Point(1015, 709);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(134, 37);
            btnLogout.TabIndex = 24;
            btnLogout.Text = "LOGOUT";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // btn_update
            // 
            btn_update.BackColor = Color.FromArgb(127, 176, 205);
            btn_update.Font = new Font("Century Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_update.ForeColor = Color.FromArgb(250, 252, 252);
            btn_update.Location = new Point(966, 525);
            btn_update.Name = "btn_update";
            btn_update.Size = new Size(183, 48);
            btn_update.TabIndex = 23;
            btn_update.Text = "UPDATE";
            btn_update.UseVisualStyleBackColor = false;
            btn_update.Click += btn_update_Click;
            // 
            // cmb_status
            // 
            cmb_status.BackColor = Color.FromArgb(250, 252, 252);
            cmb_status.Font = new Font("Century Gothic", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmb_status.ForeColor = Color.FromArgb(58, 58, 58);
            cmb_status.FormattingEnabled = true;
            cmb_status.Items.AddRange(new object[] { "-- Select --", "Confirmed", "Rescheduled", "Cancelled", "Completed" });
            cmb_status.Location = new Point(966, 441);
            cmb_status.Name = "cmb_status";
            cmb_status.Size = new Size(183, 39);
            cmb_status.TabIndex = 22;
            cmb_status.Text = "-- Select --";
            // 
            // lbl_status
            // 
            lbl_status.AutoSize = true;
            lbl_status.Font = new Font("Century Gothic", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_status.ForeColor = Color.FromArgb(58, 58, 58);
            lbl_status.Location = new Point(752, 445);
            lbl_status.Name = "lbl_status";
            lbl_status.Size = new Size(148, 27);
            lbl_status.TabIndex = 21;
            lbl_status.Text = "New Status :";
            // 
            // txtbox_id
            // 
            txtbox_id.BackColor = Color.FromArgb(250, 252, 252);
            txtbox_id.Font = new Font("Century Gothic", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtbox_id.ForeColor = Color.FromArgb(58, 58, 58);
            txtbox_id.Location = new Point(965, 341);
            txtbox_id.Multiline = true;
            txtbox_id.Name = "txtbox_id";
            txtbox_id.Size = new Size(183, 40);
            txtbox_id.TabIndex = 20;
            // 
            // lbl_id
            // 
            lbl_id.AutoSize = true;
            lbl_id.Font = new Font("Century Gothic", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_id.ForeColor = Color.FromArgb(58, 58, 58);
            lbl_id.Location = new Point(752, 347);
            lbl_id.Name = "lbl_id";
            lbl_id.Size = new Size(204, 27);
            lbl_id.TabIndex = 19;
            lbl_id.Text = "Appointment ID :";
            // 
            // lbl_update
            // 
            lbl_update.AutoSize = true;
            lbl_update.Font = new Font("Century Gothic", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_update.ForeColor = Color.FromArgb(127, 176, 205);
            lbl_update.Location = new Point(762, 243);
            lbl_update.Name = "lbl_update";
            lbl_update.Size = new Size(383, 34);
            lbl_update.TabIndex = 18;
            lbl_update.Text = "Update Appointment Status";
            // 
            // panel_results
            // 
            panel_results.BackColor = Color.FromArgb(127, 176, 205);
            panel_results.Controls.Add(listview_results);
            panel_results.Controls.Add(btn_clear);
            panel_results.Controls.Add(pic_results);
            panel_results.Controls.Add(lbl_results);
            panel_results.Location = new Point(45, 145);
            panel_results.Name = "panel_results";
            panel_results.Size = new Size(671, 545);
            panel_results.TabIndex = 16;
            // 
            // listview_results
            // 
            listview_results.BackColor = Color.FromArgb(250, 252, 252);
            listview_results.ForeColor = Color.FromArgb(58, 58, 58);
            listview_results.HeaderStyle = ColumnHeaderStyle.None;
            listview_results.Location = new Point(18, 66);
            listview_results.Name = "listview_results";
            listview_results.Size = new Size(634, 429);
            listview_results.TabIndex = 17;
            listview_results.UseCompatibleStateImageBehavior = false;
            listview_results.View = View.Details;
            // 
            // btn_clear
            // 
            btn_clear.BackColor = Color.FromArgb(250, 252, 252);
            btn_clear.Font = new Font("Century Gothic", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_clear.ForeColor = Color.FromArgb(77, 130, 160);
            btn_clear.Location = new Point(543, 502);
            btn_clear.Name = "btn_clear";
            btn_clear.Size = new Size(109, 35);
            btn_clear.TabIndex = 16;
            btn_clear.Text = "CLEAR";
            btn_clear.UseVisualStyleBackColor = false;
            btn_clear.Click += btn_clear_Click;
            // 
            // pic_results
            // 
            pic_results.Image = Properties.Resources.result;
            pic_results.Location = new Point(169, 18);
            pic_results.Name = "pic_results";
            pic_results.Size = new Size(39, 36);
            pic_results.SizeMode = PictureBoxSizeMode.Zoom;
            pic_results.TabIndex = 12;
            pic_results.TabStop = false;
            // 
            // lbl_results
            // 
            lbl_results.AutoSize = true;
            lbl_results.Font = new Font("Century Gothic", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_results.ForeColor = Color.FromArgb(250, 252, 252);
            lbl_results.Location = new Point(217, 18);
            lbl_results.Name = "lbl_results";
            lbl_results.Size = new Size(234, 34);
            lbl_results.TabIndex = 11;
            lbl_results.Text = "SEARCH RESULTS";
            // 
            // btn_search
            // 
            btn_search.BackColor = Color.FromArgb(127, 176, 205);
            btn_search.Font = new Font("Century Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_search.ForeColor = Color.FromArgb(250, 252, 252);
            btn_search.Location = new Point(733, 57);
            btn_search.Name = "btn_search";
            btn_search.Size = new Size(167, 56);
            btn_search.TabIndex = 15;
            btn_search.Text = "SEARCH";
            btn_search.UseVisualStyleBackColor = false;
            btn_search.Click += btn_search_Click;
            // 
            // txtbox_search
            // 
            txtbox_search.BackColor = Color.FromArgb(250, 252, 252);
            txtbox_search.Font = new Font("Century Gothic", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtbox_search.ForeColor = Color.FromArgb(58, 58, 58);
            txtbox_search.Location = new Point(312, 65);
            txtbox_search.Multiline = true;
            txtbox_search.Name = "txtbox_search";
            txtbox_search.Size = new Size(404, 45);
            txtbox_search.TabIndex = 8;
            // 
            // lbl_search
            // 
            lbl_search.AutoSize = true;
            lbl_search.Font = new Font("Century Gothic", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_search.ForeColor = Color.FromArgb(127, 176, 205);
            lbl_search.Location = new Point(36, 68);
            lbl_search.Name = "lbl_search";
            lbl_search.Size = new Size(259, 34);
            lbl_search.TabIndex = 4;
            lbl_search.Text = "Search by Name :";
            // 
            // pic_logo2
            // 
            pic_logo2.Image = Properties.Resources.logo;
            pic_logo2.Location = new Point(1015, 21);
            pic_logo2.Name = "pic_logo2";
            pic_logo2.Size = new Size(134, 131);
            pic_logo2.SizeMode = PictureBoxSizeMode.Zoom;
            pic_logo2.TabIndex = 3;
            pic_logo2.TabStop = false;
            // 
            // Admin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(250, 252, 252);
            ClientSize = new Size(1182, 803);
            Controls.Add(tabControl);
            MaximizeBox = false;
            Name = "Admin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Admin";
            Load += Admin_Load;
            tabControl.ResumeLayout(false);
            tab_appointments.ResumeLayout(false);
            tab_appointments.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_appointments).EndInit();
            ((System.ComponentModel.ISupportInitialize)pic_logo).EndInit();
            tab_messages.ResumeLayout(false);
            tab_messages.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pic_message).EndInit();
            ((System.ComponentModel.ISupportInitialize)pic_logo1).EndInit();
            tab_manage.ResumeLayout(false);
            tab_manage.PerformLayout();
            panel_results.ResumeLayout(false);
            panel_results.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pic_results).EndInit();
            ((System.ComponentModel.ISupportInitialize)pic_logo2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl;
        private TabPage tab_appointments;
        private TabPage tab_messages;
        private TabPage tab_manage;
        private PictureBox pic_logo;
        private Label lbl_appointments;
        private DataGridView dgv_appointments;
        private DataGridViewTextBoxColumn column_id;
        private DataGridViewTextBoxColumn column_name;
        private DataGridViewTextBoxColumn column_mobileNum;
        private DataGridViewTextBoxColumn column_email;
        private DataGridViewTextBoxColumn column_date;
        private DataGridViewTextBoxColumn column_time;
        private DataGridViewTextBoxColumn column_service;
        private DataGridViewTextBoxColumn column_status;
        private DataGridViewTextBoxColumn column_newRequestedDT;
        private Label lbl_messages;
        private PictureBox pic_logo1;
        private PictureBox pic_message;
        private PictureBox pic_logo2;
        private Label lbl_search;
        private TextBox txtbox_search;
        private Button btn_search;
        private Panel panel_results;
        private Label lbl_results;
        private PictureBox pic_results;
        private Button btn_clear;
        private Label lbl_update;
        private Label lbl_id;
        private Label lbl_status;
        private TextBox txtbox_id;
        private ComboBox cmb_status;
        private Button btn_update;
        private ListView listView_messages;
        private Button btnLogout;
        private ListView listview_results;
    }
}