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

namespace LearnXamlSyntax
{
    /// <summary>
    /// 展示x_key用法.xaml 的交互逻辑
    /// </summary>
    public partial class 展示x_key用法 : Window
    {
        public 展示x_key用法()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var str = this.FindResource("myString") as string;
            TextBlock1.Text=str;
        }
    }
}
