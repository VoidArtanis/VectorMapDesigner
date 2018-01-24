using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using Imagio.Properties;

namespace Imagio.GUI.Controls
{
    internal class GridCanvas : Canvas
    {
        private double Rec_Height;
        private double Rec_Width;
        public double zoom = 1;

        protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
        {
            if (ActualWidth > Rec_Width || ActualHeight > Rec_Height)
            {
                Rec_Width = ActualWidth;
                Rec_Height = ActualHeight;
                DrawGrid();
            }

            base.OnRenderSizeChanged(sizeInfo);
        }

        public void DrawGrid()
        {
            Children.Clear();
 
            if (Settings.Default.DrawGrid)
            {
                for (double i = 0; i < Rec_Width; i += zoom*10)
                {
                    var line = new Line();
                    line.IsHitTestVisible = false;
                    if (i%50 == 0)
                    {
                        line.Stroke = Brushes.DarkGray;
                        line.StrokeThickness = .75;
                    }
                    else
                    {
                        line.Stroke = Brushes.LightGray;
                        line.StrokeThickness = .5;
                    }
                    line.X1 = i;
                    line.X2 = i;
                    line.Y1 = 0;
                    line.Y2 = ActualHeight;
                    line.VerticalAlignment = VerticalAlignment.Stretch;
                    line.HorizontalAlignment = HorizontalAlignment.Left;
                    Children.Add(line);
                }


                for (double i = 0; i < Rec_Height; i += zoom*10)
                {
                    var line = new Line();
                    line.IsHitTestVisible = false;
                    if (i%50 == 0)
                    {
                        line.Stroke = Brushes.DarkGray;
                        line.StrokeThickness = .75;
                    }
                    else
                    {
                        line.Stroke = Brushes.LightGray;
                        line.StrokeThickness = .5;
                    }

                    line.X1 = 0;
                    line.X2 = ActualWidth;
                    line.Y1 = i;
                    line.Y2 = i;
                    line.VerticalAlignment = VerticalAlignment.Top;
                    line.HorizontalAlignment = HorizontalAlignment.Stretch;
                    Children.Add(line);
                }
            }
        }
    }
}