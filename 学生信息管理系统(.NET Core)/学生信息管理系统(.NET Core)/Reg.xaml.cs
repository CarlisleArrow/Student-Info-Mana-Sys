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
    /// Reg.xaml 的交互逻辑
    /// </summary>
    /// 注册页面
    public partial class Reg : Window
    {
        public Reg()
        {
            InitializeComponent();
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainWindow mainwindow = new MainWindow();
            mainwindow.Show();
        }
    }
}
