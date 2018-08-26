namespace PrayerControl.LIB
{
    partial class FolderBrowser
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ListBox = new System.Windows.Forms.ListBox();
            this.ofdImages = new System.Windows.Forms.OpenFileDialog();
            this.ofdFilms = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ListBox
            // 
            this.ListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ListBox.FormattingEnabled = true;
            this.ListBox.Location = new System.Drawing.Point(4, 18);
            this.ListBox.Name = "ListBox";
            this.ListBox.ScrollAlwaysVisible = true;
            this.ListBox.Size = new System.Drawing.Size(280, 277);
            this.ListBox.TabIndex = 0;
            this.ListBox.TabStop = false;
            // 
            // ofdImages
            // 
            this.ofdImages.FileName = "openFileDialog1";
            this.ofdImages.Filter = "Images|*.jpg;*.bmp";
            this.ofdImages.Multiselect = true;
            // 
            // ofdFilms
            // 
            this.ofdFilms.Filter = "VidioFile|*.wmv;*.dat;*.mp4;*.mpg;*.flv";
            this.ofdFilms.Multiselect = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.ListBox);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(287, 303);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "پوشه ها";
            // 
            // FolderBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "FolderBrowser";
            this.Size = new System.Drawing.Size(290, 310);
            this.Load += new System.EventHandler(this.FolderBrowser_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox ListBox;
        private System.Windows.Forms.OpenFileDialog ofdImages;
        private System.Windows.Forms.OpenFileDialog ofdFilms;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
