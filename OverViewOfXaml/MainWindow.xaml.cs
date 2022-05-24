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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LearnXaml
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //var filePath = @"D:\Users\Desire\Desktop\数据运维审批跟踪评价台账(2022-02-10).xlsx";
            //var dmsList = Tools.ReadExcel(filePath, "A3");
            //dmsList = Tools.FiltrateByMonth("2022/4", dmsList);

            //var reportList = Tools.GeneratorReport(dmsList);
            //DataGrid.ItemsSource = reportList;
        }
    }
}
