using DomoticProject.Controllers.DTO;
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
        }

        private void cboDevices_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int selectedDeviceID = (int)cboDevices.SelectedValue;
                if(selectedDeviceID == 0)
                {
                    btnOff.Enabled = false;
                    btnOn.Enabled = false;
                }
                else
                {
                    btnOff.Enabled = true;
                    btnOn.Enabled = true;
                }
                   
                List<GetDeviceByRoomIdAndDeviceID_Result> lstDeviceByRoomIdAndDeviceId = DeviceController.GetDeviceByRoomIdAndDeviceId(roomId, selectedDeviceID);
                List<DevicesDTO> retVal = new List<DevicesDTO>();
                foreach (GetDeviceByRoomIdAndDeviceID_Result reg in lstDeviceByRoomIdAndDeviceId)
                {
                    retVal.Add(new DevicesDTO(reg));
                }

                if (selectedDeviceID == 3)
                {
                    btnOff.Enabled = false;
                    btnOn.Enabled = false;
                    lblTemp.Text = retVal[0].Value.ToString();
                    lblUnitTemp.Text = retVal[0].Unit.ToString();
                }
                else
                {
                    lblTemp.Text = retVal[0].Value.ToString();
                    lblUnitTemp.Text = retVal[0].Unit.ToString();
                }


                pctDeviceStateOff.Visible = true;
                pctDeviceStateOn.Visible = false;
                btnOff.Visible = false;
                btnOn.Visible = true;

                if (retVal[0].State == false)
                {
                    pctDeviceStateOff.Visible = true;
                    pctDeviceStateOn.Visible = false;
                    btnOff.Visible = false;
                    btnOn.Visible = true;
                }
                else
                {
                    pctDeviceStateOff.Visible = false;
                    pctDeviceStateOn.Visible = true;
                    btnOff.Visible = true;
                    btnOn.Visible = false;
                }


            }
            catch(Exception ex)
            {

            }
        }

        private void btnOn_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch(Exception ex)
            {

            }
        }

        private void pctDeviceStateOn_Click(object sender, EventArgs e)
        {

        }

        private void btnOff_Click(object sender, EventArgs e)
        {

        }
    }
}
