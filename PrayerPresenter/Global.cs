using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AhoCorasick;
using NaghamateAsemani;

namespace PrayerControl
{
    class Global
    {
        public static string FilesDb = @"B\Files.xml";
        public static int SearchMinLength = 3;
        public static int SearchMaxLength = 20;

        public static frmCamera frmCamera = new frmCamera();
        public static frmImage frmImage = new frmImage();
        public static frmMedia frmMedia = new frmMedia();
        public static frmText frmText = new frmText();
        public static frmText frmTranslate = new frmText();
        public static frmText frmControlText = new frmText();

        public static frmBlack frmBlack = new frmBlack();
        public static frmControl frmControl = new frmControl();
        public static frmText frmBackGround = new frmText();
        public static frmOption frmOption = new frmOption();
        public static frmSearch frmSearch = new frmSearch();

        public static AhoCorasick.Trie<Location> SearchTrie = new Trie<Location>();

        public static void ShowForms()
        {
            Global.frmText.Top = -400;
            Global.frmTranslate.Top = -400;

            Global.frmCamera.Show();
            Global.frmMedia.Show();
            Global.frmImage.Show();

            Global.frmBlack.Show();
            Global.frmBackGround.Show();
            Global.frmControlText.Show();
        }

        public static void Close()
        {
            Global.frmCamera.Close();
            Global.frmMedia.Close();
            Global.frmImage.Close();
            Global.frmBlack.Close();
            Global.frmText.Close();
            Global.frmTranslate.Close();
            Global.frmControlText.Close();
            Global.frmBackGround.Close();
        }

        public static void SetPosition()
        {
            Global.frmCamera.BringToFront();
            Global.frmMedia.Activate();
            Global.frmImage.Activate();
            Global.frmBlack.Activate();
            Global.frmText.Activate();
            Global.frmTranslate.Activate();
            Global.frmBackGround.Activate();
            Global.frmControlText.Activate();
            Global.frmControl.Activate();
            Global.frmControl.Focus();
        }
    }
}
