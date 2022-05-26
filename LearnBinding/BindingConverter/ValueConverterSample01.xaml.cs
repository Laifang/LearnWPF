using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Data;

namespace LearnBinding.BindingConverter
{
    /// <summary>
    ///     ValueConverterSample01.xaml 的交互逻辑
    /// </summary>
    public partial class ValueConverterSample01 : Window
    {
        public ValueConverterSample01()
        {
            InitializeComponent();
        }

        private void BtnLoadClicked(object sender, RoutedEventArgs e)
        {
            var list = new List<Plane>()
            {
                new Plane(){Category=Category.AirPlane,Name="B-1",State=State.Unknown}, 
                new Plane(){Category=Category.AirPlane,Name="B-2",State=State.Unknown}, 
                new Plane(){Category=Category.Fighter,Name="F-22", State = State.Unknown},
                new Plane(){Category=Category.Fighter, Name="Su-47",State=State.Unknown},
                new Plane(){Category=Category.AirPlane,Name="B-52",State =State.Unknown}, 
                new Plane(){Category=Category.Fighter,Name="J-10",State=State.Unknown}
            };
            this.ListBoxPlane.ItemsSource = list;
        }

        private void BtnSaveClicked(object sender, RoutedEventArgs e)
        {
            var sb = new StringBuilder();
            foreach (Plane item in ListBoxPlane.Items)
            {
                sb.AppendLine(string.Format("Category={0},Name={1},State{2}", item.Category, item.Name, item.State));

            }
            File.WriteAllText(@"\PlaneList.txt",sb.ToString());
            MessageBox.Show("文件写入成功！");
        }
    }

    /// <summary>
    ///     飞机种类：AirPlane 客机，Fighter 战斗机
    /// </summary>
    public enum Category
    {
        AirPlane,
        Fighter
    }

    /// <summary>
    ///     飞机状态：
    ///     Available 可用，Locked锁定，Unknown 未知
    /// </summary>
    public enum State
    {
        Available,
        Locked,
        Unknown
    }

    public class Plane
    {
        public Category Category { set; get; }
        public State State { get; set; }
        public string Name { get; set; }
    }


    public class CategoryToSourceConverter : IValueConverter
    {
        /// <summary>
        ///     因为这里会根据不同的飞机类型在UI上显示不同的图标，
        ///     所以这里将Category转换为URI,编译器会把string 当做URI资源的路径
        /// </summary>
        /// <returns>URI_Path</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var c = (Category)value;
            switch (c)
            {
                case Category.AirPlane:
                    return @"\Icons\客机.png";
                case Category.Fighter:
                    return @"\Icons\战斗机.png";
                default:
                    return null;
            }
        }

        //这里逻辑上设置不会被调用，因为图标不允许用户更改
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class StateToNullableBoolConverter : IValueConverter
    {
        /// <summary>
        ///     将源中State枚举类型转换为UI里的可空bool型
        /// </summary>
        /// <returns>True or False Or Null</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var s = (State)value;
            switch (s)
            {
                case State.Available:
                    return true;
                case State.Locked:
                    return false;
                case State.Unknown:
                default:
                    return null;
            }
        }
        /// <summary>
        /// 将Bool型数据从UI转换为源的State枚举型
        /// </summary>
        /// <returns>State Enum:Available,Locked,Unknown</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var bol = (bool?)value;
            switch (bol)
            {
                case true:
                    return State.Available;
                case false:
                    return State.Locked;
                case null:
                default:
                    return State.Unknown;
            }
        }
    }
}