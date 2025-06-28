namespace RantBuddyDesktop
{
    partial class formHomepage
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
            lblOptions = new Label();
            btnCreate = new Button();
            btnRead = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            SuspendLayout();
            // 
            // lblOptions
            // 
            lblOptions.AutoSize = true;
            lblOptions.Font = new Font("Century Gothic", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblOptions.ForeColor = Color.FromArgb(64, 64, 64);
            lblOptions.Location = new Point(97, 36);
            lblOptions.Name = "lblOptions";
            lblOptions.Size = new Size(410, 34);
            lblOptions.TabIndex = 0;
            lblOptions.Text = "WHAT DO YOU WANT TO DO?";
            // 
            // btnCreate
            // 
            btnCreate.BackColor = Color.Thistle;
            btnCreate.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCreate.ForeColor = Color.FromArgb(64, 64, 64);
            btnCreate.Location = new Point(111, 89);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(147, 48);
            btnCreate.TabIndex = 1;
            btnCreate.Text = "CREATE";
            btnCreate.UseVisualStyleBackColor = false;
            btnCreate.Click += btnCreate_Click;
            // 
            // btnRead
            // 
            btnRead.BackColor = Color.Thistle;
            btnRead.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRead.ForeColor = Color.FromArgb(64, 64, 64);
            btnRead.Location = new Point(111, 160);
            btnRead.Name = "btnRead";
            btnRead.RightToLeft = RightToLeft.Yes;
            btnRead.Size = new Size(147, 48);
            btnRead.TabIndex = 2;
            btnRead.Text = "READ";
            btnRead.UseVisualStyleBackColor = false;
            btnRead.Click += btnRead_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.Thistle;
            btnUpdate.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUpdate.ForeColor = Color.FromArgb(64, 64, 64);
            btnUpdate.Location = new Point(111, 232);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.RightToLeft = RightToLeft.Yes;
            btnUpdate.Size = new Size(147, 48);
            btnUpdate.TabIndex = 3;
            btnUpdate.Text = "UPDATE";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.Thistle;
            btnDelete.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDelete.ForeColor = Color.FromArgb(64, 64, 64);
            btnDelete.Location = new Point(349, 89);
            btnDelete.Name = "btnDelete";
            btnDelete.RightToLeft = RightToLeft.Yes;
            btnDelete.Size = new Size(147, 48);
            btnDelete.TabIndex = 4;
            btnDelete.Text = "DELETE";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // formHomepage
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(192, 192, 255);
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(616, 599);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnRead);
            Controls.Add(btnCreate);
            Controls.Add(lblOptions);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "formHomepage";
            Text = "HOMEPAGE";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblOptions;
        private Button btnCreate;
        private Button btnRead;
        private Button btnUpdate;
        private Button btnDelete;
    }
}