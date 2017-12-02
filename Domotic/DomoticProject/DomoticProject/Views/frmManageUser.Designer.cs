namespace DomoticProject.Views
{
    partial class frmManageUser
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
            this.btnCreateUser = new System.Windows.Forms.Button();
            this.btnEditUser = new System.Windows.Forms.Button();
            this.btnDeleteUser = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.lblUsernameLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCreateUser
            // 
            this.btnCreateUser.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnCreateUser.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnCreateUser.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCreateUser.Location = new System.Drawing.Point(167, 31);
            this.btnCreateUser.Name = "btnCreateUser";
            this.btnCreateUser.Size = new System.Drawing.Size(100, 45);
            this.btnCreateUser.TabIndex = 0;
            this.btnCreateUser.Text = "Create User";
            this.btnCreateUser.UseVisualStyleBackColor = false;
            this.btnCreateUser.Click += new System.EventHandler(this.btnCreateUser_Click);
            // 
            // btnEditUser
            // 
            this.btnEditUser.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnEditUser.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnEditUser.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnEditUser.Location = new System.Drawing.Point(167, 87);
            this.btnEditUser.Name = "btnEditUser";
            this.btnEditUser.Size = new System.Drawing.Size(100, 45);
            this.btnEditUser.TabIndex = 1;
            this.btnEditUser.Text = "Edit User";
            this.btnEditUser.UseVisualStyleBackColor = false;
            this.btnEditUser.Click += new System.EventHandler(this.btnEditUser_Click);
            // 
            // btnDeleteUser
            // 
            this.btnDeleteUser.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnDeleteUser.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnDeleteUser.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDeleteUser.Location = new System.Drawing.Point(167, 143);
            this.btnDeleteUser.Name = "btnDeleteUser";
            this.btnDeleteUser.Size = new System.Drawing.Size(100, 45);
            this.btnDeleteUser.TabIndex = 2;
            this.btnDeleteUser.Text = "Delet User";
            this.btnDeleteUser.UseVisualStyleBackColor = false;
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.SystemColors.Control;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnBack.Location = new System.Drawing.Point(103, 208);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 30);
            this.btnBack.TabIndex = 3;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // lblUsernameLabel
            // 
            this.lblUsernameLabel.AutoSize = true;
            this.lblUsernameLabel.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblUsernameLabel.Location = new System.Drawing.Point(4, 247);
            this.lblUsernameLabel.Name = "lblUsernameLabel";
            this.lblUsernameLabel.Size = new System.Drawing.Size(38, 13);
            this.lblUsernameLabel.TabIndex = 4;
            this.lblUsernameLabel.Text = "label1";
            // 
            // frmManageUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.lblUsernameLabel);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnDeleteUser);
            this.Controls.Add(this.btnEditUser);
            this.Controls.Add(this.btnCreateUser);
            this.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.Name = "frmManageUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ManageUser";
            this.Load += new System.EventHandler(this.ManageUser_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCreateUser;
        private System.Windows.Forms.Button btnEditUser;
        private System.Windows.Forms.Button btnDeleteUser;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblUsernameLabel;
    }
}