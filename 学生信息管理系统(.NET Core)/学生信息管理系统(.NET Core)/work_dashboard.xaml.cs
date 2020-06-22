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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace 学生信息管理系统_.NET_Core_
{
    /// <summary>
    /// work_dashboard.xaml 的交互逻辑
    /// </summary>
    /// 就业信息仪表板
    public partial class work_dashboard : Page
    {
        public work_dashboard()
        {
            InitializeComponent();
            string url = "https://app.powerbi.com/view?r=eyJrIjoiNzllM2EyOWQtZTViZi00NDk3LWE2ZWUtNGYxMGJiNzE5Y2VlIiwidCI6IjNlYTQ5YmMyLWVmMWEtNDhjNC1hNDZhLWFhYTMyY2VjZTMzMCJ9";
            this.web.Navigate(url);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            work Work = new work();
            Work.Show();
            (this.Parent as Window).Close();
        }
    }
}
