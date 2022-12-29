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



        }

    }
}
