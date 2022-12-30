namespace OcrTranslation
{
    public partial class MotoPray : Form
    {
        // 외부에서 폼에 접근하기 위해 선언
        public static MotoPray motoPray;

        // 번역 시작과 중지를 나타내기 위한 자료형
        bool startSwitch = false;

        public int screenSelect = -1;

        public MotoPray()
        {
            InitializeComponent();
            motoPray = this;
        }

        private void MotoPray_Load(object sender, EventArgs e)
        {
            // 화면의 갯수를 반환하는 함수 및 comboBox에 추가
            ScreenEvent sc = new ScreenEvent();

            screenSelect = sc.ScreenDetect();

            for(int i =0; i < screenSelect; i++)
            {
                this.cbScreenSelect.Items.Add(String.Format("{0}번 화면", i + 1));
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            startSwitch = true;

            //테스트 코드
            //Papago papago = new Papago();
            //papago.Translation(this.txtTest1.Lines.Length);

            OpenCV cv = new OpenCV();

            cv.ImageCapture();
            cv.OpenCVImage();

            Ocr ocr = new Ocr();

            ocr.ImageOcr();


        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            startSwitch = false;
        }

        private void btnLocation_Click(object sender, EventArgs e)
        {
            // 테스트
            
        }

        
    }
}