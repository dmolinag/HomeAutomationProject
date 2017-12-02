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
    public partial class frmMain : Form
    {
        public LocalizationManager localizationManager = LocalizationManager.Instance;
        static String profileName = "(Main)";

        private static frmMain _Request;

        public static frmMain GetRequest()
        {
            if (_Request == null || _Request.IsDisposed)
            {
                _Request = new frmMain();
            }
            _Request.BringToFront();

            return _Request;
        }

        public frmMain()
        {
            frmSplash frm = frmSplash.GetRequest();
            frm.Show();
            frm.Visible = false;
            InitializeComponent();
            this.Font = new Font("Segoe UI", 8);
            this.Text = "Home Automation";
        }

        private void Main2_Load(object sender, EventArgs e)
        {
            if (GlobalManager.Instance.Culture != null) localizationManager.SetCulture(GlobalManager.Instance.Culture);

            this.lblUsernameLabel.Text = "Active user: " + GlobalManager.Instance.Name + " " + GlobalManager.Instance.Lastname;
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            frmLogin frm = frmLogin.GetRequest();
            frm.Show();
            this.Dispose();
        }

        private void btnRooms_Click(object sender, EventArgs e)
        {
            frmRooms frm = frmRooms.GetRequest();
            frm.Show();
            this.Visible = false;
        }

        private void btnManageUser_Click(object sender, EventArgs e)
        {
            frmManageUser frm = frmManageUser.GetRequest();
            frm.Show();
            this.Visible = false;
        }
    }
}
