using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PrayerControl;

namespace NaghamateAsemani
{
    public static class Utils
    {
        public static string StandardizeForSearch(this string s)
        {
            return s
                .Replace("ك", "ک")
                .Replace("ي", "ی")
                .Replace("ً", "")
                .Replace("ُ", "")
                .Replace("ٍ", "")
                .Replace(",", "")
                .Replace("َ", "")
                .Replace("ِ", "")
                .Replace("ّ", "")
                .Replace("ء", "")
                .Replace("ْ", "")
                .Replace("ٌ", "")
                .Replace("آ", "ا")
                .Replace("إ", "ا")
                .Replace("أ", "ا")
                .Replace("ة", "ه");
        }

        private static void AddToSearchTrie(this string verse, int matnId, string matnName, int row)
        {
            // رشته‌های به طول 20 با شروع از کاراکتر بعد از هر فاصله، پس از حذف فاصله‌ها، در درخت جستجو افزوده می‌شوند
            var s = verse.StandardizeForSearch();
            var i = 0;
            var location = new Location
            {
                MatnId = matnId,
                MatnName = matnName,
                Row = row,
                RowText = verse,
                //Offset = i,
            };
            while (true)
            {
                var sub = s.Substring(i).Replace(" ", "");
                if (sub.Length > Global.SearchMaxLength)
                    sub = sub.Substring(0, Global.SearchMaxLength);
                Global.SearchTrie.Add(sub, location);
                if (s.Length > i + 1)
                {
                    i = s.IndexOf(" ", i + 1);
                    if (i < 0)
                        break;
                }
                else
                    break;
            }
        }

        public static void BuildSearchTrie()
        {
            "سلام علیکم".AddToSearchTrie(0, "تستس", 0);
            "إِنَّ الَّذِينَ يُنادُونَكَ مِنْ وَراءِ الْحُجُراتِ أَكْثَرُهُمْ لا يَعْقِلُونَ علی".AddToSearchTrie(1, "تست", 2);
            Global.SearchTrie.Build();
        }
    }

    public class Location
    {
        public int MatnId { get; set; } // اندیس متن/سوره
        public string MatnName { get; set; } // عنوان متن/سوره
        public int Row { get; set; } // سطر/آیه
        public string RowText { get; set; } // متن آیه/سطر
        //public int Offset { get; set; } // محل عبارت جستجو در متن استاندارد شده

        public override string ToString()
        {
            return MatnName + ":" + (Row + 1) + " - " + RowText;
        }
    }
}
