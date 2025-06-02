using System.Media;
using static System.Formats.Asn1.AsnWriter;

namespace Eco_Quest
{
    public partial class Form1 : Form
    {
        //��ư�̶� �� Ŭ���� �ʵ�� ����
        private Button EasyButton = new Button();
        private Button NormalButton = new Button();
        private Button HardButton = new Button();
        private Label TitleName = new Label();


        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeGameTitleUI();

            //�� ũ�Ⱑ �ٲ� ������ �ڵ����� ��ġ ���
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
                MessageBox.Show("���� ����: " + ex.Message);
            }
        }
        private void CenterControls()
        {
            // ���� ��� ����
            TitleName.Left = (this.ClientSize.Width - TitleName.Width) / 2;

            int w = 100, h = 40;
            int x = (this.ClientSize.Width - w) / 2;
            int yStart = TitleName.Bottom + 100;

            EasyButton.Location = new Point(x, yStart);
            NormalButton.Location = new Point(x, yStart + 100);
            HardButton.Location = new Point(x, yStart + 200);
        }

        private void InitializeGameTitleUI() // ����� ��ư���� �ʱ�ȭ�ϴ� �޼���
        {
            // ���� ��
            TitleName.Text = "Eco-Quest";
            TitleName.Font = new Font("����", 20, FontStyle.Bold); // �۲�: ����, ũ��: 20, ����
            TitleName.AutoSize = true; // �ؽ�Ʈ ���̿� ���� ũ�� �ڵ� ����
            TitleName.Top = 100;

            // ���� ��� ����
            TitleName.Left = (this.ClientSize.Width - TitleName.Width) / 2;

            // ���� �߰��ϱ�
            this.Controls.Add(TitleName);

            // �ʺ�,�߼�,����� ��ư ũ�� ����
            int w = 100, h = 40;
            int x = (this.ClientSize.Width - w) / 2;
            int yStart = TitleName.Bottom + 100;

            // ���ʺ� ��ư
            EasyButton.Size = new Size(w, h);
            EasyButton.Text = "���ʺ�";
            EasyButton.Location = new Point(x, yStart);
            EasyButton.Click += (s, e) => // Ŭ�� �̺�Ʈ ����
            {
                PlayClickSound();
                MessageBox.Show("���� �������Դϴ�.");
            };
            this.Controls.Add(EasyButton);

            // �߼� ��ư
            NormalButton.Size = new Size(w, h);
            NormalButton.Text = "�߼�";
            NormalButton.Location = new Point(x, yStart + 100);
            NormalButton.Click += (s, e) =>
            {
                PlayClickSound();
                OpenGameForm("�߼�"); // ���� ȭ�� ����
            };
            this.Controls.Add(NormalButton);

            // ��� ��ư
            HardButton.Size = new Size(w, h);
            HardButton.Text = "���";
            HardButton.Location = new Point(x, yStart + 200);
            HardButton.Click += (s, e) =>
            {
                PlayClickSound();
                MessageBox.Show("���� �������Դϴ�.");
            };
            this.Controls.Add(HardButton);
        }

        private void OpenGameForm(string level)
        {
            MessageBox.Show($"������ ���̵�: {level}");
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
