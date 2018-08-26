using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.OleDb;

namespace PrayerControl
{
    public partial class frmOption : Form
    {
        public frmOption()
        {
            InitializeComponent();
            InitializeDisplayCmx();
            //SetComboBoxDataBase();
            SetCmDevices();
            //SetFonts();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region Camera
        private void SetCmDevices()
        {
            string[] a = Global.frmCamera.GetDevices();
            foreach (string s in a)
            {
              //باید اضافه شود.
              //   if (!s.Contains("cam"))
                cmDevices.Items.Add(s);
            }
           // Global.frmCamera.SetDevice(1);
        }

        private void cmDevices_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                Global.frmCamera.SetDevice(cmDevices.SelectedIndex);
            }
            catch
            {
                MessageBox.Show("انتخاب دوربین با مشکل روبرو است.","هشدار",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }
        #endregion

        #region Display
        public void InitializeDisplayCmx()
        {
            this.cmxControlDisplay.Items.Clear();
            this.cmxShowDisplay.Items.Clear();
            foreach (var d in Screen.AllScreens)
            {
                this.cmxControlDisplay.Items.Add(d.DeviceName);
                this.cmxShowDisplay.Items.Add(d.DeviceName);
            }

            try
            {
                this.cmxControlDisplay.SelectedIndex = 0;
                this.cmxShowDisplay.SelectedIndex = 1;
            }
            catch
            {
                this.cmxShowDisplay.SelectedIndex = 0;
            }
        }

        public void SetDisplay()
        {
            try
            {
                Global.frmBlack.Width = Global.frmTranslate.Width = Global.frmText.Width = Global.frmMedia.Width = Global.frmImage.Width = Global.frmCamera.Width = ShowDisplay.Bounds.Width;
                Global.frmBlack.Height = Global.frmMedia.Height = Global.frmImage.Height = Global.frmCamera.Height = ShowDisplay.Bounds.Height;
                Global.frmBlack.Left = Global.frmTranslate.Left = Global.frmText.Left = Global.frmMedia.Left = Global.frmImage.Left = Global.frmCamera.Left = ShowDisplay.Bounds.Left;
                Global.frmBlack.Top = Global.frmMedia.Top = Global.frmImage.Top = Global.frmCamera.Top = 0;

                Global.frmImage.SetScreen(ShowDisplay,0);
                Global.frmMedia.SetScreen(ShowDisplay,0);
            }
            catch
            {
            }

            try
            {
                Global.frmControlText.Width = ControlDisplay.Bounds.Width;
                Global.frmControlText.Left = ControlDisplay.Bounds.Left;
                Global.frmControlText.Top = 0;
            }
            catch
            {
            }
            try
            {
                Global.frmBackGround.Width = ControlDisplay.Bounds.Width;
                Global.frmBackGround.Left = ControlDisplay.Bounds.Left;
                Global.frmBackGround.Height = Global.frmControlText.Height;
                Global.frmBackGround.Top = 0;
            }
            catch
            {
            }
            try
            {
                Global.frmControl.WindowState = FormWindowState.Normal;
                Global.frmControl.Width = ControlDisplay.Bounds.Width;
                Global.frmControl.Height = ControlDisplay.Bounds.Height - (int)Global.frmTranslate.Height;
                Global.frmControl.Left = ControlDisplay.Bounds.Left;
                Global.frmControl.Top = (int)Global.frmControlText.Height;
            }
            catch { }
            try
            {
                this.Left = ControlDisplay.Bounds.Left;
                Global.frmBlack.Top = 0;
            }
            catch { }
        }

        private void Display_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetDisplay();
        }

        public Screen ControlDisplay
        {
            get
            {
                if (cmxControlDisplay.SelectedItem == null)
                    return null;
                return Screen.AllScreens.First(x => x.DeviceName == cmxControlDisplay.SelectedItem.ToString());

            }
        }

        public Screen ShowDisplay
        {
            get
            {
                try
                {
                    if (cmxShowDisplay.SelectedItem == null)
                        return null;
                    return Screen.AllScreens.First(x => x.DeviceName == cmxShowDisplay.SelectedItem.ToString());
                }
                catch
                {
                    return this.ControlDisplay;
                }
            }
        }
        #endregion

      
       

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x80;
                return cp;
            }
        }

        private void frmOption_Load(object sender, EventArgs e)
        {

        }

        private void chSingleDisplay_CheckedChanged(object sender, EventArgs e)
        {
            if (chSingleDisplay.Checked)
            {
                Global.frmControl.Opacity = 0;
                Global.frmBackGround.Opacity = 0;
                Global.frmControlText.Hide();
                gbDisplay.Enabled = false;
            }
            else
            {
                Global.frmControl.Opacity = 1;
                Global.frmBackGround.Opacity = 1;
                Global.frmControlText.Show();
                gbDisplay.Enabled = true;
            }
        }
    }
}
