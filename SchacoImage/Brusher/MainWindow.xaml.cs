
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using InputAction;
using ImageIdentify;
using System.Windows.Forms;
using IdentifyImageByBaiduAI;

namespace Brusher
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            //InputAction.DD_ACtion.LoadDll();
            InitializeComponent();
            CurrentMousePoint = new PointModel();
            Task.Run(() =>
            {
                while (true)
                {
                    var point = global::InputAction.MouseMove.GetMouseScreenLocation();
                    CurrentMousePoint.X = point.X;
                    CurrentMousePoint.Y = point.Y;
                    Thread.Sleep(100);
                }
            });
            this.DataContext = this;
        }

        Thread tr;

        /// <summary>
        /// 鼠标当前点
        /// </summary>
        public PointModel CurrentMousePoint { get; set; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CurrentMousePoint.SetValue();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // Test Code
            //InputAction.MouseMove.SetMouseScreenLocation(new System.Drawing.Point(PointModel.StValueX, PointModel.StValueY));
            //InputAction.DD_ACtion.MouseLeftClick();
            //InputAction.DD_ACtion.Keyboard(Keys.F);

            if (CurrentMousePoint.StValueX == 0 || CurrentMousePoint.StValueY == 0)
            {
                return;
            }

            if (this.WindowState == WindowState.Normal)
            {
                this.WindowState = WindowState.Minimized;
            }

            Thread tr = new Thread(Run);
            tr.IsBackground = true;
            tr.Start();
        }

        void Run()
        {
            while (true)
            {

                InputAction.MouseMove.SetMouseScreenLocation(new System.Drawing.Point(CurrentMousePoint.StValueX, CurrentMousePoint.StValueY));
                Thread.Sleep(500);
                InputAction.DD_ACtion.MouseLeftClick();
                Thread.Sleep(500);

                ///移开鼠标
                InputAction.MouseMove.SetMouseScreenLocation(ItemLocation.OutItem);
                Thread.Sleep(500);
                ///截取当前图片
                ImageComare.GetAndSaveCurrentImage();
                Thread.Sleep(500);
                ///跟第一个图片对比
                //if (IdentifyByOpenCV.CompareImageByHistogram(ImageComare.ImageCurrent, ImageComare.Image1_3Item) < 0.0001)
                if (IdentifyImageByBaiduAI2.Identify(ImageComare.ImageCurrent, 4, null))
                {
                    InputAction.MouseMove.SetMouseScreenLocation(ItemLocation.Item2);
                    Thread.Sleep(500);
                    InputAction.DD_ACtion.MouseLeftClick();
                    Thread.Sleep(500);
                }

                Thread.Sleep(100);

                ///移开鼠标
                InputAction.MouseMove.SetMouseScreenLocation(ItemLocation.OutItem);
                Thread.Sleep(500);
                ///截取当前图片
                ImageComare.GetAndSaveCurrentImage();
                Thread.Sleep(500);
                ///跟第2个图片对比
                //if (IdentifyByOpenCV.CompareImageByHistogram(ImageComare.ImageCurrent, ImageComare.Image2_Enter2Item) < 0.0001)
                List<string> list2 = new List<string>() { "要", "哪", "里", "弄", "到", "粘", "土", "呢"};
                if (IdentifyImageByBaiduAI2.Identify(ImageComare.ImageCurrent, 2, list2.ToArray()))
                {
                    InputAction.MouseMove.SetMouseScreenLocation(ItemLocation.Item1);
                    Thread.Sleep(500);
                    InputAction.DD_ACtion.MouseLeftClick();
                    Thread.Sleep(500);
                }
                Thread.Sleep(500);

                ///移开鼠标
                InputAction.MouseMove.SetMouseScreenLocation(ItemLocation.OutItem);
                Thread.Sleep(500);
                ///截取当前图片
                ImageComare.GetAndSaveCurrentImage();
                Thread.Sleep(500);
                ///跟第3个图片对比
                //if (IdentifyByOpenCV.CompareImageByHistogram(ImageComare.ImageCurrent, ImageComare.Image3_Enter2Item) < 0.0001)
                List<string> list3 = new List<string>() { "明", "白", "了", "就", "来"};
                if (IdentifyImageByBaiduAI2.Identify(ImageComare.ImageCurrent, 2, list3.ToArray()))
                {
                    InputAction.MouseMove.SetMouseScreenLocation(ItemLocation.Item1);
                    Thread.Sleep(500);
                    InputAction.DD_ACtion.MouseLeftClick();
                    Thread.Sleep(500);
                }
                Thread.Sleep(500);

                ///移开鼠标
                InputAction.MouseMove.SetMouseScreenLocation(ItemLocation.OutItem);
                Thread.Sleep(500);
                ///截取当前图片
                ImageComare.GetAndSaveCurrentImage();
                Thread.Sleep(500);
                ///跟第4个图片对比
                //if (IdentifyByOpenCV.CompareImageByHistogram(ImageComare.ImageCurrent, ImageComare.Image4_Enter2Item) < 0.0001)
                if (IdentifyImageByBaiduAI2.Identify(ImageComare.ImageCurrent, 1, null))
                {
                    InputAction.MouseMove.SetMouseScreenLocation(ItemLocation.Item1);
                    Thread.Sleep(500);
                    InputAction.DD_ACtion.MouseLeftClick();
                    Thread.Sleep(500);
                }
                Thread.Sleep(500);

                ///移开鼠标
                InputAction.MouseMove.SetMouseScreenLocation(ItemLocation.OutItem);
                Thread.Sleep(500);
                ///截取当前图片
                ImageComare.GetAndSaveCurrentImage();
                Thread.Sleep(500);
                ///跟第5个图片对比
                //if (IdentifyByOpenCV.CompareImageByHistogram(ImageComare.ImageCurrent, ImageComare.Image5_Enter2Item) < 0.0001)
                if (IdentifyImageByBaiduAI2.Identify(ImageComare.ImageCurrent, 3, null))
                {
                    InputAction.MouseMove.SetMouseScreenLocation(ItemLocation.Item2);
                    Thread.Sleep(500);
                    InputAction.DD_ACtion.MouseLeftClick();
                    Thread.Sleep(500);
                }
                Thread.Sleep(500);

                ///移开鼠标
                InputAction.MouseMove.SetMouseScreenLocation(ItemLocation.OutItem);
                Thread.Sleep(500);
                ///截取当前图片
                ImageComare.GetAndSaveCurrentImage();
                Thread.Sleep(500);
                ///跟第6个图片对比
                //if (IdentifyByOpenCV.CompareImageByHistogram(ImageComare.ImageCurrent, ImageComare.Image6_Enter3Item) < 0.0001)
                List<string> list6 = new List<string>() { "是", "的", "请", "开", "始", "吧" };
                if (IdentifyImageByBaiduAI2.Identify(ImageComare.ImageCurrent, 2, list6.ToArray()))
                {
                    InputAction.MouseMove.SetMouseScreenLocation(ItemLocation.Item1);
                    Thread.Sleep(500);
                    InputAction.DD_ACtion.MouseLeftClick();
                    Thread.Sleep(500);
                }
                Thread.Sleep(500);

                ///移开鼠标
                InputAction.MouseMove.SetMouseScreenLocation(ItemLocation.OutItem);
                Thread.Sleep(500);
                ///截取当前图片
                ImageComare.GetAndSaveCurrentImage();
                Thread.Sleep(500);
                ///跟第Wrong图片对比
                //if (IdentifyByOpenCV.CompareImageByHistogram(ImageComare.ImageCurrent, ImageComare.ImageWrongImage) < 0.0001)
                List<string> listWrong = new List<string>() { "品", "茗", "赏", "器" };
                if (IdentifyImageByBaiduAI2.Identify(ImageComare.ImageCurrent, 2, listWrong.ToArray()))
                {
                    InputAction.MouseMove.SetMouseScreenLocation(ItemLocation.Item2);
                    Thread.Sleep(500);
                    InputAction.DD_ACtion.MouseLeftClick();
                    Thread.Sleep(500);
                }

                ///移开鼠标
                InputAction.MouseMove.SetMouseScreenLocation(ItemLocation.OutItem);
                Thread.Sleep(500);
                ///截取当前图片
                ImageComare.GetAndSaveESCImage();
                Thread.Sleep(500);
                ///跟第esc图片对比
                //if (IdentifyByOpenCV.CompareImageByHistogram(ImageComare.ImageCurrentESC, ImageComare.ImageESC) < 0.0001)
                if (IdentifyImageByBaiduAI2.IdentifyByOverRowCount(ImageComare.ImageCurrent, 4))
                {
                    InputAction.DD_ACtion.Keyboard(Keys.Escape);
                    Thread.Sleep(500);
                }


                Thread.Sleep(1000*7);

            }


        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (tr != null && tr.ThreadState == ThreadState.Running)
                {
                    tr.Abort();
                }
            }
            catch
            { }
        }
    }
}
