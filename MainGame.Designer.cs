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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainGame));
            Limit = new System.Windows.Forms.Timer(components);
            PlasticBox = new Button();
            paperBox = new Button();
            VinylBox = new Button();
            CanBox = new Button();
            timer = new Label();
            progressBar1 = new ProgressBar();
            countDownText = new Label();
            CountDownTimer = new System.Windows.Forms.Timer(components);
            scoreLabel = new Label();
            timePanel = new Panel();
            timePanel.SuspendLayout();
            SuspendLayout();
            // 
            // Limit
            // 
            Limit.Tick += timer1_Tick;
            // 
            // PlasticBox
            // 
            PlasticBox.Image = (Image)resources.GetObject("PlasticBox.Image");
            PlasticBox.Location = new Point(41, 96);
            PlasticBox.Name = "PlasticBox";
            PlasticBox.Size = new Size(182, 295);
            PlasticBox.TabIndex = 1;
            PlasticBox.UseVisualStyleBackColor = true;
            PlasticBox.Click += EcoBox_1_Click;
            // 
            // paperBox
            // 
            paperBox.Image = (Image)resources.GetObject("paperBox.Image");
            paperBox.Location = new Point(236, 96);
            paperBox.Name = "paperBox";
            paperBox.Size = new Size(169, 295);
            paperBox.TabIndex = 2;
            paperBox.UseVisualStyleBackColor = true;
            paperBox.Click += paperBox_Click;
            // 
            // VinylBox
            // 
            VinylBox.Image = (Image)resources.GetObject("VinylBox.Image");
            VinylBox.Location = new Point(431, 96);
            VinylBox.Name = "VinylBox";
            VinylBox.Size = new Size(178, 295);
            VinylBox.TabIndex = 3;
            VinylBox.UseVisualStyleBackColor = true;
            VinylBox.Click += VinylBox_Click;
            // 
            // CanBox
            // 
            CanBox.Image = (Image)resources.GetObject("CanBox.Image");
            CanBox.Location = new Point(627, 96);
            CanBox.Name = "CanBox";
            CanBox.Size = new Size(175, 295);
            CanBox.TabIndex = 4;
            CanBox.UseVisualStyleBackColor = true;
            CanBox.Click += CanBox_Click;
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
            countDownText.Font = new Font("맑은 고딕", 20F, FontStyle.Bold, GraphicsUnit.Point, 129);
            countDownText.Location = new Point(382, 245);
            countDownText.Name = "countDownText";
            countDownText.Size = new Size(46, 54);
            countDownText.TabIndex = 7;
            countDownText.Text = "3";
            countDownText.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // CountDownTimer
            // 
            CountDownTimer.Tick += CountDownTimer_Tick;
            // 
            // scoreLabel
            // 
            scoreLabel.AutoSize = true;
            scoreLabel.Location = new Point(54, 58);
            scoreLabel.Name = "scoreLabel";
            scoreLabel.Size = new Size(74, 25);
            scoreLabel.TabIndex = 8;
            scoreLabel.Text = "점수 : 0";
            // 
            // timePanel
            // 
            timePanel.Controls.Add(countDownText);
            timePanel.Location = new Point(12, 12);
            timePanel.Name = "timePanel";
            timePanel.Size = new Size(819, 580);
            timePanel.TabIndex = 9;
            // 
            // MainGame
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(843, 604);
            Controls.Add(timePanel);
            Controls.Add(scoreLabel);
            Controls.Add(progressBar1);
            Controls.Add(timer);
            Controls.Add(CanBox);
            Controls.Add(VinylBox);
            Controls.Add(paperBox);
            Controls.Add(PlasticBox);
            Name = "MainGame";
            Text = "MainGame";
            Load += MainGame_Load;
            timePanel.ResumeLayout(false);
            timePanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Timer Limit;
        private Button PlasticBox;
        private Button paperBox;
        private Button VinylBox;
        private Button CanBox;
        private Label timer;
        private ProgressBar progressBar1;
        private Label countDownText;
        private System.Windows.Forms.Timer CountDownTimer;
        private Label scoreLabel;
        private Panel timePanel;
    }
}