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
        private Button GameEndButton = new Button();


        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            TitleBackGround();
            InitializeGameTitleUI();

            //폼 크기가 바뀔 때마다 자동으로 위치 계산
            this.Resize += (s, e) => CenterControls();


        }

        private void PlayClickSound()
        {
            try
            {
                SoundPlayer player = new SoundPlayer("click.wav");
                player.Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show("사운드 오류: " + ex.Message);
            }
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
            TitleName.Text = "Eco Quest";
            TitleName.Font = new Font("굴림", 20, FontStyle.Bold); // 글꼴: 굴림, 크기: 20, 굵게
            TitleName.BackColor = Color.Transparent;
            TitleName.ForeColor = Color.DarkGreen;
            TitleName.AutoSize = true; // 텍스트 길이에 따라 크기 자동 조정
            TitleName.Top = 100;

            // 폼에 추가하기
            this.Controls.Add(TitleName);

            // 제목 가운데 정렬
            TitleName.Left = (this.ClientSize.Width - TitleName.Width) / 2;

            // 초보,중수,고수의 버튼 크기 조절
            int w = 100, h = 40;
            int x = (this.ClientSize.Width - w) / 2;
            int yStart = TitleName.Bottom + 100;

            // 공통 스타일 적용 메서드
            void StyleButton(Button btn, string text, Color backColor, int yOffset)
            {
                btn.Size = new Size(w, h);
                btn.Text = text;
                btn.BackColor = backColor;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.Font = new Font("굴림", 11, FontStyle.Bold);
                btn.Location = new Point(x, yStart + yOffset);
                this.Controls.Add(btn);
            }

            // 왕초보 버튼
            StyleButton(EasyButton, "왕초보", Color.Gray, 0);
            EasyButton.Click += (s, e) =>
            {
                PlayClickSound();
                MessageBox.Show("현재 제작중입니다.");
            };

            // 중수 버튼
            StyleButton(NormalButton, "중수", Color.FromArgb(30, 100, 200), 60);
            NormalButton.Click += (s, e) =>
            {
                PlayClickSound();
                OpenGameForm("중수");
            };

            // 고수 버튼
            StyleButton(HardButton, "고수", Color.FromArgb(0, 130, 60), 120);
            HardButton.Click += (s, e) =>
            {
                PlayClickSound();
                MessageBox.Show("현재 제작중입니다.");
            };

            // 게임 종료 버튼
            GameEndButton.Size = new Size(100, 30);
            GameEndButton.Text = "게임종료";
            GameEndButton.BackColor = Color.Black; // 반투명 흰색
            GameEndButton.ForeColor = Color.White;
            GameEndButton.FlatStyle = FlatStyle.Flat;
            GameEndButton.FlatAppearance.BorderSize = 0;
            GameEndButton.Font = new Font("굴림", 9, FontStyle.Bold);
            GameEndButton.Location = new Point(20, 20);
            GameEndButton.Click += (s, e) =>
            {
                Application.Exit();
            };
            this.Controls.Add(GameEndButton);

        }

       
        private void OpenGameForm(string level)
        {
            MainGame gameForm = new MainGame(level);
            gameForm.Show();
            this.Hide();
        }


        private void EasyButton_Click(object sender, EventArgs e)
        {
            SoundPlayer player = new SoundPlayer("click");
            player.Play();

        }

        private void NormalButton_Click(object sender, EventArgs e)
        {
            SoundPlayer player = new SoundPlayer("click");
            player.Play();

        }

        private void HardButton_Click(object sender, EventArgs e)
        {
            SoundPlayer player = new SoundPlayer("click");
            player.Play();

        }

        private void TitleBackGround()
        {
            byte[] image = Properties.Resources.titleImage;

            using(MemoryStream ms = new MemoryStream(image))
            {
                Image img = Image.FromStream(ms);

                this.BackgroundImage = img;
                this.BackgroundImageLayout = ImageLayout.Stretch;
            }
        }
     
    }
}
