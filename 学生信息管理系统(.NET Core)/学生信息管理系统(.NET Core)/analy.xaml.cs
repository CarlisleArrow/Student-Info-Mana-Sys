using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace 学生信息管理系统_.NET_Core_
{
    /// <summary>
    /// analy.xaml 的交互逻辑
    /// </summary>
    public partial class analy : Window
    {
        //实例化WebBroswer控件，调用Power BI API呈现数据可视化效果
        public analy()
        {
            InitializeComponent();
            string url= "https://app.powerbi.com/view?r=eyJrIjoiMzhlMzhkYzMtNTk5Yy00MGQ5LWI2NzQtYzViZTA3ZDFkNjM1IiwidCI6IjNlYTQ5YmMyLWVmMWEtNDhjNC1hNDZhLWFhYTMyY2VjZTMzMCJ9";
            this.web.Navigate(url);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Stu stu = new Stu();
            stu.Show();
            this.Close();
        }
    }
}
