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
            // MotoPray
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSetting);
            this.Controls.Add(this.btnLocation);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Name = "MotoPray";
            this.Text = "MotoPray";
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnStart;
        private Button btnStop;
        private Button btnLocation;
        private Button btnSetting;
        private System.Windows.Forms.Timer tTimer;
    }
}