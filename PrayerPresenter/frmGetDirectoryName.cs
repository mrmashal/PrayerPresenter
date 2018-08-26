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
    public partial class frmGetDirectoryName : Form
    {
        public frmGetDirectoryName()
        {
            InitializeComponent();
        }

        public string DirectoryName
        {
            get
            {
                return tbDirectoryName.Text;
            }
        }

        public bool isok = false;
      private void btnOK_Click(object sender, EventArgs e)
        {
            isok = true;
            this.Close();
        }

        private void tbDirectoryName_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            isok = false;
            this.Close();
        }
    }
}
