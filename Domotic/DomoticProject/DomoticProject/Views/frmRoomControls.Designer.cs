namespace DomoticProject.Views
{
    partial class frmRoomControls
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRoomControls));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnOff = new System.Windows.Forms.Button();
            this.btnOn = new System.Windows.Forms.Button();
            this.pctDeviceStateOn = new System.Windows.Forms.PictureBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnAddDevice = new System.Windows.Forms.Button();
            this.lblHumidityUnit = new System.Windows.Forms.Label();
            this.lblHumidity = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblUnitTemp = new System.Windows.Forms.Label();
            this.lblTemp = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pctDeviceStateOff = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboDevices = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctDeviceStateOn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctDeviceStateOff)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnOff);
            this.panel1.Controls.Add(this.btnOn);
            this.panel1.Controls.Add(this.pctDeviceStateOn);
            this.panel1.Controls.Add(this.btnBack);
            this.panel1.Controls.Add(this.btnAddDevice);
            this.panel1.Controls.Add(this.lblHumidityUnit);
            this.panel1.Controls.Add(this.lblHumidity);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.lblUnitTemp);
            this.panel1.Controls.Add(this.lblTemp);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.pctDeviceStateOff);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cboDevices);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(318, 237);
            this.panel1.TabIndex = 0;
            // 
            // btnOff
            // 
            this.btnOff.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnOff.Location = new System.Drawing.Point(243, 52);
            this.btnOff.Name = "btnOff";
            this.btnOff.Size = new System.Drawing.Size(35, 31);
            this.btnOff.TabIndex = 16;
            this.btnOff.Text = "Off";
            this.btnOff.UseVisualStyleBackColor = false;
            this.btnOff.Click += new System.EventHandler(this.btnOff_Click);
            // 
            // btnOn
            // 
            this.btnOn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnOn.Location = new System.Drawing.Point(243, 52);
            this.btnOn.Name = "btnOn";
            this.btnOn.Size = new System.Drawing.Size(35, 31);
            this.btnOn.TabIndex = 15;
            this.btnOn.Text = "On";
            this.btnOn.UseVisualStyleBackColor = false;
            this.btnOn.Click += new System.EventHandler(this.btnOn_Click);
            // 
            // pctDeviceStateOn
            // 
            this.pctDeviceStateOn.Image = global::DomoticProject.Properties.Resources.LightOn;
            this.pctDeviceStateOn.Location = new System.Drawing.Point(177, 48);
            this.pctDeviceStateOn.Name = "pctDeviceStateOn";
            this.pctDeviceStateOn.Size = new System.Drawing.Size(35, 35);
            this.pctDeviceStateOn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctDeviceStateOn.TabIndex = 14;
            this.pctDeviceStateOn.TabStop = false;
            this.pctDeviceStateOn.Click += new System.EventHandler(this.pctDeviceStateOn_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnBack.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnBack.Location = new System.Drawing.Point(179, 179);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(100, 45);
            this.btnBack.TabIndex = 13;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnAddDevice
            // 
            this.btnAddDevice.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnAddDevice.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnAddDevice.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAddDevice.Location = new System.Drawing.Point(46, 179);
            this.btnAddDevice.Name = "btnAddDevice";
            this.btnAddDevice.Size = new System.Drawing.Size(100, 45);
            this.btnAddDevice.TabIndex = 12;
            this.btnAddDevice.Text = "Add Device";
            this.btnAddDevice.UseVisualStyleBackColor = false;
            // 
            // lblHumidityUnit
            // 
            this.lblHumidityUnit.AutoSize = true;
            this.lblHumidityUnit.Location = new System.Drawing.Point(243, 143);
            this.lblHumidityUnit.Name = "lblHumidityUnit";
            this.lblHumidityUnit.Size = new System.Drawing.Size(35, 13);
            this.lblHumidityUnit.TabIndex = 11;
            this.lblHumidityUnit.Text = "label6";
            // 
            // lblHumidity
            // 
            this.lblHumidity.AutoSize = true;
            this.lblHumidity.Location = new System.Drawing.Point(177, 143);
            this.lblHumidity.Name = "lblHumidity";
            this.lblHumidity.Size = new System.Drawing.Size(35, 13);
            this.lblHumidity.TabIndex = 10;
            this.lblHumidity.Text = "label6";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(53, 143);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Humidity:";
            // 
            // lblUnitTemp
            // 
            this.lblUnitTemp.AutoSize = true;
            this.lblUnitTemp.Location = new System.Drawing.Point(243, 106);
            this.lblUnitTemp.Name = "lblUnitTemp";
            this.lblUnitTemp.Size = new System.Drawing.Size(35, 13);
            this.lblUnitTemp.TabIndex = 8;
            this.lblUnitTemp.Text = "label5";
            // 
            // lblTemp
            // 
            this.lblTemp.AutoSize = true;
            this.lblTemp.Location = new System.Drawing.Point(177, 106);
            this.lblTemp.Name = "lblTemp";
            this.lblTemp.Size = new System.Drawing.Size(35, 13);
            this.lblTemp.TabIndex = 7;
            this.lblTemp.Text = "label5";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(43, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Temperature:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(58, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Device";
            // 
            // pctDeviceStateOff
            // 
            this.pctDeviceStateOff.Image = ((System.Drawing.Image)(resources.GetObject("pctDeviceStateOff.Image")));
            this.pctDeviceStateOff.Location = new System.Drawing.Point(177, 48);
            this.pctDeviceStateOff.Name = "pctDeviceStateOff";
            this.pctDeviceStateOff.Size = new System.Drawing.Size(35, 35);
            this.pctDeviceStateOff.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctDeviceStateOff.TabIndex = 3;
            this.pctDeviceStateOff.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(242, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Action";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(178, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "State";
            // 
            // cboDevices
            // 
            this.cboDevices.FormattingEnabled = true;
            this.cboDevices.Location = new System.Drawing.Point(18, 55);
            this.cboDevices.Name = "cboDevices";
            this.cboDevices.Size = new System.Drawing.Size(121, 21);
            this.cboDevices.TabIndex = 0;
            this.cboDevices.SelectedIndexChanged += new System.EventHandler(this.cboDevices_SelectedIndexChanged);
            // 
            // frmRoomControls
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(342, 261);
            this.Controls.Add(this.panel1);
            this.Name = "frmRoomControls";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Room Controls";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmLibiasRoom_FormClosing);
            this.Load += new System.EventHandler(this.LibiasRoom_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctDeviceStateOn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctDeviceStateOff)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboDevices;
        private System.Windows.Forms.PictureBox pctDeviceStateOff;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnAddDevice;
        private System.Windows.Forms.Label lblHumidityUnit;
        private System.Windows.Forms.Label lblHumidity;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblUnitTemp;
        private System.Windows.Forms.Label lblTemp;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pctDeviceStateOn;
        private System.Windows.Forms.Button btnOn;
        private System.Windows.Forms.Button btnOff;
    }
}