using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        int count = 99;

        public void OpenCVImage()
        {
            

            string path = "D:\\cap\\" + count + "aaa.png";

            ImageProcessing(path);
            count++;
        }

        

        private void ImageProcessing(string uri)
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
            Cv2.Threshold(gray, binary, 120, 255, ThresholdTypes.Binary);
            // 노이즈 제거
            Cv2.MedianBlur(binary, blur, ksize: 1);

            
            Point[][] contours;
            HierarchyIndex[] hierarchy;

            src.CopyTo(result);

            Cv2.InRange(blur, new Scalar(0, 127, 127), new Scalar(100, 255, 255), line);
            Cv2.FindContours(line, out contours, out hierarchy, RetrievalModes.Tree, ContourApproximationModes.ApproxTC89KCOS);

            List<Point[]> new_contours = new List<Point[]>();

            foreach (Point[] p in contours)
            {
                double length = Cv2.ArcLength(p, true);
                if(length > 15 && length < 200)
                {
                    new_contours.Add(p);
                    
                    //Debug.WriteLine(new_contours);
                }
            }


            for(int i = 0; i < new_contours.Count; i++)
            {
                Debug.WriteLine("0번 인덱스" + new_contours[i][0]);
                Debug.WriteLine("1번 인덱스" + new_contours[i][1]);
            }


            
            
           


            Cv2.DrawContours(result, new_contours, -1, Scalar.Red, 2, LineTypes.AntiAlias);
            

            /*
            Mat hierarchy1 = new Mat();
            Mat src2 = new Mat();
            src.CopyTo(src2);
            Cv2.FindContours(blur, out Mat[] contour1, hierarchy1, RetrievalModes.Tree, ContourApproximationModes.ApproxSimple);
            for (int i = 0; i < contour1.Length; i++)
            {
                Cv2.DrawContours(src2, contour1, i, Scalar.Red, 3, LineTypes.AntiAlias);
            }
            */
            

            // 이미지 생성
            Cv2.ImWrite(@"D:\\cap\\" + count + "bbb.png", result);
            Cv2.ImWrite(@"D:\\cap\\" + count + "ccc.png", line);

            MotoPray.motoPray.pbRemaster.Image = Bitmap.FromFile("D:\\cap\\" + count + "bbb.png");
            MotoPray.motoPray.pbRemaster.SizeMode = PictureBoxSizeMode.StretchImage;

            MotoPray.motoPray.pbOrigin.Image = Bitmap.FromFile("D:\\cap\\" + count + "ccc.png");
            MotoPray.motoPray.pbOrigin.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        
        // 이미지를 캡쳐하는 함수
        public void ImageCapture()
        {
            

            string path = "D:\\cap\\" + count + "aaa.png";

            

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

            
        }


    }
}
