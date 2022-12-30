using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;
using Point = OpenCvSharp.Point;

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

            //mat = new Mat(path, ImreadModes.Grayscale);
            //Cv2.ImWrite(@"D:\\cap\\" + 99 + "bbb.png", mat);

            // 이미지 가져오기
            Mat src = new Mat(path);
            Mat gray = new Mat();
            Mat binary = new Mat();
            Mat blur = new Mat();
            Mat dilation = new Mat();
            Mat line = new Mat();
            Mat result = new Mat();

            // GrayScale로 변환
            Cv2.CvtColor(src, gray, ColorConversionCodes.BGR2GRAY);
            // 바이너리, 이진화로 흑백으로 변환
            Cv2.Threshold(gray, binary, 50, 255, ThresholdTypes.Binary);
            // 노이즈 제거
            Cv2.MedianBlur(binary, blur, ksize: 1);

            Point[][] contours;
            HierarchyIndex[] hierarchy;

            result = blur.Clone();

            Cv2.InRange(blur, new Scalar(0, 127, 127), new Scalar(100, 255, 255), line);
            Cv2.FindContours(line, out contours, out hierarchy, RetrievalModes.Tree, ContourApproximationModes.ApproxTC89KCOS);

            List<Point[]> new_contours = new List<Point[]>();

            foreach (Point[] p in contours)
            {
                double length = Cv2.ArcLength(p, true);
                if(length > 10)
                {
                    new_contours.Add(p);
                }
            }

            

            Cv2.DrawContours(result, new_contours, -1, new Scalar(255, 0, 0), 2, LineTypes.AntiAlias, null, 1);

            // 이미지 생성
            Cv2.ImWrite(@"D:\\cap\\" + 99 + "bbb.png", result);

            MotoPray.motoPray.pbRemaster.Image = Bitmap.FromFile("D:\\cap\\" + 99 + "bbb.png");
            MotoPray.motoPray.pbRemaster.SizeMode = PictureBoxSizeMode.StretchImage;
        }

       
        // 이미지를 캡쳐하는 함수
        public void ImageCapture()
        {
            int count = 99;

            string path = "D:\\cap\\" + count + "aaa.png";

            count++;

            int refX = 0;
            int refY = 0;
            int imgW = Screen.PrimaryScreen.Bounds.Width;
            int imgH = Screen.PrimaryScreen.Bounds.Height;

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
