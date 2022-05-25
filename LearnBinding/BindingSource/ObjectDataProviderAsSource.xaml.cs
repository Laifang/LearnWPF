using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace LearnBinding.BindingSource
{
    /// <summary>
    /// ObjectDataProviderAsSource.xaml 的交互逻辑
    /// </summary>
    public partial class ObjectDataProviderAsSource : Window
    {
        public ObjectDataProviderAsSource()
        {
            InitializeComponent();
            this.SetBinding();
        }

        private void SetBinding()
        {
            //创建并配置ObjectDataProvider 对象
            var odp = new ObjectDataProvider
            {
                ObjectInstance = new Calculator(),
                MethodName = "Add"
            };
            //为Add方法的两个参数设置的值
            odp.MethodParameters.Add("0");
            odp.MethodParameters.Add("0");

            //以ObjectDataProvider 对象为Source创建Binding
            var bindingToArg1=new Binding("MethodParameters[0]")
            {
                Source = odp,
                //这句话的意思是 Binding对象只负责把UI元素收集到的数据写入其直接Source
                //(即ObjectDataProvider对象)而不是被ObjectDataProvider对象包装着的Calculator对象
                BindsDirectlyToSource = true,
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
                //一般来说如果 数据从哪里 那binding的源就是谁， 这里两个TextBox1,2 就应该是MethodParameters 的binding源，
                //但是因为MethodParameters 不是依赖属性不能设置为Binding的Target
                //在这里将 odp 设置为源 且Path 为MethodParameters 是将源和target反转了 并且限制了数据的流向
                //数据驱动UI的理念要求尽可能地使用数据对象作为Binding的Source而使UI元素作为Binding的Target

            };           
            var bindingToArg2=new Binding("MethodParameters[1]")
            {
                Source = odp,
                BindsDirectlyToSource = true,
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
            };
            //数据源本身就代表数据的时候 path使用 "."，且在XAML中 这个"."可以略写
            var bindingToResult = new Binding(".")
            {
                Source = odp
            };
            
            //将Binding 关联到UI元素上
            this.TextBox1.SetBinding(TextBox.TextProperty, bindingToArg1);
            this.TextBox2.SetBinding(TextBox.TextProperty, bindingToArg2);
            this.TextBox3.SetBinding(TextBox.TextProperty, bindingToResult);
        }
    }

    public class Calculator
    {


        public string Add(string arg1, string arg2)
        {
            double x = 0;
            double y = 0;
            double z = 0;
            if (double.TryParse(arg1, out x) && double.TryParse(arg2, out y))
            {
                z = x + y;
                return z.ToString();
            }
            return "InputError!";
        }
    }
}
