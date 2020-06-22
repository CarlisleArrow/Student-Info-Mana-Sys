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
    /// score.xaml 的交互逻辑
    /// </summary>
    /// 成绩查询
    public partial class score : Window
    {
        public score()
        {
            InitializeComponent();
            string sql = "select Name from Student";
            SqlConnection conn = new SqlConnection(DataOper.connString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            this.Display.Content = Display.Content + cmd.ExecuteScalar().ToString();




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
        //选择学期后再进行查询
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string term = comboBox1.SelectedItem.ToString();
            Console.WriteLine(term);
            SqlConnection conn = new SqlConnection(DataOper.connString);
            conn.Open();
            string sql = "select scid as 编号,class as 课程, stuid as 学分,grades as 成绩 from sc ";
            SqlDataAdapter adp1 = new SqlDataAdapter(sql, conn);
            DataTable ds = new DataTable();
            adp1.Fill(ds);
            //载入基本信息
            kb1.DataContext = ds.DefaultView;
            conn.Close();
        }
    }
}
