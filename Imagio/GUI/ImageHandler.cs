using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using Imagio.Adorners;

namespace Imagio.GUI
{
    internal static class ImageHandler
    {
        private static Point firstPoint;
        private static Canvas _selectedImage;
        private static AdornerLayer aLayer;

        public static Canvas SelectedImage
        {
            get { return _selectedImage; }
            set
            {
                var window = Application.Current.MainWindow as Designer;
                if (aLayer != null)
                {
                    if (_selectedImage != null)
                    {
                        var adorners = aLayer.GetAdorners(_selectedImage);
                        if (adorners != null)
                            aLayer.Remove(adorners[0]);
                    }
                }

                _selectedImage = value;

                if (_selectedImage != null)
                {
                    BaseHandler.ObjectSelected = true;
                    window.SelectedImageControls.IsEnabled = true;
                    aLayer = AdornerLayer.GetAdornerLayer(_selectedImage);
                    aLayer.Add(new ResizingAdorner(_selectedImage));
                    LoadImageStretch();
                    LoadSelectedImageInfo(window);
                }
                else
                {
                    BaseHandler.ObjectSelected = false;
                    window.SelectedImageControls.IsEnabled = false;
                }


                window.selectedImage.Source = value != null ? (value.Background as ImageBrush).ImageSource: null;
            }
        }

        private static void LoadSelectedImageInfo(Designer window)
        {
            window.SelectedLayerWidth.Text = (SelectedImage.ActualHeight/50.0).ToString("N") + "m, ";
            window.SelectedLayerHeight.Text = (SelectedImage.ActualWidth /50.0).ToString("N") + "m";
            window.SelectedLayerX.Text = (Canvas.GetLeft(SelectedImage)/50.0).ToString("N") + "m, ";
            window.SelectedLayerY.Text = (Canvas.GetTop(SelectedImage)/50.0).ToString("N") + "m";
        }

        public static void InitImageHandlers(ref Canvas layer)
        {

            var window = Application.Current.MainWindow as Designer;
            var uiElement = layer as UIElement;
         
            layer.MouseDown += (sender, args) =>
            {
                firstPoint = args.GetPosition(window);
                var img = sender as Canvas;
                img.CaptureMouse();
                SelectedImage = img;
                SelectionFilter.ChangeFilters(sender);
            };

            layer.PreviewMouseMove += (sender, args) =>
            {
                var img = SelectedImage as UIElement;
                if (args.LeftButton == MouseButtonState.Pressed && img != null)
                {
                    //-- Create Temp Point
                    var temp = args.GetPosition(window);
                    var res = new Point(firstPoint.X - temp.X, firstPoint.Y - temp.Y);

                    //-Update image location
                    Canvas.SetLeft(img, Canvas.GetLeft(img) - res.X);
                    Canvas.SetTop(img, Canvas.GetTop(img) - res.Y);
                    window.SelectedLayerX.Text =  (Canvas.GetLeft(img)/50.0).ToString("N")  + "m, ";
                    window.SelectedLayerY.Text =  (Canvas.GetTop(img) /50.0).ToString("N") + "m";
                    Console.WriteLine(Canvas.GetLeft(img) - res.X);

                    //-- update first point
                    firstPoint = temp;
                }
            };

            layer.PreviewMouseUp += (sender, args) =>
            {
                var img = sender as Canvas;
                img.ReleaseMouseCapture();
            };

            layer.PreviewMouseWheel += (sender, args) =>
            {
                var img = sender as Canvas;
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
                if (SelectedImage != null)
                    switch (window.SelectedImageStretch.SelectedIndex)
                {
                    case 0:
                        (SelectedImage.Background as ImageBrush).Stretch  = Stretch.Uniform;
                        break;
                    case 1:
                        (SelectedImage.Background as ImageBrush).Stretch = Stretch.UniformToFill;
                        break;
                    case 2:
                        (SelectedImage.Background as ImageBrush).Stretch = Stretch.Fill;
                        break;
                    case 3:
                        (SelectedImage.Background as ImageBrush).Stretch = Stretch.None;
                        break;
                }
            };
        }

        public static void AddImageToCanvas(ref Canvas img)
        {
            var window = Application.Current.MainWindow as Designer;

            window.MapCanvas.Children.Add(img);
            Canvas.SetLeft(img, 0);
            Canvas.SetTop(img, 0);

            InitImageHandlers(ref img);
        }

        public static void LoadImageStretch()
        {
            var window = Application.Current.MainWindow as Designer;
            switch ((SelectedImage.Background as ImageBrush).Stretch)
            {
                case Stretch.None:
                    window.SelectedImageStretch.SelectedIndex = 3;
                    break;
                case Stretch.Fill:
                    window.SelectedImageStretch.SelectedIndex = 2;
                    break;
                case Stretch.Uniform:
                    window.SelectedImageStretch.SelectedIndex = 0;
                    break;
                case Stretch.UniformToFill:
                    window.SelectedImageStretch.SelectedIndex = 1;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}