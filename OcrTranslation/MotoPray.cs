namespace OcrTranslation
{
    public partial class MotoPray : Form
    {
        public static MotoPray motoPray;

        // ���� ���۰� ������ ��Ÿ���� ���� �ڷ���
        bool startSwitch = false;


        public MotoPray()
        {
            InitializeComponent();
            motoPray = this;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            startSwitch = true;

            //�׽�Ʈ �ڵ�
            Papago papago = new Papago();
            papago.Translation(this.txtTest1.Lines.Length);

        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            startSwitch = false;
        }
    }
}