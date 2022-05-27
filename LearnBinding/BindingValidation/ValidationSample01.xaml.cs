using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace LearnBinding.BindingValidation
{
    /// <summary>
    /// ValidationSample01.xaml 的交互逻辑
    /// </summary>
    public partial class ValidationSample01 : Window
    {
        public ValidationSample01()
        {
            InitializeComponent();

            var binding = new Binding("Value")
            {
                Source = this.Slider01,
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
            };
            var vlr = new RangeValidation
            {
                //默认情况下，校验规则只会校验来自binding target的数据，
                //如果需要校验binding source 的数据 需要给校验规则加上如下属性
                ValidatesOnTargetUpdated = true
            };

            //一个绑定可以设定多个校验规则
            binding.ValidationRules.Add(vlr);

            //当需要将显示校验失败时携带的失败错误信息，则需要使用路由事件
            binding.NotifyOnValidationError = true;


            this.TextBox1.SetBinding(TextBox.TextProperty, binding);
            this.TextBox2.SetBinding(TextBox.TextProperty, binding);
            //为失败事件设定处理函数
            this.TextBox2.AddHandler(Validation.ErrorEvent, new RoutedEventHandler(this.ValidationError));
        }

        private void ValidationError(object sender, RoutedEventArgs e)
        {
            if (Validation.GetErrors(this.TextBox2).Count > 0)
            {
                // 接收校验失败事件后，对于处理函数所采取的的动作，
                // 在这里是把错误信息设置为textbox的tooltip属性，这是常见做法
                this.TextBox2.ToolTip = Validation.GetErrors(this.TextBox2)[0].ErrorContent.ToString();
            }
        }
    }
    /// <summary>
    /// 继承自ValidationRule抽象类需要实现Validate方法 来制定自己的校验规则
    /// </summary>
    public class RangeValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            //double d;
            if (double.TryParse(value.ToString(), out double d)){
                if (d >= 0 && d <= 100)
                    return new ValidationResult(true, "校验成功！");
            }
            return new ValidationResult(false, "校验失败:数据有效范围0-100!");
        }
    }
}

