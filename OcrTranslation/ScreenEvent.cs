using Gma.System.MouseKeyHook;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OcrTranslation
{
    internal class ScreenEvent
    {
        // 마우스의 좌표값
        public static int mouseDownX = 0;
        public static int mouseDownY = 0;
        public static int mouseUpX = 0;
        public static int mouseUpY = 0;

        // 마우스 훅 사용을 위한 스위치
        bool MouseDownSwitch = false;
        bool MouseUpSwitch = false;
        bool MouseMoveSwitch = false;

        public int ScreenDetect()
        {
            Screen[] sc = Screen.AllScreens;

            return sc.Length;
        }

        public void ScreenCapture()
        {
            // 운영체제가 받는 마우스 메시지를 훔쳐오기 위한 훅 선언
            IKeyboardMouseEvents globalHook;

            globalHook = Hook.GlobalEvents();

            globalHook.MouseDown += globalHookMouseDown;
            globalHook.MouseUp += globalHookMouseUp;
            globalHook.MouseMove += globalHookMouseMove;

            MouseDownSwitch = true;
            
        }

        public void ScreenFinder()
        {
            // 현재 모니터 화면을 이미지로 설정
            ImageFinderNS.ImageFinder.SetSource(ImageFinderNS.ImageFinder.MakeScreenshot());

            // 바탕화면에 찾을 이미지를 검색한 후 유사도를 설정
            // 유사도는 float 값으로 1.0f로 설정
            var finds = ImageFinderNS.ImageFinder.Find(Image.FromFile(@"filePath"), 1.0f);

            foreach(var find in finds)
            {
                // 유사도가 90프로 일치하면 클릭
                if(find.Similarity > 0.9f)
                {
                    // 찾은 이미지의 크기만큼 rect 선언
                    Rectangle rect = find.Zone;

                    
                }
            }
        }

        // 마우스 다운 이벤트
        private void globalHookMouseDown(object sender, MouseEventArgs e)
        {
            if(MouseDownSwitch)
            {
                mouseDownX = int.Parse(Cursor.Position.X.ToString());
                mouseDownY = int.Parse(Cursor.Position.Y.ToString());

                MouseUpSwitch = true;
                MouseMoveSwitch = true;
                MouseDownSwitch = false;
            }
        }
        
        // 마우스 업 이벤트
        private void globalHookMouseUp(object sender, MouseEventArgs e)
        {
            if (MouseUpSwitch)
            {
                mouseUpX = int.Parse(Cursor.Position.X.ToString());
                mouseUpY = int.Parse(Cursor.Position.Y.ToString());

                MouseMoveSwitch = false;
                MouseUpSwitch = false;
            }
        }

        // 마우스 무브 이벤트
        private void globalHookMouseMove(object sender, MouseEventArgs e)
        {
            if (MouseMoveSwitch)
            {

            }
        }


    }
}
