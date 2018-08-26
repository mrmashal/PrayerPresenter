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
using System.Runtime.InteropServices;
using System.Windows.Interop;

namespace PrayerControl
{
    /// <summary>
    /// Interaction logic for frmMatn.xaml
    /// </summary>
    public partial class frmText : Window
    {
        public event EventHandler IndexChange;
        public event EventHandler OnCompleted;

        public bool IsEnableCompletedReport
        {
            set
            {
                myDockPanel1.IsEnableCompletedReport = value;
            }
        }

        public int ActiveIndex
        {
            set
            {
                myDockPanel1.ActiveIndex = value;
            }
            get
            {
                return myDockPanel1.ActiveIndex;
            }
        }

        public frmText()
        {
            InitializeComponent();
            myDockPanel1.OnCompleted += new EventHandler(myDockPanel1_OnCompletedCompleted);
        }


        System.Drawing.Color BackColor_;
        public System.Drawing.Color BackColor
        {
            set
            {
                if (IsTransparent)
                    return;
                BackColor_ = value;
                this.Background = new SolidColorBrush(Color.FromArgb(value.A, value.R, value.G, value.B));
            }
            get
            {
                return BackColor_;
            }
        }

        bool IsTransparent_ = false;
        public bool IsTransparent
        {
            set
            {
                IsTransparent_ = value;
                if (value)
                    this.Background = Brushes.Transparent;
                else
                    BackColor = BackColor;
            }
            get
            {
                return IsTransparent_;
            }
        }

        void myDockPanel1_OnCompletedCompleted(object sender, EventArgs e)
        {
            if (this.OnCompleted != null)
                OnCompleted(null, null);
        }

        public System.Drawing.Font TextFont
        {
            set
            {
                myDockPanel1.TextFont = value;
                this.UpdateLayout();
                this.Height = myDockPanel1.ActualHeight;
            }
            get
            {
                return myDockPanel1.TextFont;
            }
        }

        public System.Drawing.Color TextColor
        {
            set
            {
                myDockPanel1.TextColor = value;
            }
            get
            {
                return myDockPanel1.TextColor;
            }
        }

        public void ClearItem()
        {
            this.myDockPanel1.Children.Clear();
        }

        public void Refresh()
        {
            myDockPanel1.Refresh();
            this.Height = myDockPanel1.ActualHeight;
        }

        public double AddItem(string text, int index)
        {
            return this.myDockPanel1.Add(text, index);
        }

        public void AddItem(string text, int index, double width)
        {
            this.myDockPanel1.Add(text, index, width);
        }

        private bool IsMotion_ = false;
        public bool IsMotion
        {
            set
            {
                if (value)
                {
                    myDockPanel1.Start();
                }
                else
                {
                    myDockPanel1.Stop();
                }
                IsMotion_ = value;
            }
            get
            {
                return IsMotion_;
            }
        }

        public bool IsEnableActiveCounter
        {
            set
            {
                myDockPanel1.IsEnableActiveCounter = value;
            }
        }

        public int Speed
        {
            set
            {
                this.myDockPanel1.speed = value;
            }
            get
            {
                return this.myDockPanel1.speed;
            }
        }

        private void myDockPanel1_IndexChange(object sender, EventArgs e)
        {
            if (IndexChange != null)
                IndexChange(null, null);
        }

        #region Window styles
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            WindowInteropHelper wndHelper = new WindowInteropHelper(this);

            int exStyle = (int)GetWindowLong(wndHelper.Handle, (int)GetWindowLongFields.GWL_EXSTYLE);

            exStyle |= (int)ExtendedWindowStyles.WS_EX_TOOLWINDOW;
            SetWindowLong(wndHelper.Handle, (int)GetWindowLongFields.GWL_EXSTYLE, (IntPtr)exStyle);
        }

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

        private void Window_Closed(object sender, EventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

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

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            myDockPanel1.IsEnableCompletedReport = false;
        }

    }
}
