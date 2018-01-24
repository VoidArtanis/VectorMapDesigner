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
    class PolygonDraw : IDisposable
    {
        private bool finished = false;
        public void Start()
        {
            var win = App.Current.MainWindow as Designer;
            Polygon poly = new Polygon();
          
            var MapCanvas = win.MapCanvas;
            MapCanvas.CaptureMouse();

            poly.FillRule =FillRule.Nonzero;
            poly.Fill = win.backgroundColorPanel.Background;
            poly.Stroke = win.foregroundColorPanel.Background;
            poly.StrokeThickness = 1;

            MapCanvas.Children.Add(poly);

            MapCanvas.PreviewMouseRightButtonDown += (sender, args) =>
            {
                if (finished) return;
                MapCanvas.ReleaseMouseCapture();
                //poly.Points.RemoveAt(poly.Points.Count  );
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
                MapCanvas.Children.Add(grd);
                ShapeHandler.SelectedImage = grd;

                ShapeHandler.InitImageHandlers(ref grd);
                finished = true;
                Dispose();
            };

            MapCanvas.PreviewMouseLeftButtonDown += (sender, args) =>
            {
                if (finished) return;
                var pos = args.GetPosition(MapCanvas);
                if (poly.Points.Count == 0)
                {
                    poly.Points.Add(pos);
                    poly.Points.Add(pos);
                }
                else
                {
                    poly.Points[poly.Points.Count - 1] = pos;
                    poly.Points.Add(pos);
                }
            };

            MapCanvas.PreviewMouseMove += (sender, args) =>
            {
                if (finished) return;
                var pos = args.GetPosition(MapCanvas);
                if (poly.Points.Count != 0)
                {
                    poly.Points[poly.Points.Count-1] = pos;
                }
            };

        }

        public void Dispose()
        {
             
        }
    }
}
