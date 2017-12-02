using DomoticProject.Controllers;
using DomoticProject.Controllers.LogicBusiness.Global;
using DomoticProject.Model;
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
    public partial class frmEditUser : Form
    {
        private static frmEditUser _Request;

        public static frmEditUser GetRequest()
        {
            if (_Request == null || _Request.IsDisposed)
            {
                _Request = new frmEditUser();
            }
            _Request.BringToFront();
            return _Request;
        }

        public frmEditUser()
        {
            InitializeComponent();
            this.Font = new Font("Segoe UI", 8);
            this.Text = "Home Automation";
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmManageUser frm = frmManageUser.GetRequest();
            frm.Show();
            this.Visible = false;
        }

        private void btnEditUser_Click(object sender, EventArgs e)
        {
            //Inputs definitions
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string name = txtName.Text;
            string lastname = txtLastname.Text;
            string email = txtEmail.Text;

            //Validate inputs
            #region "ValidateInputs"
            if (name == null || name == "")
            {
                MessageBox.Show("Name can't be empty");
                return;
            }

            if (lastname == null || lastname == "")
            {
                MessageBox.Show("Lastname can't be empty");
                return;
            }

            if (username == null || username == "")
            {
                MessageBox.Show("Username can't be empty");
                return;
            }

            List<User> registers = UserController.ListByUsername(txtUsername.Text);
            if (registers.Count > 0)
            {
                MessageBox.Show("Username already exists");
                return;
            }

            if (password.Length < 8)
            {
                MessageBox.Show("Password must be must contain 8 character or more");
                return;
            }

            int countUppercase = 0;
            foreach (char c in password)
            {
                if (Char.IsUpper(c))
                    countUppercase++;
            }

            if (countUppercase < 1)
            {
                MessageBox.Show("Password must be must contain 1 uppercase at least");
                return;
            }

            #endregion

            //Build user DTO 
            User user = new User();
            user.Username = txtUsername.Text;
            user.Name = txtName.Text;
            user.Lastname = txtLastname.Text;
            user.Email = txtEmail.Text;

            UserKeyPair encyptedHash = PasswordSecurity.CreateUserHash(password);
            user.Password = encyptedHash.HashedPassword;
            user.Salt = encyptedHash.Salt;

            user.PasswordRetries = 0;
            user.MaxRetries = 3;
            user.IsActive = true;
            user.IsDeleted = false;

            UserController.Add(user);
        }
    }
}
