using System.Windows;

namespace LearnBinding.BindingSource
{
    /// <summary>
    /// BindingWithoutSource.xaml 的交互逻辑
    /// </summary>
    public partial class BindingWithoutSource : Window
    {
        public BindingWithoutSource()
        {
            InitializeComponent();
        }
    }

    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
