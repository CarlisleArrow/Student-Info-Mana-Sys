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
using System.Data;


namespace 学生信息管理系统_.NET_Core_
{
    /// <summary>
    /// jw.xaml 的交互逻辑
    /// </summary>
    public partial class jw : Page
    {
        public jw()
        {
            InitializeComponent();
            string sql = "select Name from Student";
            SqlConnection conn = new SqlConnection(DataOper.connString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            this.Display.Content = Display.Content + cmd.ExecuteScalar().ToString();
            /*
            SqlConnection con = new SqlConnection("server=DESKTOP-JGJJF13;database=db_Sys;user=sa;pwd=msosg00921");
            con.Open();
            //执行con对象的函数，返回一个SqlCommand类型的对象
            SqlCommand cmd = con.CreateCommand();
            //把输入的数据拼接成sql语句，并交给cmd对象
            cmd.CommandText = "select*from Course1";

            //用cmd的函数执行语句，返回SqlDataReader类型的结果dr,dr就是返回的结果集（也就是数据库中查询到的表数据）
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                //构建一个ListView的数据，存入数据库数据，以便添加到listView1的行数据中
                info.Items.Add(dr["CourseCode"].ToString() +"         "+ dr["course"].ToString()+ "         "+dr["gpas"].ToString()+ "         "+dr["grade"].ToString()+ "         "+dr["pass"].ToString());
               
            }

            con.Close();
            */
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Stu stu = new Stu();
            stu.Show();
            (this.Parent as Window).Close();


        }

        private void selection1_Click(object sender, RoutedEventArgs e)
        {
            msg Msg = new msg();
            Msg.Show();
        }

        private void table1_Click(object sender, RoutedEventArgs e)
        {
            kb KB = new kb();
            KB.Show();
            (this.Parent as Window).Close();
        }

        private void grade_Click(object sender, RoutedEventArgs e)
        {
            score Score=new score();
            Score.Show();
            (this.Parent as Window).Close();
        }

        private void more_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("正在建设，无法访问", "建设中...", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
