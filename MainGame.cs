using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eco_Quest
{
    public partial class MainGame : Form
    {
        private PictureBox trashImage;
        private Random rand = new Random();
        private System.Windows.Forms.Timer gameTimer = new System.Windows.Forms.Timer();
        private System.Windows.Forms.Timer countDownTimer = new System.Windows.Forms.Timer();
        private string trashType;
        int score = 0;
        int countDown = 3;
        int gameTime = 90; //제한 시간(초)

        Button recycleBoxBtn = new Button();

        private Dictionary<string, string> trashes = new Dictionary<string, string>
        {
            {"plastic_bottle", "플라스틱"},
            {"straw", "플라스틱"},
            {"paper_cup", "종이"},
            {"newspaper", "종이"}
        };

        public MainGame()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void MainGame_Load(object sender, EventArgs e)
        {
            CreateButtons();
            countDownText.Text = ""; //카운트 다운 텍스트 초기화

            //countDownTimer 설정
            countDownTimer.Interval = 1000;
            countDownTimer.Tick += CountDownTimer_Tick;
            countDownTimer.Start();

            //게임 타이머 설정
            gameTimer.Interval = 1000;
            gameTimer.Tick += timer1_Tick;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            titleMove();
        }

        private void titleMove()
        {
            Form1 title = new Form1();
            title.Show();
            this.Hide();
        }

        //게임 타이머 Tick
        private void timer1_Tick(object sender, EventArgs e)
        {
            gameTime--;

            UpdateTime();

            if (gameTime <= 0)
            {
                gameTimer.Stop();
                MessageBox.Show("게임 종료!\n점수 : " + score);
                titleMove();
            }
        }

        private void UpdateTime()
        {
            int min = gameTime / 60;
            int sec = gameTime % 60;

            timer.Text = min + " : " + sec;
        }

        private void EcoBox_1_Click(object sender, EventArgs e)
        {
            CheckTrash("플라스틱");
        }

        private void paperBox_Click(object sender, EventArgs e)
        {
            CheckTrash("종이");
        }

        //카운트다운 타이머 Tick
        private void CountDownTimer_Tick(object sender, EventArgs e)
        {
            if (countDown > 0)
            {
                countDownText.Text = countDown.ToString();
                countDown--;
            }
            else
            {
                countDownText.Text = "";
                countDownTimer.Stop();
                gameTimer.Start();

            }
        }

        private void CheckTrash(string trash)
        {
            if (trash == trashType)
            {
                score += 10;
                scoreLabel.Text = "점수 : " + score;

                if (trashImage != null)
                    this.Controls.Remove(trashImage);
            }
            else
            {
                gameTime -= 5;
            }

            UpdateTime();
        }

        private void CreateTrash()
        {
            int i = 0;

            foreach(var item in trashes)
            {
                
            }
        }

        private void SetButtonImage(Button btn, string imageName, string text)
        {
            object obj = Properties.Resources.ResourceManager.GetObject(imageName);
            Image img = null;

            if (obj is byte[] bytes)
            {
                using (MemoryStream ms = new MemoryStream(bytes))
                {
                    img = Image.FromStream(ms);
                }
            }
            else if (obj is Image image)
            {
                img = image;
            }

            if (img != null)
            {
                btn.Image = img;
                //btn.Text = text;
                btn.ImageAlign = ContentAlignment.MiddleLeft;
                //btn.TextAlign = ContentAlignment.MiddleRight;
                btn.Size = new Size(150, 240);
            }
        }

        private void CreateButtons()
        {
            Dictionary<string, string> buttonInfo = new Dictionary<string, string>
            {
                { "PlasticBox", "플라스틱" },
                { "PaperBox", "paper" },
                { "VinylBox", "vinyl" },
                { "CanBox", "can" }
            };

            int i = 0;

            foreach(var item in buttonInfo)
            {
                Button btn = this.Controls.Find(item.Key, true).FirstOrDefault() as Button;

                if(btn != null)
                {
                    SetButtonImage(btn, item.Value, item.Key.Replace("Box", ""));
                    btn.Location = new Point(50 + i * 200, 100);
                    i++;
                }
            }
        }

    }
}
