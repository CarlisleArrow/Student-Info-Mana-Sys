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
using System.Data;
using System.Data.SqlClient;

using System.Diagnostics;

namespace 学生信息管理系统_.NET_Core_
{
    /// <summary>
    /// next.xaml 的交互逻辑
    /// </summary>
    public partial class next : Page
    {
        public next()
        {
            //调取数据库推荐课表信息
            InitializeComponent();
            SqlConnection conn = new SqlConnection(DataOper.connString);
            conn.Open();
            string sql = "select claid as 编号,课程代码 as 课程代码, 课程名称 as 课程,学分 as 学分 from optcour ";
            SqlDataAdapter adp1 = new SqlDataAdapter(sql, conn);
            DataTable ds = new DataTable();
            adp1.Fill(ds);
            //载入基本信息
            selection.ItemsSource = ds.DefaultView;

            string sql1 = "select claid as 编号,课程代码 as 课程代码, 课程名称 as 课程,学分 as 学分,开课院系 as 开课院系 from more ";
            SqlDataAdapter adp2 = new SqlDataAdapter(sql1,conn);
            DataTable ds1 = new DataTable();
            adp2.Fill(ds1);
            more.ItemsSource = ds1.DefaultView;
            conn.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            // var resultchrome = Process.Start(@"C:\Program Files (x86)\Microsoft\Edge Beta\Application\msedge.exe", "https://app.powerbi.com/groups/me/reports/2bea8c90-ffa2-49d4-94c6-09d8421c1975/ReportSection"); //谷歌浏览器
            // if (resultchrome == null)
            //{
            //  Process.Start("msedge.exe", "https://app.powerbi.com/groups/me/reports/2bea8c90-ffa2-49d4-94c6-09d8421c1975/ReportSection");
            //}
            analy Analy = new analy();
            Analy.Show();



        }
    }
}
