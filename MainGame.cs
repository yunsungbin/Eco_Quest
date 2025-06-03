using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
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

        // 흔들림+빨간 테두리 효과 타이머
        private System.Windows.Forms.Timer timerEffect = new System.Windows.Forms.Timer();

        // 빨간 테두리가 보일 사진
        private Button targetButton;
        // 흔들림 횟수 카운트
        private int shakeCount = 0;
        // 흔들기 전 원래 X 위치 저장
        private int startX;
        // 빨간 테두리를 표시할지 여부
        private bool showRedBorder = false;

        // 노란 테두리 효과용 변수
        private bool showYellowBorder = false;
        private Button yellowBorderButton = null;



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
           
            // timerEffect 초기화 및 이벤트 연결 (1번 수정 사항)
            timerEffect.Interval = 50; // 흔들림 효과 간격 (50ms)
            timerEffect.Tick += timerEffect_Tick;
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
            Button btn = sender as Button;
            CheckTrash("플라스틱", btn);
        }

        private void paperBox_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            CheckTrash("종이", btn);

        }
        private void VinylBox_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            CheckTrash("비닐", btn);
        }

        private void CanBox_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            CheckTrash("캔", btn);
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
        private void CheckTrash(string clickType, Button clickedButton)
        {
            string correctType = trashList[trashType];

            if (clickType == correctType)
            {
                score += 10;
                scoreLabel.Text = "점수 : " + score;
                ShowTrash();

                ShowCorrectEffect(clickedButton);

                PlayCorrectSound(); //정답 소리 재생
            }
            else
            {
                gameTime -= 5;
                if (gameTime < 0) gameTime = 0;

                ShakeAndRedBorder(clickedButton);

                PlayErrorSound(); //오답 소리 재생
            }

            UpdateTime();
        }


        //정답소리 재생함수
        private void PlayCorrectSound()
        {
            SoundPlayer player = new SoundPlayer("correct.wav");
            player.Play();
        }

        //오답 소리 재생 함수
        private void PlayErrorSound()
        {
            SoundPlayer player = new SoundPlayer("error.wav");
            player.Play();
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

            foreach (var item in buttonInfo)
            {
                Button btn = this.Controls.Find(item.Key, true).FirstOrDefault() as Button;

                if (btn != null)
                {
                    SetButtonImage(btn, item.Value, item.Key.Replace("Box", ""));
                    btn.Location = new Point(50 + i * 200, 100);
                    i++;

                    btn.Paint += Button_Paint; //Paint이벤트 연결
                }
            }
        }

        // 정답 효과: 흔들림 없이 노란 테두리 잠깐 표시
        private void ShowCorrectEffect(Button btn)
        {
            if (btn == null) return;

            yellowBorderButton = btn;   // 노란 테두리 표시 대상 지정
            showYellowBorder = true;       // 노란 테두리 표시 켜기
            btn.Invalidate();               // 다시 그리기 요청 (테두리 표시 위해)

            // 0.3초 후에 노란 테두리 해제용 타이머 생성 및 시작
            System.Windows.Forms.Timer yellowBorderTimer = new System.Windows.Forms.Timer();
            yellowBorderTimer.Interval = 300; // 0.3초
            yellowBorderTimer.Tick += YellowBorderTimer_Tick;
            yellowBorderTimer.Start();
        }

        // 노란 테두리 타이머 Tick 이벤트 핸들러 (일반 메서드)
        private void YellowBorderTimer_Tick(object sender, EventArgs e)
        {
            System.Windows.Forms.Timer timer = sender as System.Windows.Forms.Timer;
            if (timer == null)
            {
                timer.Stop();
                timer.Tick -= YellowBorderTimer_Tick;
                timer.Dispose();
            }

            showYellowBorder = false;                      // 노란 테두리 끄기
            if (yellowBorderButton != null)
            {
                yellowBorderButton.Invalidate();       // 다시 그려서 테두리 제거
                yellowBorderButton = null;             // 대상 해제
            }
        }



        // 오답 효과: 좌우 흔들기 + 빨간 테두리
        private void ShakeAndRedBorder(Button btn)
        {
            if (btn == null) return;

            targetButton = btn; // 효과를 줄 대상 설정
            startX = btn.Location.X; // 현재 X 위치 저장
            shakeCount = 0; // 흔들림 횟수 초기화
            showRedBorder = true; // 테두리 보이게 설정

            timerEffect.Start(); // 흔들기 효과 타이머 시작
        }

        // 흔들기 효과를 만드는 타이머 Tick 이벤트
        private void timerEffect_Tick(object sender, EventArgs e)
        {
            if (targetButton == null)
            {
                timerEffect.Stop();
                return;
            }

            if (shakeCount >= 10) // 흔들기 횟수 제한 (5번, 10번 흔들기)
            {
                timerEffect.Stop();
                showRedBorder = false;
                if (targetButton != null)
                {
                    targetButton.Location = new Point(startX, targetButton.Location.Y);
                    targetButton.Invalidate(); // 빨간 테두리 지우기 위해 다시 그리기 요청
                    targetButton = null;
                }
            }
            else
            {
                // 좌우 흔들기: 짝수는 오른쪽, 홀수는 왼쪽으로 5픽셀 이동
                int offset = (shakeCount % 2 == 0) ? 5 : -5;
                targetButton.Location = new Point(startX + offset, targetButton.Location.Y);
                targetButton.Invalidate();
                shakeCount++;
            }
        }

        // 버튼 Paint 이벤트에서 테두리 그리기
        private void Button_Paint(object sender, PaintEventArgs e)
        {
            Button btn = sender as Button;

            if (showRedBorder && targetButton == btn)
            {
                using (Pen pen = new Pen(Color.Red, 5))
                {
                    Rectangle rect = new Rectangle(0, 0, btn.Width - 1, btn.Height - 1);
                    e.Graphics.DrawRectangle(pen, rect);
                }
            }

            if (showYellowBorder && yellowBorderButton == btn)
            {
                using (Pen pen = new Pen(Color.Yellow, 5))
                {
                    Rectangle rect = new Rectangle(0, 0, btn.Width - 1, btn.Height - 1);
                    e.Graphics.DrawRectangle(pen, rect);
                }
            }
        }
    }
}
