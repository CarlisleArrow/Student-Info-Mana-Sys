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
using System.Data.SqlClient;

namespace 学生信息管理系统_.NET_Core_
{
    /// <summary>
    /// aolan.xaml 的交互逻辑
    /// </summary>
    public partial class aolan : Page
    {
        public aolan()
        {
           
            InitializeComponent();
            //显示用户名
            string sql = "select Name from Student";
            SqlConnection conn = new SqlConnection(DataOper.connString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            this.Display.Content = Display.Content + cmd.ExecuteScalar().ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Stu stu = new Stu();
            stu.Show();
            (this.Parent as Window).Close();

        }

        private void selection1_Click(object sender, RoutedEventArgs e) //显示进入对话框
        {
            MessageBox.Show("您好，欢迎进入职业发展规划平台。本平台内所有内容仅供参考，涉及到的第三方测评请您注意甄别并保留您的测试结果，谨防信息泄露。");
            dev Dev = new dev();
            Dev.Show();
            (this.Parent as Window).Close();

        }

       
        private void enter(object sender, RoutedEventArgs e)
        {
            information info = new information();
            info.Show();
            (this.Parent as Window).Close();
        }
      

        private void heart_Click_1(object sender, RoutedEventArgs e)
        {
            heart Heart = new heart();
            Heart.Show();
            (this.Parent as Window).Close();
        }

        private void work_Click(object sender, RoutedEventArgs e)
        {
            work Work = new work();
            Work.Show();
            (this.Parent as Window).Close();
        }

        private void pandemic_Click(object sender, RoutedEventArgs e)
        {
            pandemic Pandemic = new pandemic();
            Pandemic.Show();
            (this.Parent as Window).Close();
        }
    }
}
