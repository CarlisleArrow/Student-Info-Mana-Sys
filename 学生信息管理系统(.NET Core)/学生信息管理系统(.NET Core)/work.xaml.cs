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
    /// work.xaml 的交互逻辑
    /// </summary>
    /// 就业信息采集
    public partial class work : Window
    {
        public work()
        {
            InitializeComponent();
            ID.Text = MainWindow.ID();
        }

        private void sub_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection conn = new SqlConnection(DataOper.connString);
            conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            try
            {

            }
            catch (Exception)
            {

                MessageBox.Show("服务器通信中断", "信息采集系统", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            string mysql = "SELECT StuID FROM work where='" + ID.Text.Trim() + "'";
            SqlCommand mycommand = new SqlCommand(mysql, conn);
            mycommand.Connection = conn;
            Object o = mycommand.ExecuteNonQuery();
            if (o == null)
            {
                string sql = "insert into work(StuID,acad,company,ph1,location,interview,result,interview1)" +
                     "values('" + ID.Text.Trim() + "',N'"
                     + acad.Text.Trim() + "',N'"
                     + company.Text.Trim() + "',N'"
                     + ph1.Text.Trim() + "',N'" + location.Text.Trim()

                     + "',N'" + (interview.SelectedItem as ComboBoxItem).Content.ToString()
                     + "',N'" + result.Text.Trim() + "',N'" + interview1.Text.Trim() + "')";

                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
                MessageBox.Show("信息已存储"); }
            else
            {
                string update= "update work set ph1='" + ph1.Text.Trim() +
                   "', acad=N'" + acad.Text.Trim() + "', location=N'" + location.Text.Trim()  +
                   "', company=N'" + company.Text.Trim() + "', interview=N'" + (interview.SelectedItem as ComboBoxItem).Content.ToString() + "', interview1=N'" + interview1.Text.Trim() 
                   + "', result=N'" + result.Text.Trim()+ "'";
                MessageBox.Show("信息已更新");
            }

            conn.Close();
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            Stu stu = new Stu();
            this.Close();
            stu.Show();
        }

        private void dash_Click(object sender, RoutedEventArgs e)
        {
            this.Content = new work_dashboard();
        }

        private void interview1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
