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
            this.imgVideo = new System.Windows.Forms.PictureBox();
            this.imgCapture = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imgVideo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCapture)).BeginInit();
            this.SuspendLayout();
            // 
            // bntStart
            // 
            this.bntStart.Location = new System.Drawing.Point(999, 724);
            this.bntStart.Name = "bntStart";
            this.bntStart.Size = new System.Drawing.Size(41, 23);
            this.bntStart.TabIndex = 2;
            this.bntStart.Text = "Start";
            this.bntStart.UseVisualStyleBackColor = true;
            this.bntStart.Visible = false;
            this.bntStart.Click += new System.EventHandler(this.bntStart_Click);
            // 
            // bntStop
            // 
            this.bntStop.Location = new System.Drawing.Point(1042, 724);
            this.bntStop.Name = "bntStop";
            this.bntStop.Size = new System.Drawing.Size(49, 23);
            this.bntStop.TabIndex = 3;
            this.bntStop.Text = "Stop";
            this.bntStop.UseVisualStyleBackColor = true;
            this.bntStop.Visible = false;
            this.bntStop.Click += new System.EventHandler(this.bntStop_Click);
            // 
            // bntContinue
            // 
            this.bntContinue.Location = new System.Drawing.Point(979, 724);
            this.bntContinue.Name = "bntContinue";
            this.bntContinue.Size = new System.Drawing.Size(61, 23);
            this.bntContinue.TabIndex = 4;
            this.bntContinue.Text = "Continue";
            this.bntContinue.UseVisualStyleBackColor = true;
            this.bntContinue.Visible = false;
            this.bntContinue.Click += new System.EventHandler(this.bntContinue_Click);
            // 
            // bntCapture
            // 
            this.bntCapture.Location = new System.Drawing.Point(979, 724);
            this.bntCapture.Name = "bntCapture";
            this.bntCapture.Size = new System.Drawing.Size(85, 23);
            this.bntCapture.TabIndex = 5;
            this.bntCapture.Text = "Capture Image";
            this.bntCapture.UseVisualStyleBackColor = true;
            this.bntCapture.Visible = false;
            this.bntCapture.Click += new System.EventHandler(this.bntCapture_Click);
            // 
            // bntSave
            // 
            this.bntSave.Location = new System.Drawing.Point(1012, 724);
            this.bntSave.Name = "bntSave";
            this.bntSave.Size = new System.Drawing.Size(79, 23);
            this.bntSave.TabIndex = 6;
            this.bntSave.Text = "Save Image";
            this.bntSave.UseVisualStyleBackColor = true;
            this.bntSave.Visible = false;
            this.bntSave.Click += new System.EventHandler(this.bntSave_Click);
            // 
            // bntVideoFormat
            // 
            this.bntVideoFormat.Location = new System.Drawing.Point(944, 724);
            this.bntVideoFormat.Name = "bntVideoFormat";
            this.bntVideoFormat.Size = new System.Drawing.Size(147, 23);
            this.bntVideoFormat.TabIndex = 7;
            this.bntVideoFormat.Text = "Video Format";
            this.bntVideoFormat.UseVisualStyleBackColor = true;
            this.bntVideoFormat.Visible = false;
            this.bntVideoFormat.Click += new System.EventHandler(this.bntVideoFormat_Click);
            // 
            // bntVideoSource
            // 
            this.bntVideoSource.Location = new System.Drawing.Point(944, 724);
            this.bntVideoSource.Name = "bntVideoSource";
            this.bntVideoSource.Size = new System.Drawing.Size(147, 23);
            this.bntVideoSource.TabIndex = 8;
            this.bntVideoSource.Text = "Video Source";
            this.bntVideoSource.UseVisualStyleBackColor = true;
            this.bntVideoSource.Visible = false;
            this.bntVideoSource.Click += new System.EventHandler(this.bntVideoSource_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(784, 139);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(144, 122);
            this.button1.TabIndex = 9;
            this.button1.Text = "Capture";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(784, 322);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(144, 131);
            this.button2.TabIndex = 10;
            this.button2.Text = "Reset";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(784, 507);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(144, 127);
            this.button3.TabIndex = 11;
            this.button3.Text = "Authenticate";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // imgVideo
            // 
            this.imgVideo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.imgVideo.Location = new System.Drawing.Point(12, 21);
            this.imgVideo.Name = "imgVideo";
            this.imgVideo.Size = new System.Drawing.Size(720, 720);
            this.imgVideo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgVideo.TabIndex = 0;
            this.imgVideo.TabStop = false;
            // 
            // imgCapture
            // 
            this.imgCapture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.imgCapture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imgCapture.Location = new System.Drawing.Point(12, 21);
            this.imgCapture.Name = "imgCapture";
            this.imgCapture.Size = new System.Drawing.Size(720, 720);
            this.imgCapture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgCapture.TabIndex = 1;
            this.imgCapture.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(332, 39);
            this.label1.TabIndex = 12;
            this.label1.Text = "Deloitte Help Desk 1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(16, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(192, 18);
            this.label2.TabIndex = 13;
            this.label2.Text = "Please authenticate yourself";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(16, 723);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(201, 15);
            this.label3.TabIndex = 14;
            this.label3.Text = "(c) Deloitte Cloud Engineering";
            // 
            // mainWinForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(981, 759);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
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
            this.Name = "mainWinForm";
            this.Text = "Facial Authenticator - dAssist";
            this.Load += new System.EventHandler(this.mainWinForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgVideo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCapture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
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
        private System.Windows.Forms.PictureBox imgVideo;
        private System.Windows.Forms.PictureBox imgCapture;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

