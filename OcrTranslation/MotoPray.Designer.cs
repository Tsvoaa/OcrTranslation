namespace OcrTranslation
{
    partial class MotoPray
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnLocation = new System.Windows.Forms.Button();
            this.btnSetting = new System.Windows.Forms.Button();
            this.tTimer = new System.Windows.Forms.Timer(this.components);
            this.txtTest1 = new System.Windows.Forms.TextBox();
            this.txtTest2 = new System.Windows.Forms.TextBox();
            this.cbScreenSelect = new System.Windows.Forms.ComboBox();
            this.pbOrigin = new System.Windows.Forms.PictureBox();
            this.pbRemaster = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbOrigin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRemaster)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(12, 12);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "시작";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(12, 41);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 1;
            this.btnStop.Text = "중지";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnLocation
            // 
            this.btnLocation.Location = new System.Drawing.Point(12, 70);
            this.btnLocation.Name = "btnLocation";
            this.btnLocation.Size = new System.Drawing.Size(75, 23);
            this.btnLocation.TabIndex = 2;
            this.btnLocation.Text = "영역지정";
            this.btnLocation.UseVisualStyleBackColor = true;
            this.btnLocation.Click += new System.EventHandler(this.btnLocation_Click);
            // 
            // btnSetting
            // 
            this.btnSetting.Location = new System.Drawing.Point(12, 99);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(75, 23);
            this.btnSetting.TabIndex = 3;
            this.btnSetting.Text = "환경설정";
            this.btnSetting.UseVisualStyleBackColor = true;
            // 
            // tTimer
            // 
            this.tTimer.Interval = 1000;
            // 
            // txtTest1
            // 
            this.txtTest1.Location = new System.Drawing.Point(280, 12);
            this.txtTest1.Multiline = true;
            this.txtTest1.Name = "txtTest1";
            this.txtTest1.Size = new System.Drawing.Size(259, 194);
            this.txtTest1.TabIndex = 4;
            // 
            // txtTest2
            // 
            this.txtTest2.Location = new System.Drawing.Point(545, 12);
            this.txtTest2.Multiline = true;
            this.txtTest2.Name = "txtTest2";
            this.txtTest2.Size = new System.Drawing.Size(259, 194);
            this.txtTest2.TabIndex = 5;
            // 
            // cbScreenSelect
            // 
            this.cbScreenSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbScreenSelect.FormattingEnabled = true;
            this.cbScreenSelect.Location = new System.Drawing.Point(93, 70);
            this.cbScreenSelect.Name = "cbScreenSelect";
            this.cbScreenSelect.Size = new System.Drawing.Size(78, 23);
            this.cbScreenSelect.TabIndex = 6;
            // 
            // pbOrigin
            // 
            this.pbOrigin.Location = new System.Drawing.Point(12, 223);
            this.pbOrigin.Name = "pbOrigin";
            this.pbOrigin.Size = new System.Drawing.Size(543, 639);
            this.pbOrigin.TabIndex = 7;
            this.pbOrigin.TabStop = false;
            // 
            // pbRemaster
            // 
            this.pbRemaster.Location = new System.Drawing.Point(561, 223);
            this.pbRemaster.Name = "pbRemaster";
            this.pbRemaster.Size = new System.Drawing.Size(867, 639);
            this.pbRemaster.TabIndex = 8;
            this.pbRemaster.TabStop = false;
            // 
            // MotoPray
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1440, 874);
            this.Controls.Add(this.pbRemaster);
            this.Controls.Add(this.pbOrigin);
            this.Controls.Add(this.cbScreenSelect);
            this.Controls.Add(this.txtTest2);
            this.Controls.Add(this.txtTest1);
            this.Controls.Add(this.btnSetting);
            this.Controls.Add(this.btnLocation);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Name = "MotoPray";
            this.Text = "MotoPray";
            this.Load += new System.EventHandler(this.MotoPray_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbOrigin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRemaster)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnStart;
        private Button btnStop;
        private Button btnLocation;
        private Button btnSetting;
        private System.Windows.Forms.Timer tTimer;
        public TextBox txtTest1;
        public TextBox txtTest2;
        private ComboBox cbScreenSelect;
        public PictureBox pbOrigin;
        public PictureBox pbRemaster;
    }
}