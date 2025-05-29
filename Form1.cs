using System.Media;

namespace Eco_Quest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeGameTitleUI();

        }

        private void OpenGameForm(string level)
        {
            // 나중에 Form2를 만들고 전달하면 여기에 코드 작성
            MessageBox.Show($"선택한 난이도: {level}");

        }
        

        private void InitializeGameTitleUI()
        {
            //title 제목 부분
            TitleName.Text = "Eco-Quest";
            TitleName.Font = new Font("굴림", 20, FontStyle.Bold);
            TitleName.AutoSize = true;
            TitleName.Top = 100;

            // 제목이 정 가운데 위치되도록 설정
            TitleName.Left = (this.ClientSize.Width - TitleName.Width) / 2;

            //버튼 위치 조정하기
            int w = 100;
            int h = 40;

            int x = (this.ClientSize.Width - w) / 2;
            int y = TitleName.Bottom + 100;

            // 초보 버튼
            EasyButton.Size = new Size(w, h);
            EasyButton.Text = "왕초보";
            EasyButton.Location = new Point(x, y);
            EasyButton.Click += (s, e) => OpenGameForm("현재 제작중입니다.");
            this.Controls.Add(EasyButton);

            // 중수 버튼
            NormalButton.Size = new Size(w, h);
            NormalButton.Text = "중수";
            NormalButton.Location = new Point(x, y + 100);
            NormalButton.Click += (s, e) => OpenGameForm("중수모드 지금 시작합니다.");
            this.Controls.Add(NormalButton);

            // 고수 버튼
            HardButton.Size = new Size(w, h);
            HardButton.Text = "고수";
            HardButton.Location = new Point(x, y + 200);
            HardButton.Click += (s, e) => OpenGameForm("현재 제작중입니다.");
            this.Controls.Add(HardButton);


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
