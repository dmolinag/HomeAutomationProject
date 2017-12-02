using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DomoticProject.Controllers;
using DomoticProject.Controllers.LogicBusiness.Global;
using DomoticProject.Model;
using System.Drawing;

namespace DomoticProject.Views
{
    public partial class frmCreateUser : Form
    {
        private static frmCreateUser _Request;

        public static frmCreateUser GetRequest()
        {
            if (_Request == null || _Request.IsDisposed)
            {
                _Request = new frmCreateUser();
            }
            _Request.BringToFront();
            return _Request;
        }

        public frmCreateUser()
        {
            InitializeComponent();
            this.Font = new Font("Segoe UI", 8);
            this.Text = "Home Automation";
        }

        private void btnCreateUser_Click(object sender, EventArgs e)
        {
            try
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
                foreach(char c in password)
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

            catch (Exception ex)
            {
                Logger.Logger.ErrorL("PasswordRetriesListByUtilityID", "Endpoint not found exception", ex);
                MessageBox.Show("Exception: " + ex);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmManageUser frm = frmManageUser.GetRequest();
            frm.Show();
            this.Visible = false;
        }

        private void frmCreateUser_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void frmCreateUser_Load(object sender, EventArgs e)
        {

        }
    }
}
