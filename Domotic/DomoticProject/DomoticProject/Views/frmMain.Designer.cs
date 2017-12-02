namespace DomoticProject.Views
{
    partial class frmMain
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
            this.btnManageUser = new System.Windows.Forms.Button();
            this.btnRooms = new System.Windows.Forms.Button();
            this.btnStatistics = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnFrench = new System.Windows.Forms.Button();
            this.btnEnglish = new System.Windows.Forms.Button();
            this.btnEspañol = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblUsernameLabel = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnManageUser
            // 
            this.btnManageUser.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnManageUser.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnManageUser.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnManageUser.Location = new System.Drawing.Point(9, 11);
            this.btnManageUser.Name = "btnManageUser";
            this.btnManageUser.Size = new System.Drawing.Size(100, 45);
            this.btnManageUser.TabIndex = 0;
            this.btnManageUser.Text = "Manage User";
            this.btnManageUser.UseVisualStyleBackColor = false;
            this.btnManageUser.Click += new System.EventHandler(this.btnManageUser_Click);
            // 
            // btnRooms
            // 
            this.btnRooms.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnRooms.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnRooms.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnRooms.Location = new System.Drawing.Point(9, 61);
            this.btnRooms.Name = "btnRooms";
            this.btnRooms.Size = new System.Drawing.Size(100, 45);
            this.btnRooms.TabIndex = 1;
            this.btnRooms.Text = "Rooms";
            this.btnRooms.UseVisualStyleBackColor = false;
            this.btnRooms.Click += new System.EventHandler(this.btnRooms_Click);
            // 
            // btnStatistics
            // 
            this.btnStatistics.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnStatistics.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnStatistics.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnStatistics.Location = new System.Drawing.Point(9, 111);
            this.btnStatistics.Name = "btnStatistics";
            this.btnStatistics.Size = new System.Drawing.Size(100, 45);
            this.btnStatistics.TabIndex = 2;
            this.btnStatistics.Text = "Statistics";
            this.btnStatistics.UseVisualStyleBackColor = false;
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.SystemColors.Control;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnLogout.Location = new System.Drawing.Point(22, 191);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(75, 30);
            this.btnLogout.TabIndex = 3;
            this.btnLogout.Text = "Log Out";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(12, 33);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(191, 236);
            this.panel1.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnStatistics);
            this.panel2.Controls.Add(this.btnManageUser);
            this.panel2.Controls.Add(this.btnLogout);
            this.panel2.Controls.Add(this.btnRooms);
            this.panel2.Location = new System.Drawing.Point(214, 33);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(119, 236);
            this.panel2.TabIndex = 5;
            // 
            // btnFrench
            // 
            this.btnFrench.Location = new System.Drawing.Point(244, 4);
            this.btnFrench.Name = "btnFrench";
            this.btnFrench.Size = new System.Drawing.Size(28, 23);
            this.btnFrench.TabIndex = 15;
            this.btnFrench.Text = "Fr";
            this.btnFrench.UseVisualStyleBackColor = true;
            // 
            // btnEnglish
            // 
            this.btnEnglish.Location = new System.Drawing.Point(305, 4);
            this.btnEnglish.Name = "btnEnglish";
            this.btnEnglish.Size = new System.Drawing.Size(28, 23);
            this.btnEnglish.TabIndex = 14;
            this.btnEnglish.Text = "Eu";
            this.btnEnglish.UseVisualStyleBackColor = true;
            // 
            // btnEspañol
            // 
            this.btnEspañol.Location = new System.Drawing.Point(275, 4);
            this.btnEspañol.Name = "btnEspañol";
            this.btnEspañol.Size = new System.Drawing.Size(27, 23);
            this.btnEspañol.TabIndex = 13;
            this.btnEspañol.Text = "Es";
            this.btnEspañol.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(344, 24);
            this.menuStrip1.TabIndex = 16;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logOutToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // logOutToolStripMenuItem
            // 
            this.logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            this.logOutToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.logOutToolStripMenuItem.Text = "Log Out";
            // 
            // lblUsernameLabel
            // 
            this.lblUsernameLabel.AutoSize = true;
            this.lblUsernameLabel.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblUsernameLabel.Location = new System.Drawing.Point(5, 265);
            this.lblUsernameLabel.Name = "lblUsernameLabel";
            this.lblUsernameLabel.Size = new System.Drawing.Size(38, 13);
            this.lblUsernameLabel.TabIndex = 17;
            this.lblUsernameLabel.Text = "label1";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(344, 281);
            this.Controls.Add(this.lblUsernameLabel);
            this.Controls.Add(this.btnFrench);
            this.Controls.Add(this.btnEnglish);
            this.Controls.Add(this.btnEspañol);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.Main2_Load);
            this.panel2.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnManageUser;
        private System.Windows.Forms.Button btnRooms;
        private System.Windows.Forms.Button btnStatistics;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnFrench;
        private System.Windows.Forms.Button btnEnglish;
        private System.Windows.Forms.Button btnEspañol;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logOutToolStripMenuItem;
        private System.Windows.Forms.Label lblUsernameLabel;
    }
}