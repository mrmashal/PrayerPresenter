namespace PrayerControl
{
    partial class frmOption
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
            this.btnClose = new System.Windows.Forms.Button();
            this.cmxControlDisplay = new System.Windows.Forms.ComboBox();
            this.cmxShowDisplay = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmDevices = new System.Windows.Forms.ComboBox();
            this.gbDisplay = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chSingleDisplay = new System.Windows.Forms.CheckBox();
            this.gbText = new System.Windows.Forms.GroupBox();
            this.btnTextFont = new System.Windows.Forms.Button();
            this.btnTextColor = new System.Windows.Forms.Button();
            this.gbTranslate = new System.Windows.Forms.GroupBox();
            this.btnTranslateFont = new System.Windows.Forms.Button();
            this.btnTranslateColor = new System.Windows.Forms.Button();
            this.gbBackColor = new System.Windows.Forms.GroupBox();
            this.btnBackColor = new System.Windows.Forms.Button();
            this.chbIsTransparent = new System.Windows.Forms.CheckBox();
            this.fontDialogText = new System.Windows.Forms.FontDialog();
            this.colorDialogBack = new System.Windows.Forms.ColorDialog();
            this.colorDialogTranslate = new System.Windows.Forms.ColorDialog();
            this.colorDialogText = new System.Windows.Forms.ColorDialog();
            this.fontDialogTranslate = new System.Windows.Forms.FontDialog();
            this.gbDisplay.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.gbText.SuspendLayout();
            this.gbTranslate.SuspendLayout();
            this.gbBackColor.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(3, 315);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(87, 25);
            this.btnClose.TabIndex = 30;
            this.btnClose.Text = "بستن پنجره";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // cmxControlDisplay
            // 
            this.cmxControlDisplay.FormattingEnabled = true;
            this.cmxControlDisplay.Location = new System.Drawing.Point(6, 18);
            this.cmxControlDisplay.Name = "cmxControlDisplay";
            this.cmxControlDisplay.Size = new System.Drawing.Size(284, 22);
            this.cmxControlDisplay.TabIndex = 33;
            this.cmxControlDisplay.SelectedIndexChanged += new System.EventHandler(this.Display_SelectedIndexChanged);
            // 
            // cmxShowDisplay
            // 
            this.cmxShowDisplay.FormattingEnabled = true;
            this.cmxShowDisplay.Location = new System.Drawing.Point(5, 46);
            this.cmxShowDisplay.Name = "cmxShowDisplay";
            this.cmxShowDisplay.Size = new System.Drawing.Size(285, 22);
            this.cmxShowDisplay.TabIndex = 34;
            this.cmxShowDisplay.SelectedIndexChanged += new System.EventHandler(this.Display_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(293, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 14);
            this.label2.TabIndex = 37;
            this.label2.Text = "نمایشگر کنترل:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(293, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 14);
            this.label3.TabIndex = 38;
            this.label3.Text = "نمایشگر اصلی:";
            // 
            // cmDevices
            // 
            this.cmDevices.FormattingEnabled = true;
            this.cmDevices.Location = new System.Drawing.Point(6, 12);
            this.cmDevices.Name = "cmDevices";
            this.cmDevices.Size = new System.Drawing.Size(284, 22);
            this.cmDevices.TabIndex = 39;
            this.cmDevices.SelectedIndexChanged += new System.EventHandler(this.cmDevices_SelectedIndexChanged);
            // 
            // gbDisplay
            // 
            this.gbDisplay.Controls.Add(this.cmxControlDisplay);
            this.gbDisplay.Controls.Add(this.cmxShowDisplay);
            this.gbDisplay.Controls.Add(this.label2);
            this.gbDisplay.Controls.Add(this.label3);
            this.gbDisplay.Location = new System.Drawing.Point(3, 2);
            this.gbDisplay.Name = "gbDisplay";
            this.gbDisplay.Size = new System.Drawing.Size(382, 75);
            this.gbDisplay.TabIndex = 36;
            this.gbDisplay.TabStop = false;
            this.gbDisplay.Text = "تنظیمات نمایشگر";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.cmDevices);
            this.groupBox3.Location = new System.Drawing.Point(3, 78);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(382, 40);
            this.groupBox3.TabIndex = 39;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "دوربین ورودی";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(297, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 14);
            this.label4.TabIndex = 39;
            this.label4.Text = "انتخاب دوربین:";
            // 
            // chSingleDisplay
            // 
            this.chSingleDisplay.AutoSize = true;
            this.chSingleDisplay.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chSingleDisplay.Location = new System.Drawing.Point(300, 129);
            this.chSingleDisplay.Name = "chSingleDisplay";
            this.chSingleDisplay.Size = new System.Drawing.Size(81, 18);
            this.chSingleDisplay.TabIndex = 40;
            this.chSingleDisplay.Text = "تک مانیتوره";
            this.chSingleDisplay.UseVisualStyleBackColor = true;
            this.chSingleDisplay.CheckedChanged += new System.EventHandler(this.chSingleDisplay_CheckedChanged);
            // 
            // gbText
            // 
            this.gbText.Controls.Add(this.btnTextFont);
            this.gbText.Controls.Add(this.btnTextColor);
            this.gbText.Location = new System.Drawing.Point(235, 171);
            this.gbText.Name = "gbText";
            this.gbText.Size = new System.Drawing.Size(146, 48);
            this.gbText.TabIndex = 41;
            this.gbText.TabStop = false;
            this.gbText.Text = "متن اصلی";
            // 
            // btnTextFont
            // 
            this.btnTextFont.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnTextFont.Location = new System.Drawing.Point(77, 16);
            this.btnTextFont.Name = "btnTextFont";
            this.btnTextFont.Size = new System.Drawing.Size(65, 25);
            this.btnTextFont.TabIndex = 31;
            this.btnTextFont.TabStop = false;
            this.btnTextFont.Text = "فونت...";
            this.btnTextFont.UseVisualStyleBackColor = true;
            this.btnTextFont.Click += new System.EventHandler(this.btnTextFont_Click);
            // 
            // btnTextColor
            // 
            this.btnTextColor.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnTextColor.Location = new System.Drawing.Point(5, 16);
            this.btnTextColor.Name = "btnTextColor";
            this.btnTextColor.Size = new System.Drawing.Size(66, 25);
            this.btnTextColor.TabIndex = 41;
            this.btnTextColor.TabStop = false;
            this.btnTextColor.Text = "رنگ متن...";
            this.btnTextColor.UseVisualStyleBackColor = true;
            this.btnTextColor.Click += new System.EventHandler(this.btnTextColor_Click);
            // 
            // gbTranslate
            // 
            this.gbTranslate.Controls.Add(this.btnTranslateFont);
            this.gbTranslate.Controls.Add(this.btnTranslateColor);
            this.gbTranslate.Location = new System.Drawing.Point(67, 171);
            this.gbTranslate.Name = "gbTranslate";
            this.gbTranslate.Size = new System.Drawing.Size(146, 48);
            this.gbTranslate.TabIndex = 44;
            this.gbTranslate.TabStop = false;
            this.gbTranslate.Text = "ترجمه";
            // 
            // btnTranslateFont
            // 
            this.btnTranslateFont.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnTranslateFont.Location = new System.Drawing.Point(75, 16);
            this.btnTranslateFont.Name = "btnTranslateFont";
            this.btnTranslateFont.Size = new System.Drawing.Size(66, 25);
            this.btnTranslateFont.TabIndex = 32;
            this.btnTranslateFont.TabStop = false;
            this.btnTranslateFont.Text = "فونت...";
            this.btnTranslateFont.UseVisualStyleBackColor = true;
            this.btnTranslateFont.Click += new System.EventHandler(this.btnTranslateFont_Click);
            // 
            // btnTranslateColor
            // 
            this.btnTranslateColor.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnTranslateColor.Location = new System.Drawing.Point(4, 16);
            this.btnTranslateColor.Name = "btnTranslateColor";
            this.btnTranslateColor.Size = new System.Drawing.Size(66, 25);
            this.btnTranslateColor.TabIndex = 42;
            this.btnTranslateColor.TabStop = false;
            this.btnTranslateColor.Text = "رنگ متن...";
            this.btnTranslateColor.UseVisualStyleBackColor = true;
            this.btnTranslateColor.Click += new System.EventHandler(this.btnTranslateColor_Click);
            // 
            // gbBackColor
            // 
            this.gbBackColor.Controls.Add(this.btnBackColor);
            this.gbBackColor.Controls.Add(this.chbIsTransparent);
            this.gbBackColor.Location = new System.Drawing.Point(223, 245);
            this.gbBackColor.Name = "gbBackColor";
            this.gbBackColor.Size = new System.Drawing.Size(152, 48);
            this.gbBackColor.TabIndex = 45;
            this.gbBackColor.TabStop = false;
            this.gbBackColor.Text = "رنگ زمینه متن";
            // 
            // btnBackColor
            // 
            this.btnBackColor.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnBackColor.Location = new System.Drawing.Point(82, 16);
            this.btnBackColor.Name = "btnBackColor";
            this.btnBackColor.Size = new System.Drawing.Size(67, 25);
            this.btnBackColor.TabIndex = 40;
            this.btnBackColor.TabStop = false;
            this.btnBackColor.Text = "انتخاب ...";
            this.btnBackColor.UseVisualStyleBackColor = true;
            this.btnBackColor.Click += new System.EventHandler(this.btnBackColor_Click);
            // 
            // chbIsTransparent
            // 
            this.chbIsTransparent.AutoSize = true;
            this.chbIsTransparent.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chbIsTransparent.Location = new System.Drawing.Point(6, 20);
            this.chbIsTransparent.Name = "chbIsTransparent";
            this.chbIsTransparent.Size = new System.Drawing.Size(83, 18);
            this.chbIsTransparent.TabIndex = 43;
            this.chbIsTransparent.TabStop = false;
            this.chbIsTransparent.Text = "شفاف (P) ";
            this.chbIsTransparent.UseVisualStyleBackColor = true;
            this.chbIsTransparent.CheckedChanged += new System.EventHandler(this.chbIsTransparent_CheckedChanged);
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
            // frmOption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(390, 341);
            this.Controls.Add(this.gbBackColor);
            this.Controls.Add(this.gbTranslate);
            this.Controls.Add(this.gbText);
            this.Controls.Add(this.chSingleDisplay);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.gbDisplay);
            this.Controls.Add(this.btnClose);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "frmOption";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "  تنظیمات";
            this.Load += new System.EventHandler(this.frmOption_Load);
            this.gbDisplay.ResumeLayout(false);
            this.gbDisplay.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.gbText.ResumeLayout(false);
            this.gbTranslate.ResumeLayout(false);
            this.gbBackColor.ResumeLayout(false);
            this.gbBackColor.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ComboBox cmxControlDisplay;
        private System.Windows.Forms.ComboBox cmxShowDisplay;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmDevices;
        private System.Windows.Forms.GroupBox gbDisplay;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chSingleDisplay;
        public System.Windows.Forms.GroupBox gbText;
        private System.Windows.Forms.Button btnTextFont;
        private System.Windows.Forms.Button btnTextColor;
        public System.Windows.Forms.GroupBox gbTranslate;
        private System.Windows.Forms.Button btnTranslateFont;
        private System.Windows.Forms.Button btnTranslateColor;
        public System.Windows.Forms.GroupBox gbBackColor;
        private System.Windows.Forms.Button btnBackColor;
        public System.Windows.Forms.CheckBox chbIsTransparent;
        public System.Windows.Forms.FontDialog fontDialogText;
        public System.Windows.Forms.ColorDialog colorDialogBack;
        public System.Windows.Forms.ColorDialog colorDialogTranslate;
        public System.Windows.Forms.ColorDialog colorDialogText;
        public System.Windows.Forms.FontDialog fontDialogTranslate;
    }
}