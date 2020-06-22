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
    /// heart.xaml 的交互逻辑
    /// </summary>
    public partial class heart : Window
    {
        public heart()
        {
            InitializeComponent();
        }

        

        private void back_Click(object sender, RoutedEventArgs e)
        {
            Stu stu = new Stu();
            stu.Show();
            this.Close();
        }
        //心理仪表板Power BI API呈现
        private void Dashboard_Click(object sender, RoutedEventArgs e)
        {
            Dashboard dash = new Dashboard();
            dash.Show();
            this.Close();
        }
    }
}
