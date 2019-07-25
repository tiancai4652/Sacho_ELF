using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace InputAction
{
    public class MouseMove
    {
        [DllImport("user32.dll")]
        private static extern bool GetCursorPos(out TempPoint lpPoint);

        [DllImport("user32.dll", EntryPoint = "SetCursorPos")]
        private static extern int SetCursorPos(int x, int y);

        [StructLayout(LayoutKind.Sequential)]
        private struct TempPoint
        {
            public int X;
            public int Y;
            public TempPoint(int x, int y)
            {
                this.X = x;
                this.Y = y;
            }
        }

        static Point ConvertToPoint(TempPoint tp)
        {
            return new Point(tp.X, tp.Y);
        }

        /// <summary>
        /// 获取当前鼠标位于屏幕的位置
        /// </summary>
        /// <returns></returns>
        public static Point GetMouseScreenLocation()
        {
            var p = new TempPoint();
            if (GetCursorPos(out p))
            {
                return ConvertToPoint(p);
            }
            return new Point(0,0);
        }

        /// <summary>
        /// 设置鼠标位于屏幕的位置
        /// </summary>
        /// <param name="point"></param>
        public static void SetMouseScreenLocation(Point point)
        {
            SetCursorPos(point.X, point.Y);
        }
    }
}
