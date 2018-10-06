namespace PrayerControl
{
    partial class frmControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmControl));
            this.rbBlank = new System.Windows.Forms.RadioButton();
            this.rbCamera_Media = new System.Windows.Forms.RadioButton();
            this.rbCamera_Image = new System.Windows.Forms.RadioButton();
            this.rbCamera = new System.Windows.Forms.RadioButton();
            this.rbMedia = new System.Windows.Forms.RadioButton();
            this.rbImage = new System.Windows.Forms.RadioButton();
            this.rbText_Translate = new System.Windows.Forms.RadioButton();
            this.rbText = new System.Windows.Forms.RadioButton();
            this.rbTextType = new System.Windows.Forms.RadioButton();
            this.rbNone = new System.Windows.Forms.RadioButton();
            this.gbShow = new System.Windows.Forms.GroupBox();
            this.gbViewType = new System.Windows.Forms.GroupBox();
            this.gbSpeed = new System.Windows.Forms.GroupBox();
            this.btnStopPrayer = new System.Windows.Forms.Button();
            this.btnReduseSpeed = new System.Windows.Forms.Button();
            this.btnIncreseSpeed = new System.Windows.Forms.Button();
            this.gbMedia = new System.Windows.Forms.GroupBox();
            this.lbMediaDuration = new System.Windows.Forms.Label();
            this.lbMediaPosition = new System.Windows.Forms.Label();
            this.tbMedia = new System.Windows.Forms.TrackBar();
            this.btnBackwardMedia = new System.Windows.Forms.Button();
            this.btnStopMedeia = new System.Windows.Forms.Button();
            this.btnForwardMedia = new System.Windows.Forms.Button();
            this.btnEnter = new System.Windows.Forms.Button();
            this.btnOption = new System.Windows.Forms.Button();
            this.btn = new System.Windows.Forms.Button();
            this.gbLocation = new System.Windows.Forms.GroupBox();
            this.rbTopDown = new System.Windows.Forms.RadioButton();
            this.rbDown = new System.Windows.Forms.RadioButton();
            this.rbTop = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmxVerse = new System.Windows.Forms.ComboBox();
            this.cmxDataBase = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbTextType = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbTextTypeTranslate = new System.Windows.Forms.RichTextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.prayerListControl = new PrayerControl.LIB.PrayerListControl();
            this.browser = new PrayerControl.LIB.Browser();
            this.gbShow.SuspendLayout();
            this.gbViewType.SuspendLayout();
            this.gbSpeed.SuspendLayout();
            this.gbMedia.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbMedia)).BeginInit();
            this.gbLocation.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbBlank
            // 
            this.rbBlank.AutoSize = true;
            this.rbBlank.Location = new System.Drawing.Point(492, 14);
            this.rbBlank.Name = "rbBlank";
            this.rbBlank.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rbBlank.Size = new System.Drawing.Size(89, 17);
            this.rbBlank.TabIndex = 5;
            this.rbBlank.Text = "(F6) هیچکدام";
            this.rbBlank.UseVisualStyleBackColor = true;
            this.rbBlank.CheckedChanged += new System.EventHandler(this.rbType_CheckedChanged);
            // 
            // rbCamera_Media
            // 
            this.rbCamera_Media.AutoSize = true;
            this.rbCamera_Media.Location = new System.Drawing.Point(372, 14);
            this.rbCamera_Media.Name = "rbCamera_Media";
            this.rbCamera_Media.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rbCamera_Media.Size = new System.Drawing.Size(114, 17);
            this.rbCamera_Media.TabIndex = 4;
            this.rbCamera_Media.Text = "(F5) کلیپ + دوربین";
            this.rbCamera_Media.UseVisualStyleBackColor = true;
            this.rbCamera_Media.CheckedChanged += new System.EventHandler(this.rbType_CheckedChanged);
            // 
            // rbCamera_Image
            // 
            this.rbCamera_Image.AutoSize = true;
            this.rbCamera_Image.Location = new System.Drawing.Point(248, 14);
            this.rbCamera_Image.Name = "rbCamera_Image";
            this.rbCamera_Image.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rbCamera_Image.Size = new System.Drawing.Size(118, 17);
            this.rbCamera_Image.TabIndex = 3;
            this.rbCamera_Image.Text = "(F4) عکس + دوربین";
            this.rbCamera_Image.UseVisualStyleBackColor = true;
            this.rbCamera_Image.CheckedChanged += new System.EventHandler(this.rbType_CheckedChanged);
            // 
            // rbCamera
            // 
            this.rbCamera.AutoSize = true;
            this.rbCamera.Location = new System.Drawing.Point(165, 14);
            this.rbCamera.Name = "rbCamera";
            this.rbCamera.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rbCamera.Size = new System.Drawing.Size(77, 17);
            this.rbCamera.TabIndex = 2;
            this.rbCamera.Text = "(F3) دوربین";
            this.rbCamera.UseVisualStyleBackColor = true;
            this.rbCamera.CheckedChanged += new System.EventHandler(this.rbType_CheckedChanged);
            // 
            // rbMedia
            // 
            this.rbMedia.AutoSize = true;
            this.rbMedia.Location = new System.Drawing.Point(88, 14);
            this.rbMedia.Name = "rbMedia";
            this.rbMedia.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rbMedia.Size = new System.Drawing.Size(71, 17);
            this.rbMedia.TabIndex = 1;
            this.rbMedia.Text = "(F2) کلیپ";
            this.rbMedia.UseVisualStyleBackColor = true;
            this.rbMedia.CheckedChanged += new System.EventHandler(this.rbType_CheckedChanged);
            // 
            // rbImage
            // 
            this.rbImage.AutoSize = true;
            this.rbImage.Checked = true;
            this.rbImage.Location = new System.Drawing.Point(7, 14);
            this.rbImage.Name = "rbImage";
            this.rbImage.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rbImage.Size = new System.Drawing.Size(75, 17);
            this.rbImage.TabIndex = 0;
            this.rbImage.TabStop = true;
            this.rbImage.Text = "(F1) عکس";
            this.rbImage.UseVisualStyleBackColor = true;
            this.rbImage.CheckedChanged += new System.EventHandler(this.rbType_CheckedChanged);
            // 
            // rbText_Translate
            // 
            this.rbText_Translate.AutoSize = true;
            this.rbText_Translate.Enabled = false;
            this.rbText_Translate.Location = new System.Drawing.Point(98, 15);
            this.rbText_Translate.Name = "rbText_Translate";
            this.rbText_Translate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rbText_Translate.Size = new System.Drawing.Size(103, 17);
            this.rbText_Translate.TabIndex = 8;
            this.rbText_Translate.Text = "(W) متن و ترجمه";
            this.rbText_Translate.UseVisualStyleBackColor = true;
            this.rbText_Translate.CheckedChanged += new System.EventHandler(this.rbText_CheckedChanged);
            // 
            // rbText
            // 
            this.rbText.AutoSize = true;
            this.rbText.Enabled = false;
            this.rbText.Location = new System.Drawing.Point(206, 16);
            this.rbText.Name = "rbText";
            this.rbText.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rbText.Size = new System.Drawing.Size(82, 17);
            this.rbText.TabIndex = 10;
            this.rbText.Text = "(E) فقط متن";
            this.rbText.UseVisualStyleBackColor = true;
            this.rbText.CheckedChanged += new System.EventHandler(this.rbText_CheckedChanged);
            // 
            // rbTextType
            // 
            this.rbTextType.AutoSize = true;
            this.rbTextType.Location = new System.Drawing.Point(292, 16);
            this.rbTextType.Name = "rbTextType";
            this.rbTextType.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rbTextType.Size = new System.Drawing.Size(101, 17);
            this.rbTextType.TabIndex = 12;
            this.rbTextType.Text = "(R) تایپ همزمان";
            this.rbTextType.UseVisualStyleBackColor = true;
            this.rbTextType.CheckedChanged += new System.EventHandler(this.rbText_CheckedChanged);
            // 
            // rbNone
            // 
            this.rbNone.AutoSize = true;
            this.rbNone.Checked = true;
            this.rbNone.Location = new System.Drawing.Point(7, 16);
            this.rbNone.Name = "rbNone";
            this.rbNone.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rbNone.Size = new System.Drawing.Size(85, 17);
            this.rbNone.TabIndex = 16;
            this.rbNone.TabStop = true;
            this.rbNone.Text = "(Q) هیچکدام";
            this.rbNone.UseVisualStyleBackColor = true;
            this.rbNone.CheckedChanged += new System.EventHandler(this.rbText_CheckedChanged);
            // 
            // gbShow
            // 
            this.gbShow.Controls.Add(this.rbNone);
            this.gbShow.Controls.Add(this.rbTextType);
            this.gbShow.Controls.Add(this.rbText);
            this.gbShow.Controls.Add(this.rbText_Translate);
            this.gbShow.Location = new System.Drawing.Point(5, 44);
            this.gbShow.Name = "gbShow";
            this.gbShow.Size = new System.Drawing.Size(397, 41);
            this.gbShow.TabIndex = 9;
            this.gbShow.TabStop = false;
            this.gbShow.Text = "نمایش";
            // 
            // gbViewType
            // 
            this.gbViewType.Controls.Add(this.rbBlank);
            this.gbViewType.Controls.Add(this.rbImage);
            this.gbViewType.Controls.Add(this.rbCamera_Media);
            this.gbViewType.Controls.Add(this.rbCamera_Image);
            this.gbViewType.Controls.Add(this.rbMedia);
            this.gbViewType.Controls.Add(this.rbCamera);
            this.gbViewType.Location = new System.Drawing.Point(98, 148);
            this.gbViewType.Name = "gbViewType";
            this.gbViewType.Size = new System.Drawing.Size(582, 39);
            this.gbViewType.TabIndex = 10;
            this.gbViewType.TabStop = false;
            this.gbViewType.Text = "انتخاب";
            // 
            // gbSpeed
            // 
            this.gbSpeed.Controls.Add(this.btnStopPrayer);
            this.gbSpeed.Controls.Add(this.btnReduseSpeed);
            this.gbSpeed.Controls.Add(this.btnIncreseSpeed);
            this.gbSpeed.Location = new System.Drawing.Point(6, 81);
            this.gbSpeed.Name = "gbSpeed";
            this.gbSpeed.Size = new System.Drawing.Size(182, 72);
            this.gbSpeed.TabIndex = 18;
            this.gbSpeed.TabStop = false;
            this.gbSpeed.Text = "سرعت حرکت متن";
            // 
            // btnStopPrayer
            // 
            this.btnStopPrayer.Location = new System.Drawing.Point(5, 44);
            this.btnStopPrayer.Name = "btnStopPrayer";
            this.btnStopPrayer.Size = new System.Drawing.Size(171, 24);
            this.btnStopPrayer.TabIndex = 2;
            this.btnStopPrayer.TabStop = false;
            this.btnStopPrayer.Text = "حرکت (space)";
            this.btnStopPrayer.UseVisualStyleBackColor = true;
            this.btnStopPrayer.Click += new System.EventHandler(this.btnStopPrayer_Click);
            // 
            // btnReduseSpeed
            // 
            this.btnReduseSpeed.Location = new System.Drawing.Point(6, 18);
            this.btnReduseSpeed.Name = "btnReduseSpeed";
            this.btnReduseSpeed.Size = new System.Drawing.Size(81, 24);
            this.btnReduseSpeed.TabIndex = 1;
            this.btnReduseSpeed.TabStop = false;
            this.btnReduseSpeed.Text = "کاهش (-)";
            this.btnReduseSpeed.UseVisualStyleBackColor = true;
            this.btnReduseSpeed.Click += new System.EventHandler(this.btnReduseSpeed_Click);
            // 
            // btnIncreseSpeed
            // 
            this.btnIncreseSpeed.Location = new System.Drawing.Point(95, 18);
            this.btnIncreseSpeed.Name = "btnIncreseSpeed";
            this.btnIncreseSpeed.Size = new System.Drawing.Size(81, 24);
            this.btnIncreseSpeed.TabIndex = 0;
            this.btnIncreseSpeed.TabStop = false;
            this.btnIncreseSpeed.Text = "افزایش  (+)";
            this.btnIncreseSpeed.UseVisualStyleBackColor = true;
            this.btnIncreseSpeed.Click += new System.EventHandler(this.btnIncreseSpeed_Click);
            // 
            // gbMedia
            // 
            this.gbMedia.Controls.Add(this.lbMediaDuration);
            this.gbMedia.Controls.Add(this.lbMediaPosition);
            this.gbMedia.Controls.Add(this.tbMedia);
            this.gbMedia.Controls.Add(this.btnBackwardMedia);
            this.gbMedia.Controls.Add(this.btnStopMedeia);
            this.gbMedia.Controls.Add(this.btnForwardMedia);
            this.gbMedia.Enabled = false;
            this.gbMedia.Location = new System.Drawing.Point(6, 185);
            this.gbMedia.Name = "gbMedia";
            this.gbMedia.Size = new System.Drawing.Size(674, 43);
            this.gbMedia.TabIndex = 19;
            this.gbMedia.TabStop = false;
            this.gbMedia.Text = "کنترل کلیپ";
            this.gbMedia.Enter += new System.EventHandler(this.gbMedia_Enter);
            // 
            // lbMediaDuration
            // 
            this.lbMediaDuration.AutoSize = true;
            this.lbMediaDuration.Location = new System.Drawing.Point(365, 19);
            this.lbMediaDuration.Name = "lbMediaDuration";
            this.lbMediaDuration.Size = new System.Drawing.Size(35, 13);
            this.lbMediaDuration.TabIndex = 5;
            this.lbMediaDuration.Text = "00:00";
            // 
            // lbMediaPosition
            // 
            this.lbMediaPosition.AutoSize = true;
            this.lbMediaPosition.Location = new System.Drawing.Point(5, 20);
            this.lbMediaPosition.Name = "lbMediaPosition";
            this.lbMediaPosition.Size = new System.Drawing.Size(35, 13);
            this.lbMediaPosition.TabIndex = 4;
            this.lbMediaPosition.Text = "00:00";
            // 
            // tbMedia
            // 
            this.tbMedia.AutoSize = false;
            this.tbMedia.Location = new System.Drawing.Point(33, 18);
            this.tbMedia.Name = "tbMedia";
            this.tbMedia.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tbMedia.Size = new System.Drawing.Size(337, 20);
            this.tbMedia.SmallChange = 5;
            this.tbMedia.TabIndex = 3;
            this.tbMedia.TabStop = false;
            this.tbMedia.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbMedia.Scroll += new System.EventHandler(this.tbMedia_Scroll);
            // 
            // btnBackwardMedia
            // 
            this.btnBackwardMedia.Location = new System.Drawing.Point(401, 14);
            this.btnBackwardMedia.Name = "btnBackwardMedia";
            this.btnBackwardMedia.Size = new System.Drawing.Size(83, 24);
            this.btnBackwardMedia.TabIndex = 2;
            this.btnBackwardMedia.TabStop = false;
            this.btnBackwardMedia.Text = "عقب (A)";
            this.btnBackwardMedia.UseVisualStyleBackColor = true;
            this.btnBackwardMedia.Click += new System.EventHandler(this.btnBackwardMedia_Click);
            // 
            // btnStopMedeia
            // 
            this.btnStopMedeia.Location = new System.Drawing.Point(494, 14);
            this.btnStopMedeia.Name = "btnStopMedeia";
            this.btnStopMedeia.Size = new System.Drawing.Size(83, 24);
            this.btnStopMedeia.TabIndex = 1;
            this.btnStopMedeia.TabStop = false;
            this.btnStopMedeia.Text = "توقف (S)";
            this.btnStopMedeia.UseVisualStyleBackColor = true;
            this.btnStopMedeia.Click += new System.EventHandler(this.btnStopMedeia_Click);
            // 
            // btnForwardMedia
            // 
            this.btnForwardMedia.Location = new System.Drawing.Point(587, 14);
            this.btnForwardMedia.Name = "btnForwardMedia";
            this.btnForwardMedia.Size = new System.Drawing.Size(83, 24);
            this.btnForwardMedia.TabIndex = 0;
            this.btnForwardMedia.TabStop = false;
            this.btnForwardMedia.Text = "جلو (D)";
            this.btnForwardMedia.UseVisualStyleBackColor = true;
            this.btnForwardMedia.Click += new System.EventHandler(this.btnForwardMedia_Click);
            // 
            // btnEnter
            // 
            this.btnEnter.Enabled = false;
            this.btnEnter.Location = new System.Drawing.Point(6, 155);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(88, 32);
            this.btnEnter.TabIndex = 21;
            this.btnEnter.TabStop = false;
            this.btnEnter.Text = "نمایش (Enter)";
            this.btnEnter.UseVisualStyleBackColor = true;
            this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
            // 
            // btnOption
            // 
            this.btnOption.Location = new System.Drawing.Point(6, 4);
            this.btnOption.Name = "btnOption";
            this.btnOption.Size = new System.Drawing.Size(71, 41);
            this.btnOption.TabIndex = 22;
            this.btnOption.TabStop = false;
            this.btnOption.Text = "تنظیمات... (ctrl+O)";
            this.btnOption.UseVisualStyleBackColor = true;
            this.btnOption.Click += new System.EventHandler(this.btnOption_Click);
            // 
            // btn
            // 
            this.btn.Location = new System.Drawing.Point(-69, 338);
            this.btn.Name = "btn";
            this.btn.Size = new System.Drawing.Size(42, 23);
            this.btn.TabIndex = 23;
            this.btn.Text = "button1";
            this.btn.UseVisualStyleBackColor = true;
            // 
            // gbLocation
            // 
            this.gbLocation.Controls.Add(this.rbTopDown);
            this.gbLocation.Controls.Add(this.rbDown);
            this.gbLocation.Controls.Add(this.rbTop);
            this.gbLocation.Location = new System.Drawing.Point(405, 44);
            this.gbLocation.Name = "gbLocation";
            this.gbLocation.Size = new System.Drawing.Size(275, 41);
            this.gbLocation.TabIndex = 36;
            this.gbLocation.TabStop = false;
            this.gbLocation.Text = "موقعیت نمایش متن";
            // 
            // rbTopDown
            // 
            this.rbTopDown.AutoSize = true;
            this.rbTopDown.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rbTopDown.Location = new System.Drawing.Point(5, 15);
            this.rbTopDown.Name = "rbTopDown";
            this.rbTopDown.Size = new System.Drawing.Size(138, 17);
            this.rbTopDown.TabIndex = 2;
            this.rbTopDown.Text = "متن بالا - ترجمه پایین (Y)";
            this.rbTopDown.UseVisualStyleBackColor = true;
            this.rbTopDown.CheckedChanged += new System.EventHandler(this.rbLocation_CheckedChanged);
            // 
            // rbDown
            // 
            this.rbDown.AutoSize = true;
            this.rbDown.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rbDown.Checked = true;
            this.rbDown.Location = new System.Drawing.Point(147, 15);
            this.rbDown.Name = "rbDown";
            this.rbDown.Size = new System.Drawing.Size(64, 17);
            this.rbDown.TabIndex = 1;
            this.rbDown.TabStop = true;
            this.rbDown.Text = "پایین (U)";
            this.rbDown.UseVisualStyleBackColor = true;
            this.rbDown.CheckedChanged += new System.EventHandler(this.rbLocation_CheckedChanged);
            // 
            // rbTop
            // 
            this.rbTop.AutoSize = true;
            this.rbTop.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rbTop.Location = new System.Drawing.Point(216, 15);
            this.rbTop.Name = "rbTop";
            this.rbTop.Size = new System.Drawing.Size(53, 17);
            this.rbTop.TabIndex = 0;
            this.rbTop.Text = "بالا (I)";
            this.rbTop.UseVisualStyleBackColor = true;
            this.rbTop.CheckedChanged += new System.EventHandler(this.rbLocation_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.cmxVerse);
            this.groupBox2.Controls.Add(this.cmxDataBase);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(405, -2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(275, 48);
            this.groupBox2.TabIndex = 45;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "محتوا";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(84, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 38;
            this.label6.Text = "آیه/فراز:";
            // 
            // cmxVerse
            // 
            this.cmxVerse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmxVerse.FormattingEnabled = true;
            this.cmxVerse.Location = new System.Drawing.Point(6, 17);
            this.cmxVerse.Name = "cmxVerse";
            this.cmxVerse.Size = new System.Drawing.Size(79, 21);
            this.cmxVerse.TabIndex = 37;
            this.cmxVerse.TabStop = false;
            this.cmxVerse.SelectedIndexChanged += new System.EventHandler(this.cmxVerse_SelectedIndexChanged);
            // 
            // cmxDataBase
            // 
            this.cmxDataBase.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmxDataBase.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmxDataBase.FormattingEnabled = true;
            this.cmxDataBase.Location = new System.Drawing.Point(137, 17);
            this.cmxDataBase.Name = "cmxDataBase";
            this.cmxDataBase.Size = new System.Drawing.Size(101, 21);
            this.cmxDataBase.TabIndex = 29;
            this.cmxDataBase.TabStop = false;
            this.cmxDataBase.SelectedIndexChanged += new System.EventHandler(this.ComboBoxDataBase_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(238, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 36;
            this.label3.Text = "متن:";
            // 
            // tbTextType
            // 
            this.tbTextType.Location = new System.Drawing.Point(193, 87);
            this.tbTextType.Name = "tbTextType";
            this.tbTextType.Size = new System.Drawing.Size(487, 26);
            this.tbTextType.TabIndex = 49;
            this.tbTextType.Text = "";
            this.tbTextType.TextChanged += new System.EventHandler(this.tbTextType_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(18, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(393, 14);
            this.label2.TabIndex = 52;
            this.label2.Text = "هزینه استفاده از این نرم افزار  :  ذکر 14 صلوات برای سلامتی امام زمان (عج)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label4.ForeColor = System.Drawing.Color.Indigo;
            this.label4.Location = new System.Drawing.Point(349, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 53;
            this.label4.Text = "تهیه کنندگان:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(421, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(248, 58);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 50;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(7, 227);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(674, 68);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label5.ForeColor = System.Drawing.Color.Indigo;
            this.label5.Location = new System.Drawing.Point(20, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(204, 13);
            this.label5.TabIndex = 55;
            this.label5.Text = "محمد صمدیه (Moh.samadieh@gmail.com)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label1.ForeColor = System.Drawing.Color.Indigo;
            this.label1.Location = new System.Drawing.Point(220, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 13);
            this.label1.TabIndex = 54;
            this.label1.Text = "حمیدرضا رضایی (Hrremail@gmail.com) -";
            // 
            // tbTextTypeTranslate
            // 
            this.tbTextTypeTranslate.Location = new System.Drawing.Point(192, 116);
            this.tbTextTypeTranslate.Name = "tbTextTypeTranslate";
            this.tbTextTypeTranslate.Size = new System.Drawing.Size(487, 26);
            this.tbTextTypeTranslate.TabIndex = 50;
            this.tbTextTypeTranslate.Text = "";
            this.tbTextTypeTranslate.TextChanged += new System.EventHandler(this.tbTextType_TextChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.Enabled = false;
            this.btnSearch.Location = new System.Drawing.Point(293, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(109, 41);
            this.btnSearch.TabIndex = 51;
            this.btnSearch.TabStop = false;
            this.btnSearch.Text = "در حال آماده‌سازی جستجو...";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // prayerListControl
            // 
            this.prayerListControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.prayerListControl.Font = new System.Drawing.Font("B Nazanin", 12F);
            this.prayerListControl.HorizontalScrollbar = true;
            this.prayerListControl.Index = -1;
            this.prayerListControl.ItemHeight = 24;
            this.prayerListControl.Location = new System.Drawing.Point(686, 5);
            this.prayerListControl.Name = "prayerListControl";
            this.prayerListControl.ScrollAlwaysVisible = true;
            this.prayerListControl.Size = new System.Drawing.Size(331, 292);
            this.prayerListControl.TabIndex = 6;
            this.prayerListControl.TabStop = false;
            this.prayerListControl.SelectedIndexChanged += new System.EventHandler(this.prayerListControl_SelectedIndexChanged);
            // 
            // browser
            // 
            this.browser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.browser.BrowserType = PrayerControl.LIB.Browser.BrowserTypes.Image;
            this.browser.FolderIndex = -1;
            this.browser.Location = new System.Drawing.Point(6, 291);
            this.browser.Name = "browser";
            this.browser.Size = new System.Drawing.Size(1012, 309);
            this.browser.TabIndex = 3;
            this.browser.TabStop = false;
            this.browser.Load += new System.EventHandler(this.browser_Load);
            // 
            // frmControl
            // 
            this.AcceptButton = this.btnEnter;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1020, 608);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.tbTextTypeTranslate);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbSpeed);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnOption);
            this.Controls.Add(this.gbLocation);
            this.Controls.Add(this.btn);
            this.Controls.Add(this.btnEnter);
            this.Controls.Add(this.gbMedia);
            this.Controls.Add(this.gbViewType);
            this.Controls.Add(this.gbShow);
            this.Controls.Add(this.prayerListControl);
            this.Controls.Add(this.browser);
            this.Controls.Add(this.tbTextType);
            this.Font = new System.Drawing.Font("Tahoma", 8F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmControl";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "نغمات آسمانی";
            this.Activated += new System.EventHandler(this.frmControl_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmControl_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmControl_FormClosed);
            this.Load += new System.EventHandler(this.frmControl_Load);
            this.Shown += new System.EventHandler(this.frmControl_Shown);
            this.LocationChanged += new System.EventHandler(this.frmControl_LocationChanged);
            this.SizeChanged += new System.EventHandler(this.frmControl_SizeChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmControl_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmControl_KeyUp);
            this.gbShow.ResumeLayout(false);
            this.gbShow.PerformLayout();
            this.gbViewType.ResumeLayout(false);
            this.gbViewType.PerformLayout();
            this.gbSpeed.ResumeLayout(false);
            this.gbMedia.ResumeLayout(false);
            this.gbMedia.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbMedia)).EndInit();
            this.gbLocation.ResumeLayout(false);
            this.gbLocation.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public LIB.Browser browser;
        public System.Windows.Forms.RadioButton rbBlank;
        public System.Windows.Forms.RadioButton rbCamera_Media;
        public System.Windows.Forms.RadioButton rbCamera_Image;
        public System.Windows.Forms.RadioButton rbCamera;
        public System.Windows.Forms.RadioButton rbMedia;
        public System.Windows.Forms.RadioButton rbImage;
        public LIB.PrayerListControl prayerListControl;
        public System.Windows.Forms.RadioButton rbText_Translate;
        public System.Windows.Forms.RadioButton rbTextType;
        public System.Windows.Forms.RadioButton rbNone;
        public System.Windows.Forms.GroupBox gbViewType;
        public System.Windows.Forms.Button btnStopPrayer;
        public System.Windows.Forms.Button btnReduseSpeed;
        public System.Windows.Forms.Button btnIncreseSpeed;
        public System.Windows.Forms.GroupBox gbMedia;
        public System.Windows.Forms.Button btnBackwardMedia;
        public System.Windows.Forms.Button btnStopMedeia;
        public System.Windows.Forms.Button btnForwardMedia;
        public System.Windows.Forms.Button btnEnter;
        public System.Windows.Forms.GroupBox gbShow;
        public System.Windows.Forms.GroupBox gbSpeed;
        public System.Windows.Forms.Button btnOption;
        public System.Windows.Forms.RadioButton rbText;
        public System.Windows.Forms.Button btn;
        public System.Windows.Forms.RadioButton rbTopDown;
        public System.Windows.Forms.RadioButton rbDown;
        public System.Windows.Forms.RadioButton rbTop;
        public System.Windows.Forms.GroupBox gbLocation;
        public System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.ComboBox cmxDataBase;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.TrackBar tbMedia;
        public System.Windows.Forms.Label lbMediaPosition;
        public System.Windows.Forms.Label lbMediaDuration;
        public System.Windows.Forms.RichTextBox tbTextType;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.RichTextBox tbTextTypeTranslate;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.ComboBox cmxVerse;
        public System.Windows.Forms.Button btnSearch;
    }
}