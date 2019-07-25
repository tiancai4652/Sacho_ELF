
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
                Thread.Sleep(100);
                InputAction.DD_ACtion.MouseLeftClick();
                Thread.Sleep(100);

                ///移开鼠标
                InputAction.MouseMove.SetMouseScreenLocation(ItemLocation.OutItem);
                Thread.Sleep(100);
                ///截取当前图片
                ImageComare.GetAndSaveCurrentImage();
                Thread.Sleep(100);
                ///跟第一个图片对比
                if (IdentifyByOpenCV.CompareImageByHistogram(ImageComare.ImageCurrent, ImageComare.Image1_3Item) < 0.0001)
                {
                    InputAction.MouseMove.SetMouseScreenLocation(ItemLocation.Item2);
                    Thread.Sleep(100);
                    InputAction.DD_ACtion.MouseLeftClick();
                    Thread.Sleep(100);
                }
                Thread.Sleep(100);

                ///移开鼠标
                InputAction.MouseMove.SetMouseScreenLocation(ItemLocation.OutItem);
                Thread.Sleep(100);
                ///截取当前图片
                ImageComare.GetAndSaveCurrentImage();
                Thread.Sleep(100);
                ///跟第一个图片对比
                if (IdentifyByOpenCV.CompareImageByHistogram(ImageComare.ImageCurrent, ImageComare.Image2_Enter2Item) < 0.0001)
                {
                    InputAction.MouseMove.SetMouseScreenLocation(ItemLocation.Item1);
                    Thread.Sleep(100);
                    InputAction.DD_ACtion.MouseLeftClick();
                    Thread.Sleep(100);
                }
                Thread.Sleep(100);

                ///移开鼠标
                InputAction.MouseMove.SetMouseScreenLocation(ItemLocation.OutItem);
                Thread.Sleep(100);
                ///截取当前图片
                ImageComare.GetAndSaveCurrentImage();
                Thread.Sleep(100);
                ///跟第一个图片对比
                if (IdentifyByOpenCV.CompareImageByHistogram(ImageComare.ImageCurrent, ImageComare.Image3_Enter2Item) < 0.0001)
                {
                    InputAction.MouseMove.SetMouseScreenLocation(ItemLocation.Item1);
                    Thread.Sleep(100);
                    InputAction.DD_ACtion.MouseLeftClick();
                    Thread.Sleep(100);
                }
                Thread.Sleep(100);

                ///移开鼠标
                InputAction.MouseMove.SetMouseScreenLocation(ItemLocation.OutItem);
                Thread.Sleep(100);
                ///截取当前图片
                ImageComare.GetAndSaveCurrentImage();
                Thread.Sleep(100);
                ///跟第一个图片对比
                if (IdentifyByOpenCV.CompareImageByHistogram(ImageComare.ImageCurrent, ImageComare.Image4_Enter2Item) < 0.0001)
                {
                    InputAction.MouseMove.SetMouseScreenLocation(ItemLocation.Item1);
                    Thread.Sleep(100);
                    InputAction.DD_ACtion.MouseLeftClick();
                    Thread.Sleep(100);
                }
                Thread.Sleep(100);

                ///移开鼠标
                InputAction.MouseMove.SetMouseScreenLocation(ItemLocation.OutItem);
                Thread.Sleep(100);
                ///截取当前图片
                ImageComare.GetAndSaveCurrentImage();
                Thread.Sleep(100);
                ///跟第一个图片对比
                if (IdentifyByOpenCV.CompareImageByHistogram(ImageComare.ImageCurrent, ImageComare.Image5_Enter2Item) < 0.0001)
                {
                    InputAction.MouseMove.SetMouseScreenLocation(ItemLocation.Item2);
                    Thread.Sleep(100);
                    InputAction.DD_ACtion.MouseLeftClick();
                    Thread.Sleep(100);
                }
                Thread.Sleep(100);

                ///移开鼠标
                InputAction.MouseMove.SetMouseScreenLocation(ItemLocation.OutItem);
                Thread.Sleep(100);
                ///截取当前图片
                ImageComare.GetAndSaveCurrentImage();
                Thread.Sleep(100);
                ///跟第一个图片对比
                if (IdentifyByOpenCV.CompareImageByHistogram(ImageComare.ImageCurrent, ImageComare.Image6_Enter3Item) < 0.0001)
                {
                    InputAction.MouseMove.SetMouseScreenLocation(ItemLocation.Item1);
                    Thread.Sleep(100);
                    InputAction.DD_ACtion.MouseLeftClick();
                    Thread.Sleep(100);
                }
                Thread.Sleep(100);

                ///移开鼠标
                InputAction.MouseMove.SetMouseScreenLocation(ItemLocation.OutItem);
                Thread.Sleep(100);
                ///截取当前图片
                ImageComare.GetAndSaveCurrentImage();
                Thread.Sleep(100);
                ///跟第一个图片对比
                if (IdentifyByOpenCV.CompareImageByHistogram(ImageComare.ImageCurrent, ImageComare.ImageWrongImage) < 0.0001)
                {
                    Thread.Sleep(60000);
                }

                ///移开鼠标
                InputAction.MouseMove.SetMouseScreenLocation(ItemLocation.OutItem);
                Thread.Sleep(100);
                ///截取当前图片
                ImageComare.GetAndSaveESCImage();
                Thread.Sleep(100);
                ///跟第一个图片对比
                if (IdentifyByOpenCV.CompareImageByHistogram(ImageComare.ImageCurrentESC, ImageComare.ImageESC) < 0.0001)
                {
                    InputAction.DD_ACtion.Keyboard(Keys.Escape);
                    Thread.Sleep(60000);
                }


                Thread.Sleep(6000);

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
