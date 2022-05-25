using System;
using System.Collections.Generic;
using System.Linq;
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

namespace LearnBinding.BindingSource
{
    /// <summary>
    /// RelativeSourceSample.xaml 的交互逻辑
    /// </summary>
    public partial class RelativeSourceSample : Window
    {
        public RelativeSourceSample()
        {
            InitializeComponent();
        }

        private void RelativeDockPanel(object sender, RoutedEventArgs e)
        {
            var rs = new RelativeSource
            {
                AncestorLevel = 2,
                AncestorType = typeof(DockPanel)
            };
            var binding = new Binding("Name") { RelativeSource = rs };
            this.TextBox.SetBinding(TextBox.TextProperty, binding);

        }

        private void RelativeGrid(object sender, RoutedEventArgs e)
        {
            var rs = new RelativeSource
            {
                AncestorLevel = 2,
                AncestorType = typeof(Grid)
            };
            var binding = new Binding("Name") { RelativeSource = rs };
            this.TextBox.SetBinding(TextBox.TextProperty, binding);
        }

        private void RelativeSelf(object sender, RoutedEventArgs e)
        {
            var rs = new RelativeSource
            {
                Mode = RelativeSourceMode.Self
            };
            var binding = new Binding("Name") { RelativeSource = rs };
            this.TextBox.SetBinding(TextBox.TextProperty, binding);
        }
    }
}
