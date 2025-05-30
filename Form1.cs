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
            gameForm.Show(); //���� ȭ�� ����
            this.Hide(); //���� form �����
        }

        {
        // ��ü ���ѽð�
        private int totalTime;
        // ���� �ð�
        private int timeLeft;

        // ��鸲+���� �׵θ� ȿ�� Ÿ�̸�
        private System.Windows.Forms.Timer timerEffect = new System.Windows.Forms.Timer();

        // ���� �׵θ��� ���� ����
        private PictureBox targetPictureBox;
        // ��鸲 Ƚ�� ī��Ʈ
        private int shakeCount = 0;
        // ���� �� ���� X ��ġ ����
        private int startX;
        // ���� �׵θ��� ǥ������ ����
        private bool showRedBorder = false;

        // ��� �׵θ� ȿ���� ����
        private bool showYellowBorder = false;
        private PictureBox yellowBorderPictureBox = null;

        public Form1()
        {
            InitializeComponent();

            totalTime = 60; // ���� �ð��� 60�ʷ� ����
            timeLeft = totalTime;

            // ���α׷��� �� ����
            progressBar1.Maximum = totalTime;
            progressBar1.Value = totalTime;

            // Ÿ�̸� ����: 1�ʸ��� Tick �̺�Ʈ �߻�
            timer_Time.Interval = 1000; // 1��
            timer_Time.Tick += timer_Time_Tick; // Tick�� �߻��ϸ� timer_Time_Tick ����
            timer_Time.Start(); // ����

            // ��鸲 ȿ���� Ÿ�̸� ����: 0.05�ʸ��� Tick
            timerEffect.Interval = 50;
            timerEffect.Tick += timerEffect_Tick;
        }

        // �ð� Ÿ�̸� Tick �̺�Ʈ: 1�ʸ��� ����
        private void timer_Time_Tick(object sender, EventArgs e)
        {
            if (timeLeft > 0)
            {
                timeLeft--; // ���� �ð� 1�ʾ� ����
                progressBar1.Value = timeLeft; // ���α׷��� �� ����
            }
            else
            {
                timer_Time.Stop(); // �ð��� �� �Ǹ� Ÿ�̸� ����
                MessageBox.Show("Game over!");
            }
        }

        // ���� ȿ��: ��鸲 ���� ��� �׵θ� ��� ǥ��
        private void ShowCorrectEffect(PictureBox pb)
        {
            if (pb == null) return;

            yellowBorderPictureBox = pb;   // ��� �׵θ� ǥ�� ��� ����
            showYellowBorder = true;       // ��� �׵θ� ǥ�� �ѱ�
            pb.Invalidate();               // �ٽ� �׸��� ��û (�׵θ� ǥ�� ����)

            // 0.3�� �Ŀ� ��� �׵θ� ������ Ÿ�̸� ���� �� ����
            System.Windows.Forms.Timer yellowBorderTimer = new System.Windows.Forms.Timer();
            yellowBorderTimer.Interval = 300; // 0.3��
            yellowBorderTimer.Tick += YellowBorderTimer_Tick;
            yellowBorderTimer.Start();
        }

        // ��� �׵θ� Ÿ�̸� Tick �̺�Ʈ �ڵ鷯 (�Ϲ� �޼���)
        private void YellowBorderTimer_Tick(object sender, EventArgs e)
        {
            System.Windows.Forms.Timer timer = sender as System.Windows.Forms.Timer;
            if (timer == null) return;

            showYellowBorder = false;                      // ��� �׵θ� ����
            if (yellowBorderPictureBox != null)
            {
                yellowBorderPictureBox.Invalidate();       // �ٽ� �׷��� �׵θ� ����
                yellowBorderPictureBox = null;             // ��� ����
            }

            timer.Stop();                                  // Ÿ�̸� ����
            timer.Dispose();                               // �޸� ����
        }

        // ���� ȿ��: �¿� ���� + ���� �׵θ�
        private void ShakeAndRedBorder(PictureBox pb)
        {
            if (pb == null) return;

            targetPictureBox = pb; // ȿ���� �� ��� ����
            startX = pb.Location.X; // ���� X ��ġ ����
            shakeCount = 0; // ��鸲 Ƚ�� �ʱ�ȭ
            showRedBorder = true; // �׵θ� ���̰� ����
            pb.Invalidate(); // ������ �ٽ� �׸��� ��û (�׵θ� �ݿ� ����)

            timerEffect.Start(); // ���� ȿ�� Ÿ�̸� ����
        }

        // ���� ȿ���� ����� Ÿ�̸� Tick �̺�Ʈ
        private void timerEffect_Tick(object sender, EventArgs e)
        {
            if (targetPictureBox == null) return;
            // ���� ���� �� ���� �� ���� ����

            if (shakeCount < 10)
            {
                // Ȧ��/¦���� ���� �¿� �̵�
                int moveAmount = (shakeCount % 2 == 0) ? 5 : -5;
                targetPictureBox.Left = startX + moveAmount;
                shakeCount++;
            }
            else
            {
                // ���� ������ ��ġ ���� �� �׵θ� ����
                timerEffect.Stop();
                targetPictureBox.Left = startX;
                showRedBorder = false;
                targetPictureBox.Invalidate(); // �ٽ� �׷��� �׵θ� ����
                targetPictureBox = null; // ȿ�� ����
            }
        }

        // Ŭ�� �̺�Ʈ (�̰Ŵ� �ٸ��а� �־���ؼ�)
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

        // �̺�Ʈ // ����/��� �׵θ�
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

        // ���� �׵θ� �׸��� ���� �Լ�
        private void DrawRedBorder(PaintEventArgs e, PictureBox pb)
        {
            using (Pen pen = new Pen(Color.Red, 5)) // �׵θ� ����5, ������
            {
                Rectangle rect = new Rectangle(0, 0, pb.Width - 1, pb.Height - 1);
                e.Graphics.DrawRectangle(pen, rect); // �׵θ� �׸�
            }
        }

        // ��� �׵θ� �׸��� �Լ�
        private void DrawYellowBorder(PaintEventArgs e, PictureBox pb)
        {
            using (Pen pen = new Pen(Color.Yellow, 5)) // �׵θ� ����5, �����
            {
                Rectangle rect = new Rectangle(0, 0, pb.Width - 1, pb.Height - 1);
                e.Graphics.DrawRectangle(pen, rect);
            }
        }
    }
}
    }
}
