using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;
using Imagio.Converter;
using Imagio.DSP;
using Imagio.GUI.Controls;
using ImagioDevice;

namespace Imagio
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly List<Ellipse> blackBoard = new List<Ellipse>();
        private readonly float threshold = 10;
        private bool _hasPrev;
        private List<Point> _lidarCurrentPoints = new List<Point>();
        private Point _prevPoint;
        private Point p1 = new Point(0, 0);
        public List<List<Point>> Points = new List<List<Point>>();
        private int rounds;

        public MainWindow()
        {
            InitializeComponent();

            IoSerial.Instance.FindAndConnectAsync();
            Filters = new Filters();
        }

        public Filters Filters { get; }

        private void Thermal_SensorValueChanged1(int position, int distance)
        {
            distance = distance;
            if (position >= 170) rounds++;

            if (rounds > 01)
            {
                if (_lidarCurrentPoints.Count != 0)
                {
                    Points.Add(_lidarCurrentPoints);
                    _lidarCurrentPoints = new List<Point>();
                }
                return;
            }
            ;
            Point p2;
            p2 = new Point((int) (MapCanvas.ActualWidth/2.0 - distance*Math.Cos(Math.PI*position/180)),
                (int) (MapCanvas.ActualHeight/2.0 - distance*Math.Sin(Math.PI*position/180)));
            _lidarCurrentPoints.Add(p2);
            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() =>
            {
                var pts = new List<Point>();
                pts.Add(p2);
                pts.Add(p1);

                DrawMapBinary(pts);
            }));

            p1 = p2;
        }

        #region Draw Map

        public void DrawMap(List<Point> pts)
        {
            var lines = new List<Line>();
            for (var i = 1; i < pts.Count; i += 1)
            {
                var line = CreateLine(pts, i);
                lines.Add(line);
                AddEllipse(pts, i - 1, lines);
            }
            AddEllipse(pts, pts.Count - 1, lines);
        }

        private Line CreateLine(List<Point> pts, int i)
        {
            var line = new Line();
            line.Stroke = Brushes.Black;

            line.X1 = pts[i - 1].X;
            line.Y1 = pts[i - 1].Y;
            line.Y2 = pts[i].Y;
            line.X2 = pts[i].X;
            line.Tag = new Point(pts[i - 1].X, pts[i - 1].Y);
            line.SetValue(DraggableCanvas.CanBeDraggedProperty, false);
            MapCanvas.Children.Add(line);

            line.PreviewMouseUp += (sender, args) =>
            {
                var pt = new Point(args.MouseDevice.GetPosition(MapCanvas).X,
                    args.MouseDevice.GetPosition(MapCanvas).Y);

                for (var index1 = 0; index1 < Points.Count; index1++)
                {
                    var pointList = Points[index1];
                    var lineSender = sender as Line;
                    var initialPoints = lineSender.Tag is Point ? (Point) lineSender.Tag : new Point();

                    if (pointList.Contains(initialPoints))
                    {
                        var index = pointList.IndexOf(initialPoints);
                        pointList.Insert(index + 1, pt);

                        RefreshMap();
                        return;
                    }
                }
            };

            return line;
        }

        private void AddEllipse(List<Point> pts, int i, List<Line> lines)
        {
            var ee = new Ellipse();
            ee.Width = 10;
            ee.Height = 10;
            ee.Fill = Brushes.Blue;
            ee.Tag = pts[i];


            ee.PreviewMouseUp += (sender, args) =>
            {
                if (args.ChangedButton == MouseButton.Middle)
                {
                    for (var index1 = 0; index1 < Points.Count; index1++)
                    {
                        var pointList = Points[index1];
                        var ellipseSender = sender as Ellipse;
                        var initialPoints = ellipseSender.Tag is Point ? (Point) ellipseSender.Tag : new Point();

                        if (pointList.Contains(initialPoints))
                        {
                            var index = pointList.IndexOf(initialPoints);
                            pointList.RemoveAt(index);
                            RefreshMap();
                            return;
                        }
                    }
                }
                for (var index1 = 0; index1 < Points.Count; index1++)
                {
                    var pointList = Points[index1];
                    var ellipseSender = sender as Ellipse;
                    var initialPoints = ellipseSender.Tag is Point ? (Point) ellipseSender.Tag : new Point();
                    var pointOnCanvas = new Point(Canvas.GetLeft(ellipseSender) + 5,
                        Canvas.GetTop(ellipseSender) + 5);
                    if (pointList.Contains(initialPoints))
                    {
                        var index = pointList.IndexOf(initialPoints);
                        pointList[index] = pointOnCanvas;

                        return;
                    }
                }
            };

            var x = new LocationConverter(false);
            var y = new LocationConverter(true);
            MapCanvas.Children.Add(ee);
            Canvas.SetLeft(ee, pts[i].X - 5);
            Canvas.SetTop(ee, pts[i].Y - 5);
            if (lines.Count > i)
            {
                BindingOperations.SetBinding(lines[i], Line.Y1Property,
                    new Binding
                    {
                        Source = ee,
                        Path = new PropertyPath(Canvas.TopProperty),
                        ConverterParameter = ee,
                        Converter = y
                    });

                BindingOperations.SetBinding(lines[i], Line.X1Property,
                    new Binding
                    {
                        Source = ee,
                        Path = new PropertyPath(Canvas.LeftProperty),
                        Converter = x,
                        ConverterParameter = ee
                    });
            }
            if (i > 0)
            {
                BindingOperations.SetBinding(lines[i - 1], Line.Y2Property,
                    new Binding
                    {
                        Source = ee,
                        Path = new PropertyPath(Canvas.TopProperty),
                        ConverterParameter = ee,
                        Converter = y
                    });

                BindingOperations.SetBinding(lines[i - 1], Line.X2Property,
                    new Binding
                    {
                        Source = ee,
                        Path = new PropertyPath(Canvas.LeftProperty),
                        Converter = x,
                        ConverterParameter = ee
                    });
            }
            Panel.SetZIndex(ee, 1000);
        }

        public void DrawMapBinary(List<Point> pts)
        {
            var ln = new List<Line>();
            var ellipse = new Ellipse();


            ellipse.Width = 10;
            ellipse.Height = 10;
            ellipse.Fill = Brushes.Blue;


            var x = new LocationConverter(false);
            var y = new LocationConverter(true);
            MapCanvas.Children.Add(ellipse);
            Canvas.SetLeft(ellipse, pts[1].X - 5);
            Canvas.SetTop(ellipse, pts[1].Y - 5);
            ellipse.PreviewMouseUp += (sender, args) => { };
            if (blackBoard.Count > 0)
            {
                var p = new Line();
                p.PreviewMouseDown += (sender, args) =>
                {
                    if (args.MiddleButton == MouseButtonState.Pressed)
                    {
                        var pt = new Point(args.MouseDevice.GetPosition(MapCanvas).X,
                            args.MouseDevice.GetPosition(MapCanvas).Y);
                        var line = sender as Line;
                    }
                };


                p.Stroke = Brushes.Black;

                p.X1 = pts[1].X;
                p.Y1 = pts[1].Y;
                p.Y2 = pts[0].Y;
                p.X2 = pts[0].X;
                BindingOperations.SetBinding(p, Line.Y1Property,
                    new Binding
                    {
                        Source = ellipse,
                        Path = new PropertyPath(Canvas.TopProperty),
                        ConverterParameter = ellipse,
                        Converter = y
                    });

                BindingOperations.SetBinding(p, Line.X1Property,
                    new Binding
                    {
                        Source = ellipse,
                        Path = new PropertyPath(Canvas.LeftProperty),
                        Converter = x,
                        ConverterParameter = ellipse
                    });


                var lastEllipse = blackBoard.Last();
                BindingOperations.SetBinding(p, Line.Y2Property,
                    new Binding
                    {
                        Source = lastEllipse,
                        Path = new PropertyPath(Canvas.TopProperty),
                        ConverterParameter = lastEllipse,
                        Converter = y
                    });

                BindingOperations.SetBinding(p, Line.X2Property,
                    new Binding
                    {
                        Source = lastEllipse,
                        Path = new PropertyPath(Canvas.LeftProperty),
                        Converter = x,
                        ConverterParameter = lastEllipse
                    });
                p.SetValue(DraggableCanvas.CanBeDraggedProperty, false);
                MapCanvas.Children.Add(p);

                ln.Add(p);
            }


            Panel.SetZIndex(ellipse, 1000);
            blackBoard.Add(ellipse);
        }

        #endregion

        #region UI Canvas Events

        private List<Point> _currentPoints = new List<Point>();

        private void MapCanvas_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var pt = new Point(e.MouseDevice.GetPosition(MapCanvas).X, e.MouseDevice.GetPosition(MapCanvas).Y);

            if (mtog.IsChecked == true && _hasPrev)
            {
                var lst = new List<Point>();
                lst.Add(_prevPoint);
                lst.Add(pt);
                DrawMapBinary(lst);

                Points.Add(_currentPoints);
                _currentPoints = new List<Point>();
                _hasPrev = false;
            }
            else
            {
                _hasPrev = true;
            }
            _prevPoint = pt;
        }

        private void MapCanvas_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                var pt = new Point(e.MouseDevice.GetPosition(MapCanvas).X, e.MouseDevice.GetPosition(MapCanvas).Y);


                if (mtog.IsChecked == true && _hasPrev)
                {
                    var lst = new List<Point>();
                    lst.Add(_prevPoint);
                    lst.Add(pt);
                    DrawMapBinary(lst);
                    _currentPoints.Add(pt);
                }
                else
                {
                    _hasPrev = true;
                }

                _prevPoint = pt;
            }
        }

        #endregion

        #region  UI Buttons Events

        private void buttons_Click(object sender, RoutedEventArgs e)
        {
            RefreshMap();
        }

        private void RefreshMap()
        {
            MapCanvas.Children.Clear();
            for (var index = 0; index < Points.Count; index++)
            {
                DrawMap(Points[index]);
            }
        }


        private void Space(object sender, RoutedEventArgs e)
        {
            //            for (var i = Points.Count - 2; i >= 01; i -= 2)
            //            {
            //                var l1 = Math.Sqrt(Math.Pow(Points[i - 1].X, 2) + Math.Pow(Points[i - 1].Y, 2));
            //                var l2 = Math.Sqrt(Math.Pow(Points[i + 1].X, 2) + Math.Pow(Points[i + 1].Y, 2));
            //
            //                if (l1 - l2 < threshold)
            //                    Points.RemoveAt(i);
            //            }
            //
            //            MapCanvas.Children.Clear();
            //            drawMap(Points);
        }

        private void douglasPeucker_Click(object sender, RoutedEventArgs e)
        {
            MapCanvas.Children.Clear();
            var dp = new DouglasPeucker();
            for (var index = 0; index < Points.Count; index++)
            {
                var pointlist = Points[index];
                Points[index] = dp.DouglasPeuckerReduction(pointlist, 5);

                DrawMap(pointlist);
            }
        }

        private void btnConnect_Click(object sender, RoutedEventArgs e)
        {
            rounds = 0;
            Thread.Sleep(2000);
            IoSerial.Instance.Write("00", CommandType.Wireless);
            IoSerial.Instance.Write("10", CommandType.Command);
            //            Thread.Sleep(1000);
            var lidar = new LidarAutoSweep(0, 1);

            lidar.SensorValueChanged += Thermal_SensorValueChanged1;
            ;
            lidar.StartContinousReading(123);
        }

        private void douglasPeuckerbox_Click(object sender, RoutedEventArgs e)
        {
            MapCanvas.Children.Clear();
            var dp = new DouglasPeucker();
            for (var index = 0; index < Points.Count; index++)
            {
                Points[index] = dp.DouglasPeuckerReduction(Points[index], 25);

                DrawMap(Points[index]);
            }
        }

        private List<Point> polyInitialLocationList = new List<Point>();

        private void BtnGraph(object sender, RoutedEventArgs e)
        {
            MapCanvas.Children.Clear();

            for (var index = 0; index < Points.Count; index++)
            {
                var pointlist = Points[index];
                var shape = new Polygon();
                var pointCollection = new PointCollection();
                foreach (var point in pointlist)
                {
                    pointCollection.Add(new Point(point.X, point.Y));
                }
                shape.Fill = new SolidColorBrush(Colors.BurlyWood);
                shape.Stroke = Brushes.Black;
                shape.FillRule = FillRule.EvenOdd;
                shape.HorizontalAlignment = HorizontalAlignment.Left;
                shape.VerticalAlignment = VerticalAlignment.Center;
                shape.StrokeThickness = 1;
                shape.Points = pointCollection;
                shape.Tag = index; // store the index of the pointlist in points
                shape.MouseDown += (o, args) => { };
                shape.PreviewMouseUp += (o, args) =>
                {
                    var poly = o as Polygon;
                    var left = Canvas.GetLeft(poly);
                    var top = Canvas.GetLeft(poly);

                    var diff = new Point(left - poly.Points[0].X - Points[(int) poly.Tag][0].X,
                        top - poly.Points[0].Y - Points[(int) poly.Tag][0].Y);

                    var myMatrix = new Matrix();
                    myMatrix.Translate(diff.X, diff.Y);
                    for (var i = 0; i < poly.Points.Count; i++)
                    {
                        var pt = poly.Points[i];
                        Points[(int) poly.Tag][i] = myMatrix.Transform(pt);
                    }
                };
                MapCanvas.Children.Add(shape);
            }
        }

        #endregion
    }
}