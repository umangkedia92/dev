namespace WinFormCharpWebCam
{
    //Design by Pongsakorn Poosankam
    partial class mainWinForm
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
            this.imgVideo = new System.Windows.Forms.PictureBox();
            this.imgCapture = new System.Windows.Forms.PictureBox();
            this.bntStart = new System.Windows.Forms.Button();
            this.bntStop = new System.Windows.Forms.Button();
            this.bntContinue = new System.Windows.Forms.Button();
            this.bntCapture = new System.Windows.Forms.Button();
            this.bntSave = new System.Windows.Forms.Button();
            this.bntVideoFormat = new System.Windows.Forms.Button();
            this.bntVideoSource = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.imgVideo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCapture)).BeginInit();
            this.SuspendLayout();
            // 
            // imgVideo
            // 
            this.imgVideo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.imgVideo.Location = new System.Drawing.Point(300, -50);
            this.imgVideo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.imgVideo.Name = "imgVideo";
            this.imgVideo.Size = new System.Drawing.Size(720, 720);
            this.imgVideo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgVideo.TabIndex = 0;
            this.imgVideo.TabStop = false;
            // 
            // imgCapture
            // 
            this.imgCapture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.imgCapture.Location = new System.Drawing.Point(300, -50);
            this.imgCapture.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.imgCapture.Name = "imgCapture";
            this.imgCapture.Size = new System.Drawing.Size(720, 720);
            this.imgCapture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgCapture.TabIndex = 1;
            this.imgCapture.TabStop = false;
            // 
            // bntStart
            // 
            this.bntStart.Location = new System.Drawing.Point(346, 817);
            this.bntStart.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bntStart.Name = "bntStart";
            this.bntStart.Size = new System.Drawing.Size(55, 28);
            this.bntStart.TabIndex = 2;
            this.bntStart.Text = "Start";
            this.bntStart.UseVisualStyleBackColor = true;
            this.bntStart.Visible = false;
            this.bntStart.Click += new System.EventHandler(this.bntStart_Click);
            // 
            // bntStop
            // 
            this.bntStop.Location = new System.Drawing.Point(409, 817);
            this.bntStop.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bntStop.Name = "bntStop";
            this.bntStop.Size = new System.Drawing.Size(65, 28);
            this.bntStop.TabIndex = 3;
            this.bntStop.Text = "Stop";
            this.bntStop.UseVisualStyleBackColor = true;
            this.bntStop.Visible = false;
            this.bntStop.Click += new System.EventHandler(this.bntStop_Click);
            // 
            // bntContinue
            // 
            this.bntContinue.Location = new System.Drawing.Point(482, 817);
            this.bntContinue.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bntContinue.Name = "bntContinue";
            this.bntContinue.Size = new System.Drawing.Size(81, 28);
            this.bntContinue.TabIndex = 4;
            this.bntContinue.Text = "Continue";
            this.bntContinue.UseVisualStyleBackColor = true;
            this.bntContinue.Visible = false;
            this.bntContinue.Click += new System.EventHandler(this.bntContinue_Click);
            // 
            // bntCapture
            // 
            this.bntCapture.Location = new System.Drawing.Point(596, 817);
            this.bntCapture.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bntCapture.Name = "bntCapture";
            this.bntCapture.Size = new System.Drawing.Size(113, 28);
            this.bntCapture.TabIndex = 5;
            this.bntCapture.Text = "Capture Image";
            this.bntCapture.UseVisualStyleBackColor = true;
            this.bntCapture.Visible = false;
            this.bntCapture.Click += new System.EventHandler(this.bntCapture_Click);
            // 
            // bntSave
            // 
            this.bntSave.Location = new System.Drawing.Point(708, 817);
            this.bntSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bntSave.Name = "bntSave";
            this.bntSave.Size = new System.Drawing.Size(105, 28);
            this.bntSave.TabIndex = 6;
            this.bntSave.Text = "Save Image";
            this.bntSave.UseVisualStyleBackColor = true;
            this.bntSave.Visible = false;
            this.bntSave.Click += new System.EventHandler(this.bntSave_Click);
            // 
            // bntVideoFormat
            // 
            this.bntVideoFormat.Location = new System.Drawing.Point(851, 817);
            this.bntVideoFormat.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bntVideoFormat.Name = "bntVideoFormat";
            this.bntVideoFormat.Size = new System.Drawing.Size(196, 28);
            this.bntVideoFormat.TabIndex = 7;
            this.bntVideoFormat.Text = "Video Format";
            this.bntVideoFormat.UseVisualStyleBackColor = true;
            this.bntVideoFormat.Visible = false;
            this.bntVideoFormat.Click += new System.EventHandler(this.bntVideoFormat_Click);
            // 
            // bntVideoSource
            // 
            this.bntVideoSource.Location = new System.Drawing.Point(1101, 817);
            this.bntVideoSource.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bntVideoSource.Name = "bntVideoSource";
            this.bntVideoSource.Size = new System.Drawing.Size(196, 28);
            this.bntVideoSource.TabIndex = 8;
            this.bntVideoSource.Text = "Video Source";
            this.bntVideoSource.UseVisualStyleBackColor = true;
            this.bntVideoSource.Visible = false;
            this.bntVideoSource.Click += new System.EventHandler(this.bntVideoSource_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1338, 210);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Capture";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1338, 286);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(120, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "Reset";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1338, 360);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(120, 23);
            this.button3.TabIndex = 11;
            this.button3.Text = "Authenticate";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // mainWinForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1760, 858);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.bntVideoSource);
            this.Controls.Add(this.bntVideoFormat);
            this.Controls.Add(this.bntSave);
            this.Controls.Add(this.bntCapture);
            this.Controls.Add(this.bntContinue);
            this.Controls.Add(this.bntStop);
            this.Controls.Add(this.bntStart);
            this.Controls.Add(this.imgCapture);
            this.Controls.Add(this.imgVideo);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "mainWinForm";
            this.Text = "WinForm C# WebCam";
            this.Load += new System.EventHandler(this.mainWinForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgVideo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCapture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox imgVideo;
        private System.Windows.Forms.PictureBox imgCapture;
        private System.Windows.Forms.Button bntStart;
        private System.Windows.Forms.Button bntStop;
        private System.Windows.Forms.Button bntContinue;
        private System.Windows.Forms.Button bntCapture;
        private System.Windows.Forms.Button bntSave;
        private System.Windows.Forms.Button bntVideoFormat;
        private System.Windows.Forms.Button bntVideoSource;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}

