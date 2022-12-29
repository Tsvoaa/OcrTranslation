using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;

namespace OcrTranslation
{
    internal class OpenCV
    {

        Mat mat = new Mat();

        public void OpenCVImage()
        {
            

            int count = 99;

            string path = "D:\\cap\\" + count + "aaa.png";

            GrayScale(path);

        }

        private void GrayScale(string uri)
        {
            string path = uri;

            mat = new Mat(path, ImreadModes.Grayscale);
            Cv2.ImWrite(@"D:\\cap\\" + 99 + "bbb.png", mat);

            MotoPray.motoPray.pbRemaster.Image = Bitmap.FromFile("D:\\cap\\" + 99 + "bbb.png");
            MotoPray.motoPray.pbRemaster.SizeMode = PictureBoxSizeMode.StretchImage;
        }

       

        public void ImageCapture()
        {
            int count = 99;

            string path = "D:\\cap\\" + count + "aaa.png";

            count++;

            int refX = 0;
            int refY = 0;
            int imgW = 500;
            int imgH = 500;

            if(imgW == 0 || imgH == 0)
            {
                return;
            }

            using(Bitmap bitmap = new Bitmap((int)imgW, (int)imgH))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.CopyFromScreen(refX, refY, 0, 0, bitmap.Size);
                }
                bitmap.Save(path, System.Drawing.Imaging.ImageFormat.Png);
            }

            MotoPray.motoPray.pbOrigin.Image = Bitmap.FromFile(path);
            MotoPray.motoPray.pbOrigin.SizeMode = PictureBoxSizeMode.StretchImage;
        }


    }
}
