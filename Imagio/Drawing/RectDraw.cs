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
    class RectDraw : IDisposable
    {

        
        private bool finished = false;
        public void Start()
        {
            var win = App.Current.MainWindow as Designer;
            Rectangle rectangle = new Rectangle();
            var started = false;

            var MapCanvas = win.MapCanvas;
            MapCanvas.CaptureMouse();
 
            rectangle.Fill = win.backgroundColorPanel.Background;
            rectangle.Stroke = win.foregroundColorPanel.Background;
            rectangle.StrokeThickness = 1;

            MapCanvas.Children.Add(rectangle);

            MapCanvas.PreviewMouseLeftButtonUp += (sender, args) =>
            {
                if (finished) return;
                MapCanvas.ReleaseMouseCapture();
                //poly.Points.RemoveAt(poly.Points.Count  );
                var grd = new Viewbox();
                MapCanvas.Children.Remove(rectangle);
                 grd.Child = (rectangle);

                var miny = Canvas.GetTop(rectangle);
                var minx = Canvas.GetLeft(rectangle);

                Canvas.SetTop(grd, miny);
                Canvas.SetLeft(grd, minx);
 
                rectangle.Margin = new Thickness(0);
                rectangle.VerticalAlignment = VerticalAlignment.Stretch;
                rectangle.HorizontalAlignment = HorizontalAlignment.Stretch;
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
                Canvas.SetTop(rectangle,pos.Y);
                Canvas.SetLeft(rectangle, pos.X);
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

                rectangle.Width = w;
                rectangle.Height = h;

                Canvas.SetLeft(rectangle, x);
                Canvas.SetTop(rectangle, y);
            };

        }

        public void Dispose()
        {
             
        }
    }
}
