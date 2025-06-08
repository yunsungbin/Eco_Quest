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
            title = new Button();
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
            SuspendLayout();
            // 
            // title
            // 
            title.Location = new Point(8, 335);
            title.Margin = new Padding(2, 2, 2, 2);
            title.Name = "title";
            title.Size = new Size(78, 20);
            title.TabIndex = 0;
            title.Text = "title";
            title.UseVisualStyleBackColor = true;
            title.Click += button1_Click;
            // 
            // Limit
            // 
            Limit.Tick += timer1_Tick;
            // 
            // PlasticBox
            // 
            PlasticBox.Image = (Image)resources.GetObject("PlasticBox.Image");
            PlasticBox.Location = new Point(29, 58);
            PlasticBox.Margin = new Padding(2, 2, 2, 2);
            PlasticBox.Name = "PlasticBox";
            PlasticBox.Size = new Size(127, 177);
            PlasticBox.TabIndex = 1;
            PlasticBox.Text = "plastic";
            PlasticBox.UseVisualStyleBackColor = true;
            PlasticBox.Click += EcoBox_1_Click;
            // 
            // paperBox
            // 
            paperBox.Image = (Image)resources.GetObject("paperBox.Image");
            paperBox.Location = new Point(165, 58);
            paperBox.Margin = new Padding(2, 2, 2, 2);
            paperBox.Name = "paperBox";
            paperBox.Size = new Size(118, 177);
            paperBox.TabIndex = 2;
            paperBox.Text = "paper";
            paperBox.UseVisualStyleBackColor = true;
            paperBox.Click += paperBox_Click;
            // 
            // VinylBox
            // 
            VinylBox.Image = (Image)resources.GetObject("VinylBox.Image");
            VinylBox.Location = new Point(302, 58);
            VinylBox.Margin = new Padding(2, 2, 2, 2);
            VinylBox.Name = "VinylBox";
            VinylBox.Size = new Size(125, 177);
            VinylBox.TabIndex = 3;
            VinylBox.Text = "vinyl";
            VinylBox.UseVisualStyleBackColor = true;
            VinylBox.Click += VinylBox_Click;
            // 
            // CanBox
            // 
            CanBox.Image = (Image)resources.GetObject("CanBox.Image");
            CanBox.Location = new Point(439, 58);
            CanBox.Margin = new Padding(2, 2, 2, 2);
            CanBox.Name = "CanBox";
            CanBox.Size = new Size(122, 177);
            CanBox.TabIndex = 4;
            CanBox.Text = "can";
            CanBox.UseVisualStyleBackColor = true;
            CanBox.Click += CanBox_Click;
            // 
            // timer
            // 
            timer.AutoSize = true;
            timer.Location = new Point(517, 35);
            timer.Margin = new Padding(2, 0, 2, 0);
            timer.Name = "timer";
            timer.Size = new Size(39, 15);
            timer.TabIndex = 5;
            timer.Text = "0 : 00";
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(38, 13);
            progressBar1.Margin = new Padding(2, 2, 2, 2);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(520, 20);
            progressBar1.TabIndex = 6;
            // 
            // countDownText
            // 
            countDownText.AutoSize = true;
            countDownText.Font = new Font("맑은 고딕", 20F, FontStyle.Bold, GraphicsUnit.Point, 129);
            countDownText.Location = new Point(267, 147);
            countDownText.Margin = new Padding(2, 0, 2, 0);
            countDownText.Name = "countDownText";
            countDownText.Size = new Size(33, 37);
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
            scoreLabel.Location = new Point(38, 35);
            scoreLabel.Margin = new Padding(2, 0, 2, 0);
            scoreLabel.Name = "scoreLabel";
            scoreLabel.Size = new Size(49, 15);
            scoreLabel.TabIndex = 8;
            scoreLabel.Text = "점수 : 0";
            // 
            // timePanel
            // 
            timePanel.Controls.Add(countDownText);
            timePanel.Location = new Point(8, 7);
            timePanel.Margin = new Padding(2, 2, 2, 2);
            timePanel.Name = "timePanel";
            timePanel.Size = new Size(573, 348);
            timePanel.TabIndex = 9;
            timePanel.Paint += timePanel_Paint;
            // 
            // MainGame
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(590, 362);
            Controls.Add(timePanel);
            Controls.Add(scoreLabel);
            Controls.Add(countDownText);
            Controls.Add(progressBar1);
            Controls.Add(timer);
            Controls.Add(CanBox);
            Controls.Add(VinylBox);
            Controls.Add(paperBox);
            Controls.Add(PlasticBox);
            Controls.Add(title);
            Margin = new Padding(2, 2, 2, 2);
            Name = "MainGame";
            Text = "MainGame";
            Load += MainGame_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button title;
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
    }
}