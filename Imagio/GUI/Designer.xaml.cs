using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Xml;
using Imagio.Drawing;
using Imagio.Extensions;
using Imagio.Properties;
using MahApps.Metro.Controls;

namespace Imagio.GUI
{
    /// <summary>
    ///     Interaction logic for Designer.xaml
    /// </summary>
    public partial class Designer : MetroWindow
    {
        private UIElement CopyTarget;
        private PolygonDraw polygonDraw;
        private RectDraw rectDraw;
        private EllipseDraw ellipseDraw;
        public Designer()
        {
            InitializeComponent();

            CanvasHandler.InitCanvasHandlers();

            Closing += (sender, args) => { Settings.Default.Save(); };

            PreviewKeyDown += (sender, e) =>
            {
                if (BaseHandler.ObjectSelected)
                {
                    //-- #######################################
                    //-- Copy
                    //-- #######################################
                    if (e.Key == Key.C && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
                    {
                        if (ImageHandler.SelectedImage != null)
                        {
                            var img = ImageHandler.SelectedImage;
                            var savedObject = XamlWriter.Save(img);

                            // Load the XamlObject
                            var stringReader = new StringReader(savedObject);
                            var xmlReader = XmlReader.Create(stringReader);
                            CopyTarget = (Canvas) XamlReader.Load(xmlReader);
                        }
                        if (ShapeHandler.SelectedImage != null)
                        {
                            var img = ShapeHandler.SelectedImage;
                            var savedObject = XamlWriter.Save(img);

                            // Load the XamlObject
                            var stringReader = new StringReader(savedObject);
                            var xmlReader = XmlReader.Create(stringReader);
                            CopyTarget = (Viewbox) XamlReader.Load(xmlReader);
                        }
                    }

                    //-- #######################################
                    //-- Paste
                    //-- #######################################
                    if (e.Key == Key.V && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
                    {
                        var canvas = CopyTarget as Canvas;
                        if (canvas != null)
                        {
                            ImageHandler.AddImageToCanvas(ref canvas);

                            var position = Mouse.GetPosition(MapCanvas);
                            Canvas.SetTop(CopyTarget, position.Y);
                            Canvas.SetLeft(CopyTarget, position.X);
                            ImageHandler.SelectedImage = canvas;
                            SelectionFilter.ChangeFilters(CopyTarget);

                            var savedObject = XamlWriter.Save(CopyTarget);

                            // Load the XamlObject
                            var stringReader = new StringReader(savedObject);
                            var xmlReader = XmlReader.Create(stringReader);
                            CopyTarget = (Canvas) XamlReader.Load(xmlReader);
                        }
                        var grid = CopyTarget as Viewbox;
                        if (grid != null)
                        {
                            ShapeHandler.AddImageToCanvas(ref grid);

                            var position = Mouse.GetPosition(MapCanvas);
                            Canvas.SetTop(CopyTarget, position.Y);
                            Canvas.SetLeft(CopyTarget, position.X);
                            ShapeHandler.SelectedImage = grid;
                            SelectionFilter.ChangeFilters(CopyTarget);

                            var savedObject = XamlWriter.Save(CopyTarget);

                            // Load the XamlObject
                            var stringReader = new StringReader(savedObject);
                            var xmlReader = XmlReader.Create(stringReader);
                            CopyTarget = (Viewbox) XamlReader.Load(xmlReader);
                        }
                    }
                    //-- #######################################
                    //-- Delete
                    //-- #######################################
                    if (e.Key == Key.Delete)
                    {
                        if (ImageHandler.SelectedImage != null)
                        {
                            MapCanvas.Children.Remove(ImageHandler.SelectedImage);
                        }

                        if (ShapeHandler.SelectedImage != null)
                        {
                            MapCanvas.Children.Remove(ShapeHandler.SelectedImage);
                        }
                    }
                }
            };
        }


        private void foregroundColorPanel_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                foregroundColorPanel.Background = new SolidColorBrush(colorDialog.Color.ToMediaColor());
            }
        }

        private void backgroundColorPanel_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                backgroundColorPanel.Background = new SolidColorBrush(colorDialog.Color.ToMediaColor());
                ;
            }
        }

        private void btnImportImage_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var bitmap = new BitmapImage(new Uri(fileDialog.FileName));
                var img = new Canvas
                {
                    Background = new ImageBrush
                    {
                        ImageSource = bitmap,
                        Stretch = Stretch.None
                    }
                };
                img.Width = bitmap.Width;
                img.Height = bitmap.Height;

                ImageHandler.AddImageToCanvas(ref img);
            }
        }

        private void MenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            var fileDialog = new SaveFileDialog();
            if (fileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ImageFileHandler.SaveImage(MapCanvas, fileDialog.FileName);
            }
        }

        private void MapToggle_Checked(object sender, RoutedEventArgs e)
        {
            GridCanvas.DrawGrid();
        }

        private void MapToggle_Unchecked(object sender, RoutedEventArgs e)
        {
            GridCanvas.DrawGrid();
        }

        private void btnPolygonDraw_Click(object sender, RoutedEventArgs e)
        {
            polygonDraw = new PolygonDraw();
            polygonDraw.Start();
        }


        private void MenuItem_Save(object sender, RoutedEventArgs e)
        {
            var sf = new SaveFileDialog();
            sf.Filter = "*.xml|XML File";
            var result = sf.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                var savedObject = XamlWriter.Save(MapCanvas);
                File.WriteAllText(sf.FileName, savedObject);
            }
        }

        private void MenuItem_Open(object sender, RoutedEventArgs e)
        {
            var fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var content = File.ReadAllText(fileDialog.FileName);
                var stringReader = new StringReader(content);
                var xmlReader = XmlReader.Create(stringReader);
                MapCanvas = (Canvas) XamlReader.Load(xmlReader);
                CanvasHandler.InitCanvasHandlers();
            }
        }

        private void BtnRectDraw_OnClick(object sender, RoutedEventArgs e)
        {
            rectDraw = new RectDraw();
            rectDraw.Start();
        }

        private void BtnEllipseDraw_OnClick(object sender, RoutedEventArgs e)
        {
            ellipseDraw = new EllipseDraw();
            ellipseDraw.Start();
        }
 

        private void btnCapture_Click_1(object sender, RoutedEventArgs e)
        {
            new CaptureWindow().Show();
        }

        private void btnAddObject_Click(object sender, RoutedEventArgs e)
        {
            new ObjectBrowser().Show();
        }

        private void btnImportImage_Click(object sender, RoutedEventArgs e)
        {
            var fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var bitmap = new BitmapImage(new Uri(fileDialog.FileName));
                var img = new Canvas
                {
                    Background = new ImageBrush
                    {
                        ImageSource = bitmap,
                        Stretch = Stretch.None
                    }
                };
                img.Width = bitmap.Width;
                img.Height = bitmap.Height;

                ImageHandler.AddImageToCanvas(ref img);
            }
        }

        private void btnSendBack_Click(object sender, RoutedEventArgs e)
        {

            if (ImageHandler.SelectedImage != null)
            {
                Canvas.SetZIndex(ImageHandler.SelectedImage, Canvas.GetZIndex(ImageHandler.SelectedImage)-10);
        
            }

            if (ShapeHandler.SelectedImage != null)
            {
                Canvas.SetZIndex(ShapeHandler.SelectedImage, Canvas.GetZIndex(ShapeHandler.SelectedImage) - 10);
            }
        }

        private void btnMeasure_Click(object sender, RoutedEventArgs e)
        {
            new MeasureWindow().ShowDialog();
        }
    }
}