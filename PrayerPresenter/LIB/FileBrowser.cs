using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

namespace PrayerControl.LIB
{
    public class FileBrowser : Panel
    {
        public FileBrowser()
        {
            this.Width = 920;
            this.Height = 125;
            this.AutoScroll = true;
            this.BorderStyle = System.Windows.Forms.BorderStyle.None;
        }

        private Image Lighter(Image imgLight)
        {
            Graphics graphics = Graphics.FromImage(imgLight);
            Pen pLight = new Pen(Color.FromArgb(150, 250,
                                 250, 250), imgLight.Width * 2);
            graphics.DrawLine(pLight, -1, -1, imgLight.Width, imgLight.Height);
            graphics.Save();
            graphics.Dispose();
            return imgLight;
        }
        private void Disable()
        {
            if (Buttons == null)
                return;
            foreach (BrowserButton b in Buttons)
            {
                b.BackgroundImage = Lighter(b.BackgroundImage);
            }
        }

        private bool IsEnable_ = true;
        public bool IsEnable
        {
            set
            {
                IsEnable_ = value;
                this.Folder = this.Folder;
                this.index = this.index;
                if (!value)
                    Disable();

            }
            get
            {
                return IsEnable_;
            }
        }

        public void Clear()
        {
            foreach (var b in Buttons)
            {
                b.BackgroundImage.Dispose();
            }
            this.Controls.Clear();
        }


        public event EventHandler FileChanged;
        BrowserButton[] Buttons;
        public int Count = 0;
        string Folder_;
        public string Folder
        {
            set
            {
                try
                {
                    this.AutoScroll = true;
                    if (value == null)
                        return;
                    this.Folder_ = value;

                    string a = value + @"\thum";

                    string[] f = Directory.GetFiles(a, "*.jpg");

                    //
                    string[] arr = Directory.GetFiles(value);

                    foreach (string s in f)
                    {
                        FileInfo fi = new FileInfo(s);
                        bool bl = false;

                        foreach (string s1  in arr)
                        {
                            FileInfo fi1 = new FileInfo(s1);
                            if (fi.Name == fi1.Name + ".jpg")
                            {
                                bl = true;
                                break;
                            }
                        }
                        if (!bl)
                        {
                            File.Delete(s);
                        }
                    }
                    //

                    f = Directory.GetFiles(a, "*.jpg");
                    this.Count = f.Count();
                    this.Controls.Clear();
                    int j = 5;
                    int i = 0;

                    Buttons = new BrowserButton[f.Length];
                    foreach (string s in f)
                    {
                        BrowserButton b = new BrowserButton(s, i);
                        b.Click += new EventHandler(b_Click);
                        b.Location = new Point(j, 2);
                        j += 105;
                        Buttons[i] = b;
                        i++;
                        this.Controls.Add(b);
                    }

                    if (!IsEnable)
                        Disable();
                }
                catch
                {
                }
            }
            get
            {
                return this.Folder_;
            }
        }

        public Button ActiveButton;
        void b_Click(object sender, EventArgs e)
        {
            if (!this.IsEnable)
                return;
            BrowserButton b = sender as BrowserButton;
            this.index = b.index;
            if (FileChanged == null)
                return;
            FileChanged(sender, e);
        }

        public string SelectedFile
        {
            get
            {
                if (ActiveButton == null)
                    return null;
                return ActiveButton.Tag.ToString();
            }
        }

        //برای نامگذاری
        public int NextNumber()
        {
            int i = 0;
            if (Buttons == null)
                return i;
            foreach (BrowserButton b in Buttons)
            {
                try
                {
                    FileInfo fi = new FileInfo(b.Tag.ToString());
                    string s = fi.Name;
                    string[] arr = s.Split('.');
                    int t = arr[arr.Length - 1].Length + 1;
                    s = s.Remove(s.Length - t);

                    t = Convert.ToInt32(s);
                    if (t > i)
                        i = t;
                }
                catch { }
            }
            return ++i;
        }

        int index_;
        public int index
        {
            set
            {
                index_ = value;

                if (Buttons == null || value >= Buttons.Length || value < 0)
                    return;

                Buttons[value].Focus();
                if (this.ActiveButton != null)
                {
                    ActiveButton.FlatAppearance.BorderSize = 0;
                }
                ActiveButton = Buttons[value];
                Buttons[value].FlatAppearance.BorderSize = 4;
                if (FileChanged != null)
                    FileChanged(null, null);

                this.ScrollToControl(Buttons[value]);
            }
            get
            {
                return index_;
            }
        }

    }
}
