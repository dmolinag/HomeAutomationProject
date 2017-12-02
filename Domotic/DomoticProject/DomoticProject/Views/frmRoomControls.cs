using DomoticProject.Controllers.DTO;
using DomoticProject.Controllers.LogicBusiness;
using DomoticProject.Controllers.LogicBusiness.Global;
using DomoticProject.Controllers.Queries;
using DomoticProject.Model;
using HomeAutomation.Response;
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
    public partial class frmRoomControls : Form
    {
        static String profileName = "(LibiasRoom)";
        static int roomId;

        private static frmRoomControls _Request;

        public static frmRoomControls GetRequest(int roomID)
        {
            if (_Request == null || _Request.IsDisposed)
            {
                _Request = new frmRoomControls();
            }
            _Request.BringToFront();
            roomId = roomID;
            return _Request;
        }

        public frmRoomControls()
        {
            InitializeComponent();
            this.Font = new Font("Segoe UI", 8);
            this.Text = "Home Automation";
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void LibiasRoom_Load(object sender, EventArgs e)
        {
            //Load Room Devices information and fill the comboboxes
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
                    pctDeviceStateOff.Visible = true;
                    return;
                }

                //Get Room Devices information (Devices state, temperature, humidity)
                List<GetDeviceByRoomIdAndDeviceID_Result> lstDeviceByRoomIdAndDeviceId = DeviceController.GetDeviceByRoomIdAndDeviceId(roomId, selectedDeviceID);
                List<DevicesDTOPartial> retVal = new List<DevicesDTOPartial>();
                foreach (GetDeviceByRoomIdAndDeviceID_Result reg in lstDeviceByRoomIdAndDeviceId)
                {
                    retVal.Add(new DevicesDTOPartial(reg));
                }

                if (selectedDeviceID == 3)
                {
                    btnOff.Visible = true;
                    btnOn.Enabled = false;
                    lblTemp.Text = retVal[0].Value.ToString();
                    lblUnitTemp.Text = retVal[0].Unit.ToString();
                    return;
                }
                else
                {
                    lblTemp.Text = "-";
                    lblUnitTemp.Text = "-";
                    lblHumidity.Text = "-";
                    lblHumidityUnit.Text = "-";
                }

                if (retVal[0].State == false)
                {
                    pctDeviceStateOff.Visible = true;
                    pctDeviceStateOn.Visible = false;
                    btnOff.Visible = false;
                    btnOn.Visible = true;
                    btnOn.Enabled = true;
                    btnOff.Enabled = false;
                }
                else
                {
                    pctDeviceStateOff.Visible = false;
                    pctDeviceStateOn.Visible = true;
                    btnOff.Visible = true;
                    btnOn.Visible = false;
                    btnOff.Enabled = true;
                    btnOn.Enabled = false;
                }
            }
            catch(Exception ex)
            {
                Logger.Logger.ErrorL(profileName, "Endpoint not found exception", ex);
                MessageBox.Show("Exception: " + ex);
            }
        }

        private void btnOn_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedDeviceID = (int)cboDevices.SelectedValue;
                bool buttonState = true;
                //Get Room Devices information (Devices state, temperature, humidity)
                List<GetDeviceByRoomIdAndDeviceID_Result> lstDeviceByRoomIdAndDeviceId = DeviceController.GetDeviceByRoomIdAndDeviceId(roomId, selectedDeviceID);
                List<DevicesDTOPartial> retVal = new List<DevicesDTOPartial>();
                foreach (GetDeviceByRoomIdAndDeviceID_Result reg in lstDeviceByRoomIdAndDeviceId)
                {
                    retVal.Add(new DevicesDTOPartial(reg));
                }

                bool deviceState = retVal[0].State;

                //Validate that the device State is off
                if (deviceState == buttonState)
                {
                    pctDeviceStateOff.Visible = false;
                    pctDeviceStateOn.Visible = true;
                    btnOff.Visible = true;
                    btnOn.Visible = false;
                    btnOff.Enabled = true;
                    btnOn.Enabled = false;
                    MessageBox.Show("Device already on");
                    return;
                }

                //Update Room Device state and OnTimeDuration 
                RoomDeviceResponse deviceStateValidation = RoomDeviceUpdate.UpdateDeviceStatus(roomId, selectedDeviceID, buttonState);

                if(deviceStateValidation.Code != 0)
                {
                    Logger.Logger.Info(profileName, "Method Response: The device has the same status. Username:" + GlobalManager.Instance.Username);
                    MessageBox.Show("Error");
                    return;
                }

                Logger.Logger.Info(profileName, "Method Response: Successful obtain request. ");

                btnOn.Enabled = false;
                btnOff.Enabled = true;
                btnOn.Visible = false;
                btnOff.Visible = true;
                pctDeviceStateOff.Visible = false;
                pctDeviceStateOn.Visible = true;
            }
            catch(Exception ex)
            {
                Logger.Logger.ErrorL(profileName, "Endpoint not found exception", ex);
                MessageBox.Show("Exception: " + ex);
            }
        }

        private void pctDeviceStateOn_Click(object sender, EventArgs e)
        {

        }

        private void btnOff_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedDeviceID = (int)cboDevices.SelectedValue;
                bool buttonState = false;

                //Get Room Devices information (Devices state, temperature, humidity)
                List<GetDeviceByRoomIdAndDeviceID_Result> lstDeviceByRoomIdAndDeviceId = DeviceController.GetDeviceByRoomIdAndDeviceId(roomId, selectedDeviceID);
                List<DevicesDTOPartial> retVal = new List<DevicesDTOPartial>();
                foreach (GetDeviceByRoomIdAndDeviceID_Result reg in lstDeviceByRoomIdAndDeviceId)
                {
                    retVal.Add(new DevicesDTOPartial(reg));
                }

                bool deviceState = retVal[0].State;

                if (deviceState == buttonState)
                {
                    pctDeviceStateOff.Visible = true;
                    pctDeviceStateOn.Visible = false;
                    btnOff.Visible = false;
                    btnOn.Visible = true;
                    btnOff.Enabled = false;
                    btnOn.Enabled = true;
                    MessageBox.Show("Device already off");
                    return;
                }

                RoomDeviceResponse deviceStateValidation = RoomDeviceUpdate.UpdateDeviceStatus(roomId, selectedDeviceID, buttonState);

                if (deviceStateValidation.Code != 0)
                {
                    Logger.Logger.Info(profileName, "Method Response: The device has the same status. Username:" + GlobalManager.Instance.Username);
                    MessageBox.Show(deviceStateValidation.Message);
                    return;
                }

                btnOn.Enabled = true;
                btnOff.Enabled = false;
                btnOn.Visible = true;
                btnOff.Visible = false;
                pctDeviceStateOff.Visible = true;
                pctDeviceStateOn.Visible = false;

                Logger.Logger.Info(profileName, "Method Response: Successful obtain request. ");
            }
            catch (Exception ex)
            {
                Logger.Logger.ErrorL(profileName, "Endpoint not found exception", ex);
                MessageBox.Show("Exception: " + ex);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmRooms frm = frmRooms.GetRequest();
            frm.Show();
            this.Visible = false;
        }

        private void frmLibiasRoom_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
