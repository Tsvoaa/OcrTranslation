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
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            startSwitch = false;
        }
    }
}