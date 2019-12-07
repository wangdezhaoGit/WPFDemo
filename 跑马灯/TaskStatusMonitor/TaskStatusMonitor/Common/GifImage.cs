using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace TaskStatusMonitor.Common
{
    public class GifImage:Image
    {
        public static DependencyProperty IsVisableProperty = DependencyProperty.Register("VisableChanged", typeof(bool), typeof(GifImage), new PropertyMetadata(new PropertyChangedCallback(OnVisableChanged)));
        public bool VisableChanged
        {
            get
            {

                return (bool)GetValue(IsVisableProperty);
            }
            set
            {
                SetValue(IsVisableProperty, value);

            }
        }
        static ImageSource imageSource;
        public GifImage()
        {
            try
            {
                if (imageSource == null)
                    imageSource = new BitmapImage(new Uri(@"D:\dezhaowang\Test\跑马灯\TaskStatusMonitor\TaskStatusMonitor\Images\66.gif"));
            }
            catch (Exception ex)
            {

            }
        }
        static void OnVisableChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                   Image image = sender as Image;
                if (image != null)
                {

                    if (image.IsVisible)
                    {
                        image.SetValue(WpfAnimatedGif.ImageBehavior.AnimatedSourceProperty, imageSource);
                    }
                    else
                    {
                        image.SetValue(WpfAnimatedGif.ImageBehavior.AnimatedSourceProperty, null);
                    }
                }

            }
            catch (Exception ex)
            {

            }
        }
    }
}
