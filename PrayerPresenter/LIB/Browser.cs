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
    /// <summary>
    /// این کنترل از دو کنترل فایل بروزر تشکیل شده است که یکی برای عکس و دیگری برای فیلم می باشد.
    /// البته یک کنترل فولدر بروزر هم داخل این کنترل هست که با تغییر در آن باید فایلهای همان پوشه نمایش داده شود.
    /// </summary>
    public partial class Browser : UserControl
    {
        //وقتی وارد پوشه ای می شویم آخرین عکس نمایش داده شده انتخاب شود
        Dictionary<int, int> ImageDictionary = new Dictionary<int, int>();

        //وقتی وارد پوشه ای می شویم آخرین کلیپ نمایش داده شده انتخاب شود
        Dictionary<int, int> FilmDictionary = new Dictionary<int, int>();

        public enum BrowserTypes
        {
            Image, Film, Camera
        }

        BrowserTypes BrowserType_ = BrowserTypes.Image;
        public BrowserTypes BrowserType
        {
            set
            {
                //بسته به اینکه عکس یا فیلم باشد دیگری را غیر فعال می کنیم
                if (value == BrowserTypes.Image)
                {
                    ImageBrowser.IsEnable = true;
                    FilmBrowser.IsEnable = false;
                }

                else if (value == BrowserTypes.Film)
                {
                    ImageBrowser.IsEnable = false;
                    FilmBrowser.IsEnable = true;
                }

                else
                {
                    ImageBrowser.IsEnable = false;
                    FilmBrowser.IsEnable = false;
                }

                BrowserType_ = value;
            }
            get
            {
                return BrowserType_;
            }
        }

        /// <summary>
        /// وقتی پوشه انتخابی عوض می شود
        /// </summary>
        public event EventHandler FolderChanged;
        /// <summary>
        /// وقتی فایل انتخابی عوض می شود
        /// </summary>
        public event EventHandler FileChanged;

        public Browser()
        {
            InitializeComponent();
            folderBrowser.FolderChanged += new EventHandler(folderBrowser_FolderChanged);
            ImageBrowser.FileChanged += new EventHandler(ImageBrowser_FileChanged);
            FilmBrowser.FileChanged += new EventHandler(FilmBrowser_FileChanged);
        }

        void FilmBrowser_FileChanged(object sender, EventArgs e)
        {
            //قبل از اینکه سراغ فایل بعدی بروی آخرین ایندکس را برای مشاهده های بعدی این پوشه ذخیره کن
            FilmDictionary[folderBrowser.CurrentIndex] = FilmBrowser.index;
            if (FileChanged != null)
                FileChanged(null, null);
        }

        void ImageBrowser_FileChanged(object sender, EventArgs e)
        {
            ImageDictionary[folderBrowser.CurrentIndex] = ImageBrowser.index;
            if (FileChanged != null)
                FileChanged(null, null);
        }

        void folderBrowser_FolderChanged(object sender, EventArgs e)
        {
            try
            {
                //فایل های عکس و فیلم را تنظیم کن
                string s = folderBrowser.GetCurrentFolderName();
                ImageBrowser.Folder = @"Files\" + s + @"\PIC";
                FilmBrowser.Folder = @"Files\" + s + @"\FILM";

                //برو سراغ آخرین ایندکس
                ImageBrowser.index = ImageDictionary[folderBrowser.CurrentIndex];
                FilmBrowser.index = FilmDictionary[folderBrowser.CurrentIndex];

                // هم کنترل فولدر بروزر این رویداد را دارد هم کنترل بروزر
                if (FolderChanged != null)
                    FolderChanged(null, null);


            }
            catch
            {
            }
        }

        private void Browser_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
                folderBrowser.init();
            //در بدو شروع باید ایندکس همه پوشه ها صفر شود
            for (int i = 0; i < folderBrowser.GetFolderCount(); i++)
            {
                ImageDictionary.Add(i, 0);
                FilmDictionary.Add(i, 0);
            }
        }

        /// <summary>
        /// برو سراغ فایل بعدی خواه حالت عکس باشد یا حالت فیلم به صورت هوشمند عمل می کند
        /// و بعد از آخرین فایل به سراغ اولین فایل خواهد رفت
        /// </summary>
        public void GoToNextIndex()
        {

            if (BrowserType == BrowserTypes.Image)
            {
                ImageBrowser.index++;
                if (ImageBrowser.index >= ImageBrowser.Count)
                    ImageBrowser.index = 0;
            }
            else if (BrowserType == BrowserTypes.Film)
            {
                FilmBrowser.index++;
                if (FilmBrowser.index >= FilmBrowser.Count)
                    FilmBrowser.index = 0;

            }
        }

        public void GoToPreviousIndex()
        {
            if (BrowserType == BrowserTypes.Image)
            {
                ImageBrowser.index--;
                if (ImageBrowser.index < 0)
                    ImageBrowser.index = ImageBrowser.Count - 1;
            }
            else
            {
                FilmBrowser.index--;
                if (FilmBrowser.index < 0)
                    FilmBrowser.index = FilmBrowser.Count - 1; ;

            }
        }

        /// <summary>
        /// برو سراغ فولدر شماره ...
        /// 
        /// </summary>
        /// <param name="number"></param>
        public void GoToFolder(int number)
        {
            folderBrowser.GoToFolder(number);
        }

        /// <summary>
        /// تنظیم و گرفتن شماره فولدر انتخابی
        /// </summary>
        public int FolderIndex
        {
            set
            {
                folderBrowser.CurrentIndex = value;
            }
            get
            {
                return folderBrowser.CurrentIndex;
            }
        }

        /// <summary>
        /// آدرس عکس انتخابی
        /// </summary>
        public string SelectedImage
        {
            get
            {
                if (ImageBrowser.SelectedFile == null)
                    return null;
                return ImageBrowser.SelectedFile.ToString();
            }
        }

        /// <summary>
        /// آدرس کلیپ انتخابی
        /// </summary>
        public string SelectedFilm
        {
            get
            {
                if (FilmBrowser.SelectedFile == null)
                    return null;
                return FilmBrowser.SelectedFile.ToString();
            }
        }


        /// <summary>
        /// اضافه کردن پوشه
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                frmGetDirectoryName frm = new frmGetDirectoryName();
                frm.ShowDialog();
                if (!frm.isok)
                    return;

                string fn = frm.DirectoryName;

                Directory.CreateDirectory(@"Files\" + fn);
                Directory.CreateDirectory(@"Files\" + fn + @"\PIC");
                Directory.CreateDirectory(@"Files\" + fn + @"\PIC\thum");
                Directory.CreateDirectory(@"Files\" + fn + @"\FILM");
                Directory.CreateDirectory(@"Files\" + fn + @"\FILM\thum");

                DataSet ds = new DataSet();
                ds.ReadXml(@"Files\Folders.xml");
                if (ds.Tables.Count == 0)
                {
                    ds.Tables.Add("tbl");
                    DataColumn dc = new DataColumn("Name");
                    ds.Tables[0].Columns.Add(dc);
                }

                DataRow dr = ds.Tables[0].NewRow();
                dr[0] = fn;
                ds.Tables[0].Rows.Add(dr);
                ds.WriteXml(@"Files\Folders.xml");

                folderBrowser.init();
            }
            catch
            {
            }
        }

        /// <summary>
        /// اضافه کردن تصویر در پوشه جاری
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = ofdImages.ShowDialog();
                if (dr == DialogResult.Cancel)
                    return;
                int i = ImageBrowser.NextNumber();
                foreach (string f in ofdImages.FileNames)
                {
                    try
                    {
                        string fn = i.ToString("0000000000") + ".jpg";
                        File.Copy(f, @"Files\" + folderBrowser.GetCurrentFolderName() + @"\PIC\" + fn);
                        Image img = Image.FromFile(f);
                        img = (Image)(new Bitmap(img, new Size(100, 100)));
                        //اضافه بر اضافه کردن تصویر باید عکس کوجک جهت نمایش در صفحه کنترل نیز ساخته شده و ذخیره شود
                        img.Save(@"Files\" + folderBrowser.GetCurrentFolderName() + @"\PIC\thum\" + fn + ".jpg");
                        i++;
                    }
                    catch
                    {
                        continue;
                    }
                }
            }
            catch
            {
            }
            finally
            {
                int t = folderBrowser.CurrentIndex;
                folderBrowser.CurrentIndex = -3;
                folderBrowser.CurrentIndex = t;
            }
        }

        /// <summary>
        /// اضافه کردن کلیپ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            DialogResult dr = ofdFilms.ShowDialog();
            if (dr == DialogResult.Cancel)
                return;

            int i = FilmBrowser.NextNumber();
            bool isinsert = false;

            //بر خلاف عکس کلیپ ها را یکی یکی اضافه می کنیم
            FileInfo fi = new FileInfo(ofdFilms.FileName);
            string fn = i.ToString("0000000000") + fi.Extension;
            try
            {
                string fa = @"Files\" + folderBrowser.GetCurrentFolderName() + @"\FILM\" + fn;
                File.Copy(ofdFilms.FileName, fa);
                isinsert = true;
                //برای گرفتن عکس از کلیپ از پروژه دانلود شده استفاده می کنیم
                try
                {
                    Image img = FrameGrabber.GetFrameFromVideo(fa, 0.2d);

                    img = (Image)(new Bitmap(img, new Size(100, 100)));
                    img.Save(@"Files\" + folderBrowser.GetCurrentFolderName() + @"\FILM\\thum\" + fn + ".jpg");
                }
                catch
                {
                    Image img = new Bitmap(1, 1);
                    Graphics drawing = Graphics.FromImage(img);

                    img.Dispose();
                    drawing.Dispose();

                    img = new Bitmap(100, 100);

                    drawing = Graphics.FromImage(img);
                    drawing.Clear(Color.Silver);
                    Brush textBrush = new SolidBrush(Color.Black);
                    drawing.DrawString(fi.Name, this.Font, textBrush, 10, 40);
                    drawing.Save();
                    textBrush.Dispose();
                    drawing.Dispose();
                    img.Save(@"Files\" + folderBrowser.GetCurrentFolderName() + @"\FILM\\thum\" + fn + ".jpg");
                }
            }
            catch (Exception ex)
            {
                //اگر فایل اضافه شده و فقط در گرفتن عکس مشکلی وجود دارد یک عکس خالی برای آن اضافه کن
                if (isinsert)
                {
                    Image img = (Image)(new Bitmap(100, 100));
                    img.Save(@"Files\" + folderBrowser.GetCurrentFolderName() + @"\FILM\\thum\" + fn + ".jpg");
                }
                //continue;
            }
            //یک لحظه هیج پوشه ای را انتخاب نمی کنیم و دوباره پوشه قبلی را انتخاب می کنیم تا فایل های اضافه شده نمایش داده شود
            int t = folderBrowser.CurrentIndex;
            folderBrowser.CurrentIndex = -3;
            folderBrowser.CurrentIndex = t;
        }

        /// <summary>
        /// حذف پوشه انتخابی
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("با حذف این پوشه تمام فایل های موجود در آن نیز حذف می شود. آیا پوشه حذف شود؟", "تایید", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                int t = folderBrowser.CurrentIndex;
                string s = folderBrowser.GetCurrentFolderName();

                //هیچ پوشه ای انتخاب نباشد تا بتوانیم پوشه را پاک کنیم بدون اینکه ویندوز خطا دهد
                //هر موقع خواستیم هیچ پوشه ای انتخاب نباشد باید مقدار -3 را به آن بدهیم
                //folderBrowser.CurrentIndex = -3;

                if (dr == DialogResult.Yes)
                {
                    ImageBrowser.Clear();
                    FilmBrowser.Clear();
                    folderBrowser.CurrentIndex = -3;



                    DataSet ds = new DataSet();
                    ds.ReadXml(@"Files\Folders.xml");
                    ds.Tables[0].Rows.RemoveAt(t);
                    ds.WriteXml(@"Files\Folders.xml");

                    folderBrowser.init();
                    folderBrowser.GoToFolder(1);

                    Directory.Delete(@"Files\" + s, true);

                }
            }
            catch (Exception ex)
            {
            }
        }

        /// <summary>
        /// حذف عکس انتخابی
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("آیا فایل انتخابی حذف شود؟", "تایید", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr != DialogResult.Yes)
                    return;

                int t = folderBrowser.CurrentIndex;
                string d = @"\Files\" + folderBrowser.GetCurrentFolderName() + @"\PIC";

                folderBrowser.CurrentIndex = -3;
                ImageBrowser.Clear();

                try
                {

                    //عکس کوچک آن هم پاک شود
                    string f = Application.StartupPath + @"\" + this.SelectedImage;
                    FileInfo fi = new FileInfo(f);
                    File.Delete(f);
                    File.Delete(Application.StartupPath + d + @"\thum\" + fi.Name + ".jpg");
                    //File.Delete(Application.StartupPath + @"\" + d + @"\thum\" + fi.Name + ".jpg");

                }
                catch
                {

                }
                folderBrowser.CurrentIndex = t;
            }
            catch
            {
            }
        }

        /// <summary>
        /// حذف کلیپ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            try
            {
                string d = @"\Files\" + folderBrowser.GetCurrentFolderName() + @"\FILM";

                DialogResult dr = MessageBox.Show("آیا فایل انتخابی حذف شود؟", "تایید", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                int t = folderBrowser.CurrentIndex;
                folderBrowser.CurrentIndex = -3;
                FilmBrowser.Clear();
                if (dr != DialogResult.Yes)
                    return;
                try
                {
                    string f = Application.StartupPath + @"\" + this.SelectedFilm;

                    FileInfo fi = new FileInfo(f);
                    File.Delete(f);
                    File.Delete(Application.StartupPath + d + @"\thum\" + fi.Name + ".jpg");
                    //File.Delete(Application.StartupPath + @"\" + d + @"\thum\" + fi.Name + ".jpg");
                }
                catch { }
                folderBrowser.CurrentIndex = t;
            }
            catch
            {
            }
        }

        /// <summary>
        /// اگر هیچ تصویری انتخاب نیست منوی حذف تصویر غیر فعال باشد
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void msImage_Opening(object sender, CancelEventArgs e)
        {
            if (ImageBrowser.SelectedFile == null)
                toolStripMenuItem10.Enabled = false;
            else
                toolStripMenuItem10.Enabled = true;
        }

        /// <summary>
        /// وقتی هیچ گلیپی انتخاب نیست حذف کلیپ غیر فعال باشد
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void msFilms_Opening(object sender, CancelEventArgs e)
        {
            if (FilmBrowser.SelectedFile == null)
                toolStripMenuItem14.Enabled = false;
            else
                toolStripMenuItem14.Enabled = true;
        }

        /// <summary>
        /// وقتی هیچ پوشه ای انتخاب نیست منوی حذف پوشه غیر فعال باشد
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void msFolder_Opening(object sender, CancelEventArgs e)
        {
            if (folderBrowser.CurrentIndex == -1)
                toolStripMenuItem2.Enabled = false;
            else
                toolStripMenuItem2.Enabled = true;
        }
    }
}
