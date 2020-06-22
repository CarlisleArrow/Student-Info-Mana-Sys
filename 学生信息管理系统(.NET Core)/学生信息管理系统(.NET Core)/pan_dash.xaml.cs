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
    /// pan_dash.xaml 的交互逻辑
    /// </summary>
    /// 疫情状况仪表板
    public partial class pan_dash : Page
    {
        
        public pan_dash()
        {
            InitializeComponent();
            string url = "https://app.powerbi.com/view?r=eyJrIjoiZDc5N2M3NTMtZDczNy00OTljLThjNzktMjExODQxMWU2M2MxIiwidCI6IjNlYTQ5YmMyLWVmMWEtNDhjNC1hNDZhLWFhYTMyY2VjZTMzMCJ9";
            this.web.Navigate(url);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            pandemic Pan = new pandemic();
            Pan.Show();
            (this.Parent as Window).Close();
        }
    }
}
