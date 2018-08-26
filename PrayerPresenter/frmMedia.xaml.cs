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
using System.Windows.Shapes;
using System.Windows.Forms;
using System.Windows.Media.Animation;
using System.Windows.Interop;
using System.Runtime.InteropServices;

namespace PrayerControl
{
    /// <summary>
    /// Interaction logic for frmMedia.xaml
    /// </summary>
    public partial class frmMedia : Window
    {

        //public int duration()
        //{
        //    int t = (int)MediaElement.NaturalDuration.TimeSpan.TotalMilliseconds;
        //    return t;
        //}

        public TimeSpan MediaDuration
        {
            get
            {
                return MediaElement.NaturalDuration.TimeSpan;
            }
        }

        public event EventHandler onMediaOpend;
        private void MediaElement_MediaOpened(object sender, RoutedEventArgs e)
        {
            if (onMediaOpend != null)
                onMediaOpend(null, null);
        }

        public TimeSpan MediaPosition
        {
            set
            {
                MediaElement.Position = value;
            }
            get
            {
                return MediaElement.Position;
            }
        }

        Timer timer = new Timer();

        public void Pause()
        {
            this.MediaElement.Pause();
        }

        public void Play()
        {
            this.MediaElement.Play();
        }

        public void Forward()
        {
            MediaElement.Position += TimeSpan.FromSeconds(5); 
        }

        public void Backward()
        {
            MediaElement.Position -= TimeSpan.FromSeconds(5); 
        }

        public frmMedia()
        {
            InitializeComponent();
            timer.Tick += new EventHandler(timer_Tick);
        }

        public void PauseDelay(int delay)
        {
            timer.Interval = delay;
            timer.Enabled = true;
        }

        void timer_Tick(object sender, EventArgs e)
        {
            this.Pause();
            timer.Enabled = false;
        }

        public void ChangeOpacity(double Value, int DurationTime, int starttime)
        {
            DoubleAnimation da = new DoubleAnimation()
            {
                BeginTime = new TimeSpan(0, 0, starttime),
                From = this.Opacity,
                To = Value,
                Duration = new Duration(new TimeSpan(0, 0, DurationTime))
            };
            this.BeginAnimation(Image.OpacityProperty, da);
        }

        string MediaSource_ = "";
        public string MediaSource
        {
            set
            {
                MediaElement.Source = new Uri(value);
                MediaSource_ = value;
            }
            get
            {
                return MediaSource_;
            }

        }

        public void SetScreen(Screen s,int reduce)
        {
            MediaElement.Width = s.Bounds.Width;
            this.Height  =MediaElement.Height = s.Bounds.Height - reduce;
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //MediaElement.Width = this.Width;
            //MediaElement.Height = this.Height;

            //MediaElement.Width = Screen.AllScreens.First().Bounds.Width;
            //MediaElement.Height = Screen.AllScreens.First().Bounds.Height;

            WindowInteropHelper wndHelper = new WindowInteropHelper(this);

            int exStyle = (int)GetWindowLong(wndHelper.Handle, (int)GetWindowLongFields.GWL_EXSTYLE);

            exStyle |= (int)ExtendedWindowStyles.WS_EX_TOOLWINDOW;
            SetWindowLong(wndHelper.Handle, (int)GetWindowLongFields.GWL_EXSTYLE, (IntPtr)exStyle);

        }
        #region Window styles
        [Flags]
        public enum ExtendedWindowStyles
        {
            // ...
            WS_EX_TOOLWINDOW = 0x00000080,
            // ...
        }

        public enum GetWindowLongFields
        {
            // ...
            GWL_EXSTYLE = (-20),
            // ...
        }

        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowLong(IntPtr hWnd, int nIndex);

        public static IntPtr SetWindowLong(IntPtr hWnd, int nIndex, IntPtr dwNewLong)
        {
            int error = 0;
            IntPtr result = IntPtr.Zero;
            // Win32 SetWindowLong doesn't clear error on success
            SetLastError(0);

            if (IntPtr.Size == 4)
            {
                // use SetWindowLong
                Int32 tempResult = IntSetWindowLong(hWnd, nIndex, IntPtrToInt32(dwNewLong));
                error = Marshal.GetLastWin32Error();
                result = new IntPtr(tempResult);
            }
            else
            {
                // use SetWindowLongPtr
                result = IntSetWindowLongPtr(hWnd, nIndex, dwNewLong);
                error = Marshal.GetLastWin32Error();
            }

            if ((result == IntPtr.Zero) && (error != 0))
            {
                throw new System.ComponentModel.Win32Exception(error);
            }

            return result;
        }

        [DllImport("user32.dll", EntryPoint = "SetWindowLongPtr", SetLastError = true)]
        private static extern IntPtr IntSetWindowLongPtr(IntPtr hWnd, int nIndex, IntPtr dwNewLong);

        [DllImport("user32.dll", EntryPoint = "SetWindowLong", SetLastError = true)]
        private static extern Int32 IntSetWindowLong(IntPtr hWnd, int nIndex, Int32 dwNewLong);

        private static int IntPtrToInt32(IntPtr intPtr)
        {
            return unchecked((int)intPtr.ToInt64());
        }

        [DllImport("kernel32.dll", EntryPoint = "SetLastError")]
        public static extern void SetLastError(int dwErrorCode);
        #endregion

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Global.SetPosition();

        }

        private void Window_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            System.Windows.Forms.Cursor.Hide();
        }

        private void Window_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            System.Windows.Forms.Cursor.Show();
        }
      
    }
}
