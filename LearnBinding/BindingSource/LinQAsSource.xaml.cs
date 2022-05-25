using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;
using System.Xml.Linq;
using LearnBinding.Tools;

namespace LearnBinding.BindingSource
{
    /// <summary>
    /// LinQAsSource.xaml 的交互逻辑
    /// </summary>
    public partial class LinQAsSource : Window
    {
        private List<Student> list;
        public LinQAsSource()
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

            ListViewStudent.ItemsSource = list.Where(x => x.Age > 20);
        }
        private void ButtonBase_OnClick2(object sender, RoutedEventArgs e)
        {
            DataTable dt = list.ToDataTable();
            ListViewStudent.ItemsSource = from row in dt.Rows.Cast<DataRow>()
                where (int.Parse(row["Age"].ToString())>20) 
                select new Student()
                {
                    Id = int.Parse(row["Id"].ToString()),
                    Age = int.Parse(row["Age"].ToString()),
                    Name = row["Name"].ToString()
                };
        }
        private void ButtonBase_OnClick3(object sender, RoutedEventArgs e)
        {
            XDocument xdoc = XDocument.Load(@"D:\csharp_code\LearnWPF\LearnBinding\BindingPath\StudentData.xml");

            ListViewStudent.ItemsSource =
                from element in xdoc.Descendants("Student")
                where int.Parse(element.Element("Age").Value) > 20
                select new Student()
                {
                    Id = int.Parse(element.Attribute("Id").Value),
                    Age = int.Parse(element.Element("Age").Value),
                    Name = element.Element("Name").Value

                };
        }
    }
}
