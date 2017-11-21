using DomoticProject.Controllers.Queries;
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
    public partial class LibiasRoom : Form
    {
        static int roomId = 1;
        private static LibiasRoom _Request;

        public static LibiasRoom GetRequest()
        {
            if (_Request == null || _Request.IsDisposed)
            {
                _Request = new LibiasRoom();
            }
            _Request.BringToFront();


            return _Request;

        }


        public LibiasRoom()
        {
            this.Font = new Font("Segoe UI", 8);
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void LibiasRoom_Load(object sender, EventArgs e)
        {
            List<GetDevicesByRoomId_Result> lstDevicesByRoomId = DeviceController.GetDevicesByRoomId(roomId);
            GetDevicesByRoomId_Result selectOneDevice = new GetDevicesByRoomId_Result() { Device = "Select One", DeviceID = 0 };
            lstDevicesByRoomId.Insert(0, selectOneDevice);
            cboDevices.ValueMember = "DeviceID";
            cboDevices.DisplayMember = "Device";
            cboDevices.DataSource = lstDevicesByRoomId;
            cboDevices.SelectedValue = 0;
            timer1.Start();
        }

        private void cboDevices_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int selectedDeviceID = (int)cboDevices.SelectedValue;
            //lbl


            //List<City> lsCities = CityController.GetByCountryID(selectedCountryId);
            //lsCities.Add(new City() { Name = "Select One", CityID = 0 });
            //cboCityHeadquarter.DataSource = lsCities;
            //cboCityHeadquarter.ValueMember = "CityID";
            //cboCityHeadquarter.DisplayMember = "Name";
            //cboCityHeadquarter.SelectedValue = 0;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            LibiasRoom.ActiveForm.Refresh();
        }
    }
}
