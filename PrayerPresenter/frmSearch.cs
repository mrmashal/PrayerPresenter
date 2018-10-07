using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.OleDb;
using NaghamateAsemani;

namespace PrayerControl
{
    public partial class frmSearch : Form
    {
        public AhoCorasick.Trie<Location> SearchTrie { get; set; }

        public frmSearch()
        {
            InitializeComponent();
        }

        private void frmSearch_Activated(object sender, EventArgs e)
        {
            tbSearch.Focus();
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            lbResults.Items.Clear();
            if (SearchTrie == null)
                return;
            if (tbSearch.Text.Length < Global.SearchMinLength)
                return;

            var standardText = tbSearch.Text.Replace(" ", "").StandardizeForSearch();
            var results = SearchTrie.Find(standardText).ToArray();
            lbResults.Items.AddRange(results);
        }

        private void frmSearch_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    Close();
                    return;
                case Keys.Enter:
                    lbResults_DoubleClick(null, null);
                    return;
                case Keys.Up:
                    e.SuppressKeyPress = true;
                    if (lbResults.Items.Count > 0)
                        lbResults.SelectedIndex = Math.Max(lbResults.SelectedIndex - 1, 0);
                    return;
                case Keys.Down:
                    e.SuppressKeyPress = true;
                    if (lbResults.Items.Count > 0)
                        lbResults.SelectedIndex = Math.Min(lbResults.SelectedIndex + 1, lbResults.Items.Count - 1);
                    return;
            }
        }

        private void lbResults_DoubleClick(object sender, EventArgs e)
        {
            var location = lbResults.SelectedItem as Location;
            if (location == null)
                return;

            Global.frmControl.GoToVerse = location.VerseIdx;
            Global.frmControl.cmxDataBase.SelectedIndex = location.TextIdx;
            Close();
        }
    }
}
