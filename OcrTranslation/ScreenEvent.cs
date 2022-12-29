using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OcrTranslation
{
    internal class ScreenEvent
    {

        public int ScreenDetect()
        {
            Screen[] sc = Screen.AllScreens;

            return sc.Length;
        }

    }
}
