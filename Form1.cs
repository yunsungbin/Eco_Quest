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
            gameForm.Show(); //게임 화면 열기
            this.Hide(); //현재 form 숨기기
        }
    }
}
