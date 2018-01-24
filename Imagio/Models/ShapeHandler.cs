using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Imagio.Adorners;

namespace Imagio.GUI
{
    internal static class ShapeHandler
    {
        private static Point firstPoint;
        private static Viewbox _selectedShape;
        private static AdornerLayer aLayer;

        public static Viewbox SelectedImage
        {
            get { return _selectedShape; }
            set
            {
                var window = Application.Current.MainWindow as Designer;
                if (aLayer != null)
                {
                    if (_selectedShape != null)
                    {
                        var adorners = aLayer.GetAdorners(_selectedShape);
                        if (adorners != null)
                            aLayer.Remove(adorners[0]);
                    }
                }

                _selectedShape = value;

                if (_selectedShape != null)
                {
                    BaseHandler.ObjectSelected = true;
                    window.SelectedImageControls.IsEnabled = true;
                    aLayer = AdornerLayer.GetAdornerLayer(_selectedShape);
                    aLayer.Add(new ResizingAdorner(_selectedShape));
                    value.Measure(new Size((int)value.ActualWidth, (int)value.ActualHeight));
                    value.Arrange(new Rect(new Size((int)value.ActualWidth, (int)value.ActualHeight)));
                    if (value.ActualWidth > 0 || value.ActualWidth > 0)
                    {
                        RenderTargetBitmap rtb = new RenderTargetBitmap((int) value.ActualWidth,
                            (int) value.ActualHeight, 96, 96, PixelFormats.Pbgra32);
                        rtb.Render(value);
                        window.selectedImage.Source = rtb;
                    }
                }
                else
                {
                    BaseHandler.ObjectSelected = false;
                    window.SelectedImageControls.IsEnabled = false;
                    window.selectedImage.Source = null;
                }
         
               

            }
        }
 

        public static void InitImageHandlers(ref Viewbox layer)
        {
            var window = Application.Current.MainWindow as Designer;
            var uiElement = layer as UIElement;
             layer.MouseDown += (sender, args) =>
            {
                firstPoint = args.GetPosition(window);
                var img = sender as Viewbox;
                img.CaptureMouse();
                SelectedImage = img;
                SelectionFilter.ChangeFilters(sender);
            };

            layer.PreviewMouseMove += (sender, args) =>
            {
                var img = SelectedImage as Viewbox;
                if (args.LeftButton == MouseButtonState.Pressed && img != null)
                {
                    //-- Create Temp Point
                    var temp = args.GetPosition(window);
                    var res = new Point(firstPoint.X - temp.X, firstPoint.Y - temp.Y);

                    //-Update image location
                    Canvas.SetLeft(img, Canvas.GetLeft(img) - res.X);
                    Canvas.SetTop(img, Canvas.GetTop(img) - res.Y);
                    window.SelectedLayerX.Text =  (Canvas.GetLeft(img) / 50.0).ToString("N") + "m, ";
                    window.SelectedLayerY.Text = (Canvas.GetTop(img) / 50.0).ToString("N")  + "m";
                    Console.WriteLine(Canvas.GetLeft(img) - res.X);

                    //-- update first point
                    firstPoint = temp;
                }
            };

            layer.PreviewMouseUp += (sender, args) =>
            {
                var img = sender as UIElement;
                img.ReleaseMouseCapture();
            };

            layer.PreviewMouseWheel += (sender, args) =>
            {
                var img = sender as UIElement;
                var mat = img.RenderTransform.Value;
                var mouse = args.GetPosition(img);

                if (Keyboard.IsKeyDown(Key.LeftCtrl))
                {
                    if (args.Delta > 0) mat.RotateAtPrepend(2, mouse.X, mouse.Y);
                    else mat.RotateAtPrepend(-2, mouse.X, mouse.Y);
                }

                img.RenderTransform = new MatrixTransform(mat);
            };

            layer.SizeChanged += (sender, args) =>
            {
                if (SelectedImage != null)
                {
                    window.SelectedLayerWidth.Text = (SelectedImage.ActualHeight/50.0).ToString("N") + "m, ";
                    window.SelectedLayerHeight.Text = (SelectedImage.ActualWidth / 50.0).ToString("N") + "m";
                }
            };

            //combo box
            window.SelectedImageStretch.SelectionChanged += (sender, args) =>
            {
                if(SelectedImage !=null)
                switch (window.SelectedImageStretch.SelectedIndex)
                {
                    case 0:
                        (SelectedImage  ).Stretch = Stretch.Uniform;
                        break;
                    case 1:
                        (SelectedImage  ).Stretch = Stretch.UniformToFill;
                        break;
                    case 2:
                        (SelectedImage  ).Stretch = Stretch.Fill;
                        break;
                    case 3:
                        (SelectedImage ).Stretch = Stretch.None;
                        break;
                }
            };
        }

        public static void AddImageToCanvas(ref Viewbox img)
        {
            var window = Application.Current.MainWindow as Designer;

            window.MapCanvas.Children.Add(img);
            Canvas.SetLeft(img, 0);
            Canvas.SetTop(img, 0);

            InitImageHandlers(ref img);
        }

    
    }
}