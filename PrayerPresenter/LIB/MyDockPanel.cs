using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Media.Animation;
using System.Windows;
using System.Windows.Media;

namespace PrayerControl.LIB
{
    public class MyDockPanel : DockPanel
    {
        DoubleAnimation da;
        public List<MyLabel> arr = new List<MyLabel>();
        public event EventHandler IndexChange;
        public event EventHandler OnCompleted;
        Timer timer = new Timer();
        Timer timerCompleted = new Timer();


        public bool IsEnableCompletedReport
        {
            set
            {
                this.timerCompleted.Enabled = value;
            }
        }

        public bool IsEnableActiveCounter
        {
            set
            {
                this.timer.Enabled = value;
            }
        }

        System.Drawing.Font TextFont_;
        public System.Drawing.Font TextFont
        {
            set
            {
                TextFont_ = value;
                foreach (var ml in arr)
                {
                    ml.FontFamily = new FontFamily(TextFont.Name);
                    ml.FontWeight = TextFont.Bold ? System.Windows.FontWeights.Bold : System.Windows.FontWeights.Regular;
                    ml.FontStyle = TextFont.Italic ? System.Windows.FontStyles.Italic : System.Windows.FontStyles.Normal;
                    ml.FontSize = TextFont.Size;
                }
            }
            get
            {
                return TextFont_;
            }
        }

        System.Drawing.Color TextColor_;
        public System.Drawing.Color TextColor
        {
            set
            {
                TextColor_ = value;
                foreach (var ml in arr)
                {
                    ml.Foreground = new SolidColorBrush(Color.FromArgb(value.A, value.R,  value.G, value.B));
                }
            }
            get
            {
                return TextColor_;
            }
        }

        public void Refresh()
        {
            this.UpdateLayout();
            Canvas.SetRight(this, Global.frmOption.ShowDisplay.Bounds.Width);

            this.UpdateLayout();

            da = new DoubleAnimation()
            {
                BeginTime = new TimeSpan(0, 0, 0),
                From = Canvas.GetRight(this),
                To = 0,
                Duration = new Duration(new TimeSpan(0, 0, 1))
            };
            this.BeginAnimation(Canvas.RightProperty, da);
        }

        public MyDockPanel()
        {
            this.FlowDirection = System.Windows.FlowDirection.RightToLeft;
            timer.Interval = 300;
            timer.Tick += new EventHandler(timer_Tick);
            timerCompleted.Interval = 300;
            timerCompleted.Tick += new EventHandler(timerCompleted_Tick);
        }

        void timerCompleted_Tick(object sender, EventArgs e)
        {

            if (Canvas.GetRight(this) <= -this.ActualWidth && OnCompleted != null)
            {
                OnCompleted(null, null);
                timerCompleted.Enabled = false;
            }
        }

        void timer_Tick(object sender, EventArgs e)
        {    
            foreach (MyLabel l in arr)
            {
                Vector vec = VisualTreeHelper.GetOffset(l);
                double x = Canvas.GetRight(this) + vec.X;

                Screen scr = Global.frmOption.ShowDisplay;
                if (scr == null)
                    continue;

                int w = scr.Bounds.Width;
                
                int b = (w * 3) / 4;
                if (x > b && x < b + 80)
                {
                    if (this.ActiveIndex_ != l.index && IndexChange != null)
                    {
                        this.ActiveIndex_ = l.index;
                        IndexChange(null, null);
                    }
                    break;
                }
            }



        }

        int ActiveIndex_ = 0;
        public int ActiveIndex
        {
            set
            {
                Vector vec = VisualTreeHelper.GetOffset(arr[value]);
                double d = -1 * (int)vec.X;

                da = new DoubleAnimation()
                {
                    BeginTime = new TimeSpan(0, 0, 0),
                    From = Canvas.GetRight(this),
                    To = d,
                    Duration = new Duration(new TimeSpan(0, 0, 1))
                };
                this.BeginAnimation(Canvas.RightProperty, da);

                ActiveIndex_ = value;
            }
            get
            {
                return ActiveIndex_;
            }
        }

        int speed_ = 50;
        public int speed
        {
            set
            {
                if (value < 10 || value > 9999)
                    return;

                speed_ = value;
                Start();
            }
            get
            {
                return speed_;
            }
        }
                

        public void Start()
        {
            try
            {
                int t = Math.Abs((int)(-this.ActualWidth - Canvas.GetRight(this))) / this.speed;
                da = new DoubleAnimation()
                {
                    BeginTime = new TimeSpan(0, 0, 0),
                    From = Canvas.GetRight(this),
                    To = -this.ActualWidth,
                    Duration = new Duration(new TimeSpan(0, 0, t))
                };
                this.BeginAnimation(Canvas.RightProperty, da);
            }
            catch
            {
            }
        }

        public void Stop()
        {
            da = new DoubleAnimation()
            {
                BeginTime = new TimeSpan(0, 0, 0),
                From = Canvas.GetRight(this),
                To = Canvas.GetRight(this),
                Duration = new Duration(new TimeSpan(0, 0, 1))
            };
            this.BeginAnimation(Canvas.RightProperty, da);
        }

        public double Add(string text, int index)
        {
            MyLabel ml = new MyLabel();
            text = text.Replace(@"
", " ");
            ml.Content = text;

            ml.FontFamily = new FontFamily(TextFont.Name);
            ml.FontWeight = TextFont.Bold ? System.Windows.FontWeights.Bold : System.Windows.FontWeights.Regular;
            ml.FontStyle = TextFont.Italic ? System.Windows.FontStyles.Italic : System.Windows.FontStyles.Normal;
            ml.FontSize = TextFont.Size;
            ml.Background = Brushes.Transparent;
            ml.Foreground = new SolidColorBrush(Color.FromArgb(this.TextColor.A, this.TextColor.R, this.TextColor.G, this.TextColor.B));

            ml.index = index;
            this.Children.Add(ml);
            arr.Add(ml);
            this.UpdateLayout();
            return ml.ActualWidth;
        }

        public void Add(string text, int index, double width)
        {
            MyLabel ml = new MyLabel();
            text = text.Replace(@"
", " ");
            ml.HorizontalContentAlignment = System.Windows.HorizontalAlignment.Center;
            ml.Width = width;
            ml.Content = text;

            ml.FontFamily = new FontFamily(TextFont.Name);
            ml.FontWeight = TextFont.Bold ? System.Windows.FontWeights.Bold : System.Windows.FontWeights.Regular;
            ml.FontStyle = TextFont.Italic ? System.Windows.FontStyles.Italic : System.Windows.FontStyles.Normal;
            ml.FontSize = TextFont.Size;
            ml.Background = Brushes.Transparent;
            ml.Foreground = new SolidColorBrush(Color.FromArgb(this.TextColor.A, this.TextColor.R, this.TextColor.G, this.TextColor.B));

            ml.index = index;
            this.Children.Add(ml);
            arr.Add(ml);
        }
    }
}