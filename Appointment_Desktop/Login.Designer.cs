namespace Appointment_Desktop
{
    partial class Login
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
            lbl_login = new Label();
            lbl_username = new Label();
            txtbox_username = new TextBox();
            lbl_pass = new Label();
            txtbox_pass = new TextBox();
            txtbox_login = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(77, 130, 160);
            panel1.Controls.Add(lbl_login);
            panel1.Location = new Point(-4, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(644, 128);
            panel1.TabIndex = 2;
            // 
            // lbl_login
            // 
            lbl_login.AutoSize = true;
            lbl_login.Font = new Font("Century Gothic", 40.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_login.ForeColor = Color.FromArgb(250, 252, 252);
            lbl_login.Location = new Point(188, 23);
            lbl_login.Name = "lbl_login";
            lbl_login.Size = new Size(260, 80);
            lbl_login.TabIndex = 1;
            lbl_login.Text = "ADMIN";
            // 
            // lbl_username
            // 
            lbl_username.AutoSize = true;
            lbl_username.Font = new Font("Century Gothic", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_username.ForeColor = Color.FromArgb(58, 58, 58);
            lbl_username.Location = new Point(45, 271);
            lbl_username.Name = "lbl_username";
            lbl_username.Size = new Size(150, 31);
            lbl_username.TabIndex = 3;
            lbl_username.Text = "Username :";
            // 
            // txtbox_username
            // 
            txtbox_username.BackColor = Color.FromArgb(250, 252, 252);
            txtbox_username.Font = new Font("Century Gothic", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtbox_username.ForeColor = Color.FromArgb(58, 58, 58);
            txtbox_username.Location = new Point(214, 268);
            txtbox_username.Multiline = true;
            txtbox_username.Name = "txtbox_username";
            txtbox_username.Size = new Size(365, 40);
            txtbox_username.TabIndex = 8;
            // 
            // lbl_pass
            // 
            lbl_pass.AutoSize = true;
            lbl_pass.Font = new Font("Century Gothic", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_pass.ForeColor = Color.FromArgb(58, 58, 58);
            lbl_pass.Location = new Point(45, 412);
            lbl_pass.Name = "lbl_pass";
            lbl_pass.Size = new Size(143, 31);
            lbl_pass.TabIndex = 9;
            lbl_pass.Text = "Password :";
            // 
            // txtbox_pass
            // 
            txtbox_pass.BackColor = Color.FromArgb(250, 252, 252);
            txtbox_pass.Font = new Font("Century Gothic", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtbox_pass.ForeColor = Color.FromArgb(58, 58, 58);
            txtbox_pass.Location = new Point(214, 409);
            txtbox_pass.Multiline = true;
            txtbox_pass.Name = "txtbox_pass";
            txtbox_pass.PasswordChar = '●';
            txtbox_pass.Size = new Size(365, 40);
            txtbox_pass.TabIndex = 10;
            // 
            // txtbox_login
            // 
            txtbox_login.BackColor = Color.FromArgb(127, 176, 205);
            txtbox_login.Font = new Font("Century Gothic", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtbox_login.ForeColor = Color.FromArgb(250, 252, 252);
            txtbox_login.Location = new Point(308, 528);
            txtbox_login.Name = "txtbox_login";
            txtbox_login.Size = new Size(173, 60);
            txtbox_login.TabIndex = 16;
            txtbox_login.Text = "LOGIN";
            txtbox_login.UseVisualStyleBackColor = false;
            txtbox_login.Click += txtbox_login_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(250, 252, 252);
            ClientSize = new Size(632, 803);
            Controls.Add(txtbox_login);
            Controls.Add(txtbox_pass);
            Controls.Add(lbl_pass);
            Controls.Add(txtbox_username);
            Controls.Add(lbl_username);
            Controls.Add(panel1);
            MaximizeBox = false;
            Name = "Login";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label lbl_login;
        private Label lbl_username;
        private TextBox txtbox_username;
        private Label lbl_pass;
        private TextBox txtbox_pass;
        private Button txtbox_login;
    }
}