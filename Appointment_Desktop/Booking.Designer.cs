using System.Windows.Forms;

namespace Appointment_Desktop
{
    partial class Booking
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
            lbl_book = new Label();
            pic_calendar = new PictureBox();
            lbl_name = new Label();
            lbl_mobileNum = new Label();
            lbl_email = new Label();
            lbl_date = new Label();
            lbl_time = new Label();
            lbl_service = new Label();
            txtbox_name = new TextBox();
            txtbox_mobileNum = new TextBox();
            txtbox_email = new TextBox();
            dtp_date = new DateTimePicker();
            cmb_service = new ComboBox();
            btn_book = new Button();
            dtp_time = new DateTimePicker();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pic_calendar).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(77, 130, 160);
            panel1.Controls.Add(lbl_book);
            panel1.Controls.Add(pic_calendar);
            panel1.Location = new Point(0, -1);
            panel1.Name = "panel1";
            panel1.Size = new Size(633, 87);
            panel1.TabIndex = 0;
            // 
            // lbl_book
            // 
            lbl_book.AutoSize = true;
            lbl_book.Font = new Font("Century Gothic", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_book.ForeColor = Color.FromArgb(250, 252, 252);
            lbl_book.Location = new Point(158, 24);
            lbl_book.Name = "lbl_book";
            lbl_book.Size = new Size(379, 40);
            lbl_book.TabIndex = 1;
            lbl_book.Text = "Book An Appointment";
            // 
            // pic_calendar
            // 
            pic_calendar.Image = Properties.Resources.calendar;
            pic_calendar.Location = new Point(95, 19);
            pic_calendar.Name = "pic_calendar";
            pic_calendar.Size = new Size(60, 50);
            pic_calendar.SizeMode = PictureBoxSizeMode.Zoom;
            pic_calendar.TabIndex = 0;
            pic_calendar.TabStop = false;
            // 
            // lbl_name
            // 
            lbl_name.AutoSize = true;
            lbl_name.Font = new Font("Century Gothic", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_name.ForeColor = Color.FromArgb(58, 58, 58);
            lbl_name.Location = new Point(34, 175);
            lbl_name.Name = "lbl_name";
            lbl_name.Size = new Size(94, 27);
            lbl_name.TabIndex = 1;
            lbl_name.Text = "Name :";
            // 
            // lbl_mobileNum
            // 
            lbl_mobileNum.AutoSize = true;
            lbl_mobileNum.Font = new Font("Century Gothic", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_mobileNum.ForeColor = Color.FromArgb(58, 58, 58);
            lbl_mobileNum.Location = new Point(34, 247);
            lbl_mobileNum.Name = "lbl_mobileNum";
            lbl_mobileNum.Size = new Size(202, 27);
            lbl_mobileNum.TabIndex = 2;
            lbl_mobileNum.Text = "Mobile Number :";
            // 
            // lbl_email
            // 
            lbl_email.AutoSize = true;
            lbl_email.Font = new Font("Century Gothic", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_email.ForeColor = Color.FromArgb(58, 58, 58);
            lbl_email.Location = new Point(34, 321);
            lbl_email.Name = "lbl_email";
            lbl_email.Size = new Size(86, 27);
            lbl_email.TabIndex = 3;
            lbl_email.Text = "Email :";
            // 
            // lbl_date
            // 
            lbl_date.AutoSize = true;
            lbl_date.Font = new Font("Century Gothic", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_date.ForeColor = Color.FromArgb(58, 58, 58);
            lbl_date.Location = new Point(34, 394);
            lbl_date.Name = "lbl_date";
            lbl_date.Size = new Size(195, 27);
            lbl_date.TabIndex = 4;
            lbl_date.Text = "Preferred Date : ";
            // 
            // lbl_time
            // 
            lbl_time.AutoSize = true;
            lbl_time.Font = new Font("Century Gothic", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_time.ForeColor = Color.FromArgb(58, 58, 58);
            lbl_time.Location = new Point(34, 472);
            lbl_time.Name = "lbl_time";
            lbl_time.Size = new Size(193, 27);
            lbl_time.TabIndex = 5;
            lbl_time.Text = "Preferred Time : ";
            // 
            // lbl_service
            // 
            lbl_service.AutoSize = true;
            lbl_service.Font = new Font("Century Gothic", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_service.ForeColor = Color.FromArgb(58, 58, 58);
            lbl_service.Location = new Point(34, 549);
            lbl_service.Name = "lbl_service";
            lbl_service.Size = new Size(114, 27);
            lbl_service.TabIndex = 6;
            lbl_service.Text = "Service : ";
            // 
            // txtbox_name
            // 
            txtbox_name.BackColor = Color.FromArgb(250, 252, 252);
            txtbox_name.Font = new Font("Century Gothic", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtbox_name.ForeColor = Color.FromArgb(58, 58, 58);
            txtbox_name.Location = new Point(245, 170);
            txtbox_name.Multiline = true;
            txtbox_name.Name = "txtbox_name";
            txtbox_name.Size = new Size(365, 40);
            txtbox_name.TabIndex = 7;
            // 
            // txtbox_mobileNum
            // 
            txtbox_mobileNum.BackColor = Color.FromArgb(250, 252, 252);
            txtbox_mobileNum.Font = new Font("Century Gothic", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtbox_mobileNum.ForeColor = Color.FromArgb(58, 58, 58);
            txtbox_mobileNum.Location = new Point(245, 242);
            txtbox_mobileNum.Multiline = true;
            txtbox_mobileNum.Name = "txtbox_mobileNum";
            txtbox_mobileNum.Size = new Size(365, 40);
            txtbox_mobileNum.TabIndex = 8;
            // 
            // txtbox_email
            // 
            txtbox_email.BackColor = Color.FromArgb(250, 252, 252);
            txtbox_email.Font = new Font("Century Gothic", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtbox_email.ForeColor = Color.FromArgb(58, 58, 58);
            txtbox_email.Location = new Point(245, 316);
            txtbox_email.Multiline = true;
            txtbox_email.Name = "txtbox_email";
            txtbox_email.Size = new Size(365, 40);
            txtbox_email.TabIndex = 9;
            // 
            // dtp_date
            // 
            dtp_date.CalendarFont = new Font("Century Gothic", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtp_date.CalendarForeColor = Color.FromArgb(58, 58, 58);
            dtp_date.CalendarMonthBackground = Color.FromArgb(250, 252, 252);
            dtp_date.CalendarTitleBackColor = Color.FromArgb(127, 176, 205);
            dtp_date.CalendarTitleForeColor = Color.FromArgb(58, 58, 58);
            dtp_date.CustomFormat = " ";
            dtp_date.Font = new Font("Century Gothic", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtp_date.Format = DateTimePickerFormat.Custom;
            dtp_date.Location = new Point(245, 394);
            dtp_date.Name = "dtp_date";
            dtp_date.Size = new Size(365, 36);
            dtp_date.TabIndex = 11;
            dtp_date.ValueChanged += dateTimePicker_ValueChanged;
            // 
            // cmb_service
            // 
            cmb_service.BackColor = Color.FromArgb(250, 252, 252);
            cmb_service.Font = new Font("Century Gothic", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmb_service.ForeColor = Color.FromArgb(58, 58, 58);
            cmb_service.FormattingEnabled = true;
            cmb_service.Items.AddRange(new object[] { "-- Select a service --", "Whitening Peel", "Facial Treatment", "Chemical Peeling", "Facial Focusing Acne", "Laser Treatment" });
            cmb_service.Location = new Point(245, 547);
            cmb_service.Name = "cmb_service";
            cmb_service.Size = new Size(365, 35);
            cmb_service.TabIndex = 12;
            cmb_service.Text = "-- Select a service --";
            // 
            // btn_book
            // 
            btn_book.BackColor = Color.FromArgb(127, 176, 205);
            btn_book.Font = new Font("Century Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_book.ForeColor = Color.FromArgb(250, 252, 252);
            btn_book.Location = new Point(341, 655);
            btn_book.Name = "btn_book";
            btn_book.Size = new Size(167, 53);
            btn_book.TabIndex = 14;
            btn_book.Text = "BOOK";
            btn_book.UseVisualStyleBackColor = false;
            btn_book.Click += btn_book_Click;
            // 
            // dtp_time
            // 
            dtp_time.CalendarFont = new Font("Century Gothic", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtp_time.CalendarForeColor = Color.FromArgb(58, 58, 58);
            dtp_time.CalendarMonthBackground = Color.FromArgb(250, 252, 252);
            dtp_time.CalendarTitleBackColor = Color.FromArgb(127, 176, 205);
            dtp_time.CalendarTitleForeColor = Color.FromArgb(58, 58, 58);
            dtp_time.CustomFormat = "hh:mm tt";
            dtp_time.Font = new Font("Century Gothic", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtp_time.Format = DateTimePickerFormat.Custom;
            dtp_time.Location = new Point(245, 469);
            dtp_time.Name = "dtp_time";
            dtp_time.ShowUpDown = true;
            dtp_time.Size = new Size(365, 36);
            dtp_time.TabIndex = 15;
            dtp_time.Value = new DateTime(2025, 6, 23, 16, 38, 22, 215);
            // 
            // Booking
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(250, 252, 252);
            ClientSize = new Size(632, 803);
            Controls.Add(dtp_time);
            Controls.Add(btn_book);
            Controls.Add(cmb_service);
            Controls.Add(dtp_date);
            Controls.Add(txtbox_email);
            Controls.Add(txtbox_mobileNum);
            Controls.Add(txtbox_name);
            Controls.Add(lbl_service);
            Controls.Add(lbl_time);
            Controls.Add(lbl_date);
            Controls.Add(lbl_email);
            Controls.Add(lbl_mobileNum);
            Controls.Add(lbl_name);
            Controls.Add(panel1);
            MaximizeBox = false;
            Name = "Booking";
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
        private Label lbl_book;
        private PictureBox pic_calendar;
        private Label lbl_name;
        private Label lbl_mobileNum;
        private Label lbl_email;
        private Label lbl_date;
        private Label lbl_time;
        private Label lbl_service;
        private TextBox txtbox_name;
        private TextBox txtbox_mobileNum;
        private TextBox txtbox_email;
        private DateTimePicker dtp_date;
        private ComboBox cmb_service;
        private Button btn_book;
        private DateTimePicker dtp_time;
    }
}