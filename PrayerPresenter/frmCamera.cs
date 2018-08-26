using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DirectX.Capture;
using DShowNET;


namespace PrayerControl
{
    public partial class frmCamera : Form
    {


        protected override CreateParams CreateParams
        {
            get
            {
                try
                {
                    CreateParams cp = base.CreateParams;
                    cp.ExStyle |= 0x80;
                    return cp;
                }
                catch
                {
                    return null;
                }
            }
        }


        Capture capture = null;
        private Filters filters ;
        private TVSelections tvSelections ;

        //Capture capture = null;
        //private Filters filters = new Filters();
        //private TVSelections tvSelections = new TVSelections();

        public frmCamera()
        {
                InitializeComponent();
            try
            {
                filters = new Filters();
                tvSelections = new TVSelections();
            }
            catch(Exception x)
            {
            }
        }

        public string[] GetDevices()
        {
            try
            {
                Filter videoDevice = null;
                if (capture != null)
                    videoDevice = capture.VideoDevice;

                string[] a = new string[filters.VideoInputDevices.Count];
                for (int c = 0; c < filters.VideoInputDevices.Count; c++)
                {
                    try
                    {
                        Filter f = filters.VideoInputDevices[c];
                        a[c] = f.Name;
                    }
                    catch
                    {
                    }
                }
                return a;
            }
            catch(Exception x)
            {
                return new string[]{};
            }
        }

        public void SetDevice(int DeviceIndex)
        {
            try
            {
                Filter videoDevice = null;

                if (capture != null)
                {
                    capture.Dispose();
                    capture = null;
                }

                videoDevice = filters.VideoInputDevices[DeviceIndex];

                if (videoDevice != null)
                {
                    capture = new Capture(videoDevice, null, false);
                }


                capture.PreviewWindow = this.panel;

                capture.dxUtils.VideoStandard = AnalogVideoStandard.PAL_B;
                int i = 0;
                for (; i < capture.VideoSources.Count; i++)
                    if (capture.VideoSources[i].Name == "Video Composite")
                        break;
                try
                {

                    this.capture.Tuner.InputType = TunerInputType.Cable;

                    capture.FrameSize = new System.Drawing.Size(720, 576);
                    capture.FrameRate = 25;
                }
                catch
                {
                }
            }
            catch
            {
            }
        }

        private void frmCamera_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                Application.Exit();
            }
            catch
            {
            }
        }

        private void frmCamera_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                Global.SetPosition();
            }
            catch
            {
            }
        }

        private void frmCamera_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                System.Windows.Forms.Cursor.Hide();
            }
            catch
            {
            }
        }

        private void frmCamera_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                System.Windows.Forms.Cursor.Show();
            }
            catch
            {
            }
        }
    }
}
