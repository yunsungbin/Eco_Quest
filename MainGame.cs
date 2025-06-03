using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

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
        private PictureBox targetPictureBox;
        // 흔들림 횟수 카운트
        private int shakeCount = 0;
        // 흔들기 전 원래 X 위치 저장
        private int startX;
        // 빨간 테두리를 표시할지 여부
        private bool showRedBorder = false;

        // 노란 테두리 효과용 변수
        private bool showYellowBorder = false;
        private PictureBox yellowBorderPictureBox = null;

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

        private void VinylBox_Click(object sender, EventArgs e)
        {
            CheckTrash("비닐");
        }

        private void CanBox_Click(object sender, EventArgs e)
        {
            CheckTrash("캔");
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
            Dictionary<string, string> buttonType = new Dictionary<string, string>
            {
                { "플라스틱", "plastic" },
                { "종이", "paper" },
                { "비닐", "vinyl" },
                { "캔", "can" }
            };

            int i = 0;

            foreach (var item in buttonType)
            {
                Button btn = new Button
                {
                    Name = item.Value + "Box",
                    Size = new Size(150, 240),
                    Location = new Point(50 + (i * 120), 95),
                    Tag = item.Key
                };

                //btn.Image = Properties.Resources.Plastic;
                btn.ImageAlign = ContentAlignment.TopCenter;
                btn.Text = item.Key;
                btn.TextAlign = ContentAlignment.BottomCenter;

                //클릭 이벤트
                btn.Click += (sender, e) =>
                {
                    Button clicked = sender as Button;
                    string clickedType = clicked.Tag.ToString();
                    CheckTrash(clickedType);
                };

                this.Controls.Add(btn);
                i++;
            }
        }

        // 정답 효과: 흔들림 없이 노란 테두리 잠깐 표시
        private void ShowCorrectEffect(PictureBox pb)
        {
            if (pb == null) return;

            yellowBorderPictureBox = pb;   // 노란 테두리 표시 대상 지정
            showYellowBorder = true;       // 노란 테두리 표시 켜기
            pb.Invalidate();               // 다시 그리기 요청 (테두리 표시 위해)

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
            if (timer == null) return;

            showYellowBorder = false;                      // 노란 테두리 끄기
            if (yellowBorderPictureBox != null)
            {
                yellowBorderPictureBox.Invalidate();       // 다시 그려서 테두리 제거
                yellowBorderPictureBox = null;             // 대상 해제
            }

            timer.Stop();                                  // 타이머 중지
            timer.Dispose();                               // 메모리 정리
        }

        // 오답 효과: 좌우 흔들기 + 빨간 테두리
        private void ShakeAndRedBorder(PictureBox pb)
        {
            if (pb == null) return;

            targetPictureBox = pb; // 효과를 줄 대상 설정
            startX = pb.Location.X; // 현재 X 위치 저장
            shakeCount = 0; // 흔들림 횟수 초기화
            showRedBorder = true; // 테두리 보이게 설정
            pb.Invalidate(); // 강제로 다시 그리기 요청 (테두리 반영 위해)

            timerEffect.Start(); // 흔들기 효과 타이머 시작
        }

        // 흔들기 효과를 만드는 타이머 Tick 이벤트
        private void timerEffect_Tick(object sender, EventArgs e)
        {
            if (targetPictureBox == null) return;
            // 값이 없을 때 실행 시 오류 방지

            if (shakeCount < 10)
            {
                // 홀수/짝수에 따라 좌우 이동
                int moveAmount = (shakeCount % 2 == 0) ? 5 : -5;
                targetPictureBox.Left = startX + moveAmount;
                shakeCount++;
            }
            else
            {
                // 흔들기 끝나면 위치 복원 및 테두리 제거
                timerEffect.Stop();
                targetPictureBox.Left = startX;
                showRedBorder = false;
                targetPictureBox.Invalidate(); // 다시 그려서 테두리 제거
                targetPictureBox = null; // 효과 종료
            }
        }

        // 클릭 이벤트 (이거는 다른분거 넣어야해서)
        private void pictureBoxRecycle1_Click(object sender, EventArgs e)
        {
            //
        }

        private void pictureBoxRecycle2_Click(object sender, EventArgs e)
        {
            //
        }

        private void pictureBoxRecycle3_Click(object sender, EventArgs e)
        {
            //
        }

        private void pictureBoxRecycle4_Click(object sender, EventArgs e)
        {
            //
        }

        // 빨간 테두리 그리는 실제 함수
        private void DrawRedBorder(PaintEventArgs e, PictureBox pb)
        {
            using (Pen pen = new Pen(Color.Red, 5)) // 테두리 굵기5, 빨간색
            {
                Rectangle rect = new Rectangle(0, 0, pb.Width - 1, pb.Height - 1);
                e.Graphics.DrawRectangle(pen, rect); // 테두리 그림
            }
        }

        // 노란 테두리 그리는 함수
        private void DrawYellowBorder(PaintEventArgs e, PictureBox pb)
        {
            using (Pen pen = new Pen(Color.Yellow, 5)) // 테두리 굵기5, 노란색
            {
                Rectangle rect = new Rectangle(0, 0, pb.Width - 1, pb.Height - 1);
                e.Graphics.DrawRectangle(pen, rect);
            }
        }
    }
}
