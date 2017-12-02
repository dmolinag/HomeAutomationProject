using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DomoticProject.Controllers.LogicBusiness.Global;

namespace DomoticProject.Views
{
    public partial class frmManageUser : Form
    {
        private static frmManageUser _Request;

        public static frmManageUser GetRequest()
        {
            if (_Request == null || _Request.IsDisposed)
            {
                _Request = new frmManageUser();
            }
            _Request.BringToFront();
            return _Request;
        }

        public frmManageUser()
        {
            InitializeComponent();
            this.Font = new Font("Segoe UI", 8);
            this.Text = "Home Automation";
        }

        private void ManageUser_Load(object sender, EventArgs e)
        {
            this.lblUsernameLabel.Text = "Active user: " + GlobalManager.Instance.Name + " " + GlobalManager.Instance.Lastname;
        }

        private void btnCreateUser_Click(object sender, EventArgs e)
        {
            frmCreateUser frm = frmCreateUser.GetRequest();
            frm.Show();
            this.Visible = false;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmMain frm = frmMain.GetRequest();
            frm.Show();
            this.Visible = false;
        }

        private void btnEditUser_Click(object sender, EventArgs e)
        {
            frmEditUser frm = frmEditUser.GetRequest();
            frm.Show();
            this.Visible = false;
        }
    }
}
