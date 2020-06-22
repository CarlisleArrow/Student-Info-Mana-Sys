using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Diagnostics;

namespace 学生信息管理系统_.NET_Core_
{
    /// <summary>
    /// dev.xaml 的交互逻辑
    /// </summary>
    public partial class dev : Window
    {
        public dev()
        {
            InitializeComponent();
            SqlConnection conn = new SqlConnection(DataOper.connString);
            conn.Open();
            string sql = "select class as 课程, stuid as 学分,grades as 成绩 from sc order by grades desc";
            SqlDataAdapter adp1 = new SqlDataAdapter(sql, conn);
            DataTable ds = new DataTable();
            adp1.Fill(ds);
            //载入基本信息
            cj.ItemsSource = ds.DefaultView;
            conn.Close();
        }

        

        private void mbti_Click(object sender, RoutedEventArgs e)
        {
            // System.Diagnostics.Process.Start("http://www.apesk.com/mbti");
            var resultchrome = Process.Start(@"C:\Program Files\Internet Explorer\iexplore.exe", "http://www.apesk.com/mbti" ); //谷歌浏览器
            if (resultchrome == null)
            {
                Process.Start("iexplore.exe", "http://www.apesk.com/mbti");
            }

            //System.Diagnostics.Process.Start("iexplore.exe","https://wwww.baidu.com");
        }

        private void hld_Click(object sender, RoutedEventArgs e)
        {
            //System.Diagnostics.Process.Start("iexplore.exe","http://www.apesk.com/holland/index.html");
            var resultchrome = Process.Start(@"C:\Program Files\Internet Explorer\iexplore.exe", "http://www.apesk.com/holland/index.html"); //谷歌浏览器
            if (resultchrome == null)
            {
                Process.Start("iexplore.exe", "http://www.apesk.com/holland/index.html");
            }
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            Stu stu = new Stu();
            stu.Show();
            this.Close();
        }

        private void next_Click(object sender, RoutedEventArgs e)
        {
            this.Content = new next();

        }
    }
}
