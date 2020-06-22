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
    /// kb.xaml 的交互逻辑
    /// </summary>
    public partial class kb : Window
    {
        public kb()
        {
            InitializeComponent();
            string sql = "select Name from Student";
            SqlConnection conn = new SqlConnection(DataOper.connString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            this.Display.Content = Display.Content + cmd.ExecuteScalar().ToString();
            
            //获取学生学号
            string stuxuehao = MainWindow.ID();

            string sql1 = "select stuid from Student where Number = '" + stuxuehao + "'";
            SqlCommand cmd1 = new SqlCommand(sql1, conn);
            String id1 = cmd1.ExecuteScalar().ToString();
            int stuid = 0;
            int.TryParse(id1, out stuid);
            //用到两个数据库的连接操作
            //建立DataGrid标头，对应数据库内容呈现
            sql1 = "select claid as 编号,coursename as 课程名称,teacher as 教师,term as 学期,time as 上课时间,location as 上课地点 from selection";
            SqlDataAdapter adp1 = new SqlDataAdapter(sql1, conn);
            DataSet ds = new DataSet();
            adp1.Fill(ds);
            //载入基本信息
            kb1.ItemsSource = ds.Tables[0].DefaultView;
            conn.Close();
        }

        private void kb1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Stu stu = new Stu();
            stu.Show();
            
        }
    }
    }

