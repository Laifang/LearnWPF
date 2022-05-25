using System;
using System.Collections.Generic;
using System.Data;
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
using LearnBinding.Tools;
namespace LearnBinding.BindingPath
{
    /// <summary>
    /// ADOAsSource.xaml 的交互逻辑
    /// 使用ADO.NET 作为数据源 也就是DataTable 
    /// </summary>
    public partial class ADOAsSource : Window
    {
        private List<Student> list;
        public ADOAsSource()
        {
            InitializeComponent();
             list = new List<Student>()
            {
                new Student(){Id=0,Age = 10,Name = "tom"},
                new Student(){Id=1,Age = 22,Name = "Jack"},
                new Student(){Id=2,Age = 11,Name = "summer"},
                new Student(){Id=3,Age = 32,Name = "home"},
                new Student(){Id=4,Age = 23,Name = "Hello"},
                new Student(){Id=5,Age = 16,Name = "John"},
                new Student(){Id=6,Age = 44,Name = "wei"},
                new Student(){Id=7,Age = 12,Name = "tim"},
            };


        }


        private void ButtonBase_OnClick1(object sender, RoutedEventArgs e)
        {
            DataTable dt = this.Load();
            this.ListBox1.DisplayMemberPath = "Name";
            this.ListBox1.ItemsSource = dt.DefaultView;
        }

        private void ButtonBase_OnClick2(object sender, RoutedEventArgs e)
        {
            DataTable dt = this.Load();
            this.ListView1.ItemsSource = dt.DefaultView;
        }        
        private void ButtonBase_OnClick3(object sender, RoutedEventArgs e)
        {
            DataTable dt = this.Load();
            this.ListView1.DataContext = dt;
            //DataTable不能直接作为 ListView 的 ItemSource 但如果设置为DataContext 在设置一个无source 和path的 binding  则会自动寻找
            this.ListView1.SetBinding(ListView.ItemsSourceProperty, new Binding());
        }

        private DataTable Load()
        {
            return list.ToDataTable();
        }
    }
}
