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

           

            // 좌표값만 저장하기 위해 2차원 배열 선언
            // X 좌표는 0번, Y 좌표는 1번 인덱스에 저장
            int[,] location = new int[new_contours.Count, 2];
            
            for(int i = 0; i < new_contours.Count; i++)
            {
                // 순수 숫자 값만 가져오기 위해 문자열 가공
                string[] str = new_contours[i][1].ToString().Split(' ');
                str[0] = str[0].Substring(3);
                str[1] = str[1].Substring(2);
                str[1] = str[1].Substring(0, str[1].Length - 1);

                
                location[i, 0] = int.Parse(str[0]);
                location[i, 1] = int.Parse(str[1]);

                //Debug.Write(location[i, 0] + "  ");
                //Debug.WriteLine(location[i, 1] + "  1번");

            }
            
            /*
                X값 또는 Y값을 기준으로 크기순으로 좌표를 정리할 필요가 있음 
                X값 기준으로 정렬 시 값이 같다면 추가적으로 Y값을 비교하여 정리
                
                정리된 좌표값을 기준으로 X값 또는 Y값이 동일한 값들을 비교하여
                가장 작은 값과 가장 큰 값을 저장
            */

            // 좌표 값들을 X값을 기준으로 정렬하는 코드
            for(int j = 0; j < location.GetLength(0); j++)
            {
                for (int i = 1; i < location.GetLength(0); i++)
                {
                    int xValue = 0;
                    int yValue = 0;

                    if (location[i - 1, 0] > location[i, 0])
                    {
                        xValue = location[i - 1, 0];
                        yValue = location[i - 1, 1];

                        location[i - 1, 0] = location[i, 0];
                        location[i - 1, 1] = location[i, 1];

                        location[i, 0] = xValue;
                        location[i, 1] = yValue;

                        xValue = 0;
                        yValue = 0;
                    }
                    else if (location[i - 1, 0] == location[i, 0])
                    {
                        if (location[i - 1, 1] > location[i, 1])
                        {
                            yValue = location[i - 1, 1];

                            location[i - 1, 1] = location[i, 1];
                            location[i, 1] = yValue;

                            yValue = 0;
                        }
                    }

                }
            }

            

            for(int i = 0; i < location.GetLength(0); i++)
            {
                Debug.Write(location[i, 0] + "  ");
                Debug.WriteLine(location[i, 1] + "  2번");
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
