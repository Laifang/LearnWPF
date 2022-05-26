using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace LearnBinding
{
    /// <summary>
    /// MultiBindingSample01.xaml 的交互逻辑
    /// </summary>
    public partial class MultiBindingSample01 : Window
    {
        public MultiBindingSample01()
        {
            InitializeComponent();
            this.SetMultiBinding();
        }

        private void SetMultiBinding()
        {
            //准备基础Binding
            var b1 = new Binding("Text") { Source = this.TextBox01 };
            var b2 = new Binding("Text") { Source = this.TextBox02 };
            var b3 = new Binding("Text") { Source = this.TextBox03 };
            var b4 = new Binding("Text") { Source = this.TextBox04 };

            //准备MultiBinding
            var mb = new MultiBinding(){Mode = BindingMode.OneWay};
            //注意：MultiBinding对添加顺序是敏感的
            mb.Bindings.Add(b1);
            mb.Bindings.Add(b2);
            mb.Bindings.Add(b3);
            mb.Bindings.Add(b4);
            mb.Converter = new LoginMultiConverter();
            //将MultiBinding与Button 的开关属性相关联
            this.Button1.SetBinding(Button.IsEnabledProperty, mb);
        }
    }

    internal class LoginMultiConverter : IMultiValueConverter
    {
        //设置button有效的校验逻辑
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var condition1 = values.Cast<string>().Any(text => string.IsNullOrEmpty(text));
            var condition2 = values[0].ToString() == values[1].ToString();
            var condition3 = values[2].ToString() == values[3].ToString();
            return condition1 && condition2 && condition3;
        }

        //不会被调用
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
