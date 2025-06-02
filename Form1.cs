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
                PlayClickSound();
                MessageBox.Show("현재 제작중입니다.");
            };
            this.Controls.Add(EasyButton);

            // 중수 버튼
            NormalButton.Size = new Size(w, h);
            NormalButton.Text = "중수";
            NormalButton.Location = new Point(x, yStart + 100);
            NormalButton.Click += (s, e) =>
            {
                PlayClickSound();
                OpenGameForm("중수"); // 게임 화면 열기
            };
            this.Controls.Add(NormalButton);

            // 고수 버튼
            HardButton.Size = new Size(w, h);
            HardButton.Text = "고수";
            HardButton.Location = new Point(x, yStart + 200);
            HardButton.Click += (s, e) =>
            {
                PlayClickSound();
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
    }
}
