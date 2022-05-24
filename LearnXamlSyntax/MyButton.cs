using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace LearnXamlSyntax
{
    internal class MyButton : Button
    {
        public Type MyWindowType { set; get; }

        protected override void OnClick()
        {
            base.OnClick();
            var window = Activator.CreateInstance(this.MyWindowType) as Window;

            if (window !=null)
            {
                window.ShowDialog();
            }

        }
    
    
}
}
