namespace PrayerControl
{
    partial class frmSearch
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.fontDialogText = new System.Windows.Forms.FontDialog();
            this.colorDialogBack = new System.Windows.Forms.ColorDialog();
            this.colorDialogTranslate = new System.Windows.Forms.ColorDialog();
            this.colorDialogText = new System.Windows.Forms.ColorDialog();
            this.fontDialogTranslate = new System.Windows.Forms.FontDialog();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.lbResults = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // fontDialogText
            // 
            this.fontDialogText.Color = System.Drawing.SystemColors.ControlText;
            this.fontDialogText.Font = new System.Drawing.Font("B Nazanin", 50F, System.Drawing.FontStyle.Bold);
            // 
            // colorDialogTranslate
            // 
            this.colorDialogTranslate.Color = System.Drawing.Color.White;
            // 
            // colorDialogText
            // 
            this.colorDialogText.Color = System.Drawing.Color.White;
            // 
            // fontDialogTranslate
            // 
            this.fontDialogTranslate.Color = System.Drawing.SystemColors.ControlText;
            this.fontDialogTranslate.Font = new System.Drawing.Font("B Nazanin", 23F, System.Drawing.FontStyle.Bold);
            // 
            // tbSearch
            // 
            this.tbSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSearch.Location = new System.Drawing.Point(0, 0);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(775, 22);
            this.tbSearch.TabIndex = 0;
            this.tbSearch.TextChanged += new System.EventHandler(this.tbSearch_TextChanged);
            // 
            // lbResults
            // 
            this.lbResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbResults.FormattingEnabled = true;
            this.lbResults.ItemHeight = 14;
            this.lbResults.Location = new System.Drawing.Point(0, 26);
            this.lbResults.Name = "lbResults";
            this.lbResults.Size = new System.Drawing.Size(775, 298);
            this.lbResults.TabIndex = 1;
            this.lbResults.DoubleClick += new System.EventHandler(this.lbResults_DoubleClick);
            // 
            // frmSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 329);
            this.Controls.Add(this.lbResults);
            this.Controls.Add(this.tbSearch);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "frmSearch";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "جستجو";
            this.Activated += new System.EventHandler(this.frmSearch_Activated);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmSearch_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.FontDialog fontDialogText;
        public System.Windows.Forms.ColorDialog colorDialogBack;
        public System.Windows.Forms.ColorDialog colorDialogTranslate;
        public System.Windows.Forms.ColorDialog colorDialogText;
        public System.Windows.Forms.FontDialog fontDialogTranslate;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.ListBox lbResults;
    }
}