namespace formLogin
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
            lblWelcome = new Label();
            lblUsername = new Label();
            lblPin = new Label();
            tbxUsername = new TextBox();
            tbxPin = new TextBox();
            btnLogin = new Button();
            SuspendLayout();
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblWelcome.Location = new Point(49, 23);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(540, 28);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "WELCOME! PLEASE ENTER YOUR ACCOUNT ^v^";
            lblWelcome.Click += lblWelcome_Click;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUsername.ForeColor = Color.FromArgb(64, 64, 64);
            lblUsername.Location = new Point(82, 94);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(129, 28);
            lblUsername.TabIndex = 1;
            lblUsername.Text = "Username";
            lblUsername.Click += lblUsername_Click;
            // 
            // lblPin
            // 
            lblPin.AutoSize = true;
            lblPin.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPin.ForeColor = Color.FromArgb(64, 64, 64);
            lblPin.Location = new Point(112, 162);
            lblPin.Name = "lblPin";
            lblPin.Size = new Size(45, 28);
            lblPin.TabIndex = 2;
            lblPin.Text = "Pin";
            lblPin.Click += lblPin_Click;
            // 
            // tbxUsername
            // 
            tbxUsername.CharacterCasing = CharacterCasing.Lower;
            tbxUsername.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tbxUsername.Location = new Point(256, 91);
            tbxUsername.MaxLength = 10;
            tbxUsername.Name = "tbxUsername";
            tbxUsername.Size = new Size(228, 37);
            tbxUsername.TabIndex = 3;
            tbxUsername.TextChanged += tbxUsername_TextChanged;
            // 
            // tbxPin
            // 
            tbxPin.CharacterCasing = CharacterCasing.Lower;
            tbxPin.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tbxPin.Location = new Point(256, 153);
            tbxPin.MaxLength = 4;
            tbxPin.Name = "tbxPin";
            tbxPin.Size = new Size(228, 37);
            tbxPin.TabIndex = 4;
            tbxPin.TextChanged += tbxPin_TextChanged;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(255, 192, 255);
            btnLogin.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogin.Location = new Point(298, 228);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(135, 45);
            btnLogin.TabIndex = 5;
            btnLogin.Text = "LOGIN";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // formLogin
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(192, 192, 255);
            ClientSize = new Size(623, 307);
            Controls.Add(btnLogin);
            Controls.Add(tbxPin);
            Controls.Add(tbxUsername);
            Controls.Add(lblPin);
            Controls.Add(lblUsername);
            Controls.Add(lblWelcome);
            Name = "formLogin";
            Text = "ANNYEONG!!!";
            Load += formLogin_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblWelcome;
        private Label lblUsername;
        private Label lblPin;
        private TextBox tbxUsername;
        private TextBox tbxPin;
        private Button btnLogin;
    }
}
