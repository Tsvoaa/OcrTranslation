namespace OcrTranslation
{
    public partial class MotoPray : Form
    {
        // �ܺο��� ���� �����ϱ� ���� ����
        public static MotoPray motoPray;

        // ���� ���۰� ������ ��Ÿ���� ���� �ڷ���
        bool startSwitch = false;

        public int screenSelect = -1;

        public MotoPray()
        {
            InitializeComponent();
            motoPray = this;
        }

        private void MotoPray_Load(object sender, EventArgs e)
        {
            // ȭ���� ������ ��ȯ�ϴ� �Լ� �� comboBox�� �߰�
            ScreenEvent sc = new ScreenEvent();

            screenSelect = sc.ScreenDetect();

            for(int i =0; i < screenSelect; i++)
            {
                this.cbScreenSelect.Items.Add(String.Format("{0}�� ȭ��", i + 1));
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            startSwitch = true;

            //�׽�Ʈ �ڵ�
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
            // �׽�Ʈ
            
        }

        
    }
}