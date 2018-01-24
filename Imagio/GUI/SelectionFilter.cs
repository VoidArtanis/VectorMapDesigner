using System.Windows;
using System.Windows.Media;
using Microsoft.Expression.Media.Effects;

namespace Imagio.GUI
{
    static class SelectionFilter
    {

        public static void ChangeFilters(object sender)
        {
            var window = App.Current.MainWindow as Designer;

            var self = sender as UIElement;
            foreach (var child in window.MapCanvas.Children)
            {
                var element = child as UIElement;
                if (element != self)
                    element.Effect = null;
            }
            if (self != null && self.Effect == null)
            {
                var tone = new ColorToneEffect();
                tone.DarkColor = Colors.Brown;
                tone.LightColor = Colors.Red;
                self.Effect = tone;
            }
        }
    }
}
