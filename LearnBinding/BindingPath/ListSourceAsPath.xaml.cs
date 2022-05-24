using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// ListSourceAsPath.xaml 的交互逻辑
    /// 集合对象作为绑定源时  path可以做的操作
    /// </summary>
    public partial class ListSourceAsPath : Window
    {
        public ListSourceAsPath()
        {

            InitializeComponent();
            strList = new List<string>() { "tim", "jack", "mike" };
            //默认元素作为Path使用  path="/"
            TextBox1.SetBinding(TextBox.TextProperty, new Binding("/") { Source = strList });
            TextBox2.SetBinding(TextBox.TextProperty, new Binding("/Length") { Source = strList, Mode = BindingMode.OneWay });
            TextBox3.SetBinding(TextBox.TextProperty, new Binding("/[2]") { Source = strList, Mode = BindingMode.OneWay });


            countries = new List<Country>()
            {
                new Country(){Name = "中国",Provinces = new List<Province>()
                {
                    new Province()
                    {
                        Name = "广东省",
                        Cities = new List<City>()
                        {
                            new City(){Name = "深圳市"},
                            new City(){Name ="广州市"}
                        },
                    },
                    new Province()
                    {
                        Name = "江西",
                        Cities = new List<City>()
                        {
                            new City(){Name = "赣州市"},
                            new City(){Name = "南昌市"}
                        },
                    }

                }},
                new Country(){Name = "美国",Provinces = new List<Province>()},

            };

            //这种语法不好用，带有疑惑性,还不如 一路点进去：多级路径
            //List元素默认 就是集合第一个元素 使用path="/"表示 ,如果是第n个需要path="[n-1].Property"来表示属性
            // 疑问：这里怎么样用xaml标记扩展语法来binding
            // 因为在xaml中不能直接访问 c#代码中定义和声明的元素 ，暂时还不知道如何解决这个问题，
            // 难道在xaml中只能定义 控件之间的绑定吗？ 思考 2022年5月24日16点47分
            TextBox4.SetBinding(TextBox.TextProperty, new Binding("[1].Name") { Source = countries });

            TextBox5.SetBinding(TextBox.TextProperty, new Binding("Provinces[1].Cities[1].Name") { Source = countries });
            TextBox6.SetBinding(TextBox.TextProperty, new Binding("/Provinces/Cities[1].Name") { Source = countries });


        }

        private List<string> strList;
        private List<Country> countries;


        
    }

    class City
    {
        public string Name { get; set; }
    }

    class Province
    {
        public string Name { get; set; }
        public List<City> Cities { get; set; }
    }

    class Country
    {
        public string Name { get; set; }
        public List<Province> Provinces { get; set; }
    }

}
