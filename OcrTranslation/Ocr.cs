using IronOcr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OcrTranslation
{
    internal class Ocr
    {
        private static int count = 99;
        private static string path = "D:\\cap\\" + count + "bbb.png";

        public void ImageOcr()
        {
            //Bitmap oc = (Bitmap)this.pbCapture.Image;
            var Ocr = new IronTesseract();

            Ocr.Language = OcrLanguage.English;

            /*
            switch (this.cbBefore.SelectedItem.ToString())
            {
                case "한국어":
                    Ocr.Language = OcrLanguage.Korean;
                    break;
                case "일본어":
                    Ocr.Language = OcrLanguage.Japanese;
                    break;
                case "영어":
                    Ocr.Language = OcrLanguage.English;
                    break;
            }
            */

            using (var Input = new OcrInput(@path))
            {
                // 디지털 노이즈 및 스캔 불량 수정
                //Input.DeNoise();
                //Input.Contrast();
                // 회전 및 원근 수정
                //Input.Deskew();
                //Input.EnhanceResolution();

                var Result = Ocr.Read(Input);
                MotoPray.motoPray.txtTest1.Text = Result.Text;
            }
        }

    }
}
