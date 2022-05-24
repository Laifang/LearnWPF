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

namespace LearnControl
{
    /// <summary>
    /// TestListControl.xaml 的交互逻辑
    /// </summary>
    public partial class TestListControl : Window
    {
        public TestListControl()
        {
            InitializeComponent();
        }

        private void Button3_OnClick(object sender, RoutedEventArgs e)

        {
            var btn =sender as Button;
            var lv1 = VisualTreeHelper.GetParent(btn);
            var lv2 = VisualTreeHelper.GetParent(lv1);
            var lv3 = VisualTreeHelper.GetParent(lv2);


            MessageBox.Show("lv1:"+lv1.GetType().ToString());
            MessageBox.Show("lv2:"+lv2.GetType().ToString());
            MessageBox.Show("lv3:"+lv3.GetType().ToString());
        }
    }
}
