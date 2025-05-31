using static System.Formats.Asn1.AsnWriter;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Eco_Quest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainGame gameForm = new MainGame();
            gameForm.Show(); //게임 화면 열기
            this.Hide(); //현재 form 숨기기
        }

        
        // 전체 제한시간
        private int totalTime;
        // 남은 시간
        private int timeLeft;

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

        // 시간 타이머 Tick 이벤트: 1초마다 실행
        private void timer_Time_Tick(object sender, EventArgs e)
        {
            if (timeLeft > 0)
            {
                timeLeft--; // 남은 시간 1초씩 감소
                progressBar1.Value = timeLeft; // 프로그래스 바 갱신
            }
            else
            {
                timer_Time.Stop(); // 시간이 다 되면 타이머 정지
                MessageBox.Show("Game over!");
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

        // 이벤트 // 빨간/노란 테두리
        private void pictureBoxRecycle1_Paint(object sender, PaintEventArgs e)
        {
            if (showRedBorder && targetPictureBox == pictureBoxRecycle1)
                DrawRedBorder(e, pictureBoxRecycle1);

            if (showYellowBorder && yellowBorderPictureBox == pictureBoxRecycle1)
                DrawYellowBorder(e, pictureBoxRecycle1);
        }

        private void pictureBoxRecycle2_Paint(object sender, PaintEventArgs e)
        {
            if (showRedBorder && targetPictureBox == pictureBoxRecycle2)
                DrawRedBorder(e, pictureBoxRecycle2);

            if (showYellowBorder && yellowBorderPictureBox == pictureBoxRecycle2)
                DrawYellowBorder(e, pictureBoxRecycle2);
        }

        private void pictureBoxRecycle3_Paint(object sender, PaintEventArgs e)
        {
            if (showRedBorder && targetPictureBox == pictureBoxRecycle3)
                DrawRedBorder(e, pictureBoxRecycle3);

            if (showYellowBorder && yellowBorderPictureBox == pictureBoxRecycle3)
                DrawYellowBorder(e, pictureBoxRecycle3);
        }

        private void pictureBoxRecycle4_Paint(object sender, PaintEventArgs e)
        {
            if (showRedBorder && targetPictureBox == pictureBoxRecycle4)
                DrawRedBorder(e, pictureBoxRecycle4);

            if (showYellowBorder && yellowBorderPictureBox == pictureBoxRecycle4)
                DrawYellowBorder(e, pictureBoxRecycle4);
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

    
using System.Media;
using static System.Formats.Asn1.AsnWriter;

namespace Eco_Quest
{
    public partial class Form1 : Form
    {
        //버튼이랑 라벨 클래스 필드로 선언
        private Button EasyButton = new Button();
        private Button NormalButton = new Button();
        private Button HardButton = new Button();
        private Label TitleName = new Label();


        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeGameTitleUI();

            //폼 크기가 바뀔 때마다 자동으로 위치 계산
            this.Resize += (s, e) => CenterControls();


        }

        private void CenterControls()
        {
            // 제목 가운데 정렬
            TitleName.Left = (this.ClientSize.Width - TitleName.Width) / 2;

            int w = 100, h = 40;
            int x = (this.ClientSize.Width - w) / 2;
            int yStart = TitleName.Bottom + 100;

            EasyButton.Location = new Point(x, yStart);
            NormalButton.Location = new Point(x, yStart + 100);
            HardButton.Location = new Point(x, yStart + 200);
        }

        private void InitializeGameTitleUI() // 제목과 버튼들을 초기화하는 메서드
        {
            // 제목 라벨
            TitleName.Text = "Eco-Quest";
            TitleName.Font = new Font("굴림", 20, FontStyle.Bold); // 글꼴: 굴림, 크기: 20, 굵게
            TitleName.AutoSize = true; // 텍스트 길이에 따라 크기 자동 조정
            TitleName.Top = 100;

            // 제목 가운데 정렬
            TitleName.Left = (this.ClientSize.Width - TitleName.Width) / 2;

            // 폼에 추가하기
            this.Controls.Add(TitleName);

            // 초보,중수,고수의 버튼 크기 조절
            int w = 100, h = 40;
            int x = (this.ClientSize.Width - w) / 2;
            int yStart = TitleName.Bottom + 100;

            // 왕초보 버튼
            EasyButton.Size = new Size(w, h);
            EasyButton.Text = "왕초보";
            EasyButton.Location = new Point(x, yStart);
            EasyButton.Click += (s, e) => // 클릭 이벤트 설정
            {
                //PlayClickSound(); // 클릭 소리 재생 근데 지금 문제 생겨서 작동 안되거든요? 그래서 일단 주석처리 했습니다. 추후에 넣겠습니다.
                MessageBox.Show("현재 제작중입니다.");
            };
            this.Controls.Add(EasyButton);

            // 중수 버튼
            NormalButton.Size = new Size(w, h);
            NormalButton.Text = "중수";
            NormalButton.Location = new Point(x, yStart + 100);
            NormalButton.Click += (s, e) =>
            {
                //PlayClickSound();
                OpenGameForm("중수"); // 게임 화면 열기
            };
            this.Controls.Add(NormalButton);

            // 고수 버튼
            HardButton.Size = new Size(w, h);
            HardButton.Text = "고수";
            HardButton.Location = new Point(x, yStart + 200);
            HardButton.Click += (s, e) =>
            {
                // PlayClickSound();
                MessageBox.Show("현재 제작중입니다.");
            };
            this.Controls.Add(HardButton);
        }

        private void OpenGameForm(string level)
        {
            MessageBox.Show($"선택한 난이도: {level}");
            MainGame gameForm = new MainGame();
            gameForm.Show();
            this.Hide();
        }


        private void EasyButton_Click(object sender, EventArgs e)
        {
            SoundPlayer player = new SoundPlayer("click.wav");
        }

        private void NormalButton_Click(object sender, EventArgs e)
        {
            SoundPlayer player = new SoundPlayer("click.wav");
        }

        private void HardButton_Click(object sender, EventArgs e)
        {
            SoundPlayer player = new SoundPlayer("click.wav");
        }
    }
}
