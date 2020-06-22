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
    /// pandemic.xaml 的交互逻辑
    /// </summary>
    /// 疫情信息采集
    public partial class pandemic : Window
    {
        public pandemic()
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
            //捕获异常
          /*  try
            {
                conn.Open();
            }
            catch (Exception)
            {

                MessageBox.Show("无法联机");
                return;
            }*/
            //学号查询，判断该字段在数据库表中是否存在
            string mysql = "select StuID from pandemic where StuID='" + ID.Text.Trim() + "'";
            SqlCommand mycommand = new SqlCommand(mysql,conn);
            mycommand.Connection = conn;
            Object o = mycommand.ExecuteNonQuery();
            //如果不存在则新增,否则更新字段
            if (o == null)
            {
                string sql = "insert into pandemic(StuID,ph,acad,location,susp,travel,symptom,temp,confirm1,date)" +
                     "values('" + ID.Text.Trim() + "',N'"
                     + ph1.Text.Trim() + "',N'"
                     + acad.Text.Trim() + "',N'"
                     + location.Text.Trim() + "',N'" + (susp.SelectedItem as ComboBoxItem).Content.ToString()
                     + travel.Text.Trim() + "',N'" + (symp.SelectedItem as ComboBoxItem).Content.ToString()
                     + "',N'" + temp.Text.Trim()
                     + "',N'" + (confirm.SelectedItem as ComboBoxItem).Content.ToString() + "',N'" + Date.SelectedDate.ToString() + "')";

                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
                MessageBox.Show("信息已存储");
            }
            else
            {
                string update = "update pandemic set ph='" + ph1.Text.Trim() +
                   "', acad=N'" + acad.Text.Trim() + "', location=N'" + location.Text.Trim() + "', susp=N'" + (susp.SelectedItem as ComboBoxItem).Content.ToString() +
                   "', travel=N'" + travel.Text.Trim() + "', symptom=N'" + (symp.SelectedItem as ComboBoxItem).Content.ToString() + "', temp=N'" + temp.Text.Trim() + "', confirm1=N'"
                   + (confirm.SelectedItem as ComboBoxItem).Content.ToString() + "', date=N'" + Date.SelectedDate.ToString()+"'";
                cmd.CommandText = update;
                cmd.ExecuteNonQuery();
                MessageBox.Show("信息已更新");
            }
            conn.Close();
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Stu stu = new Stu();
            stu.Show();
        }

        private void pan_dashboard_Click(object sender, RoutedEventArgs e)
        {
            this.Content = new pan_dash();

        }
    }
}
