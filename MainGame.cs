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
        PictureBox trash;
        private System.Windows.Forms.Timer gameTimer = new System.Windows.Forms.Timer();
        private System.Windows.Forms.Timer countDownTimer = new System.Windows.Forms.Timer();
        private string trashType;
        int score = 0;
        int countDown = 3;
        int gameTime = 90; //제한 시간(초)

        public MainGame()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void MainGame_Load(object sender, EventArgs e)
        {
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
                MessageBox.Show("게임 종료!");
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

        }

        //카운트다운 타이머 Tick
        private void CountDownTimer_Tick(object sender, EventArgs e)
        {
            if(countDown > 0)
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
    }
}
