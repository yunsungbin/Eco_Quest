using static System.Formats.Asn1.AsnWriter;

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
    }
}
