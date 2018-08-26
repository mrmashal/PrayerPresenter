using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PrayerControl
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Window1 frm = new Window1();
        private void button1_Click(object sender, EventArgs e)
        {
            frm.Opacity = 1;
            frm.MediaSource = @"K:\fILM\sorood melli.DAT";
            frm.onMediaOpend += new EventHandler(frm_onMediaOpend);
            frm.Play();
            frm.Show();
        }

        void frm_onMediaOpend(object sender, EventArgs e)
        {
            trackBar1.Maximum = frm.duration();
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
           frm. SetPosition(trackBar1.Value);
        }
    }
}
