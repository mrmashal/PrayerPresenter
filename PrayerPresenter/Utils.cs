using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
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

        private static void AddToSearchTries(this string verse, int textIdx, string textName, int verseIdx)
        {
            // رشته‌های به طول 20 با شروع از کاراکتر بعد از هر فاصله، پس از حذف فاصله‌ها، در درخت جستجو افزوده می‌شوند
            var s = verse.StandardizeForSearch();
            var i = 0;
            var shortTextName = textName.Replace("سوره ", "").Replace("دعای ", "").Replace("زیارت ", "").Replace("مناجات ", "");
            var location = new Location
            {
                TextIdx = textIdx,
                TextName = shortTextName,
                VerseIdx = verseIdx,
                VerseText = verse,
                //Offset = i,
            };
            Global.GotoSearchTrie.Add(
                shortTextName.Replace(" ", "").StandardizeForSearch() + ":" + verseIdx,
                location
            );
            while (true)
            {
                var sub = s.Substring(i).Replace(" ", "");
                if (sub.Length > Global.SearchMaxLength)
                    sub = sub.Substring(0, Global.SearchMaxLength);
                Global.TextSearchTrie.Add(sub, location);
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

        public static void BuildSearchTries(BackgroundWorker bw)
        {
            DataSet ds = new DataSet();
            ds.ReadXml(Global.FilesDb);
            var fileTable = ds.Tables[0];

            for (int j = 0; j < fileTable.Rows.Count; j++)
            {
                var percentage = (int)Math.Round((double)(100 * j) / fileTable.Rows.Count);
                bw.ReportProgress(percentage);

                var textName = fileTable.Rows[j][0].ToString();
                var filename = fileTable.Rows[j][1].ToString();

                var connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=B\" + filename;
                var con = new OleDbConnection();
                con.ConnectionString = connectionString;
                con.Open();
                var cmd = new OleDbCommand();
                cmd.Connection = con;
                cmd.CommandText = "select * from tbl ORDER BY ID";
                var dt = new DataTable();
                var adapter = new OleDbDataAdapter();
                adapter.SelectCommand = cmd;
                adapter.Fill(dt);
                con.Close();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var text = dt.Rows[i][1].ToString();

                    text.AddToSearchTries(j, textName, i);
                }
            }
        }
    }

    public class Location
    {
        public int TextIdx { get; set; } // اندیس متن/سوره
        public string TextName { get; set; } // عنوان متن/سوره
        public int VerseIdx { get; set; } // اندیس سطر/آیه
        public string VerseText { get; set; } // متن آیه/سطر
        //public int Offset { get; set; } // محل عبارت جستجو در متن استاندارد شده

        public override string ToString()
        {
            return TextName + ":" + VerseIdx + " - " + VerseText;
        }
    }
}
