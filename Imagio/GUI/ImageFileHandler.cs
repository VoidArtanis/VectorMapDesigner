using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Imagio.GUI
{
    public class ImageFileHandler
    {
        public static void SaveImage(Canvas control,string path)
        {
            control.Measure(new Size((int)control.ActualWidth, (int)control.ActualHeight));
            control.Arrange(new Rect(new Size((int)control.ActualWidth, (int)control.ActualHeight)));
            RenderTargetBitmap rtb = new RenderTargetBitmap((int)control.ActualWidth, (int)control.ActualHeight, 96, 96, PixelFormats.Pbgra32);
            rtb.Render(control);
     
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                PngBitmapEncoder encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(rtb));
                encoder.Save(stream);
            }

        }
    }
}