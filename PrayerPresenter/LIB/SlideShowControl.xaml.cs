using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Animation;
using System.Windows.Forms;

namespace PrayerControl.LIB
{
    /// <summary>
    /// Interaction logic for SlideShowControl.xaml
    /// </summary>
    public partial class SlideShowControl : System.Windows.Controls.UserControl
    {
        //public float Opacity
        //public double ImageOpacity
        //{
        //    set
        //    {

        //        DoubleAnimation da = new DoubleAnimation()
        //        {
        //            BeginTime = new TimeSpan(0, 0, 0),
        //            From = img0.Opacity,
        //            To = value,
        //            Duration = new Duration(new TimeSpan(0, 0, 8))
        //        };
        //        img0.BeginAnimation(Image.OpacityProperty, da);
        //    }

        //    get
        //    {
        //        return img0.Opacity;
        //    }
        //}

        public double ImageOpacity
        {
            get
            {
                return img0.Opacity;
            }
        }

        public void ChangeOpacity(double Value, int DurationTime)
        {
            DoubleAnimation da = new DoubleAnimation()
            {
                BeginTime = new TimeSpan(0, 0, 0),
                From = img0.Opacity,
                To = Value,
                Duration = new Duration(new TimeSpan(0, 0, DurationTime))
            };
            img0.BeginAnimation(Image.OpacityProperty, da);
        }

        public ImageSource Img
        {
            set
            {
                //جای فکر دارد
                if (this.ImageOpacity != 1)
                {
                    img0.Source = value;
                    return;
                }


                img1.Source = img0.Source;
                img0.Source = value;

                img0.Opacity = 1;
                DoubleAnimation da = new DoubleAnimation()
                {
                    BeginTime = new TimeSpan(0, 0, 0),
                    From = 1,
                    To = 0,
                    Duration = new Duration(new TimeSpan(0, 0, 3))
                };
                img1.BeginAnimation(Image.OpacityProperty, da);
            }
        }

        public void SetImageOntime(ImageSource ImageSource)
        {
            img0.Source = ImageSource;
            img0.Opacity = 1;
            img1.Opacity = 0;
        }

        public SlideShowControl()
        {
            InitializeComponent();
            img0.Width = img1.Width = this.Width;
            img0.Height = img1.Height = this.Height;
        }

        public void setScreen(Screen s,int reduce)
        {
            img0.Width = s.Bounds.Width;
            img1.Width = s.Bounds.Width;
            can.Width = s.Bounds.Width;

            img0.Height = s.Bounds.Height - reduce;
            img1.Height = s.Bounds.Height - reduce;
            can.Height = s.Bounds.Height - reduce;
        }

        private void aa_Loaded(object sender, RoutedEventArgs e)
        {
            //نیاز به اصلاح دارد
            
        }

    }
}

