using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DomoticProject.Views;
using DomoticProject.Controllers;
using System.Security.Cryptography;
using DomoticProject.Controllers.LogicBusiness.Global;
using DomoticProject.Model;
using DomoticProject.DTO;
using HomeAutomation.Response;
using DomoticProject.Logger;

namespace DomoticProject
{
    public partial class frmLogin : Form
    {
        static String profileName = "(Login)";

        private static frmLogin _Request;

        public static frmLogin GetRequest()
        {
            if (_Request == null || _Request.IsDisposed)
            {
                _Request = new frmLogin();
            }
            _Request.BringToFront();

            return _Request;

        }


        public frmLogin()
        {
            this.Font = new Font("Segoe UI", 8);
            InitializeComponent();
            
        }

        private void btnCreateUser_Click(object sender, EventArgs e)
        {
            CreateUser frm = CreateUser.GetRequest();
            frm.Show();
            this.Visible = false;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txtUsername.Text;
                string password = txtPassword.Text;

                #region "ValidateInputs"
                //Verify the username input 
                if (username == null || username == "")
                {
                    MessageBox.Show("Username can't be empty");
                    return;
                }

                //Verify the password input 
                if (password == null || password == "")
                {
                    MessageBox.Show("Password can't be empty");
                    return;
                }

                //User Validation
                UserResponse passwordValidation = Security.PasswordValidation(username, password);

                if (passwordValidation.Code != 0)
                {
                    Logger.Logger.Info(profileName, "Method Response: Invalid access permissions. Username:" + username);
                    MessageBox.Show("Message error: " + passwordValidation.Message + " Error Code: " + passwordValidation.Code);
                    return;
                }


                frmMain frm = frmMain.GetRequest();
                frm.Show();
                this.Visible = false;
                #endregion
            }
            catch (Exception ex)
            {
                Logger.Logger.ErrorL(profileName, "Endpoint not found exception", ex);
                MessageBox.Show("Exception: " + ex);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void txtUsername_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
        }

        private void txtPassword_Click(object sender, EventArgs e)
        {
            txtPassword.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.ActiveControl = btnLogin;
        }
    }
}
