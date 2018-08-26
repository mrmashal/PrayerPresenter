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

namespace PrayerControl
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }


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

        public int duration()
        {
            int t = (int)MediaElement.NaturalDuration.TimeSpan.TotalMilliseconds;
            return t;
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

        public event EventHandler onMediaOpend;
        private void MediaElement_MediaOpened(object sender, RoutedEventArgs e)
        {
            if (onMediaOpend != null)
                onMediaOpend(null, null);
        }

        public void SetPosition(int value)
        {
            MediaElement.Position =TimeSpan.FromMilliseconds( value);
        }
    }
}