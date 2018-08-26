using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using JockerSoft.Media;

namespace PrayerControl.LIB
{
    public partial class FolderBrowser : UserControl
    {
        public FolderBrowser()
        {
            InitializeComponent();
            ListBox.SelectedIndexChanged += new EventHandler(ListBox_SelectedIndexChanged);
        }

        void ListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FolderChanged == null)
                return;
            FolderChanged(sender, e);
        }

        public event EventHandler FolderChanged;

        public string GetCurrentFolderName()
        {
            string s = ListBox.SelectedItem.ToString();
            string[] arr = s.Split('-');
            s = "";
            for (int i = 1; i < arr.Length; i++)
                s += arr[i];
            return s;
        }

        public void GoToFolder(int number)
        {
            try
            {
                ListBox.SelectedIndex = number - 1;
            }
            catch
            {
            }
        }

        public int GetFolderCount()
        {
            return ListBox.Items.Count;
        }

        public int CurrentIndex
        {
            set
            {
                if (value == -3)
                    ListBox.SelectedIndex = -1;

                else if (value < 0)
                {
                    ListBox.SelectedIndex = ListBox.Items.Count - 1;
                    return;
                }

                else if (value >= ListBox.Items.Count)
                {
                    ListBox.SelectedIndex = 0;
                    return;
                }

                if(value != -3)
                ListBox.SelectedIndex = value;
            }
            get
            {
                return ListBox.SelectedIndex;
            }
        }

        public void init()
        {
            try{
            ListBox.Items.Clear();

            DataSet ds = new DataSet();
            //ds.ReadXml(@"Files\Folders.xml");
           

            if (!File.Exists(@"Files\Folders.xml"))
            {
                string[] arr = { "امام علی (ع)", "امام حسن (ع)","امام حسین (ع)", "امام سجاد (ع)", "امام باقر (ع)", "امام صادق (ع)", "امام کاظم (ع)", "امام رضا (ع)", "امام جواد (ع)", "امام هادی (ع)", "امام حسن عسگری (ع)", "امام زمان (ع)", "حضرت زهرا (س)", "مکه", "مدینه"};

                ds.Tables.Add("tbl");
                DataColumn dc = new DataColumn("Name");

                ds.Tables[0].Columns.Add(dc);
                foreach (string fn in arr)
                {
                    Directory.CreateDirectory(@"Files\" + fn);
                    Directory.CreateDirectory(@"Files\" + fn + @"\PIC");
                    Directory.CreateDirectory(@"Files\" + fn + @"\PIC\thum");
                    Directory.CreateDirectory(@"Files\" + fn + @"\FILM");
                    Directory.CreateDirectory(@"Files\" + fn + @"\FILM\thum");

                  
                    DataRow dr = ds.Tables[0].NewRow();
                    
                    dr[0] = fn;
                    ds.Tables[0].Rows.Add(dr);
                }
                ds.WriteXml(@"Files\Folders.xml");
            }

            ds = new DataSet();
            ds.ReadXml(@"Files\Folders.xml");
            if(ds.Tables.Count == 0)
                return;
            int i = 1;
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                ListBox.Items.Add(i.ToString() + "-" + r[0].ToString());
                i++;
            }

            //اضافه کردن
            //DataRow dr = ds.Tables[0].NewRow();
            //dr[0] = "علی";
            //ds.Tables[0].Rows.Add(dr);
            //ds.WriteXml(@"Files\Folders.xml");

                //ListBox.Items.Clear();
                //DirectoryInfo MainDirectory = new DirectoryInfo(@"Files\");
                //DirectoryInfo[] dr = MainDirectory.GetDirectories().OrderBy(p => p.CreationTime).ToArray();
                //int i = 1;
                //foreach (DirectoryInfo d in dr)
                //{
                //    ListBox.Items.Add(i.ToString() + "-" + d.Name);
                //    i++;
                //}
            }
                catch
            {
                MessageBox.Show("نرم افزار اجازه دسترسی به فایلهای این درایو را ندارد لذا به مسیر نصب نرم افزار رفته و پس از راست کلیک روی فایل اجرایی گزینه \n\r run as administrator \n\r را انتخاب نمایید.", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);

                }
        }

        private void FolderBrowser_Load(object sender, EventArgs e)
        {
        }

    }
}
