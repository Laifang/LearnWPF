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
using System.Xml;

namespace LearnBinding.BindingPath
{
    /// <summary>
    /// XMLAsSource.xaml 的交互逻辑
    /// </summary>
    public partial class XMLAsSource : Window
    {
        public XMLAsSource()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick1(object sender, RoutedEventArgs e)
        {
            XmlDocument doc =new XmlDocument();
            try
            {
                doc.Load(@"D:\csharp_code\LearnWPF\LearnBinding\BindingPath\StudentData.xml");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                throw;
            }
            

            XmlDataProvider xdp =new XmlDataProvider();
            xdp.Document = doc;

            xdp.XPath = @"/StudentList/Student";

            this.StudentListView.DataContext=xdp;
            this.StudentListView.SetBinding(ListView.ItemsSourceProperty, new Binding());
        }
        private void ButtonBase_OnClick2(object sender, RoutedEventArgs e)
        {

            //这里是对 XMLDataProvider source属性的另一个写法的示例
            XmlDataProvider xdp = new XmlDataProvider();
            xdp.Source = new Uri(@"D:\csharp_code\LearnWPF\LearnBinding\BindingPath\StudentData.xml");

            xdp.XPath = @"/StudentList/Student";

            this.StudentListView.DataContext = xdp;
            this.StudentListView.SetBinding(ListView.ItemsSourceProperty, new Binding());
        }
    }
}
