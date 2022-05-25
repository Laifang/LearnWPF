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

namespace LearnBinding.BindingPath
{
    /// <summary>
    /// EnuListAsSource.xaml 的交互逻辑
    /// </summary>
    public partial class EnuListAsSource : Window
    {
        public EnuListAsSource()
        {
            InitializeComponent();

            var list = new List<Student>()
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

            this.StudenListBox.ItemsSource = list;
            this.StudenListBox.DisplayMemberPath = "Name";

            var binding = new Binding("SelectedItem.Id") { Source = this.StudenListBox };
            this.IdTextBox.SetBinding(TextBox.TextProperty, binding);

        }
    }
}
