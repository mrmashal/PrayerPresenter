using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace PrayerControl.LIB
{
    public class MyLabel:Label
    {
        public MyLabel()
        {
        }

        int index_;
        public int index
        {
            set
            {
                index_ = value;
            }
            get
            {
                return index_;
            }
        }
    }
}
