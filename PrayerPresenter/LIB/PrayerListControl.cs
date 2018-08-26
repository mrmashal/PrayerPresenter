using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Data.OleDb;
using System.Data;

namespace PrayerControl.LIB
{
    public class PrayerListControl : ListBox
    {
        private void initializeComponent()
        {
            this.Font = new Font(new FontFamily("tahoma"), 9);
        }

        public event EventHandler IndexChange;

        public void ClearItem()
        {
            this.Items.Clear();
        }

        public void AddItem(string item)
        {
            this.Items.Add(item);
        }
         
        public PrayerListControl()
        {
            this.initializeComponent();
            this.MouseClick += new MouseEventHandler(fn_MouseClick);
            this.HorizontalScrollbar = true;
            this.ScrollAlwaysVisible = true;
        }

        void fn_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                this.Index = this.SelectedIndex;
                if (IndexChange != null)
                    IndexChange(null, null);
            }
            catch
            {
            }
        }

        public string SelectedText
        {
            get
            {
                if (this.SelectedItem == null)
                    return null;
                return this.SelectedItem.ToString();
            }
        }

         
        public int Index
        {
            set
            {
                if (value > this.Items.Count - 1 || value < -1)
                    return;
                try
                {
                    if (value + 5 < this.Items.Count)
                        this.SelectedIndex = value + 5;
                    else
                        this.SelectedIndex = this.Items.Count - 1;
                }
                catch
                {
                }
                try
                {
                    if (value - 5 >= 0)
                        this.SelectedIndex = value - 5;
                    else
                        this.SelectedIndex = 0;
                }
                catch
                {
                }
                try
                {
                    this.SelectedIndex = value;
                }
                catch
                {
                }
            }
            get
            {
                return this.SelectedIndex;
            }
        }
    }
}