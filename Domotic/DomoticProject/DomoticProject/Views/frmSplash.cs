using System;
using System.Windows.Forms;

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
            progressBar.Maximum = 1400;

            progressBar.Step = 1;

            for (int i = 0; i <= 1400; i++)
            {
                progressBar.PerformStep();
            }
        }
    }
}
