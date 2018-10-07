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
using System.Windows.Media.Imaging;
using System.IO;
using System.Data.OleDb;
using NaghamateAsemani;

namespace PrayerControl
{
    public partial class frmControl : Form
    {
        private BackgroundWorker _bw;

        #region DataBase

        void SetComboBoxDataBase()
        {
            cmxDataBase.Items.Clear();

            DataSet ds = new DataSet();
            ds.ReadXml(Global.FilesDb);

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                cmxDataBase.Items.Add(dr[0].ToString());
            }
        }

        void frmMatn_IndexChange(object sender, EventArgs e)
        {
            this.prayerListControl.Index = Global.frmText.ActiveIndex;
            VerseUpdated();
        }

        bool havedata = false;

        List<string> TextList = new List<string>();
        List<string> TranslationList = new List<string>();

        public int GoToVerse = 0;

        public void DataBind()
        {
            DataSet ds = new DataSet();
            ds.ReadXml(Global.FilesDb);
            string Filename = ds.Tables[0].Rows[this.cmxDataBase.SelectedIndex][1].ToString();
            string ConnectinString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=B\" + Filename;
            try
            {
                OleDbConnection con = new OleDbConnection();
                con.ConnectionString = ConnectinString;
                con.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = con;
                cmd.CommandText = "select * from tbl ORDER BY ID";
                DataTable dt = new DataTable();
                OleDbDataAdapter adapter = new OleDbDataAdapter();
                adapter.SelectCommand = cmd;
                adapter.Fill(dt);
                con.Close();

                Global.frmText.Close();
                Global.frmControlText.Close();
                Global.frmTranslate.Close();

                Global.frmText = new frmText();
                Global.frmControlText = new frmText();
                Global.frmTranslate = new frmText();

                Global.frmText.IsEnableActiveCounter = true;
                Global.frmText.IndexChange += new EventHandler(frmMatn_IndexChange);

                Global.frmText.Show();
                Global.frmTranslate.Show();
                Global.frmControlText.Show();

                this.SetFonts();

                this.prayerListControl.ClearItem();

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("خطا در اتصال با بانک اطلاعاتی");
                    return;
                }

                bool isGoran = cmxDataBase.SelectedItem.ToString().Contains("سوره");

                TextList.Clear();
                TranslationList.Clear();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var text = dt.Rows[i][1].ToString();
                    var translation = dt.Rows[i][2].ToString();

                    //اگر سوره قرآن است باید آخر هر کدام شماره آیه هم اضافه شود
                    if (isGoran)
                    {
                        if (i == 0)
                        {
                            this.prayerListControl.AddItem("      " + text);
                            double d = Global.frmText.AddItem("      " + text, i);
                            Global.frmControlText.AddItem("      " + text, i);
                            Global.frmTranslate.AddItem("      " + translation, i, d);
                            TextList.Add(text);
                            TranslationList.Add(translation);
                        }
                        else
                        {
                            this.prayerListControl.AddItem("           " + text + " ( " + i + " ) ");
                            double d = Global.frmText.AddItem("           " + text + " ( " + i + " ) ", i);
                            Global.frmControlText.AddItem("           " + text + " ( " + i + " ) ", i);
                            Global.frmTranslate.AddItem("           " + translation + " ( " + i + " ) ", i, d);
                            TextList.Add(text + " ( " + i + " ) ");
                            TranslationList.Add(translation + " ( " + i + " ) ");
                        }
                    }
                    else
                    {
                        //اضافه کردن شماره برای اینکه راحت فرازها را پیدا کنند
                        string tmp = "";
                        if (!cmxDataBase.SelectedItem.ToString().Contains("جوشن"))
                            tmp = (i + 1) + "- ";
                        this.prayerListControl.AddItem(tmp + text);
                        double d = Global.frmText.AddItem(text, i);
                        Global.frmControlText.AddItem(text, i);
                        Global.frmTranslate.AddItem(translation, i, d);
                        TextList.Add(text);
                        TranslationList.Add(translation);
                    }
                }

                //this.prayerListControl.Index = 0;

                Global.frmText.Refresh();
                Global.frmControlText.Refresh();
                Global.frmTranslate.Refresh();

                havedata = true;
                rbText.Enabled = true;
                rbText_Translate.Enabled = true;

                this.SetTextLocation();
                rbText_CheckedChanged(null, null);

                if (GoToVerse >= dt.Rows.Count)
                    GoToVerse = 0;
                this.prayerListControl.Index = GoToVerse;
                this.prayerListControl_IndexChange(null, null);

