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

        private void btnTextFont_Click(object sender, EventArgs e)
        {
            DialogResult dr = fontDialogText.ShowDialog();
            if (dr != System.Windows.Forms.DialogResult.Cancel)
            {
                Global.frmText.TextFont = this.fontDialogText.Font;
                Global.frmControlText.TextFont = this.fontDialogText.Font;
                if (Global.frmControl.cmxDataBase.SelectedIndex >= 0)
                    Global.frmControl.DataBind();

                if (Global.frmControl.frmTextType != null)
                {
                    Global.frmText.TextFont = this.fontDialogText.Font;
                }
            }
            Global.frmControl.SetTextLocation();

            //Global.frmControl.btn.Focus();
        }

        private void btnTranslateFont_Click(object sender, EventArgs e)
        {
            DialogResult dr = fontDialogTranslate.ShowDialog();
            if (dr != System.Windows.Forms.DialogResult.Cancel)
                Global.frmTranslate.TextFont = this.fontDialogTranslate.Font;
            Global.frmControl.SetTextLocation();
            //Global.frmControl.btn.Focus();
        }

        private void btnBackColor_Click(object sender, EventArgs e)
        {
            DialogResult dr = colorDialogBack.ShowDialog();
            if (dr != System.Windows.Forms.DialogResult.Cancel)
            {
                Global.frmText.BackColor = this.colorDialogBack.Color;
                Global.frmTranslate.BackColor = this.colorDialogBack.Color;
                Global.frmControlText.BackColor = this.colorDialogBack.Color;
                if (Global.frmControl.frmTextType != null)
                    Global.frmControl.frmTextType.BackColor = this.colorDialogBack.Color;
            }
            //Global.frmControl.btn.Focus();
        }

        private void btnTextColor_Click(object sender, EventArgs e)
        {
            DialogResult dr = colorDialogText.ShowDialog();
            if (dr != System.Windows.Forms.DialogResult.Cancel)
            {
                Global.frmText.TextColor = this.colorDialogText.Color;
                Global.frmControlText.TextColor = this.colorDialogText.Color;
                if (Global.frmControl.frmTextType != null)
                    Global.frmControl.frmTextType.TextColor = this.colorDialogText.Color;
            }
            //Global.frmControl.btn.Focus();
        }

        private void btnTranslateColor_Click(object sender, EventArgs e)
        {
            DialogResult dr = colorDialogTranslate.ShowDialog();
            if (dr != System.Windows.Forms.DialogResult.Cancel)
            {
                Global.frmTranslate.TextColor = this.colorDialogTranslate.Color;
            }
            //Global.frmControl.btn.Focus();
        }

        private void chbIsTransparent_CheckedChanged(object sender, EventArgs e)
        {

            Global.frmTranslate.IsTransparent = Global.frmText.IsTransparent = chbIsTransparent.Checked;
            if (Global.frmControl.frmTextType != null)
            {
                Global.frmControl.frmTextType.IsTransparent = chbIsTransparent.Checked;
            }
            btnBackColor.Enabled = !chbIsTransparent.Checked;
            Global.frmControl.SetfrmSize();
            //Global.frmControl.btn.Focus();
        }


    }
}
