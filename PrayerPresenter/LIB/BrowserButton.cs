using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace PrayerControl.LIB
{

    class BrowserButton : Button
    {
        //ایندکس هر دکمه - فایل - را داخل خود آن هم ذخیره می کنیم.
        int index_;
        public int index
        {
            get
            {
                return index_;
            }
        }

        /// <summary>
        /// با ساخته شدن هر دکمه تصویر آن و ایندکس آن نیز شکل می گیرد
        /// </summary>
        /// <param name="imageurl"></param>
        /// <param name="index"></param>
        public BrowserButton(string imageurl, int index)
        {
            string s = imageurl.Replace(@"\thum", "");
            string []arr= s.Split('.');
            //طول پسوند
            int t= arr[arr.Length - 1].Length + 1;
            //آدرس هر فایل داخل تگ آن ذخیره می شود
            this.Tag = s.Remove(s.Length - t);
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.FlatAppearance.BorderColor = Color.Red;
            this.Width = this.Height = 100;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.BackgroundImage = Image.FromFile(imageurl);
            this.index_ = index;
            this.Click += new EventHandler(BrowserButton_Click);
        }

        void BrowserButton_Click(object sender, EventArgs e)
        {
            
        }

    }
}
