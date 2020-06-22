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
    /// information.xaml 的交互逻辑
    /// </summary>
    public partial class information : Window
    {
        public information()
        {
            InitializeComponent();
            ID.Text = MainWindow.ID();
        }

        private void sub_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection conn = new SqlConnection(DataOper.connString);
            conn.Open();
            try
            {

            }
            catch (Exception)
            {

                MessageBox.Show("Cannot catch the server!");
            }
            string mysql = "select StuID from infor where StuID='" + ID.Text.Trim() + "'";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            Object o = cmd.ExecuteNonQuery();
            if (o == null)
            {
                string sql = "insert into infor(学号,类别,留校原因,联系电话,家长电话,假期宿舍,宿舍床号,中途离校,离校日期)" +
                     "values('" + ID.Text.Trim() + "',N'"
                     + type.Text.Trim() + "',N'"
                     + (reason.SelectedItem as ComboBoxItem).Content.ToString()+ "',N'"
                     + ph1.Text.Trim() + "',N'" + ph2.Text.Trim()
                     + dor.Text.Trim() + "',N'" + bed.Text.Trim()
                     + "',N'" + (interex.SelectedItem as ComboBoxItem).Content.ToString()
                     + "',N'" + date.Text.Trim() + "',N'" + date.Text.Trim() + "')";
                //将XAML页控件获取到的字段回传数据库
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
                MessageBox.Show("信息已存储");
            }
            else
            {
                string update = "update infor set 学号'" + ID.Text.Trim() + "',类别=N'" + type.Text.Trim() + "',留校原因=N'"
                    + (reason.SelectedItem as ComboBoxItem).Content.ToString() + "',联系电话=N'" 
                    + ph1.Text.Trim() + ",家长电话=N'" + ph2.Text.Trim() +
                    ",假期宿舍=N" + dor.Text.Trim() + "',宿舍床号=N'" + bed.Text.Trim() + "',中途离校=N'" 
                    + (interex.SelectedItem as ComboBoxItem).Content.ToString() +
                    "',离校日期=N'" + date.Text.Trim()+"'";
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
    }
    }

