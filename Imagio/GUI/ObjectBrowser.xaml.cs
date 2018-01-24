using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Image = Imagio.Models.Image;

namespace Imagio.GUI
{
    /// <summary>
    /// Interaction logic for ObjectBrowser.xaml
    /// </summary>
    public partial class ObjectBrowser : Window
    {
        public static Dictionary<string, List<Image>> dict = new Dictionary<string, List<Image>>();
        public ObjectBrowser()
        {

            InitializeComponent();

            dict.Clear();
            tabControl.Items.Clear();
            foreach (var dir in Directory.GetDirectories(".\\objects"))
            {
                var name = new DirectoryInfo(dir).Name;
                tabControl.Items.Add(name);
                foreach (var file in Directory.GetFiles(dir, "*.*", SearchOption.AllDirectories))
                {
                    if (dict.ContainsKey(name))
                    {
                        dict[name].Add(new Image()
                        {
                            Path = Directory.GetParent(Assembly.GetExecutingAssembly().Location) + file,
                            Title = new FileInfo(file).Name
                        });
                    }
                    else
                    {
                        dict.Add(name, new List<Image>()
                        {
                            new Image()
                            {
                                       Path = Directory.GetParent(Assembly.GetExecutingAssembly().Location) + file,
                            Title = new FileInfo(file).Name
                            }
                        });
                    }

                }

            }
            lst.ItemsSource = dict["Furniture"];
            tabControl.SelectionChanged += TabControl_SelectionChanged;
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (tabControl.SelectedValue as String != null && dict.ContainsKey(tabControl.SelectedValue as String))
                lst.ItemsSource = dict[tabControl.SelectedValue as String];
        }

        private void lst_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (lst.SelectedItem != null)
            {
                var grd = new Viewbox();
                var bitmap = new BitmapImage(new Uri((lst.SelectedItem as Image).Path));
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
            Close();
        }
    }
}
