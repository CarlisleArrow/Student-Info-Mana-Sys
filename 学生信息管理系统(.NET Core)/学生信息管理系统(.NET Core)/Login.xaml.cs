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
using System.Data;
using System.Data.SqlClient;

namespace 学生信息管理系统_.NET_Core_
{
    /// <summary>
    /// Login.xaml 的交互逻辑
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            string sql = "select Name from Student";
            SqlConnection conn = new SqlConnection(DataOper.connString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            this.display.Content = display.Content + cmd.ExecuteScalar().ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Stu stu = new Stu();
            stu.Show();
            this.Close();
        }
    }
}
