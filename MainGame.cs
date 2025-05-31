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
        //현재 표시되는 쓰레기
        private PictureBox trashImage;
        private Label trashLabel;

        //다음에 등장할 쓰레기
        private PictureBox nextTrashImage;
        private Label nextTrashLabel;

        private Random rand = new Random();
        private System.Windows.Forms.Timer gameTimer = new System.Windows.Forms.Timer();
        private System.Windows.Forms.Timer countDownTimer = new System.Windows.Forms.Timer();

        private string trashType;
        private string nextTrashType;

        int score = 0;
        int countDown = 3;
        int gameTime = 90; //제한 시간(초)

        //쓰레기 이름과 분리수거 종류 매핑(key: 이미지, value : 종류)
        private Dictionary<string, string> trashList = new Dictionary<string, string>
        {
            {"plastic_bottle", "플라스틱"},
            {"straw", "플라스틱"},
            {"paper_cup", "종이"},
            {"newspaper", "종이"},
            {"can", "캔"},
            {"vinyl_bag", "비닐"}
        };

        //키와 매핑된 이미지 저장(리소스에서 가져옴)
        private Dictionary<string, Image> trashImages = new Dictionary<string, Image>();

        public MainGame()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void MainGame_Load(object sender, EventArgs e)
        {
            LoadTrashImages();

            initUI();
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

        //리소스 이미지 로드 및 dictionary에 저장
        private void LoadTrashImages()
        {
            foreach (var item in trashList)
            {
                // 리소스 등록 필요 (파일명과 키 일치)
                trashImages[item.Key] = (Image)Properties.Resources.ResourceManager.GetObject(item.Key);
            }
        }

        //화면 UI요소
        private void initUI()
        {
            trashImage = new PictureBox
            {
                Location = new Point(100, 300),
                Size = new Size(100, 100),
                SizeMode = PictureBoxSizeMode.Zoom
            };
            this.Controls.Add(trashImage);

            trashLabel = new Label
            {
                Location = new Point(100, 400),
                Size = new Size(100, 30),
                TextAlign = ContentAlignment.MiddleCenter
            };
            this.Controls.Add(trashLabel);

            nextTrashImage = new PictureBox
            {
                Location = new Point(250, 250),
                Size = new Size(50, 50),
                SizeMode = PictureBoxSizeMode.Zoom
            };
            this.Controls.Add(nextTrashImage);

            nextTrashLabel = new Label
            {
                Location = new Point(240, 370),
                Size = new Size(80, 20),
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("맑은 고딕", 9, FontStyle.Bold)
            };
            this.Controls.Add(nextTrashLabel);

            NextTrash();
            ShowTrash();
        }

        //다음 쓰레기 랜덤으로 설정
        private void NextTrash()
        {
            var key = trashList.Keys.ToList();
            var randKey = key[rand.Next(key.Count)];
            nextTrashType = randKey;
            nextTrashImage.Image = trashImages[nextTrashType];
            nextTrashLabel.Text = trashList[nextTrashType];
        }

        //현재 쓰레기로 교체
        private void ShowTrash()
        {
            trashType = nextTrashType;
            trashImage.Image = trashImages[trashType];
            trashLabel.Text = trashList[trashType];

            NextTrash();
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

        //쓰레기통 버튼 클릭 시
        private void CheckTrash(string clickType)
        {
            string correctType = trashList[trashType];

            if (clickType == trashType)
            {
                score += 10;
                scoreLabel.Text = "점수 : " + score;
                ShowTrash();
            }
            else
            {
                gameTime -= 5;
                if (gameTime < 0) gameTime = 0;
            }

            UpdateTime();
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

        //분리수거 버튼 생성
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
