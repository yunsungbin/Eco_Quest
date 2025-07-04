﻿using System;
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
        // — 점수 시스템 관련 필드 추가 — 
        private int score = 0;
        private string difficulty;  // 난이도 정보를 저장할 필드
        int countDown = 3;
        int totalTime = 90; //제한 시간(초)
        int gameTime; //현재 시간

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
        private Dictionary<string, (string category, string name)> trashList = new Dictionary<string, (string, string)>
        {
            {"plastic_bag", ("plastic", "플라스틱 가방")},
            {"disposable_cups", ("plastic", "플라스틱 컵")},
            {"waterbottle", ("plastic", "페트병")},
            {"paper", ("paper", "신문지")},
            {"paperes", ("paper", "종이 뭉치")},
            {"envelope", ("paper", "봉투")},
            {"Can", ("can", "알루미늄 캔")},
            {"blueCan", ("can", "음료 캔")},
            {"redCan", ("can", "주스 캔")},
            {"vinyl_bag", ("vinyl", "비닐봉투")},
            {"blue_vinyl_bag", ("vinyl", "파란 비닐봉투")},
            {"trash_vinyl", ("vinyl", "쓰레기 비닐")}
        };

        //키와 매핑된 이미지 저장(리소스에서 가져옴)
        private Dictionary<string, Image> trashImages = new Dictionary<string, Image>();

        Dictionary<string, Point> buttonPositions = new Dictionary<string, Point>();

        public MainGame(string level)
        {
            InitializeComponent();
            timePanel.BringToFront();
            this.StartPosition = FormStartPosition.CenterScreen;
            difficulty = level;

            scoreLabel_Click(null, null);

            timerEffect.Interval = 50;
            timerEffect.Tick += timerEffect_Tick;

            gameTime = totalTime;
            progressBar1.Maximum = totalTime;
            progressBar1.Value = totalTime;

            this.KeyPreview = true;  // 폼이 키 입력을 먼저 받도록 설정
            this.KeyDown += MainGame_KeyDown;
        }

        private void MainGame_Load(object sender, EventArgs e)
        {
            LoadTrashImages();

            timePanel.Show();
            initUI();
            CreateButtons();
            //CreateButtons();
            countDownText.Text = ""; //카운트 다운 텍스트 초기화

            //countDownTimer 설정
            countDownTimer.Interval = 1000;
            countDownTimer.Tick += CountDownTimer_Tick;
            countDownTimer.Start();

            //게임 타이머 설정
            gameTimer.Interval = 1000;
            gameTimer.Tick += timer1_Tick;

            PlasticBox.Paint += Button_Paint;
            paperBox.Paint += Button_Paint;
            VinylBox.Paint += Button_Paint;
            CanBox.Paint += Button_Paint;
        }

        //리소스 이미지 로드 및 dictionary에 저장
        private void LoadTrashImages()
        {
            foreach (var item in trashList)
            {
                // 리소스 등록 필요 (파일명과 키 일치)
                object res = Properties.Resources.ResourceManager.GetObject(item.Key);

                if (res is byte[] bytes)
                {
                    using (MemoryStream ms = new MemoryStream(bytes))
                    {
                        trashImages[item.Key] = Image.FromStream(ms);
                    }
                }
                else
                {
                    MessageBox.Show($"리소스 '{item.Key}'는 byte[]가 아닙니다.");
                }

            }
        }

        //화면 UI요소
        private void initUI()
        {
            trashImage = new PictureBox
            {
                Location = new Point(350, 400),
                Size = new Size(100, 100),
                SizeMode = PictureBoxSizeMode.Zoom
            };
            this.Controls.Add(trashImage);

            trashLabel = new Label
            {
                Location = new Point(300, 500),
                Size = new Size(200, 30),
                TextAlign = ContentAlignment.MiddleCenter
            };
            this.Controls.Add(trashLabel);

            nextTrashImage = new PictureBox
            {
                Location = new Point(500, 400),
                Size = new Size(50, 50),
                SizeMode = PictureBoxSizeMode.Zoom
            };
            this.Controls.Add(nextTrashImage);

            nextTrashLabel = new Label
            {
                Location = new Point(425, 450),
                Size = new Size(200, 30),
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
            var info = trashList[nextTrashType];
            nextTrashLabel.Text = info.name;
        }

        //현재 쓰레기로 교체
        private void ShowTrash()
        {
            trashType = nextTrashType;
            trashImage.Image = trashImages[trashType];
            var info = trashList[trashType];
            trashLabel.Text = info.name;

            NextTrash();
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
                PlayEndGameSound();
                if (score >= 300) MessageBox.Show("게임 종료!\n점수 : " + score + "\nA등급");
                else if (score >= 200) MessageBox.Show("게임 종료!\n점수 : " + score + "\nB등급");
                else if (score >= 100) MessageBox.Show("게임 종료!\n점수 : " + score + "\nC등급");
                else MessageBox.Show("게임 종료!\n점수 : " + score + "\n등급 없음");
                titleMove();
            }
        }

        private void UpdateTime()
        {
            int min = gameTime / 60;
            int sec = gameTime % 60;

            timer.Text = min + " : " + sec;
            if (gameTime >= 0)
                progressBar1.Value = gameTime;
            else
                progressBar1.Value = 0;
        }

        private void EcoBox_1_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            CheckTrash("plastic", btn);
        }

        private void paperBox_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            CheckTrash("paper", btn);

        }
        private void VinylBox_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            CheckTrash("vinyl", btn);
        }

        private void CanBox_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            CheckTrash("can", btn);
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
                UpdateTime();
                gameTimer.Start();
                timePanel.Hide();
            }
        }

        //쓰레기통 버튼 클릭 시
        private void CheckTrash(string clickType, Button clickedButton)
        {
            string correctType = trashList[trashType].category;

            if (clickType == correctType)
            {
                score += 10;
                scoreLabel_Click(null, null);
                ShowTrash();

                ShowCorrectEffect(clickedButton);

                PlayCorrectSound(); //정답 소리 재생
            }
            else
            {
                gameTime -= 5;
                if (gameTime < 0) gameTime = 0;

                ResetButtonPosition();
                ShakeAndRedBorder(clickedButton);

                PlayErrorSound(); //오답 소리 재생
            }

            UpdateTime();
        }


        //정답소리 재생함수
        private void PlayCorrectSound()
        {
            try
            {
                SoundPlayer player = new SoundPlayer("correct.wav");
                player.Play();
            }
            catch
            {
                // 사운드 파일이 없거나 오류 시 무시
            }
        }

        //오답 소리 재생 함수
        private void PlayErrorSound()
        {
            try
            {
                SoundPlayer player = new SoundPlayer("error.wav");
                player.Play();
            }
            catch
            {
                // 사운드 파일이 없거나 오류 시 무시
            }
        }

        //끝난 소리 재생
        private void PlayEndGameSound()
        {
            SoundPlayer player = new SoundPlayer("GameOver.wav");
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
                // 버튼 크기 설정
                btn.Size = new Size(150, 240);

                // 이미지 크기 조정
                Image resizedImg = new Bitmap(img, btn.Size);

                btn.Image = resizedImg;
                btn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

        ////분리수거 버튼 생성
        private void CreateButtons()
        {
            Dictionary<string, string> buttonInfo = new Dictionary<string, string>
            {
                { "PlasticBox", "plastic" },
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
                    SetButtonImage(btn, item.Key, item.Value);
                    btn.Location = new Point(50 + i * 200, 100);
                    btn.Paint += Button_Paint; //Paint이벤트 연결
                    buttonPositions[btn.Name] = btn.Location;
                    i++;
                }
            }
        }

        private void ResetButtonPosition()
        {
            foreach (var item in buttonPositions)
            {
                Button btn = this.Controls.Find(item.Key, true).FirstOrDefault() as Button;
                if (btn != null)
                {
                    btn.Location = item.Value;
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
        private void scoreLabel_Click(object sender, EventArgs e)
        {
            scoreLabel.Text = "점수 : " + score;
        }

        private void MainGame_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Pause();
            }
        }

        private void Pause()
        {
            // 타이머 모두 멈추기
            gameTimer.Stop();
            countDownTimer.Stop();
            timerEffect.Stop();

            // 메시지 박스 띄우기
            var result = MessageBox.Show("게임을 종료하고 타이틀 화면으로 돌아가시겠습니까?", "게임 종료 확인", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                titleMove();  // 타이틀 폼으로 이동
            }
            else
            {
                // 다시 타이머 시작
                countDownTimer.Start();
                gameTimer.Start();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Pause();
        }
    }
}
