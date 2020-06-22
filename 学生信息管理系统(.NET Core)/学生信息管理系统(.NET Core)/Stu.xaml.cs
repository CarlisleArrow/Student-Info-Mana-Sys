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
    /// Stu.xaml 的交互逻辑
    /// </summary>
    /// 学生页面
    public partial class Stu : Window
    {
        public Stu()
        {
            InitializeComponent();
            //Display.Content = Display.Content + Name;
            //显示学号对应数据库姓名
            string sql = "select Name from Student";
            SqlConnection conn = new SqlConnection(DataOper.connString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            this.Display.Content =Display.Content+ cmd.ExecuteScalar().ToString();


        }
#pragma warning disable CS0108 // '“Stu.Name”隐藏继承的成员“FrameworkElement.Name”。如果是有意隐藏，请使用关键字 new。
        public static string Name = "";
#pragma warning restore CS0108 // '“Stu.Name”隐藏继承的成员“FrameworkElement.Name”。如果是有意隐藏，请使用关键字 new。
        DataOper dataoper = new DataOper();

       
        private void ShowInfo()
        {
#pragma warning disable CS0219 // 变量“headID”已被赋值，但从未使用过它的值
            int headID = 0;
#pragma warning restore CS0219 // 变量“headID”已被赋值，但从未使用过它的值
            string sql = "select Name from Student where Number="+MainWindow.display+"";
            SqlDataReader dataReader = dataoper.GetDataReader(sql);
            if (dataReader.Read())
            {
                if (!(dataReader["Name"] is DBNull))
                {
                    Name = dataReader["Name"].ToString();
                    Display.Content = Display.Content + Name;
                }
            }
            dataReader.Close();
            DataOper.connection.Close();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Content = new Info();
            
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainWindow login = new MainWindow();
            login.Show();
        }

       

        private void jw_Click(object sender, RoutedEventArgs e)
        {
            this.Content = new jw();
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Content = new aolan();
            Stu stu = new Stu();
            stu.Close();
        }
    }
}
