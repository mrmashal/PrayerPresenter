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
            this.gbDisplay.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(3, 125);
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
            // frmOption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(390, 156);
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
    }
}