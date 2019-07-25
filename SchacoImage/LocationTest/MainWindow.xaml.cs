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

namespace LocationTest
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
                    var point = InputAction.MouseMove.GetMouseLocation();
                    PointModel.X = point.X;
                    PointModel.Y = point.Y;
                    Thread.Sleep(100);
                }
            });
            this.DataContext = this;
        }

        public PointModel PointModel { get; set; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PointModel.SetValue();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
