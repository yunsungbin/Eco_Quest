namespace Eco_Quest
{
    partial class MainGame
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
            components = new System.ComponentModel.Container();
            title = new Button();
            Limit = new System.Windows.Forms.Timer(components);
            EcoBox_1 = new Button();
            EcoBox_2 = new Button();
            EcoBox_3 = new Button();
            EcoBox_4 = new Button();
            timer = new Label();
            progressBar1 = new ProgressBar();
            countDownText = new Label();
            CountDownTimer = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // title
            // 
            title.Location = new Point(12, 558);
            title.Name = "title";
            title.Size = new Size(112, 34);
            title.TabIndex = 0;
            title.Text = "title";
            title.UseVisualStyleBackColor = true;
            title.Click += button1_Click;
            // 
            // Limit
            // 
            Limit.Tick += timer1_Tick;
            // 
            // EcoBox_1
            // 
            EcoBox_1.Location = new Point(54, 95);
            EcoBox_1.Name = "EcoBox_1";
            EcoBox_1.Size = new Size(150, 240);
            EcoBox_1.TabIndex = 1;
            EcoBox_1.Text = "plastic";
            EcoBox_1.UseVisualStyleBackColor = true;
            EcoBox_1.Click += EcoBox_1_Click;
            // 
            // EcoBox_2
            // 
            EcoBox_2.Location = new Point(249, 95);
            EcoBox_2.Name = "EcoBox_2";
            EcoBox_2.Size = new Size(150, 240);
            EcoBox_2.TabIndex = 2;
            EcoBox_2.Text = "paper";
            EcoBox_2.UseVisualStyleBackColor = true;
            // 
            // EcoBox_3
            // 
            EcoBox_3.Location = new Point(450, 95);
            EcoBox_3.Name = "EcoBox_3";
            EcoBox_3.Size = new Size(150, 240);
            EcoBox_3.TabIndex = 3;
            EcoBox_3.Text = "vinyl";
            EcoBox_3.UseVisualStyleBackColor = true;
            // 
            // EcoBox_4
            // 
            EcoBox_4.Location = new Point(647, 95);
            EcoBox_4.Name = "EcoBox_4";
            EcoBox_4.Size = new Size(150, 240);
            EcoBox_4.TabIndex = 4;
            EcoBox_4.Text = "can";
            EcoBox_4.UseVisualStyleBackColor = true;
            // 
            // timer
            // 
            timer.AutoSize = true;
            timer.Location = new Point(739, 58);
            timer.Name = "timer";
            timer.Size = new Size(58, 25);
            timer.TabIndex = 5;
            timer.Text = "0 : 00";
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(54, 21);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(743, 34);
            progressBar1.TabIndex = 6;
            // 
            // countDownText
            // 
            countDownText.AutoSize = true;
            countDownText.Font = new Font("맑은 고딕", 12F, FontStyle.Bold, GraphicsUnit.Point, 129);
            countDownText.Location = new Point(411, 67);
            countDownText.Name = "countDownText";
            countDownText.Size = new Size(28, 32);
            countDownText.TabIndex = 7;
            countDownText.Text = "3";
            countDownText.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // CountDownTimer
            // 
            CountDownTimer.Tick += CountDownTimer_Tick;
            // 
            // MainGame
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(843, 604);
            Controls.Add(countDownText);
            Controls.Add(progressBar1);
            Controls.Add(timer);
            Controls.Add(EcoBox_4);
            Controls.Add(EcoBox_3);
            Controls.Add(EcoBox_2);
            Controls.Add(EcoBox_1);
            Controls.Add(title);
            Name = "MainGame";
            Text = "MainGame";
            Load += MainGame_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button title;
        private System.Windows.Forms.Timer Limit;
        private Button EcoBox_1;
        private Button EcoBox_2;
        private Button EcoBox_3;
        private Button EcoBox_4;
        private Label timer;
        private ProgressBar progressBar1;
        private Label countDownText;
        private System.Windows.Forms.Timer CountDownTimer;
    }
}