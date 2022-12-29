namespace OcrTranslation
{
    public partial class MotoPray : Form
    {
        bool startSwitch = false;


        public MotoPray()
        {
            InitializeComponent();
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