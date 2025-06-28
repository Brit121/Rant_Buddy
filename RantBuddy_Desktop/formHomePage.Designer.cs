namespace RantBuddy_Desktop
{
    partial class formHomePage
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            lblSelect = new System.Windows.Forms.Label();
            btnCreate = new System.Windows.Forms.Button();
            btnRead = new System.Windows.Forms.Button();
            btnUpdate = new System.Windows.Forms.Button();
            btnDelete = new System.Windows.Forms.Button();
            btnSearch = new System.Windows.Forms.Button();
            btnExit = new System.Windows.Forms.Button();
            dgvRants = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvRants).BeginInit();
            SuspendLayout();
            // 
            // lblSelect
            // 
            lblSelect.AutoSize = true;
            lblSelect.BackColor = System.Drawing.Color.Transparent;
            lblSelect.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            lblSelect.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            lblSelect.Location = new System.Drawing.Point(75, 27);
            lblSelect.Name = "lblSelect";
            lblSelect.Size = new System.Drawing.Size(388, 30);
            lblSelect.TabIndex = 0;
            lblSelect.Text = "PLEASE SELECT AN OPTION";
            lblSelect.Click += label1_Click;
            // 
            // btnCreate
            // 
            btnCreate.BackColor = System.Drawing.Color.Thistle;
            btnCreate.Font = new System.Drawing.Font("Bookman Old Style", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            btnCreate.ForeColor = System.Drawing.Color.Black;
            btnCreate.Location = new System.Drawing.Point(37, 85);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new System.Drawing.Size(176, 49);
            btnCreate.TabIndex = 1;
            btnCreate.Text = "CREATE";
            btnCreate.UseVisualStyleBackColor = false;
            btnCreate.Click += btnCreate_Click;
            // 
            // btnRead
            // 
            btnRead.BackColor = System.Drawing.Color.Thistle;
            btnRead.Font = new System.Drawing.Font("Bookman Old Style", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            btnRead.ForeColor = System.Drawing.Color.Black;
            btnRead.Location = new System.Drawing.Point(37, 155);
            btnRead.Name = "btnRead";
            btnRead.Size = new System.Drawing.Size(176, 49);
            btnRead.TabIndex = 2;
            btnRead.Text = "READ";
            btnRead.UseVisualStyleBackColor = false;
            btnRead.Click += btnRead_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = System.Drawing.Color.Thistle;
            btnUpdate.Font = new System.Drawing.Font("Bookman Old Style", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            btnUpdate.ForeColor = System.Drawing.Color.Black;
            btnUpdate.Location = new System.Drawing.Point(325, 85);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new System.Drawing.Size(176, 49);
            btnUpdate.TabIndex = 3;
            btnUpdate.Text = "UPDATE";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = System.Drawing.Color.Thistle;
            btnDelete.Font = new System.Drawing.Font("Bookman Old Style", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            btnDelete.ForeColor = System.Drawing.Color.Black;
            btnDelete.Location = new System.Drawing.Point(325, 155);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new System.Drawing.Size(176, 49);
            btnDelete.TabIndex = 4;
            btnDelete.Text = "DELETE";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = System.Drawing.Color.Thistle;
            btnSearch.Font = new System.Drawing.Font("Bookman Old Style", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            btnSearch.ForeColor = System.Drawing.Color.Black;
            btnSearch.Location = new System.Drawing.Point(37, 226);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new System.Drawing.Size(176, 49);
            btnSearch.TabIndex = 5;
            btnSearch.Text = "SEARCH";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnExit
            // 
            btnExit.BackColor = System.Drawing.Color.Thistle;
            btnExit.Font = new System.Drawing.Font("Bookman Old Style", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            btnExit.ForeColor = System.Drawing.Color.Black;
            btnExit.Location = new System.Drawing.Point(325, 226);
            btnExit.Name = "btnExit";
            btnExit.Size = new System.Drawing.Size(176, 49);
            btnExit.TabIndex = 6;
            btnExit.Text = "EXIT";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            // 
            // dgvRants
            // 
            dgvRants.AllowUserToAddRows = false;
            dgvRants.AllowUserToDeleteRows = false;
            dgvRants.AllowUserToResizeColumns = false;
            dgvRants.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Schoolbook", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            dgvRants.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvRants.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvRants.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dgvRants.BackgroundColor = System.Drawing.Color.Thistle;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dgvRants.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvRants.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRants.Location = new System.Drawing.Point(22, 298);
            dgvRants.Name = "dgvRants";
            dgvRants.ReadOnly = true;
            dgvRants.RowHeadersWidth = 62;
            dgvRants.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvRants.Size = new System.Drawing.Size(517, 169);
            dgvRants.TabIndex = 7;
            dgvRants.CellContentClick += dgvRants_CellContentClick;
            // 
            // formHomePage
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
            ClientSize = new System.Drawing.Size(560, 479);
            Controls.Add(dgvRants);
            Controls.Add(btnExit);
            Controls.Add(btnSearch);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnRead);
            Controls.Add(btnCreate);
            Controls.Add(lblSelect);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            Name = "formHomePage";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "HOME PAGE";
            Load += formHomePage_Load;
            ((System.ComponentModel.ISupportInitialize)dgvRants).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblSelect;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.DataGridView dgvRants;
    }
}