using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using Imagio.DSP;
using ImagioDevice;
using MahApps.Metro.Controls;

namespace Imagio.GUI
{
    /// <summary>
    ///     Interaction logic for Designer.xaml
    /// </summary>
    public partial  class CaptureWindow : MetroWindow
    {
        private Message prevMessage;

        public int CurrentValue { get; set; }
        public int ReaderFunctionIndex1 { get; set; }
        public int ReaderFunctionIndex2 { get; set; }
        private int rounds = 0;
        Polygon poly = new Polygon();
        public CaptureWindow()
        {
         
           
            InitializeComponent();
            Grid.IsEnabled = false;
            Init();
            Closing += (sender, args) =>
            {
             
             IoSerial.Instance.CloseSerial();   
            };

        }

        public async void Init()
        {
            Status.Text = "Establishing Connection";
            await Task.Run(() => Thread.Sleep(1000));
           await Task.Run(() => IoSerial.Instance.FindAndConnect());
            rounds = 0;
            Designer designer = (Designer)App.Current.MainWindow;
            Status.Text = "Switching Device To Wireless Context";
            Thread.Sleep(1000);
            IoSerial.Instance.Write("00", CommandType.Wireless);
            Thread.Sleep(1000);
            Status.Text = "Starting Sweep Scan";
           
            IoSerial.Instance.Write("10", CommandType.Command);
            ReaderFunctionIndex1 = Convert.ToInt32(1 + 0.ToString());
            ReaderFunctionIndex2 = Convert.ToInt32(1 + 1.ToString());
            IoSerial.Instance.NewMessageArrived+=InstanceOnNewMessageArrived;
            IoSerial.Instance.Write(ReaderFunctionIndex1.ToString(), CommandType.Command);
    
            MapCanvas.Children.Add(poly);
            poly.Fill = designer.backgroundColorPanel.Background;
            poly.Stroke = designer.foregroundColorPanel.Background;
            poly.StrokeThickness = 1;
            poly.FillRule = FillRule.Nonzero;
            IoSerial.Instance.Write("11", CommandType.Command);
            GrdStartup.Visibility = Visibility.Hidden;
        }

        private void InstanceOnNewMessageArrived(Message msg)
        {
            if (msg != null && msg.Command != String.Empty)
            {
                try
                {
                    if (msg.Response.FunctionIndex == ReaderFunctionIndex1.ToString())
                    //update the events if the this is the right sensor
                    {
                        prevMessage = msg;

                    }
                    if (msg.Response.FunctionIndex == ReaderFunctionIndex2.ToString() && prevMessage != null)
                    {
                        CurrentValue = Convert.ToInt32(Response.GetResponse(msg).Value);
                        double position = Convert.ToDouble(Response.GetResponse(prevMessage).Value);
                        double distance = Convert.ToDouble(Response.GetResponse(msg).Value);
                        Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                        {

                            distance = (int)((distance / 100.0) * 50);


                            prog.Maximum = 170;
                            prog.Value = position;
                            txtStatus.Text = "Scanning";
                            txtDegrees.Text = position + "°";
                            txtDistance.Text = distance + "m";
                            Point p2;
                            p2 = new Point((int)(MapCanvas.ActualWidth / 2.0 - distance * Math.Cos(Math.PI * position / 180)),
                                (int)(MapCanvas.ActualHeight / 2.0 - distance * Math.Sin(Math.PI * position / 180)));
                            poly.Points.Add(p2);
                            if (position > 180)
                            {
                                Grid.IsEnabled = true;
                            }
                        }));
                        prevMessage = null;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

      

        private void btnReject_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnAccept_Click(object sender, RoutedEventArgs e)
        {
            var grd = new Viewbox(); 
            MapCanvas.Children.Remove(poly);
            grd.Child = (poly);

            var miny = poly.Points.Min(_ => _.Y);
            var minx = poly.Points.Min(_ => _.X);

            Canvas.SetTop(grd, miny);
            Canvas.SetLeft(grd, minx);

            PointCollection pc = new PointCollection();
            for (int index = 0; index < poly.Points.Count; index++)
            {
                var point = poly.Points[index];
                point.Y = point.Y - miny;
                point.X = point.X - minx;
                pc.Add(point);
            }
            poly.Points = pc;

            poly.Margin = new Thickness(0);
            poly.VerticalAlignment = VerticalAlignment.Stretch;
            poly.HorizontalAlignment = HorizontalAlignment.Stretch;
            Designer designer = (Designer)App.Current.MainWindow;
            designer.MapCanvas.Children.Add(grd);
            ShapeHandler.SelectedImage = grd;
            ShapeHandler.InitImageHandlers(ref grd);
        }

        private void btnSmartFilter_Click(object sender, RoutedEventArgs e)
        {
            DouglasPeucker dp = new DouglasPeucker();
            var d = poly.Points.ToList();
           var t =  dp.DouglasPeuckerReduction(d, 10);
            PointCollection pc = new PointCollection();
            foreach (var point in t)
            {
                pc.Add(point);
            }
            poly.Points = pc;
        }
    }
}