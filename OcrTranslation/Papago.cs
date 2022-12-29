using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OcrTranslation
{
    internal class Papago
    {
        public void Translation(int txtLen)
        {
            // Papago API 사용을 위한 객체 생성
            WebRequest webRequest = null;
            WebResponse webResponse = null;
            Stream stream = null;
            StreamReader streamReader = null;

            // Papago API url
            string url = "https://openapi.naver.com/v1/papago/n2mt";

            // 번역할 텍스트의 라인별로 번역
            for (int i = 0; i < txtLen; i++)
            {

                if (MotoPray.motoPray.txtTest1.Lines[i] != "")   //this.txtTranslation.Lines[i] != ""
                {
                    string param = String.Format("source=en&target=ko&text={0}", MotoPray.motoPray.txtTest1.Lines[i]);

                    byte[] bytearray = Encoding.UTF8.GetBytes(param);

                    webRequest = WebRequest.Create(url);
                    webRequest.Method = "POST";
                    webRequest.ContentType = "application/x-www-form-urlencoded";
                    webRequest.Headers.Add("X-Naver-Client-Id", "RAsF16FVQVOI6TS7a7Dy");
                    webRequest.Headers.Add("X-Naver-Client-Secret", "VSGwbT9kKl");

                    webRequest.ContentLength = bytearray.Length;

                    stream = webRequest.GetRequestStream();
                    stream.Write(bytearray, 0, bytearray.Length);
                    stream.Close();

                    webResponse = webRequest.GetResponse();
                    stream = webResponse.GetResponseStream();
                    streamReader = new StreamReader(stream);
                    string sReturn = streamReader.ReadToEnd();

                    streamReader.Close();
                    stream.Close();
                    webResponse.Close();

                    JObject jObject = JObject.Parse(sReturn);

                    MotoPray.motoPray.txtTest2.Text += jObject["message"]["result"]["translatedText"].ToString() + Environment.NewLine;
                }
                else
                {
                    MotoPray.motoPray.txtTest2.Text += Environment.NewLine;
                }
            }

        }

    }
}
