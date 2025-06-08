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
        private Button GameEndButton = new Button();


        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            TitleBackGround();
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
            TitleName.Text = "Eco Quest";
            TitleName.Font = new Font("����", 20, FontStyle.Bold); // �۲�: ����, ũ��: 20, ����
            TitleName.BackColor = Color.Transparent;
            TitleName.ForeColor = Color.DarkGreen;
            TitleName.AutoSize = true; // �ؽ�Ʈ ���̿� ���� ũ�� �ڵ� ����
            TitleName.Top = 100;

            // ���� �߰��ϱ�
            this.Controls.Add(TitleName);

            // ���� ��� ����
            TitleName.Left = (this.ClientSize.Width - TitleName.Width) / 2;

            // �ʺ�,�߼�,����� ��ư ũ�� ����
            int w = 100, h = 40;
            int x = (this.ClientSize.Width - w) / 2;
            int yStart = TitleName.Bottom + 100;

            // ���� ��Ÿ�� ���� �޼���
            void StyleButton(Button btn, string text, Color backColor, int yOffset)
            {
                btn.Size = new Size(w, h);
                btn.Text = text;
                btn.BackColor = backColor;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.Font = new Font("����", 11, FontStyle.Bold);
                btn.Location = new Point(x, yStart + yOffset);
                this.Controls.Add(btn);
            }

            // ���ʺ� ��ư
            StyleButton(EasyButton, "���ʺ�", Color.Gray, 0);
            EasyButton.Click += (s, e) =>
            {
                PlayClickSound();
                MessageBox.Show("���� �������Դϴ�.");
            };

            // �߼� ��ư
            StyleButton(NormalButton, "�߼�", Color.FromArgb(30, 100, 200), 60);
            NormalButton.Click += (s, e) =>
            {
                PlayClickSound();
                OpenGameForm("�߼�");
            };

            // ��� ��ư
            StyleButton(HardButton, "���", Color.FromArgb(0, 130, 60), 120);
            HardButton.Click += (s, e) =>
            {
                PlayClickSound();
                MessageBox.Show("���� �������Դϴ�.");
            };

            // ���� ���� ��ư
            GameEndButton.Size = new Size(100, 30);
            GameEndButton.Text = "��������";
            GameEndButton.BackColor = Color.Black; // ������ ���
            GameEndButton.ForeColor = Color.White;
            GameEndButton.FlatStyle = FlatStyle.Flat;
            GameEndButton.FlatAppearance.BorderSize = 0;
            GameEndButton.Font = new Font("����", 9, FontStyle.Bold);
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
