using DomoticProject.Controllers.LogicBusiness.Global;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DomoticProject.Views
{
    public partial class frmRooms : Form
    {
        public LocalizationManager localizationManager = LocalizationManager.Instance;

        int RoomID;
        private static frmRooms _Request;

        public static frmRooms GetRequest()
        {
            if (_Request == null || _Request.IsDisposed)
            {
                _Request = new frmRooms();
            }
            _Request.BringToFront();

            return _Request;
        }

        public frmRooms()
        {
            if (GlobalManager.Instance.Culture != null) localizationManager.SetCulture(GlobalManager.Instance.Culture);

            InitializeComponent();
            this.Font = new Font("Segoe UI", 8);
            this.Text = "Home Automation";
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLogin frm = frmLogin.GetRequest();
            frm.Show();
            this.Visible = false;
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnLibiasRoom_Click(object sender, EventArgs e)
        {
            RoomID = 1;
            frmRoomControls frm = frmRoomControls.GetRequest(RoomID);
            frm.Show();
            this.Visible = false;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmMain frm = frmMain.GetRequest();
            frm.Show();
            this.Visible = false;
        }

        private void btnMHsRoom_Click(object sender, EventArgs e)
        {
            RoomID = 2;
            frmRoomControls frm = frmRoomControls.GetRequest(RoomID);
            frm.Show();
            this.Visible = false;
        }
    }
}
