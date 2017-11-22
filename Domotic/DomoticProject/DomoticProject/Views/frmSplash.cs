using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DomoticProject.DTO;

namespace DomoticProject.Views
{
    public partial class frmSplash : Form
    {
        private static frmSplash _Request;

        public static frmSplash GetRequest()
        {
            if (_Request == null || _Request.IsDisposed)
            {
                _Request = new frmSplash();
            }
            _Request.BringToFront();
            return _Request;
        }


        public frmSplash()
        {
            InitializeComponent();
        }

        private void frmSplash_Load(object sender, EventArgs e)
        {
            progressBar.Minimum = 0;
            progressBar.Maximum = 40;

            progressBar.Step = 1;

            for (int i = 0; i <= 40; i++)
            {
                progressBar.PerformStep();
            }
        }
    }
}
