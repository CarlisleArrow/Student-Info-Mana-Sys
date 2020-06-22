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
namespace 学生信息管理系统_.NET_Core_
{
    /// <summary>
    /// Info.xaml 的交互逻辑
    /// </summary>
    public partial class Info : Page
    {
        public Info()
        {
            InitializeComponent();
            Display.Content = Display.Content + MainWindow.display;
            SqlConnection con = new SqlConnection(DataOper.connString);
            con.Open();
            //执行con对象的函数，返回一个SqlCommand类型的对象
            SqlCommand cmd = con.CreateCommand();
            //把输入的数据拼接成sql语句，并交给cmd对象
            cmd.CommandText = "select*from Student";

            //用cmd的函数执行语句，返回SqlDataReader类型的结果dr,dr就是返回的结果集（也就是数据库中查询到的表数据）
            SqlDataReader dr = cmd.ExecuteReader();
            //用dr的read函数，每执行一次，返回一个包含下一行数据的集合dr
            while (dr.Read())
            {
                //构建一个ListView的数据，存入数据库数据，以便添加到listView1的行数据中
                info.Items.Add("学号" + ":" + dr["Number"].ToString()+"                     "+"姓名" + ":" + dr["Name"].ToString());
                info.Items.Add("");
                info.Items.Add("性别" + ":" + dr["Sex"].ToString()+"                                    "+ "年龄" + ":" + dr["Age"].ToString());
                info.Items.Add("");
                info.Items.Add("籍贯"+":"+dr["Location"].ToString()+ "                               "+"民族"+":"+dr["type"].ToString());
                info.Items.Add("");
                info.Items.Add("学院" + ":" + dr["College"].ToString() + "                     "+ "班级" + ":" + dr["Class"].ToString());
                info.Items.Add("");
                info.Items.Add("政治面貌" + ":" + dr["Policy"].ToString() + "                     " + "户口性质" + ":" + dr["Home"].ToString());
                info.Items.Add("");
                info.Items.Add("学历层次"+":"+dr["study"].ToString()+"                            "+"学制"+":"+dr["Year"].ToString());
                info.Items.Add("");
                info.Items.Add("联系方式" + ":" + dr["PhoneNumber"].ToString() + "               "+"欢迎来到重庆科技学院!");
            }

            con.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Stu stu = new Stu();
            stu.Show();
            (this.Parent as Window).Close();
        }

        private void info_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
