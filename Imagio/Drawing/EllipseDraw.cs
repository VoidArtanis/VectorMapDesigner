using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using Imagio.GUI;

namespace Imagio.Drawing
{
    class EllipseDraw : IDisposable
    {  
        private bool finished = false;
        public void Start()
        {
            var win = App.Current.MainWindow as Designer;
            Ellipse ellipse = new Ellipse();
            var started = false;

            var MapCanvas = win.MapCanvas;
            MapCanvas.CaptureMouse();
 
            ellipse.Fill = win.backgroundColorPanel.Background;
            ellipse.Stroke = win.foregroundColorPanel.Background;
            ellipse.StrokeThickness = 1;

            MapCanvas.Children.Add(ellipse);

            MapCanvas.PreviewMouseLeftButtonUp += (sender, args) =>
            {
                if (finished) return;
                MapCanvas.ReleaseMouseCapture();
                //poly.Points.RemoveAt(poly.Points.Count  );
                var grd = new Viewbox();
                MapCanvas.Children.Remove(ellipse);
                 grd.Child = (ellipse);

                var miny = Canvas.GetTop(ellipse);
                var minx = Canvas.GetLeft(ellipse);

                Canvas.SetTop(grd, miny);
                Canvas.SetLeft(grd, minx);
 
                ellipse.Margin = new Thickness(0);
                ellipse.VerticalAlignment = VerticalAlignment.Stretch;
                ellipse.HorizontalAlignment = HorizontalAlignment.Stretch;
                MapCanvas.Children.Add(grd);
                ShapeHandler.SelectedImage = grd;

                ShapeHandler.InitImageHandlers(ref grd);
                finished = true;
                Dispose();
            };

            Point startPoint = new Point();
            MapCanvas.PreviewMouseLeftButtonDown += (sender, args) =>
            {
                if (finished) return;
                var pos = args.GetPosition(MapCanvas);
                Canvas.SetTop(ellipse,pos.Y);
                Canvas.SetLeft(ellipse, pos.X);
                startPoint = pos;
                started = true;
            };

            MapCanvas.PreviewMouseMove += (sender, args) =>
            {
                if (finished || !started) return;

                var pos = args.GetPosition(MapCanvas);
                var x = Math.Min(pos.X, startPoint.X);
                var y = Math.Min(pos.Y, startPoint.Y);

                var w = Math.Max(pos.X, startPoint.X) - x;
                var h = Math.Max(pos.Y, startPoint.Y) - y;

                ellipse.Width = w;
                ellipse.Height = h;

                Canvas.SetLeft(ellipse, x);
                Canvas.SetTop(ellipse, y);
            };
        }

        public void Dispose()
        {
             
        }
    }
}
