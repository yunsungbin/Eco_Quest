namespace Eco_Quest
{
    partial class Form1
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            pictureBoxRecycle1 = new PictureBox();
            pictureBoxRecycle2 = new PictureBox();
            pictureBoxRecycle3 = new PictureBox();
            pictureBoxRecycle4 = new PictureBox();
            progressBar1 = new ProgressBar();
            timer_Time = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)pictureBoxRecycle1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxRecycle2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxRecycle3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxRecycle4).BeginInit();
            SuspendLayout();
            // 
            // pictureBoxRecycle1
            // 
            pictureBoxRecycle1.Image = (Image)resources.GetObject("pictureBoxRecycle1.Image");
            pictureBoxRecycle1.Location = new Point(102, 150);
            pictureBoxRecycle1.Name = "pictureBoxRecycle1";
            pictureBoxRecycle1.Size = new Size(195, 281);
            pictureBoxRecycle1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxRecycle1.TabIndex = 0;
            pictureBoxRecycle1.TabStop = false;
            pictureBoxRecycle1.Click += pictureBoxRecycle1_Click;
            pictureBoxRecycle1.Paint += pictureBoxRecycle1_Paint;
            // 
            // pictureBoxRecycle2
            // 
            pictureBoxRecycle2.Image = (Image)resources.GetObject("pictureBoxRecycle2.Image");
            pictureBoxRecycle2.Location = new Point(351, 150);
            pictureBoxRecycle2.Name = "pictureBoxRecycle2";
            pictureBoxRecycle2.Size = new Size(195, 281);
            pictureBoxRecycle2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxRecycle2.TabIndex = 1;
            pictureBoxRecycle2.TabStop = false;
            pictureBoxRecycle2.Click += pictureBoxRecycle2_Click;
            pictureBoxRecycle2.Paint += pictureBoxRecycle2_Paint;
            // 
            // pictureBoxRecycle3
            // 
            pictureBoxRecycle3.Image = (Image)resources.GetObject("pictureBoxRecycle3.Image");
            pictureBoxRecycle3.Location = new Point(603, 150);
            pictureBoxRecycle3.Name = "pictureBoxRecycle3";
            pictureBoxRecycle3.Size = new Size(195, 281);
            pictureBoxRecycle3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxRecycle3.TabIndex = 2;
            pictureBoxRecycle3.TabStop = false;
            pictureBoxRecycle3.Click += pictureBoxRecycle3_Click;
            pictureBoxRecycle3.Paint += pictureBoxRecycle3_Paint;
            // 
            // pictureBoxRecycle4
            // 
            pictureBoxRecycle4.Image = (Image)resources.GetObject("pictureBoxRecycle4.Image");
            pictureBoxRecycle4.Location = new Point(876, 150);
            pictureBoxRecycle4.Name = "pictureBoxRecycle4";
            pictureBoxRecycle4.Size = new Size(195, 281);
            pictureBoxRecycle4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxRecycle4.TabIndex = 3;
            pictureBoxRecycle4.TabStop = false;
            pictureBoxRecycle4.Click += pictureBoxRecycle4_Click;
            pictureBoxRecycle4.Paint += pictureBoxRecycle4_Paint;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(12, 22);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(1138, 58);
            progressBar1.TabIndex = 4;
            // 
            // timer_Time
            // 
            timer_Time.Interval = 1000;
            timer_Time.Tick += timerEffect_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1162, 664);
            Controls.Add(progressBar1);
            Controls.Add(pictureBoxRecycle4);
            Controls.Add(pictureBoxRecycle3);
            Controls.Add(pictureBoxRecycle2);
            Controls.Add(pictureBoxRecycle1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBoxRecycle1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxRecycle2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxRecycle3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxRecycle4).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBoxRecycle1;
        private PictureBox pictureBoxRecycle2;
        private PictureBox pictureBoxRecycle3;
        private PictureBox pictureBoxRecycle4;
        private ProgressBar progressBar1;
        private System.Windows.Forms.Timer timer_Time;
    }
}
