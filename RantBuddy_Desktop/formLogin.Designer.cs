using RantBuddyDataService;
using System;
using System.Windows.Forms;

namespace RantBuddy_Desktop
{
    partial class formLogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblLogin = new Label();
            lblUsername = new Label();
            lblPin = new Label();
            tbxUsername = new TextBox();
            tbxPin = new TextBox();
            btnLogin = new Button();
            SuspendLayout();
            // 
            // lblLogin
            // 
            lblLogin.AutoSize = true;
            lblLogin.Font = new System.Drawing.Font("Lucida Console", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            lblLogin.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            lblLogin.Location = new System.Drawing.Point(50, 31);
            lblLogin.Name = "lblLogin";
            lblLogin.Size = new System.Drawing.Size(412, 20);
            lblLogin.TabIndex = 0;
            lblLogin.Text = "PLEASE LOGIN YOUR ACCOUNT ^ v ^";
            lblLogin.Click += lblLogin_Click;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            lblUsername.Location = new System.Drawing.Point(68, 104);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new System.Drawing.Size(124, 25);
            lblUsername.TabIndex = 1;
            lblUsername.Text = "Username";
            lblUsername.Click += lblUsername_Click;
            // 
            // lblPin
            // 
            lblPin.AutoSize = true;
            lblPin.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            lblPin.Location = new System.Drawing.Point(102, 159);
            lblPin.Name = "lblPin";
            lblPin.Size = new System.Drawing.Size(48, 25);
            lblPin.TabIndex = 2;
            lblPin.Text = "Pin";
            lblPin.Click += lblPin_Click;
            // 
            // tbxUsername
            // 
            tbxUsername.CharacterCasing = CharacterCasing.Lower;
            tbxUsername.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            tbxUsername.Location = new System.Drawing.Point(228, 95);
            tbxUsername.MaxLength = 10;
            tbxUsername.Name = "tbxUsername";
            tbxUsername.Size = new System.Drawing.Size(189, 34);
            tbxUsername.TabIndex = 3;
            tbxUsername.TextChanged += tbxUsername_TextChanged;
            // 
            // tbxPin
            // 
            tbxPin.CharacterCasing = CharacterCasing.Lower;
            tbxPin.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            tbxPin.Location = new System.Drawing.Point(228, 150);
            tbxPin.MaxLength = 4;
            tbxPin.Name = "tbxPin";
            tbxPin.Size = new System.Drawing.Size(189, 34);
            tbxPin.TabIndex = 4;
            tbxPin.UseSystemPasswordChar = true;
            tbxPin.TextChanged += tbxPin_TextChanged;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = System.Drawing.Color.FromArgb(128, 128, 255);
            btnLogin.Font = new System.Drawing.Font("Mongolian Baiti", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            btnLogin.Location = new System.Drawing.Point(184, 207);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new System.Drawing.Size(135, 47);
            btnLogin.TabIndex = 5;
            btnLogin.Text = "LOGIN";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // formLogin
            // 
            BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
            ClientSize = new System.Drawing.Size(531, 282);
            Controls.Add(btnLogin);
            Controls.Add(tbxPin);
            Controls.Add(tbxUsername);
            Controls.Add(lblPin);
            Controls.Add(lblUsername);
            Controls.Add(lblLogin);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "formLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "HELLO, WELCOME!";
            ResumeLayout(false);
            PerformLayout();
            // 
            // Form1
            // 

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = tbxUsername.Text.Trim();
            string pin = tbxPin.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(pin))
            {
                MessageBox.Show("Please enter both username and pin.", "Missing Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            RantBuddy_Service service = new RantBuddy_Service();
            bool isValid = service.ValidateAccount(username, pin);

            if (isValid)
            {
                MessageBox.Show("Login successful!", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information);

                formHomePage home = new formHomePage(tbxUsername.Text); 
                home.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or pin. Please try again.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tbxUsername_TextChanged(object sender, EventArgs e) { }
        private void tbxPin_TextChanged(object sender, EventArgs e) { }
        private void lblPin_Click(object sender, EventArgs e) { }
        private void lblUsername_Click(object sender, EventArgs e) { }
        private void lblLogin_Click(object sender, EventArgs e) { }

        #endregion

        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblPin;
        private System.Windows.Forms.TextBox tbxUsername;
        private System.Windows.Forms.TextBox tbxPin;
        private System.Windows.Forms.Button btnLogin;
    }
}
