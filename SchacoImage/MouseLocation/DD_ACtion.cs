using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InputAction
{
    /// <summary>
    /// 使用DD模块模拟键盘鼠标操作
    /// </summary>
    public class DD_ACtion
    {
        static CDD dd;

        /// <summary>
        /// 此操作需要管理员权限
        /// </summary>
        static DD_ACtion()
        {
            dd = new CDD();
            string path = "Dll\\DD81200x64.32.dll";
            if (!LoadDllFile(path))
            {
                throw new Exception();
            }
        }

        static bool LoadDllFile(string dllfile)
        {
            dd = new CDD();
            System.IO.FileInfo fi = new System.IO.FileInfo(dllfile);
            if (!fi.Exists)
            {
                System.Windows.Forms.MessageBox.Show("文件不存在");
                return false;
            }
            int ret = dd.Load(dllfile);
            if (ret == -2) { System.Windows.Forms.MessageBox.Show("装载库时发生错误"); return false; }
            if (ret == -1) { System.Windows.Forms.MessageBox.Show("取函数地址时发生错误"); return false; }
            if (ret == 0) { /*System.Windows.Forms.MessageBox.Show("非增强模块"); */}

            return true;
        }

        /// <summary>
        /// 鼠标左键点击,使用前必须先调用LoadDll或SetDD方法
        /// </summary>
        /// <param name="MouseDownDurationDelay">鼠标按下持续时间</param>
        /// <param name="AfterClickDelay">鼠标点击后的延迟(多次连续点击间的延迟)</param>
        public static void MouseLeftClick(int MouseKeepDownDelay=100, int AfterClickDelay = 100)
        {
            dd.btn(1);
            Thread.Sleep(MouseKeepDownDelay);
            dd.btn(2);
            dd.btn(2);
            Thread.Sleep(AfterClickDelay);
        }

        /// <summary>
        /// 鼠标右键点击,使用前必须先调用LoadDll或SetDD方法
        /// </summary>
        /// <param name="MouseDownDurationDelay">鼠标按下持续时间</param>
        /// <param name="AfterClickDelay">鼠标点击后的延迟(多次连续点击间的延迟)</param>
        public static void MouseRightClick(int MouseKeepDownDelay = 100, int AfterClickDelay = 100)
        {
            dd.btn(4);
            Thread.Sleep(MouseKeepDownDelay);
            dd.btn(8);
            Thread.Sleep(AfterClickDelay);
        }

        /// <summary>
        /// 键盘按键,使用前必须先调用LoadDll或SetDD方法
        /// </summary>
        /// <param name="key">要按的键</param>
        /// <param name="KeyKeepDownDelay">键触底时间</param>
        /// <param name="AfterKeyboardDelay">键与键之间的延迟(多次连续按键的延迟)</param>
        public static void Keyboard(Keys key,int KeyKeepDownDelay=100,int AfterKeyboardDelay=200)
        {
            if (KeyToDDKey.Dic.Keys.Contains(key))
            {
                dd.key(KeyToDDKey.Dic[key], 1);
                Thread.Sleep(KeyKeepDownDelay);
                dd.key(KeyToDDKey.Dic[key], 2);
                Thread.Sleep(AfterKeyboardDelay);
            }
            else
            {
                throw new Exception("No Kyes in the Dictionary.");
            }
        }

    }
}
