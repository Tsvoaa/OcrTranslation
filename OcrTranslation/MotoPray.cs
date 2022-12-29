namespace OcrTranslation
{
    public partial class MotoPray : Form
    {
        public static MotoPray motoPray;

        // 번역 시작과 중지를 나타내기 위한 자료형
        bool startSwitch = false;


        public MotoPray()
        {
            InitializeComponent();
            motoPray = this;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            startSwitch = true;

            //테스트 코드
            Papago papago = new Papago();
            papago.Translation(this.txtTest1.Lines.Length);

        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            startSwitch = false;
        }
    }
}