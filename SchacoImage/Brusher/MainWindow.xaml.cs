
using ImageComare;
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
            InitializeComponent();
            PointModel = new PointModel();
            Task.Run(() =>
            {
                while (true)
                {
                    var point = global::InputAction.MouseMove.GetMouseLocation();
                    PointModel.X = point.X;
                    PointModel.Y = point.Y;
                    Thread.Sleep(100);
                }
            });
            this.DataContext = this;
        }
        Thread tr;

        public PointModel PointModel { get; set; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PointModel.SetValue();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //MouseLocation.MouseLocation.SetMouseLocation(new System.Drawing.Point(PointModel.StValueX, PointModel.StValueY));
            //Click();
            //PressESC();

            if (PointModel.StValueX == 0 || PointModel.StValueY == 0)
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

                InputAction.MouseMove.SetMouseLocation(new System.Drawing.Point(PointModel.StValueX, PointModel.StValueY));
                Thread.Sleep(100);
                InputAction.DD_ACtion.MouseLeftClick();
                Thread.Sleep(100);

                ///移开鼠标
                InputAction.MouseMove.SetMouseLocation(ItemLocation.OutItem);
                Thread.Sleep(100);
                ///截取当前图片
                ImageComare.GetAndSaveCurrentImage();
                Thread.Sleep(100);
                ///跟第一个图片对比
                if (IdentifyByOpenCV.CompareImageByHistogram(ImageComare.ImageCurrent, ImageComare.Image1_3Item) < 0.0001)
                {
                    InputAction.MouseMove.SetMouseLocation(ItemLocation.Item2);
                    Thread.Sleep(100);
                    InputAction.DD_ACtion.MouseLeftClick();
                    Thread.Sleep(100);
                }
                Thread.Sleep(100);

                ///移开鼠标
                InputAction.MouseMove.SetMouseLocation(ItemLocation.OutItem);
                Thread.Sleep(100);
                ///截取当前图片
                ImageComare.GetAndSaveCurrentImage();
                Thread.Sleep(100);
                ///跟第一个图片对比
                if (IdentifyByOpenCV.CompareImageByHistogram(ImageComare.ImageCurrent, ImageComare.Image2_Enter2Item) < 0.0001)
                {
                    InputAction.MouseMove.SetMouseLocation(ItemLocation.Item1);
                    Thread.Sleep(100);
                    InputAction.DD_ACtion.MouseLeftClick();
                    Thread.Sleep(100);
                }
                Thread.Sleep(100);

                ///移开鼠标
                InputAction.MouseMove.SetMouseLocation(ItemLocation.OutItem);
                Thread.Sleep(100);
                ///截取当前图片
                ImageComare.GetAndSaveCurrentImage();
                Thread.Sleep(100);
                ///跟第一个图片对比
                if (IdentifyByOpenCV.CompareImageByHistogram(ImageComare.ImageCurrent, ImageComare.Image3_Enter2Item) < 0.0001)
                {
                    InputAction.MouseMove.SetMouseLocation(ItemLocation.Item1);
                    Thread.Sleep(100);
                    InputAction.DD_ACtion.MouseLeftClick();
                    Thread.Sleep(100);
                }
                Thread.Sleep(100);

                ///移开鼠标
                InputAction.MouseMove.SetMouseLocation(ItemLocation.OutItem);
                Thread.Sleep(100);
                ///截取当前图片
                ImageComare.GetAndSaveCurrentImage();
                Thread.Sleep(100);
                ///跟第一个图片对比
                if (IdentifyByOpenCV.CompareImageByHistogram(ImageComare.ImageCurrent, ImageComare.Image4_Enter2Item) < 0.0001)
                {
                    InputAction.MouseMove.SetMouseLocation(ItemLocation.Item1);
                    Thread.Sleep(100);
                    InputAction.DD_ACtion.MouseLeftClick();
                    Thread.Sleep(100);
                }
                Thread.Sleep(100);

                ///移开鼠标
                InputAction.MouseMove.SetMouseLocation(ItemLocation.OutItem);
                Thread.Sleep(100);
                ///截取当前图片
                ImageComare.GetAndSaveCurrentImage();
                Thread.Sleep(100);
                ///跟第一个图片对比
                if (IdentifyByOpenCV.CompareImageByHistogram(ImageComare.ImageCurrent, ImageComare.Image5_Enter2Item) < 0.0001)
                {
                    InputAction.MouseMove.SetMouseLocation(ItemLocation.Item2);
                    Thread.Sleep(100);
                    InputAction.DD_ACtion.MouseLeftClick();
                    Thread.Sleep(100);
                }
                Thread.Sleep(100);

                ///移开鼠标
                InputAction.MouseMove.SetMouseLocation(ItemLocation.OutItem);
                Thread.Sleep(100);
                ///截取当前图片
                ImageComare.GetAndSaveCurrentImage();
                Thread.Sleep(100);
                ///跟第一个图片对比
                if (IdentifyByOpenCV.CompareImageByHistogram(ImageComare.ImageCurrent, ImageComare.Image6_Enter3Item) < 0.0001)
                {
                    InputAction.MouseMove.SetMouseLocation(ItemLocation.Item1);
                    Thread.Sleep(100);
                    InputAction.DD_ACtion.MouseLeftClick();
                    Thread.Sleep(100);
                }
                Thread.Sleep(100);

                ///移开鼠标
                InputAction.MouseMove.SetMouseLocation(ItemLocation.OutItem);
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
                InputAction.MouseMove.SetMouseLocation(ItemLocation.OutItem);
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
