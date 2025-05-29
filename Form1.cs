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
            // ���߿� Form2�� ����� �����ϸ� ���⿡ �ڵ� �ۼ�
            MessageBox.Show($"������ ���̵�: {level}");

        }
        

        private void InitializeGameTitleUI()
        {
            //title ���� �κ�
            TitleName.Text = "Eco-Quest";
            TitleName.Font = new Font("����", 20, FontStyle.Bold);
            TitleName.AutoSize = true;
            TitleName.Top = 100;

            // ������ �� ��� ��ġ�ǵ��� ����
            TitleName.Left = (this.ClientSize.Width - TitleName.Width) / 2;

            //��ư ��ġ �����ϱ�
            int w = 100;
            int h = 40;

            int x = (this.ClientSize.Width - w) / 2;
            int y = TitleName.Bottom + 100;

            // �ʺ� ��ư
            EasyButton.Size = new Size(w, h);
            EasyButton.Text = "���ʺ�";
            EasyButton.Location = new Point(x, y);
            EasyButton.Click += (s, e) => OpenGameForm("���� �������Դϴ�.");
            this.Controls.Add(EasyButton);

            // �߼� ��ư
            NormalButton.Size = new Size(w, h);
            NormalButton.Text = "�߼�";
            NormalButton.Location = new Point(x, y + 100);
            NormalButton.Click += (s, e) => OpenGameForm("�߼���� ���� �����մϴ�.");
            this.Controls.Add(NormalButton);

            // ��� ��ư
            HardButton.Size = new Size(w, h);
            HardButton.Text = "���";
            HardButton.Location = new Point(x, y + 200);
            HardButton.Click += (s, e) => OpenGameForm("���� �������Դϴ�.");
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
