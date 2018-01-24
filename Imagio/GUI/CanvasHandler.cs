using System;
using System.Windows;
using System.Windows.Input;
using Imagio.Properties;

namespace Imagio.GUI
{
    internal static class CanvasHandler
    {
        public static void InitCanvasHandlers()
        {
            var window = Application.Current.MainWindow as Designer;
            window.txtRatio.Text = "1m : " + Settings.Default.PixelMeterRatio + "px";
            window.MapCanvas.PreviewMouseLeftButtonDown += (sender, args) =>
            {
                SelectionFilter.ChangeFilters(null);
                ImageHandler.SelectedImage = null;
                ShapeHandler.SelectedImage = null;
            
            };

            window.MapCanvas.PreviewMouseMove += (sender, args) =>
            {
                var point = args.GetPosition(window.MapCanvas);
                window.txtCursor.Text = string.Format("x: {0}px, y: {1}px",(int) point.X, (int)point.Y);
                window.txtCursorMeters.Text = string.Format("x: {0}m, y: {1}m",  (point.X/Settings.Default.PixelMeterRatio).ToString("N"), (point.Y / Settings.Default.PixelMeterRatio).ToString("N"));
            };

            window.MapCanvas.MouseWheel += (sender, args) =>
            {
                if (Keyboard.IsKeyDown(Key.LeftAlt) && BaseHandler.ObjectSelected == false )
                {
                    if (args.Delta > 0)
                    {
                        window.TxtMapZoom.Text = (Convert.ToSingle(window.TxtMapZoom.Text)*1.15).ToString();
                    }
                    else
                    {
                        window.TxtMapZoom.Text = (Convert.ToSingle(window.TxtMapZoom.Text)/1.15).ToString();
                    }

                    window.PanningCanvas.InvalidateMeasure();
                }
            };
        }
    }
}