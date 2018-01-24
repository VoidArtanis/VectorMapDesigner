using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using Imagio.DSP;
using ImagioDevice;
using MahApps.Metro.Controls;
using Timer = System.Timers.Timer;
namespace Imagio.GUI
{
    /// <summary>
    ///     Interaction logic for Designer.xaml
    /// </summary>
    public partial  class MeasureWindow : MetroWindow
    {
        private Message prevMessage;
        private   Timer loopTimer;
        public int CurrentValue { get; set; }
        public int ReaderFunctionIndex1 { get; set; }
        public int ReaderFunctionIndex2 { get; set; }
        private int rounds = 0;
        Polygon poly = new Polygon();
        private double factor = 0;
        public MeasureWindow()
        {
         
           
            InitializeComponent();
            loopTimer = new Timer();
            loopTimer.Interval = 1; 
    loopTimer.Enabled = false;
            loopTimer.Elapsed += loopTimerEvent;
             Init();
            Closing += (sender, args) =>
            {
             IoSerial.Instance.CloseSerial();   
            };
            btnLeft.PreviewMouseDown += (sender, args) =>
            {
                pos -= 5;
                if (pos > 180) pos = 180;
                if (pos < 0) pos = 0;
                IoSerial.Instance.Write(Convert.ToInt32((pos / 2)).ToString(), CommandType.Info);
                //                factor = -0.2;
                //                loopTimer.Enabled = true;
                //                loopTimer.Start();
            } ;
            btnRight.PreviewMouseDown += (sender, args) =>
            {
                pos += 5;
                if (pos > 180) pos = 180;
                if (pos < 0) pos = 0;
                IoSerial.Instance.Write(Convert.ToInt32( (pos/2)).ToString(), CommandType.Info);
                //                factor = .2;
                //                loopTimer.Enabled = true;
                //                loopTimer.Start();
            };

            btnLeft.PreviewMouseUp += (sender, args) =>
            {
          
                loopTimer.Enabled = false;
                loopTimer.Stop();;
            };
            btnRight.PreviewMouseUp += (sender, args) =>
            {
         
                loopTimer.Enabled = false;
                loopTimer.Stop(); ;
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
           
           
            ReaderFunctionIndex1 = Convert.ToInt32(2 + 1.ToString());
            ReaderFunctionIndex2 = Convert.ToInt32(2 + 1.ToString());
            IoSerial.Instance.NewMessageArrived+=InstanceOnNewMessageArrived;
            IoSerial.Instance.Write(ReaderFunctionIndex1.ToString(), CommandType.Command);
    
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
                            txtDistance.Text = distance.ToString();

                             
                            txtStatus.Text = "Completed!";
                             
                        
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

      
 

        private void btnAccept_Click(object sender, RoutedEventArgs e)
        {
            var grd = new Viewbox(); 
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
 
        private void LaserToggle_Unchecked(object sender, RoutedEventArgs e)
        {
            IoSerial.Instance.Write("21", CommandType.Command);
        }

        private void LaserToggle_Checked(object sender, RoutedEventArgs e)
        {
            IoSerial.Instance.Write("11", CommandType.Command);
        }

        private double pos = 0;
        private   void loopTimerEvent(Object source, ElapsedEventArgs e)
        {
            pos += factor;
            if (pos > 180) pos = 180;
            if (pos <0) pos = 0;
            IoSerial.Instance.Write(pos.ToString(), CommandType.Info);

        }

        private void buttonbtnMeasure_Click(object sender, RoutedEventArgs e)
        {
            IoSerial.Instance.Write("20", CommandType.Command);
        }
    }
}