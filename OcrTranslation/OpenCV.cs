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

            // 영역을 표시하기 위한 코드
            // 글자와 이미지 등을 구별하지 못하므로 조건을 이용하여 글자를 찾아내기
            Point[][] contours;
            HierarchyIndex[] hierarchy;

            src.CopyTo(result);

            Cv2.InRange(blur, new Scalar(0, 127, 127), new Scalar(100, 255, 255), line);
            Cv2.FindContours(line, out contours, out hierarchy, RetrievalModes.Tree, ContourApproximationModes.ApproxTC89KCOS);

            List<Point[]> new_contours = new List<Point[]>();

            foreach (Point[] p in contours)
            {
                double length = Cv2.ArcLength(p, true);
                // 일정 길이만을 추출해서 최대한 글자가 포함되게 설정
                if(length > 15 && length < 200)
                {
                    new_contours.Add(p);
                    
                    //Debug.WriteLine(new_contours);
                }
            }

           

            // 좌표값만 저장하기 위해 2차원 배열 선언
            // X 좌표는 0번, Y 좌표는 1번 인덱스에 저장
            // new_contours의 1번 인덱스의 값을 사용
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

            // 좌표 값들을 Y값을 기준으로 정렬하는 코드

            int yLocationCount = 0;
            int[,] ySort = (int[,])location.Clone();

            for(int j = 0; j < ySort.GetLength(0); j++)
            {
                yLocationCount = 0;

                for (int i = 1; i < ySort.GetLength(0); i++)
                {
                    int xValue = 0;
                    int yValue = 0;

                    if (ySort[i - 1, 1] > ySort[i, 1])
                    {
                        xValue = ySort[i - 1, 0];
                        yValue = ySort[i - 1, 1];

                        ySort[i - 1, 0] = ySort[i, 0];
                        ySort[i - 1, 1] = ySort[i, 1];

                        ySort[i, 0] = xValue;
                        ySort[i, 1] = yValue;

                        xValue = 0;
                        yValue = 0;
                    }
                    else if (ySort[i - 1, 1] == ySort[i, 1])
                    {
                        if (ySort[i - 1, 0] > ySort[i, 0])
                        {
                            xValue = ySort[i - 1, 0];

                            ySort[i - 1, 0] = ySort[i, 0];
                            ySort[i, 0] = xValue;

                            xValue = 0;
                        }
                        // Y좌표값이 겹치는 경우를 카운트
                        yLocationCount++;
                    }

                }
            }

            // 좌표 값들을 X값을 기준으로 정렬하는 코드
            int xLocationCount = 0;
            int[,] xSort = (int[,])location.Clone();

            for (int j = 0; j < xSort.GetLength(0); j++)
            {
                xLocationCount = 0;

                for (int i = 1; i < xSort.GetLength(0); i++)
                {
                    int xValue = 0;
                    int yValue = 0;

                    if (xSort[i - 1, 0] > xSort[i, 0])
                    {
                        xValue = xSort[i - 1, 0];
                        yValue = xSort[i - 1, 1];

                        xSort[i - 1, 0] = xSort[i, 0];
                        xSort[i - 1, 1] = xSort[i, 1];

                        xSort[i, 0] = xValue;
                        xSort[i, 1] = yValue;

                        xValue = 0;
                        yValue = 0;
                    }
                    else if (xSort[i - 1, 0] == xSort[i, 0])
                    {
                        if (xSort[i - 1, 1] > xSort[i, 1])
                        {
                            yValue = xSort[i - 1, 1];

                            xSort[i - 1, 1] = xSort[i, 1];
                            xSort[i, 1] = yValue;

                            yValue = 0;
                        }
                        // X좌표값이 겹치는 경우를 카운트
                        xLocationCount++;
                    }

                }
            }

            Debug.WriteLine(yLocationCount);
            Debug.WriteLine(xLocationCount);

            // 좌표값을 동일한 경우 최대값과 최소값으로 구분하여 나누기
            /*
                0번 인덱스 : Min X 좌표
                1번 인덱스 : Max X 좌표
                2번 인덱스 : Y 좌표
            */
            int[,] mmYLocation = new int[yLocationCount, 3];

            int minXLoc = 0;
            int MaxXLoc = 0;
            int YLoc = 0;

            int mmYLocationCount = 0;

            YLoc = ySort[0, 1];

            minXLoc = ySort[0, 0];
            MaxXLoc = ySort[0, 0];

            for (int i = 1; i < ySort.GetLength(0); i++)
            {
                

                if(YLoc == ySort[i, 1])
                {
                    if(minXLoc > ySort[i, 0])
                    {
                        minXLoc = ySort[i, 0];
                    }
                    else if(MaxXLoc < ySort[i, 0])
                    {
                        MaxXLoc = ySort[i, 0];
                    }
                }
                else if(YLoc != ySort[i, 1])
                {
                    mmYLocation[mmYLocationCount, 0] = minXLoc;
                    mmYLocation[mmYLocationCount, 1] = MaxXLoc;
                    mmYLocation[mmYLocationCount, 2] = YLoc;

                    mmYLocationCount++;

                    YLoc = ySort[i, 1];
                    minXLoc = ySort[i, 0];
                    MaxXLoc = ySort[i, 0];
                }

            }

            // 좌표값을 동일한 경우 최대값과 최소값으로 구분하여 나누기
            /*
                0번 인덱스 : Min Y 좌표
                1번 인덱스 : Max Y 좌표
                2번 인덱스 : X 좌표
            */
            int[,] mmXLocation = new int[xLocationCount * 2, 3];

            int minYLoc = 0;
            int MaxYLoc = 0;
            int XLoc = 0;

            int mmXLocationCount = 0;

            XLoc = xSort[0, 0];

            minYLoc = xSort[0, 1];
            MaxYLoc = xSort[0, 1];

            for (int i = 1; i < xSort.GetLength(0); i++)
            {


                if (XLoc == xSort[i, 0])
                {
                    if (minYLoc > xSort[i, 1])
                    {
                        minYLoc = xSort[i, 1];
                    }
                    else if (MaxYLoc < xSort[i, 1])
                    {
                        MaxYLoc = xSort[i, 1];
                    }
                }
                else if (XLoc != xSort[i, 0])
                {
                    mmXLocation[mmXLocationCount, 0] = minYLoc;
                    mmXLocation[mmXLocationCount, 1] = MaxYLoc;
                    mmXLocation[mmXLocationCount, 2] = XLoc;

                    mmXLocationCount++;

                    XLoc = xSort[i, 0];
                    minYLoc = xSort[i, 1];
                    MaxYLoc = xSort[i, 1];
                }

            }



            // minX, MaxX, minY, MaxY의 값을 구하고 Rectangle로 영역 지정
            int minX = 0;
            int minY = 0;
            int maxX = 0;
            int maxY = 0;

            int[,] rectLocation = new int[ySort.GetLength(0), 4];
            int rectCount = 0;

            minX = ySort[0, 0];
            minY = ySort[0, 1];
            maxX = ySort[0, 0];
            maxY = ySort[0, 1];

            for (int i = 1; i < ySort.GetLength(0); i++)
            {
                int baseY = (int)(minY + maxY) / 2;
                int baseX = (int)(minX + maxX) / 2;

                if(ySort[i, 1] + 3 > maxY || ySort[i, 1] - 3 < minY)
                {
                    if(ySort[i, 0] + 50 > maxX || ySort[i, 0] - 50 < minX)
                    {
                        if (minY > ySort[i, 1])
                        {
                            minY = ySort[i, 1];
                        }
                        else if (maxY < ySort[i, 1])
                        {
                            maxY = ySort[i, 1];
                        }
                        
                        if(minX > ySort[i, 0])
                        {
                            minX = ySort[i, 0];
                        }
                        else if(maxX < ySort[i, 0])
                        {
                            maxX = ySort[i, 0];
                        }
                    }
                    else
                    {
                        rectLocation[rectCount, 0] = minX;
                        rectLocation[rectCount, 1] = minY;
                        rectLocation[rectCount, 2] = maxX;
                        rectLocation[rectCount, 3] = maxY;

                        minX = ySort[i, 0];
                        minY = ySort[i, 1];
                        maxX = ySort[i, 0];
                        maxY = ySort[i, 1];

                        rectCount++;
                    }

                    
                }
                else
                {
                    rectLocation[rectCount, 0] = minX;
                    rectLocation[rectCount, 1] = minY;
                    rectLocation[rectCount, 2] = maxX;
                    rectLocation[rectCount, 3] = maxY;

                    minX = ySort[rectCount, 0];
                    minY = ySort[rectCount, 1];
                    maxX = ySort[rectCount, 0];
                    maxY = ySort[rectCount, 1];

                    rectCount++;
                }

                

            }

            // 좌표값을 압축시켜주는 코드
            int width = 0;
            int height = 0;

            width = rectLocation[0,2] - rectLocation[0, 0];
            height = rectLocation[0,3] - rectLocation[0, 1];

            int[,] rectCompess = new int[1000, 4];
            int[,] rectCompess2;
            int rectCompessCount = 0;

            rectCompess2 = rectLocation;

            for(int j = 0; j < 0; j++)
            {
                

                for (int i = 1; i < rectCompess2.GetLength(0); i += 2)
                {
                    if (rectCompess2[i, 0] == 0 && rectCompess2[i, 1] == 0 && rectCompess2[i, 2] == 0 && rectCompess2[i, 3] == 0)
                    {
                        break;
                    }

                    if (rectCompess2[i - 1, 0] + 100 > rectCompess2[i, 0] && rectCompess2[i - 1, 0] < rectCompess2[i, 0])
                    {
                        rectCompess[rectCompessCount, 0] = rectCompess2[i - 1, 0];
                    }
                    else
                    {
                        rectCompess[rectCompessCount, 0] = rectCompess2[i, 0];
                    }

                    if (rectCompess2[i - 1, 1] + 100 > rectCompess2[i, 1] && rectCompess2[i - 1, 1] < rectCompess2[i, 1])
                    {
                        rectCompess[rectCompessCount, 1] = rectCompess2[i - 1, 1];
                    }
                    else
                    {
                        rectCompess[rectCompessCount, 1] = rectCompess2[i, 1];
                    }

                    if (rectCompess2[i - 1, 2] < rectCompess2[i, 2] + 100 && rectCompess2[i - 1, 2] > rectCompess2[i, 2])
                    {
                        rectCompess[rectCompessCount, 2] = rectCompess2[i - 1, 2];
                    }
                    else
                    {
                        rectCompess[rectCompessCount, 2] = rectCompess2[i, 2];
                    }

                    if (rectCompess2[i - 1, 3] < rectCompess2[i, 3] + 100 && rectCompess2[i - 1, 3] > rectCompess2[i, 3])
                    {
                        rectCompess[rectCompessCount, 3] = rectCompess2[i - 1, 3];
                    }
                    else
                    {
                        rectCompess[rectCompessCount, 3] = rectCompess2[i, 3];
                    }

                    rectCompessCount++;
                }

                rectCompess2 = rectCompess;
                rectCompess = new int[1000, 4];
                rectCompessCount = 0;

            }


            rectCompess = rectCompess2;

            

           

           

            


            for (int i = 0; i < rectCompess.GetLength(0); i++)
            {
                Debug.WriteLine(rectCompess[i, 0] + "  " + rectCompess[i, 1] + "  " + rectCompess[i, 2] + "  " + rectCompess[i, 3]);
            }

            
            // 좌표값으로 사각형을 그려주는 코드
            for(int i = 0; i < rectCompess.GetLength(0); i++)
            {
                //Debug.WriteLine(rectLocation[i, 0] + "  " + rectLocation[i, 1] + "  " + rectLocation[i, 2] + "  " + rectLocation[i, 3]);

                if (!(rectCompess[i, 0] == 0 && rectCompess[i, 1] == 0 && rectCompess[i, 2] == 0 && rectCompess[i, 3] == 0))
                {
                    

                    if (rectCompess[i, 2] - rectCompess[i, 0] > 2000 || rectCompess[i, 3] - rectCompess[i, 1] > 2000)
                    {
                        
                    }
                    else
                    {
                        if (rectCompess[1, 2] - rectCompess[i, 0] > 0 || rectCompess[i, 3] - rectCompess[i, 1] > 0)
                        {
                            
                        }
                        else
                        {
                            
                        }
                        

                    }
                }
                else
                {
                    break;
                }
                Rect locationRect = new Rect(rectCompess[i, 0] + 10, rectCompess[i, 1] - 50, rectCompess[i, 2], rectCompess[i, 3]);
                Cv2.Rectangle(result, locationRect, Scalar.YellowGreen, 2);


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
