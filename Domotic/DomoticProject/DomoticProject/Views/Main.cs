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
            if (GlobalManager.Instance.Culture != null) localizationManager.SetCulture(GlobalManager.Instance.Culture);

            frmSplash frm = frmSplash.GetRequest();
            frm.Show();

            InitializeComponent();
            this.Font = new Font("Segoe UI", 8);
            this.Text = "Home Automation - " + GlobalManager.Instance.Name + " " + GlobalManager.Instance.Lastname;
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
            LibiasRoom frm = LibiasRoom.GetRequest();
            frm.Show();
            this.Visible = false;
        }
    }
}
