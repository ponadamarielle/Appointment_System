namespace Appointment_Desktop
{
    partial class RequestForm
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
            panel1 = new Panel();
            lbl_request = new Label();
            pic_calendar = new PictureBox();
            lbl_id = new Label();
            txtbox_id = new TextBox();
            lbl_requestType = new Label();
            cmb_request = new ComboBox();
            btn_cancel = new Button();
            btn_submit = new Button();
            lbl_newDate = new Label();
            lbl_newTime = new Label();
            dtp_newDate = new DateTimePicker();
            dtp_newTime = new DateTimePicker();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pic_calendar).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(77, 130, 160);
            panel1.Controls.Add(lbl_request);
            panel1.Controls.Add(pic_calendar);
            panel1.Location = new Point(-4, -1);
            panel1.Name = "panel1";
            panel1.Size = new Size(638, 89);
            panel1.TabIndex = 1;
            // 
            // lbl_request
            // 
            lbl_request.AutoSize = true;
            lbl_request.Font = new Font("Century Gothic", 19.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_request.ForeColor = Color.FromArgb(250, 252, 252);
            lbl_request.Location = new Point(100, 24);
            lbl_request.Name = "lbl_request";
            lbl_request.Size = new Size(485, 38);
            lbl_request.TabIndex = 1;
            lbl_request.Text = "Appointment Change Request";
            // 
            // pic_calendar
            // 
            pic_calendar.Image = Properties.Resources.calendar;
            pic_calendar.Location = new Point(34, 18);
            pic_calendar.Name = "pic_calendar";
            pic_calendar.Size = new Size(60, 50);
            pic_calendar.SizeMode = PictureBoxSizeMode.Zoom;
            pic_calendar.TabIndex = 0;
            pic_calendar.TabStop = false;
            // 
            // lbl_id
            // 
            lbl_id.AutoSize = true;
            lbl_id.Font = new Font("Century Gothic", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_id.ForeColor = Color.FromArgb(58, 58, 58);
            lbl_id.Location = new Point(30, 211);
            lbl_id.Name = "lbl_id";
            lbl_id.Size = new Size(204, 27);
            lbl_id.TabIndex = 2;
            lbl_id.Text = "Appointment ID :";
            // 
            // txtbox_id
            // 
            txtbox_id.BackColor = Color.FromArgb(250, 252, 252);
            txtbox_id.Font = new Font("Century Gothic", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtbox_id.ForeColor = Color.FromArgb(58, 58, 58);
            txtbox_id.Location = new Point(284, 205);
            txtbox_id.Multiline = true;
            txtbox_id.Name = "txtbox_id";
            txtbox_id.Size = new Size(321, 40);
            txtbox_id.TabIndex = 8;
            // 
            // lbl_requestType
            // 
            lbl_requestType.AutoSize = true;
            lbl_requestType.Font = new Font("Century Gothic", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_requestType.ForeColor = Color.FromArgb(58, 58, 58);
            lbl_requestType.Location = new Point(30, 300);
            lbl_requestType.Name = "lbl_requestType";
            lbl_requestType.Size = new Size(176, 27);
            lbl_requestType.TabIndex = 9;
            lbl_requestType.Text = "Request Type :";
            // 
            // cmb_request
            // 
            cmb_request.BackColor = Color.FromArgb(250, 252, 252);
            cmb_request.Font = new Font("Century Gothic", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmb_request.ForeColor = Color.FromArgb(58, 58, 58);
            cmb_request.FormattingEnabled = true;
            cmb_request.Items.AddRange(new object[] { "-- Select request type --", "Cancel Appointment", "Reschedule Appointment" });
            cmb_request.Location = new Point(284, 298);
            cmb_request.Name = "cmb_request";
            cmb_request.Size = new Size(321, 35);
            cmb_request.TabIndex = 13;
            cmb_request.Text = "-- Select request type--";
            cmb_request.SelectedIndexChanged += cmb_request_SelectedIndexChanged;
            // 
            // btn_cancel
            // 
            btn_cancel.BackColor = Color.FromArgb(127, 176, 205);
            btn_cancel.Font = new Font("Century Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_cancel.ForeColor = Color.FromArgb(250, 252, 252);
            btn_cancel.Location = new Point(114, 593);
            btn_cancel.Name = "btn_cancel";
            btn_cancel.Size = new Size(167, 53);
            btn_cancel.TabIndex = 14;
            btn_cancel.Text = "CANCEL";
            btn_cancel.UseVisualStyleBackColor = false;
            btn_cancel.Click += btn_cancel_Click;
            // 
            // btn_submit
            // 
            btn_submit.BackColor = Color.FromArgb(127, 176, 205);
            btn_submit.Font = new Font("Century Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_submit.ForeColor = Color.FromArgb(250, 252, 252);
            btn_submit.Location = new Point(365, 593);
            btn_submit.Name = "btn_submit";
            btn_submit.Size = new Size(167, 53);
            btn_submit.TabIndex = 15;
            btn_submit.Text = "SUBMIT";
            btn_submit.UseVisualStyleBackColor = false;
            btn_submit.Click += btn_submit_Click;
            // 
            // lbl_newDate
            // 
            lbl_newDate.AutoSize = true;
            lbl_newDate.Font = new Font("Century Gothic", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_newDate.ForeColor = Color.FromArgb(58, 58, 58);
            lbl_newDate.Location = new Point(30, 393);
            lbl_newDate.Name = "lbl_newDate";
            lbl_newDate.Size = new Size(253, 27);
            lbl_newDate.TabIndex = 16;
            lbl_newDate.Text = "New Preferred Date : ";
            lbl_newDate.Visible = false;
            // 
            // lbl_newTime
            // 
            lbl_newTime.AutoSize = true;
            lbl_newTime.Font = new Font("Century Gothic", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_newTime.ForeColor = Color.FromArgb(58, 58, 58);
            lbl_newTime.Location = new Point(30, 472);
            lbl_newTime.Name = "lbl_newTime";
            lbl_newTime.Size = new Size(251, 27);
            lbl_newTime.TabIndex = 17;
            lbl_newTime.Text = "New Preferred Time : ";
            lbl_newTime.Visible = false;
            // 
            // dtp_newDate
            // 
            dtp_newDate.CalendarFont = new Font("Century Gothic", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtp_newDate.CalendarForeColor = Color.FromArgb(58, 58, 58);
            dtp_newDate.CalendarMonthBackground = Color.FromArgb(250, 252, 252);
            dtp_newDate.CalendarTitleBackColor = Color.FromArgb(127, 176, 205);
            dtp_newDate.CalendarTitleForeColor = Color.FromArgb(58, 58, 58);
            dtp_newDate.CustomFormat = " ";
            dtp_newDate.Font = new Font("Century Gothic", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtp_newDate.Format = DateTimePickerFormat.Custom;
            dtp_newDate.Location = new Point(284, 389);
            dtp_newDate.Name = "dtp_newDate";
            dtp_newDate.Size = new Size(321, 36);
            dtp_newDate.TabIndex = 19;
            dtp_newDate.Value = new DateTime(2025, 6, 17, 0, 0, 0, 0);
            dtp_newDate.Visible = false;
            dtp_newDate.ValueChanged += dtp_newDate_ValueChanged;
            // 
            // dtp_newTime
            // 
            dtp_newTime.CalendarFont = new Font("Century Gothic", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtp_newTime.CalendarForeColor = Color.FromArgb(58, 58, 58);
            dtp_newTime.CalendarMonthBackground = Color.FromArgb(250, 252, 252);
            dtp_newTime.CalendarTitleBackColor = Color.FromArgb(127, 176, 205);
            dtp_newTime.CalendarTitleForeColor = Color.FromArgb(58, 58, 58);
            dtp_newTime.Font = new Font("Century Gothic", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtp_newTime.Format = DateTimePickerFormat.Custom;
            dtp_newTime.Location = new Point(284, 472);
            dtp_newTime.Name = "dtp_newTime";
            dtp_newTime.ShowUpDown = true;
            dtp_newTime.Size = new Size(321, 36);
            dtp_newTime.TabIndex = 20;
            dtp_newTime.UseWaitCursor = true;
            dtp_newTime.Format = DateTimePickerFormat.Custom;
            dtp_newTime.CustomFormat = "hh:mm tt";
            dtp_newTime.Value = DateTime.Now;
            dtp_newTime.Visible = false;
            // 
            // RequestForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(250, 252, 252);
            ClientSize = new Size(632, 803);
            Controls.Add(dtp_newTime);
            Controls.Add(dtp_newDate);
            Controls.Add(lbl_newTime);
            Controls.Add(lbl_newDate);
            Controls.Add(btn_submit);
            Controls.Add(btn_cancel);
            Controls.Add(cmb_request);
            Controls.Add(lbl_requestType);
            Controls.Add(txtbox_id);
            Controls.Add(lbl_id);
            Controls.Add(panel1);
            Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            MaximizeBox = false;
            Name = "RequestForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pic_calendar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label lbl_request;
        private PictureBox pic_calendar;
        private Label lbl_id;
        private TextBox txtbox_id;
        private Label lbl_requestType;
        private ComboBox cmb_request;
        private Button btn_cancel;
        private Button btn_submit;
        private Label lbl_newDate;
        private Label lbl_newTime;
        private DateTimePicker dtp_newDate;
        private DateTimePicker dtp_newTime;
    }
}