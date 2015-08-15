using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DatFramework.Views
{
    public class ImageOnlyButton : Button
    {
        static ImageOnlyButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ImageOnlyButton), new FrameworkPropertyMetadata(typeof(ImageOnlyButton)));
        }

        public ImageSource Image
        {
            get { return (ImageSource)GetValue(ImageProperty); }
            set { SetValue(ImageProperty, value); }
        }

        public static readonly DependencyProperty ImageProperty = DependencyProperty.Register
        (
            "Image",
            typeof(ImageSource),
            typeof(ImageOnlyButton), 
            new PropertyMetadata(null)
        );

        public double ImageHeight
        {
            get { return (double)GetValue(ImageHeightProperty); }
            set { SetValue(ImageHeightProperty, value); }
        }

        public static readonly DependencyProperty ImageHeightProperty = DependencyProperty.Register
        (
            "ImageHeight",
            typeof(double),
            typeof(ImageOnlyButton), 
            new PropertyMetadata(Double.NaN)
        );

        public double ImageWidth
        {
            get { return (double)GetValue(ImageWidthProperty); }
            set { SetValue(ImageWidthProperty, value); }
        }

        public static readonly DependencyProperty ImageWidthProperty = DependencyProperty.Register
        (
            "ImageWidth",
            typeof(double),
            typeof(ImageOnlyButton), 
            new PropertyMetadata(Double.NaN)
        );
    }
}