                //this.gbSpeed.Enabled = true;
                this.gbShow.Enabled = true;
                Global.frmOption.SetDisplay();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا");
            }
        }


        private void ComboBoxDataBase_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //if (DataBaseName == "" || MessageBox.Show("آیا محتوا تغییر کند؟", "تائید", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                //{
                    this.prayerListControl.Index = -1;
                    DataBind();
                    this.Text = "نغمات آسمانی - " + this.cmxDataBase.SelectedItem.ToString();
                    rbText_Translate.Checked = true;
                //}
                //else
                //{
                //    this.cmxDataBase.SelectedText = DataBaseName;
                //}

                btn.Focus();
            }
            catch
            {
            }

        }

        //string DataBaseName = "";

        #endregion


        #region Font
        /// <summary>
        /// تنظیم فونت
        /// </summary>
        public void SetFonts()
        {
            if (Global.frmText != null)
            {
                Global.frmText.TextFont = Global.frmOption.fontDialogText.Font;
                Global.frmText.TextColor = Global.frmOption.colorDialogText.Color;
                Global.frmText.BackColor = Global.frmOption.colorDialogBack.Color;
                Global.frmText.IsTransparent = Global.frmOption.chbIsTransparent.Checked;
            }

            if (Global.frmControlText != null)
            {
                Global.frmControlText.TextFont = Global.frmOption.fontDialogText.Font;
                Global.frmControlText.TextColor = Global.frmOption.colorDialogText.Color;
                Global.frmControlText.BackColor = Global.frmOption.colorDialogBack.Color;

            }

            if (Global.frmTranslate != null)
            {
                Global.frmTranslate.TextFont = Global.frmOption.fontDialogTranslate.Font;
                Global.frmTranslate.TextColor = Global.frmOption.colorDialogTranslate.Color;
                Global.frmTranslate.IsTransparent = Global.frmOption.chbIsTransparent.Checked;
                Global.frmTranslate.BackColor = Global.frmOption.colorDialogBack.Color;
            }

            if (this.frmTextType != null)
            {
                this.frmTextType.TextFont = Global.frmOption.fontDialogText.Font;
                this.frmTextType.TextColor = Global.frmOption.colorDialogText.Color;
                this.frmTextType.BackColor = Global.frmOption.colorDialogBack.Color;
                this.frmTextType.IsTransparent = Global.frmOption.chbIsTransparent.Checked;
            }
        }



        #endregion


        #region Location
        public enum Locations
        {
            Top, Down, TopDown
        }

        Locations TextLocation_ = Locations.Down;
        public Locations TextLocation
        {
            set
            {
                switch (value)
                {
                    case Locations.Top:
                        if (frmTextType != null)
                            frmTextType.Top = 0;
                        Global.frmText.Top = 0;
                        Global.frmTranslate.Top = Global.frmText.Height;

                        break;
                    case Locations.Down:
                        if (frmTextType != null)
                            frmTextType.Top = Global.frmOption.ShowDisplay.Bounds.Height - frmTextType.Height;

                        if (rbText.Checked)
                            Global.frmText.Top = Global.frmOption.ShowDisplay.Bounds.Height - Global.frmText.Height;
                        else
                            Global.frmText.Top = Global.frmOption.ShowDisplay.Bounds.Height - Global.frmTranslate.Height - Global.frmText.Height;
                        Global.frmTranslate.Top = Global.frmOption.ShowDisplay.Bounds.Height - Global.frmTranslate.Height;

                        break;
                    case Locations.TopDown:
                        if (frmTextType != null)
                            frmTextType.Top = 0;

                        Global.frmText.Top = 0;
                        Global.frmTranslate.Top = Global.frmOption.ShowDisplay.Bounds.Height - Global.frmTranslate.Height;
                        break;
                }
                TextLocation_ = value;
            }
            get
            {
                return TextLocation_;
            }
        }

        public void SetTextLocation()
        {
            if (rbTop.Checked)
                this.TextLocation = Locations.Top;
            else if (rbDown.Checked)
                this.TextLocation = Locations.Down;
            else if (rbTopDown.Checked)
                this.TextLocation = Locations.TopDown;
        }
        #endregion

        Timer TimerMedia = new Timer();

        private void rbLocation_CheckedChanged(object sender, EventArgs e)
        {
            SetfrmSize();
            this.SetTextLocation();
        }

        public frmControl()
        {
            InitializeComponent();
            prayerListControl.IndexChange += new EventHandler(prayerListControl_IndexChange);
            SetComboBoxDataBase();
            browser.FolderChanged += new EventHandler(browser_FolderChanged);
            browser.FileChanged += new EventHandler(browser_FileChanged);
            TimerMedia.Interval = 1000;
            TimerMedia.Tick += new EventHandler(TimreMedia_Tick);
            TimerMedia.Enabled = true;
        }

        void TimreMedia_Tick(object sender, EventArgs e)
        {
            try
            {
                tbMedia.Value = (int)Global.frmMedia.MediaPosition.TotalMilliseconds;
                lbMediaPosition.Text = ((int)Global.frmMedia.MediaPosition.Minutes).ToString("00") + ":" + ((int)Global.frmMedia.MediaPosition.Seconds).ToString("00");
            }
            catch
            {
            }
        }

        void browser_FileChanged(object sender, EventArgs e)
        {
            btnEnter.Enabled = true;
        }

        void browser_FolderChanged(object sender, EventArgs e)
        {
            btnEnter.Enabled = true;
        }

        private void CleanFolders()
        {
            try
            {
                DataSet ds = new DataSet();
                ds.ReadXml(@"Files\Folders.xml");

                string[] arr = Directory.GetDirectories(@"Files\");

                foreach (string d in arr)
                {
                    DirectoryInfo di = new DirectoryInfo(d);
                    bool b = false;
                    foreach (DataRow r in ds.Tables[0].Rows)
                    {
                        if (di.Name == r[0].ToString())
                        {
                            b = true;
                            break;
                        }
                    }
                    if (!b)
                        di.Delete(true);
                }
            }
            catch
            {
            }


        }

        private void frmControl_Load(object sender, EventArgs e)
        {
            // prepare search trie
            _bw = new BackgroundWorker();
            _bw.WorkerReportsProgress = true;
            _bw.DoWork += (object s1, DoWorkEventArgs e1) =>
            {
                Utils.BuildSearchTries(_bw);
            };
            _bw.ProgressChanged += (object s1, ProgressChangedEventArgs e1) =>
            {
                btnSearch.Text = "در حال آماده‌سازی جستجو (" + e1.ProgressPercentage + "%)...";
            };
            _bw.RunWorkerCompleted += (object s1, RunWorkerCompletedEventArgs e1) =>
            {
                if (e1.Error != null)
                {
                    btnSearch.Text = e1.Error.ToString();
                }
                else
                {
                    btnSearch.Text = "جستجو... (Ctrl+F)";
                    btnSearch.Enabled = true;
                    btnGoto.Enabled = true;
                }
            };
            _bw.RunWorkerAsync();


            //this.WindowState = FormWindowState.Maximized;
            if (Screen.AllScreens.Count() < 2)
                MessageBox.Show("لطفا قبل از استفاده از نرم افزار ویدئو پروژکتور را به کامپیوتر وصل کرده به مسیر زیر بروید \n\r Control Panel\\Display\\Adjust resulution\\Multiple displays\n\r و آن را روی \n\r Extend these displays\n\r تنظیم کنید.","",MessageBoxButtons.OK,MessageBoxIcon.Warning,MessageBoxDefaultButton.Button1,MessageBoxOptions.RightAlign);

            groupBox1.BackColor = Color.FromArgb(245, 245, 255);
            Global.ShowForms();
            browser.BrowserType = LIB.Browser.BrowserTypes.Image;
            browser.GoToFolder(1);
            SendToOutput();

            System.Globalization.CultureInfo language = new System.Globalization.CultureInfo("fa-ir");
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(language);

            //CleanFolders();
        }


        private void frmControl_FormClosed(object sender, FormClosedEventArgs e)
        {
            Global.Close();
        }

        public enum ViewType
        {
            Image, Media, Camera, Camera_Image, Camera_Media, black
        }

        ViewType CurrentView = ViewType.black;

        private void SendToOutput()
        {
            //تغییر به تصویر
            if (rbImage.Checked)
            {
                switch (CurrentView)
                {
                    case ViewType.Image:
                        Global.frmImage.ImageSource = new BitmapImage(new Uri(Application.StartupPath + @"\" + browser.SelectedImage, UriKind.RelativeOrAbsolute));
                        Global.frmMedia.ChangeOpacity(0, 0, 1);

                        Global.frmBlack.ChangeOpacity(0, 0, 1);
                        break;
                    case ViewType.Media:
                    case ViewType.Camera:
                    case ViewType.Camera_Media:
                        Global.frmImage.SetImageOntime(new BitmapImage(new Uri(Application.StartupPath + @"\" + browser.SelectedImage, UriKind.RelativeOrAbsolute)));
                        Global.frmImage.ChangeOpacity(1, 4, 1);
                        Global.frmBlack.ChangeOpacity(0, 1, 1);
                        Global.frmMedia.PauseDelay(5000);
                        break;
                    case ViewType.Camera_Image:
                        Global.frmImage.SetImageOntime(new BitmapImage(new Uri(Application.StartupPath + @"\" + browser.SelectedImage, UriKind.RelativeOrAbsolute)));
                        Global.frmImage.ChangeOpacity(1, 2, 1);
                        Global.frmBlack.ChangeOpacity(0, 1, 1);
                        break;
                    case ViewType.black:
                        try
                        {
                            Global.frmImage.SetImageOntime(new BitmapImage(new Uri(Application.StartupPath + @"\" + browser.SelectedImage, UriKind.RelativeOrAbsolute)));
                            Global.frmImage.ChangeOpacity(1, 1, 1);
                            Global.frmMedia.ChangeOpacity(0, 1, 1);
                            Global.frmBlack.ChangeOpacity(0, 4, 1);
                        }
                        catch { }
                        break;
                }
                this.CurrentView = ViewType.Image;
            }

                //تغییر به کلیپ
            else if (rbMedia.Checked)
            {
                string s = Application.StartupPath + @"\" + browser.SelectedFilm;
                if (Global.frmMedia.MediaSource != s)
                {
                    Global.frmMedia.MediaSource = s;
                    Global.frmMedia.onMediaOpend += new EventHandler(frmMedia_onMediaOpend);
                }
                else
                {
                    Global.frmMedia.Play();
                }
                Global.frmMedia.Play();
                switch (CurrentView)
                {
                    case ViewType.Image:
                        Global.frmMedia.ChangeOpacity(1, 1, 3);
                        Global.frmImage.ChangeOpacity(0, 4, 3);
                        Global.frmBlack.ChangeOpacity(0, 1, 3);
                        break;
                    case ViewType.Media:
                        //تغییر فایل کلیپ
                        Global.frmBlack.ChangeOpacity(0, 1, 3);
                        Global.frmImage.ChangeOpacity(0, 1, 3);
                        break;

                    case ViewType.Camera:
                        Global.frmMedia.ChangeOpacity(1, 4, 3);
                        Global.frmBlack.ChangeOpacity(0, 1, 3);
                        Global.frmImage.ChangeOpacity(0, 1, 3);
                        break;
                    case ViewType.Camera_Image:
                        Global.frmMedia.ChangeOpacity(1, 4, 3);
                        Global.frmImage.ChangeOpacity(0, 4, 3);
                        Global.frmBlack.ChangeOpacity(0, 1, 3);
                        break;
                    case ViewType.Camera_Media:
                        Global.frmMedia.ChangeOpacity(1, 3, 3);
                        Global.frmBlack.ChangeOpacity(0, 3, 3);
                        Global.frmImage.ChangeOpacity(0, 3, 3);
                        break;
                    case ViewType.black:
                        Global.frmImage.ChangeOpacity(0, 3, 3);
                        Global.frmMedia.ChangeOpacity(1, 3, 3);
                        Global.frmBlack.ChangeOpacity(0, 3, 3);
                        break;
                }
                this.CurrentView = ViewType.Media;
            }

            //تغییر به دوربین
            else if (rbCamera.Checked)
            {
                switch (CurrentView)
                {
                    case ViewType.Image:
                        Global.frmMedia.ChangeOpacity(0, 1, 1);
                        Global.frmImage.ChangeOpacity(0, 4, 1);
                        break;
                    case ViewType.Media:
                        Global.frmMedia.ChangeOpacity(0, 4, 1);
                        Global.frmImage.ChangeOpacity(0, 1, 1);
                        Global.frmMedia.PauseDelay(5000);
                        break;
                    case ViewType.Camera_Image:
                        Global.frmImage.ChangeOpacity(0, 2, 1);
                        Global.frmMedia.ChangeOpacity(0, 1, 1);
                        break;
                    case ViewType.Camera_Media:
                        Global.frmMedia.ChangeOpacity(0, 2, 1);
                        Global.frmBlack.ChangeOpacity(0, 1, 1);
                        Global.frmImage.ChangeOpacity(0, 1, 1);
                        Global.frmMedia.PauseDelay(5000);
                        break;
                    case ViewType.black:
                        Global.frmImage.ChangeOpacity(0, 1, 1);
                        Global.frmMedia.ChangeOpacity(0, 1, 1);
                        Global.frmBlack.ChangeOpacity(0, 3, 1);
                        break;
                }
                this.CurrentView = ViewType.Camera;
            }

                //تغییر به عکس و دوربین
            else if (rbCamera_Image.Checked)
            {
                switch (CurrentView)
                {
                    case ViewType.Image:
                        Global.frmImage.SetImageOntime(new BitmapImage(new Uri(Application.StartupPath + @"\" + browser.SelectedImage, UriKind.RelativeOrAbsolute)));
                        Global.frmMedia.ChangeOpacity(0, 1, 1);
                        Global.frmImage.ChangeOpacity(0.5, 3, 1);
                        Global.frmBlack.ChangeOpacity(0, 1, 1);
                        break;
                    case ViewType.Media:
                        Global.frmMedia.PauseDelay(5000);
                        Global.frmImage.SetImageOntime(new BitmapImage(new Uri(Application.StartupPath + @"\" + browser.SelectedImage, UriKind.RelativeOrAbsolute)));
                        Global.frmMedia.ChangeOpacity(0, 4, 1);
                        Global.frmImage.ChangeOpacity(0.5, 4, 1);
                        Global.frmBlack.ChangeOpacity(0, 1, 1);
                        break;
                    case ViewType.Camera:
                        Global.frmImage.SetImageOntime(new BitmapImage(new Uri(Application.StartupPath + @"\" + browser.SelectedImage, UriKind.RelativeOrAbsolute)));
                        Global.frmImage.ChangeOpacity(0.5, 2, 1);
                        Global.frmMedia.Opacity = Global.frmBlack.Opacity = 0;
                        break;
                    case ViewType.Camera_Image:
                        Global.frmImage.ImageSource = new BitmapImage(new Uri(Application.StartupPath + @"\" + browser.SelectedImage, UriKind.RelativeOrAbsolute));
                        Global.frmMedia.Opacity = Global.frmBlack.Opacity = 0;
                        break;
                    case ViewType.Camera_Media:
                        Global.frmMedia.PauseDelay(4000);
                        Global.frmMedia.ChangeOpacity(0, 3, 1);
                        Global.frmImage.ChangeOpacity(0.5, 3, 1);
                        Global.frmBlack.ChangeOpacity(0, 1, 1);
                        break;
                    case ViewType.black:
                        Global.frmMedia.ChangeOpacity(0, 1, 1);
                        Global.frmImage.SetImageOntime(new BitmapImage(new Uri(Application.StartupPath + @"\" + browser.SelectedImage, UriKind.RelativeOrAbsolute)));
                        Global.frmBlack.ChangeOpacity(0, 4, 1);
                        Global.frmImage.ChangeOpacity(0.5, 1, 1);
                        break;
                }

                this.CurrentView = ViewType.Camera_Image;
            }

                //تغییر به کلیپ و دوربین
            else if (rbCamera_Media.Checked)
            {
                string s = Application.StartupPath + @"\" + browser.SelectedFilm;
                if (Global.frmMedia.MediaSource != s)
                    Global.frmMedia.MediaSource = s;
                else
                    Global.frmMedia.Play();
                Global.frmMedia.Play();
                switch (CurrentView)
                {
                    case ViewType.Image:
                        Global.frmMedia.ChangeOpacity(0.5, 1, 3);
                        Global.frmImage.ChangeOpacity(0, 3, 3);
                        Global.frmBlack.ChangeOpacity(0, 1, 3);
                        break;
                    case ViewType.Media:
                        Global.frmMedia.ChangeOpacity(0.5, 2, 3);
                        Global.frmImage.ChangeOpacity(0, 1, 3);
                        Global.frmBlack.ChangeOpacity(0, 1, 3);
                        break;
                    case ViewType.Camera:
                        Global.frmMedia.ChangeOpacity(0.5, 3, 3);
                        Global.frmImage.Opacity = Global.frmBlack.Opacity = 0;
                        break;
                    case ViewType.Camera_Image:
                        Global.frmMedia.ChangeOpacity(0.5, 3, 3);
                        Global.frmImage.ChangeOpacity(0, 3, 3);
                        Global.frmBlack.ChangeOpacity(0, 1, 3);
                        break;
                    case ViewType.black:
                        Global.frmMedia.ChangeOpacity(0.5, 1, 3);
                        Global.frmImage.ChangeOpacity(0, 1, 3);
                        Global.frmBlack.ChangeOpacity(0, 4, 3);
                        break;
                }
                this.CurrentView = ViewType.Camera_Media;
            }
            //تغییر به صفحه مشکی
            else if (rbBlank.Checked)
            {
                try
                {
                    Global.frmBlack.ChangeOpacity(1, 3, 1);
                    this.CurrentView = ViewType.black;
                    Global.frmMedia.PauseDelay(5000);
                }
                catch { }
            }
        }

        /// <summary>
        /// وقتی فایل لود شد
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void frmMedia_onMediaOpend(object sender, EventArgs e)
        {
            tbMedia.Maximum = (int)Global.frmMedia.MediaDuration.TotalMilliseconds;
            lbMediaDuration.Text = ((int)Global.frmMedia.MediaDuration.TotalMinutes).ToString("00") + ":" + ((int)Global.frmMedia.MediaDuration.Seconds).ToString("00");
        }

        void prayerListControl_IndexChange(object sender, EventArgs e)
        {
            Global.frmText.ActiveIndex = prayerListControl.Index;
            Global.frmControlText.ActiveIndex = prayerListControl.Index;
            Global.frmTranslate.ActiveIndex = prayerListControl.Index;

            VerseUpdated();
        }

        private void VerseUpdated()
        {
            try
            {
                tbTextType.Text = TextList[prayerListControl.Index];
                tbTextTypeTranslate.Text = TranslationList[prayerListControl.Index];
            }
            catch { }
        }

        int tempNumber = 0;
        private void frmControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnEnter_Click(null, null);
                return;
            }

            if (e.KeyCode == Keys.P && e.Control && e.Shift && e.Alt)
                MessageBox.Show("حمید رضا رضایی           شماره ملی 1292453656");
            if (e.KeyCode == Keys.O && e.Control)
            {
                btnOption_Click(null, null);
                return;
            }
            if (e.KeyCode == Keys.F && e.Control)
            {
                btnSearch_Click(null, null);
                return;
            }
            if (e.KeyCode == Keys.G && e.Control)
            {
                btnGoto_Click(null, null);
                return;
            }
            switch (e.KeyCode)
            {
                case Keys.F1:
                    rbImage.Checked = true;
                    return;
                case Keys.F2:
                    rbMedia.Checked = true;
                    return;
                case Keys.F3:
                    rbCamera.Checked = true;
                    return;
                case Keys.F4:
                    rbCamera_Image.Checked = true;
                    return;
                case Keys.F5:
                    rbCamera_Media.Checked = true;
                    return;
                case Keys.F6:
                    rbBlank.Checked = true;
                    return;
            }

            if (tbTextType.Focused || tbTextTypeTranslate.Focused || cmxDataBase.Focused)
                return;

            switch (e.KeyCode)
            {
                case Keys.Q:
                    rbNone.Checked = true;
                    return;
                case Keys.R:
                    rbTextType.Checked = true;
                    return;
                case Keys.W:
                    if (rbText_Translate.Enabled)
                        rbText_Translate.Checked = true;
                    return;
                case Keys.E:
                    if (rbText.Enabled)
                        rbText.Checked = true;
                    return;
                case Keys.Right:
                    browser.GoToNextIndex();
                    btnEnter.Enabled = true;
                    return;
                case Keys.Left:
                    browser.GoToPreviousIndex();
                    btnEnter.Enabled = true;
                    return;
                case Keys.Up:
                    rbImage.Checked = true;

                    //this.browser.FolderIndex--;
                    return;
                case Keys.Down:
                    rbMedia.Checked = true;
                    //this.browser.FolderIndex++;
                    return;
                case Keys.S:
                    btnStopMedeia_Click(null, null);
                    return;
                case Keys.D:
                    btnForwardMedia_Click(null, null);
                    return;
                case Keys.A:
                    btnBackwardMedia_Click(null, null);
                    return;
                case Keys.Space:
                    btnStopPrayer_Click(null, null);
                    return;
                case Keys.Y:
                    rbTopDown.Checked = true;
                    return;
                case Keys.U:
                    rbDown.Checked = true;
                    return;
                case Keys.I:
                    rbTop.Checked = true;
                    return;
                case Keys.P:
                    Global.frmOption.chbIsTransparent.Checked = !Global.frmOption.chbIsTransparent.Checked;
                    return;
            }

            if (e.KeyValue == 187)
            {
                btnIncreseSpeed_Click(null, null);
            }

            if (e.KeyValue == 189)
            {
                btnReduseSpeed_Click(null, null);
            }

            if (e.KeyValue == 17)
                tempNumber = 0;

            if (e.KeyValue > 47 && e.KeyValue < 58 && e.Control)
            {
                int t = e.KeyValue - 48;
                tempNumber = tempNumber * 10 + t;
            }
        }

        void frmControl_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyValue == 17 && tempNumber != 0)
            {
                this.browser.GoToFolder(tempNumber);
                btnEnter.Enabled = true;
                browser.Visible = false;
                browser.Visible = true;
            }
        }
        private void rbText_CheckedChanged(object sender, EventArgs e)
        {
            //try
            //{
            btnEnter.Enabled = true;
            if (!gbShow.Enabled)
            {
                btn.Focus();
                return;
            }


            if (rbText.Checked)
            {
                gbSpeed.Enabled = havedata;

                Global.frmText.Show();
                Global.frmTranslate.Hide();
                if (this.TextLocation == Locations.Down)
                    Global.frmText.Top = Global.frmOption.ShowDisplay.Bounds.Height - Global.frmText.Height;
            }
            if (rbText_Translate.Checked)
            {
                gbSpeed.Enabled = havedata;

                Global.frmText.Show();
                Global.frmTranslate.Show();
                if (this.TextLocation == Locations.Down)
                    Global.frmText.Top = Global.frmOption.ShowDisplay.Bounds.Height - Global.frmTranslate.Height - Global.frmText.Height;
            }

            SetfrmSize();

            if (rbNone.Checked)
            {
                if (frmTextType != null)
                    frm_OnCompleted(null, null);
                if (havedata)
                {
                    Global.frmText.Hide();
                    Global.frmTranslate.Hide();
                    Global.frmTranslate.IsMotion = Global.frmControlText.IsMotion = Global.frmText.IsMotion = false;
                }


            }
            else if (rbTextType.Checked)
            {
                if (havedata)
                {
                    Global.frmText.Hide();
                    Global.frmTranslate.Hide();
                    Global.frmTranslate.IsMotion = Global.frmControlText.IsMotion = Global.frmText.IsMotion = false;
                }
                this.tbTextType.Focus();
            }
            this.Activate();
            //}
            //catch
            //{
            //    this.Activate();
            //    btn.Focus();
            //}
        }

        public void SetfrmSize()
        {
            ///تنظیم اندازه عکس
            if (rbNone.Checked || rbTextType.Checked || Global.frmOption.chbIsTransparent.Checked)
            {
                ///
                Global.frmImage.SetScreen(Global.frmOption.ShowDisplay, 0);
                Global.frmMedia.SetScreen(Global.frmOption.ShowDisplay, 0);

                //Global.frmMedia.Height = Global.frmImage.Height = Global.frmOption.ShowDisplay.Bounds.Height;
                Global.frmMedia.Top = Global.frmImage.Top = 0;
                ///
                return;
            }
            else if (!rbTextType.Checked)
            {
                if (rbTop.Checked || rbTopDown.Checked)
                    Global.frmMedia.Top = Global.frmImage.Top = Global.frmText.Height;
                else
                    Global.frmMedia.Top = Global.frmImage.Top = 0;

                //Global.frmMedia.Height = Global.frmImage.Height = Global.frmOption.ShowDisplay.Bounds.Height - Global.frmText.Height;
                Global.frmImage.SetScreen(Global.frmOption.ShowDisplay, (int)Global.frmText.Height);
                Global.frmMedia.SetScreen(Global.frmOption.ShowDisplay, (int)Global.frmText.Height);


            }
        }

        private void rbType_CheckedChanged(object sender, EventArgs e)
        {
            if (!gbViewType.Enabled)
            {
                btn.Focus();
                return;
            }
            if (rbImage.Checked)
            {
                browser.BrowserType = LIB.Browser.BrowserTypes.Image;
                //gbImage.Enabled = true;
                gbMedia.Enabled = false;
            }
            else if (rbMedia.Checked)
            {
                browser.BrowserType = LIB.Browser.BrowserTypes.Film;
                //gbImage.Enabled = false;
                gbMedia.Enabled = true;
            }
            else if (rbCamera.Checked)
            {
                browser.BrowserType = LIB.Browser.BrowserTypes.Camera;
                //gbImage.Enabled = gbMedia.Enabled = false;
            }
            else if (rbCamera_Image.Checked)
            {
                browser.BrowserType = LIB.Browser.BrowserTypes.Image;
                //gbImage.Enabled = true;
                gbMedia.Enabled = false;
            }
            else if (rbCamera_Media.Checked)
            {
                browser.BrowserType = LIB.Browser.BrowserTypes.Film;
                //gbImage.Enabled = false;
                gbMedia.Enabled = true;
            }
            else if (rbBlank.Checked)
            {
                browser.BrowserType = LIB.Browser.BrowserTypes.Camera;
                //gbImage.Enabled = gbMedia.Enabled = false;
            }
            this.btnEnter.Enabled = true;
            this.Activate();
            btn.Focus();
        }

        #region Type
        public frmText frmTextType;
        private void SendTextType()
        {
            if (frmTextType != null)
            {
                frmTextType.Close();
                frmTextType = null;
            }
            frmTextType = new frmText();
            frmTextType.IsEnableCompletedReport = true;
            frmTextType.Width = Global.frmOption.ShowDisplay.Bounds.Width;
            frmTextType.Left = Global.frmOption.ShowDisplay.Bounds.Left;

            frmTextType.Top = -400;
            frmTextType.Show();
            frmTextType.Refresh();

            frmTextType.TextFont = Global.frmOption.fontDialogText.Font;
            frmTextType.TextColor = Global.frmOption.colorDialogText.Color;
            frmTextType.BackColor = Global.frmOption.colorDialogBack.Color;
            frmTextType.IsTransparent = Global.frmOption.chbIsTransparent.Checked;

            frmTextType.AddItem(tbTextType.Text, 0);

            frmTextType.Refresh();


            frmTextType.OnCompleted += new EventHandler(frm_OnCompleted);

            if (this.TextLocation == Locations.Down)
                frmTextType.Top = Global.frmOption.ControlDisplay.Bounds.Height - frmTextType.Height;
            else
                frmTextType.Top = 0;

            frmTextType.IsMotion = true;
            btn.Focus();
        }
        //}

        void frm_OnCompleted(object sender, EventArgs e)
        {

            try
            {
                frmTextType.Close();
                frmTextType = null;
                this.rbNone.Checked = true;
            }
            catch { }
        }
        #endregion


        private void btnStopPrayer_Click(object sender, EventArgs e)
        {
            try
            {
                if (!gbSpeed.Enabled)
                {
                    btn.Focus();
                    return;
                }

                if (frmTextType != null && rbTextType.Checked)
                {
                    frmTextType.IsMotion = !frmTextType.IsMotion;
                    if (frmTextType.IsMotion)
                        btnStopPrayer.Text = "توقف (Space)";
                    else
                        btnStopPrayer.Text = "حرکت (Space)";
                }
                else if (!rbTextType.Checked)
                {
                    Global.frmTranslate.IsMotion = Global.frmControlText.IsMotion = Global.frmText.IsMotion = !Global.frmText.IsMotion;
                    if (Global.frmControlText.IsMotion)
                        btnStopPrayer.Text = "توقف (Space)";
                    else
                        btnStopPrayer.Text = "حرکت (Space)";
                }

                btn.Focus();
            }
            catch
            {
                btn.Focus();

            }
        }

        private void btnReduseSpeed_Click(object sender, EventArgs e)
        {
            if (!gbSpeed.Enabled)
            {
                btn.Focus();

                return;
            }

            if (rbTextType != null && rbTextType.Checked)
            {
                frmTextType.Speed -= 20;
            }
            else
            {
                Global.frmText.Speed -= 20;
                Global.frmControlText.Speed -= 20;
                Global.frmTranslate.Speed -= 20;
            }

            btn.Focus();
        }

        private void btnIncreseSpeed_Click(object sender, EventArgs e)
        {
            if (!gbSpeed.Enabled)
            {
                btn.Focus();
                return;
            }
            if (rbTextType != null && rbTextType.Checked)
            {
                frmTextType.Speed += 20;
            }
            else
            {
                Global.frmText.Speed += 20;
                Global.frmControlText.Speed += 20;
                Global.frmTranslate.Speed += 20;
                btn.Focus();
            }
        }


        bool IsMediaPlay = true;
        private void btnStopMedeia_Click(object sender, EventArgs e)
        {
            if (!gbMedia.Enabled)
            {
                btn.Focus();
                return;
            }
            if (IsMediaPlay)
            {
                Global.frmMedia.Pause();
                btnStopMedeia.Text = "حرکت (S)";
            }
            else
            {
                Global.frmMedia.Play();
                btnStopMedeia.Text = "توقف (S)";
            }
            IsMediaPlay = !IsMediaPlay;
            btn.Focus();

        }

        private void btnForwardMedia_Click(object sender, EventArgs e)
        {
            if (!gbMedia.Enabled)
            {
                btn.Focus();
                return;
            }
            Global.frmMedia.Forward();
            btn.Focus();
        }

        private void btnBackwardMedia_Click(object sender, EventArgs e)
        {
            if (!gbMedia.Enabled)
            {
                btn.Focus();
                return;
            }
            Global.frmMedia.Backward();
            btn.Focus();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            if (!btnEnter.Enabled)
            {
                btn.Focus();
                return;
            }
            if (rbTextType.Checked)
            {
                SendTextType();
            }
            else
            {
                this.SendToOutput();
            }
            this.btnEnter.Enabled = false;
            btn.Focus();
        }

        private void btnOption_Click(object sender, EventArgs e)
        {
            try
            {
                Global.frmOption.InitializeDisplayCmx();

                Global.frmText.IsMotion = false;
                Global.frmControlText.IsMotion = false;
                Global.frmTranslate.IsMotion = false;
                btnStopPrayer.Text = "حرکت (Space)";
                btn.Focus();
            }
            catch { }
            Global.frmOption.ShowDialog();
        }

        private void prayerListControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            btn.Focus();
        }

        private void browser_Load(object sender, EventArgs e)
        {

        }

        private void tbTextType_TextChanged(object sender, EventArgs e)
        {
            this.btnEnter.Enabled = true;
        }

        /// <summary>
        /// تغییر موقعیت با تغییر track bar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbMedia_Scroll(object sender, EventArgs e)
        {
            Global.frmMedia.MediaPosition = TimeSpan.FromMilliseconds(tbMedia.Value);
        }

        private void gbMedia_Enter(object sender, EventArgs e)
        {
        }

        private void frmControl_Shown(object sender, EventArgs e)
        {
            Global.SetPosition();
        }

        private void frmControl_Activated(object sender, EventArgs e)
        {
        }

        private void frmControl_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
                return;
            Global.frmOption.SetDisplay();
            Global.SetPosition();
        }

        private void frmControl_FormClosing(object sender, FormClosingEventArgs e)
        {
            //DialogResult dr = MessageBox.Show("آیا برای خروج از برنامه مطمئن هستید؟" , "" , MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            //if (dr == DialogResult.No)
            //    e.Cancel = true;
        }

        private void frmControl_LocationChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
                return;
            Global.frmOption.SetDisplay();
            Global.SetPosition();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!btnSearch.Enabled)
                return;

            Global.frmSearch.Text = "جستجو";
            Global.frmSearch.SearchTrie = Global.TextSearchTrie;
            Global.frmSearch.ShowDialog();
        }

        private void btnGoto_Click(object sender, EventArgs e)
        {
            if (!btnGoto.Enabled)
                return;

            Global.frmSearch.Text = "جهش سریع";
            Global.frmSearch.SearchTrie = Global.GotoSearchTrie;
            Global.frmSearch.ShowDialog();
        }

    }
}