namespace PrayerControl.LIB
{
    partial class Browser
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Browser));
            this.msFolder = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.ofdFilms = new System.Windows.Forms.OpenFileDialog();
            this.ofdImages = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.msFilms = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem13 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem14 = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.msImage = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripMenuItem();
            this.ImageBrowser = new PrayerControl.LIB.FileBrowser();
            this.FilmBrowser = new PrayerControl.LIB.FileBrowser();
            this.folderBrowser = new PrayerControl.LIB.FolderBrowser();
            this.msFolder.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.msFilms.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.msImage.SuspendLayout();
            this.SuspendLayout();
            // 
            // msFolder
            // 
            this.msFolder.Font = new System.Drawing.Font("Tahoma", 8F);
            this.msFolder.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2});
            this.msFolder.Name = "ms";
            this.msFolder.Size = new System.Drawing.Size(149, 48);
            this.msFolder.Opening += new System.ComponentModel.CancelEventHandler(this.msFolder_Opening);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem1.Image")));
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(148, 22);
            this.toolStripMenuItem1.Text = "ایجاد پوشه جدید";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem2.Image")));
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(148, 22);
            this.toolStripMenuItem2.Text = "حذف پوشه";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // ofdFilms
            // 
            this.ofdFilms.Filter = "VidioFile|*.wmv;*.mpg";
            // 
            // ofdImages
            // 
            this.ofdImages.FileName = "openFileDialog1";
            this.ofdImages.Filter = "Images|*.jpg;*.bmp";
            this.ofdImages.Multiselect = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.FilmBrowser);
            this.groupBox1.Location = new System.Drawing.Point(4, 150);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(956, 149);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "کلیپ ها";
            // 
            // msFilms
            // 
            this.msFilms.Font = new System.Drawing.Font("Tahoma", 8F);
            this.msFilms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem13,
            this.toolStripMenuItem14});
            this.msFilms.Name = "ms";
            this.msFilms.Size = new System.Drawing.Size(152, 48);
            this.msFilms.Opening += new System.ComponentModel.CancelEventHandler(this.msFilms_Opening);
            // 
            // toolStripMenuItem13
            // 
            this.toolStripMenuItem13.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem13.Image")));
            this.toolStripMenuItem13.Name = "toolStripMenuItem13";
            this.toolStripMenuItem13.Size = new System.Drawing.Size(151, 22);
            this.toolStripMenuItem13.Text = "اضافه کردن کلیپ";
            this.toolStripMenuItem13.Click += new System.EventHandler(this.toolStripMenuItem5_Click);
            // 
            // toolStripMenuItem14
            // 
            this.toolStripMenuItem14.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem14.Image")));
            this.toolStripMenuItem14.Name = "toolStripMenuItem14";
            this.toolStripMenuItem14.Size = new System.Drawing.Size(151, 22);
            this.toolStripMenuItem14.Text = "حذف کلیپ";
            this.toolStripMenuItem14.Click += new System.EventHandler(this.toolStripMenuItem6_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.ImageBrowser);
            this.groupBox2.Location = new System.Drawing.Point(4, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(956, 147);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "تصاویر";
            // 
            // msImage
            // 
            this.msImage.Font = new System.Drawing.Font("Tahoma", 8F);
            this.msImage.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem9,
            this.toolStripMenuItem10});
            this.msImage.Name = "ms";
            this.msImage.Size = new System.Drawing.Size(154, 48);
            this.msImage.Opening += new System.ComponentModel.CancelEventHandler(this.msImage_Opening);
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem9.Image")));
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(153, 22);
            this.toolStripMenuItem9.Text = "اضافه کردن تصویر";
            this.toolStripMenuItem9.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // toolStripMenuItem10
            // 
            this.toolStripMenuItem10.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem10.Image")));
            this.toolStripMenuItem10.Name = "toolStripMenuItem10";
            this.toolStripMenuItem10.Size = new System.Drawing.Size(153, 22);
            this.toolStripMenuItem10.Text = "حذف تصویر";
            this.toolStripMenuItem10.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // ImageBrowser
            // 
            this.ImageBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ImageBrowser.AutoScroll = true;
            this.ImageBrowser.ContextMenuStrip = this.msImage;
            this.ImageBrowser.Folder = null;
            this.ImageBrowser.index = 0;
            this.ImageBrowser.IsEnable = true;
            this.ImageBrowser.Location = new System.Drawing.Point(4, 23);
            this.ImageBrowser.Name = "ImageBrowser";
            this.ImageBrowser.Size = new System.Drawing.Size(948, 120);
            this.ImageBrowser.TabIndex = 2;
            // 
            // FilmBrowser
            // 
            this.FilmBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.FilmBrowser.AutoScroll = true;
            this.FilmBrowser.ContextMenuStrip = this.msFilms;
            this.FilmBrowser.Folder = null;
            this.FilmBrowser.index = 0;
            this.FilmBrowser.IsEnable = true;
            this.FilmBrowser.Location = new System.Drawing.Point(4, 24);
            this.FilmBrowser.Name = "FilmBrowser";
            this.FilmBrowser.Size = new System.Drawing.Size(948, 120);
            this.FilmBrowser.TabIndex = 3;
            // 
            // folderBrowser
            // 
            this.folderBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.folderBrowser.ContextMenuStrip = this.msFolder;
            this.folderBrowser.CurrentIndex = -1;
            this.folderBrowser.Location = new System.Drawing.Point(968, -1);
            this.folderBrowser.Name = "folderBrowser";
            this.folderBrowser.Size = new System.Drawing.Size(291, 300);
            this.folderBrowser.TabIndex = 1;
            // 
            // Browser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.folderBrowser);
            this.Name = "Browser";
            this.Size = new System.Drawing.Size(1263, 307);
            this.Load += new System.EventHandler(this.Browser_Load);
            this.msFolder.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.msFilms.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.msImage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private FolderBrowser folderBrowser;
        private FileBrowser ImageBrowser;
        private FileBrowser FilmBrowser;
        private System.Windows.Forms.ContextMenuStrip msFolder;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.OpenFileDialog ofdFilms;
        private System.Windows.Forms.OpenFileDialog ofdImages;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ContextMenuStrip msImage;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem9;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem10;
        private System.Windows.Forms.ContextMenuStrip msFilms;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem13;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem14;
    }
}
