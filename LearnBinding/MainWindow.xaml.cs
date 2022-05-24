using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace LearnBinding
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window

    {
        private Student stu;
        public MainWindow()
        {
            InitializeComponent();
            ////数据源
            //stu = new Student();
            ////准备Binding
            //Binding binding = new Binding();
            //binding.Source = stu;
            //binding.Path = new PropertyPath("Name");

            ////使用Binding 连接数据源与Binding 目标（Ui界面元素）
            //BindingOperations.SetBinding(this.TextBox, TextBox.TextProperty, binding);

            //上述可以简化如下 三合一操作
            this.TextBox.SetBinding(TextBox.TextProperty, new Binding("Name") { Source = stu = new Student() });

            // this.TextBox2.SetBinding(Texbox2.TextProperty,new Binding("value"){ElementName="Silder"});
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            stu.Name += "名字"; 
            //注意现在操作的是stu对象的名字却改变了textbox的值
        }
    }

    public class Student:INotifyPropertyChanged //实现属性变更接口

    {
    private string _name;

    public string Name
    {
        get => _name;
        set
        {
            _name = value;
            // 触发事件
            if (this.PropertyChanged !=null)
            {
                //出发参数为Name的 属性变更事件 调用响应方法
                this.PropertyChanged.Invoke(this,new PropertyChangedEventArgs("Name"));
            }
        }
        
    }
        //实现接口的 属性变更事件
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
