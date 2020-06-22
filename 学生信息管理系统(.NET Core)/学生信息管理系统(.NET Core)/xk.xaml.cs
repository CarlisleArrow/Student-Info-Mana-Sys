using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

using System.Collections.Generic;

namespace 学生信息管理系统_.NET_Core_
{
    /// <summary>
    /// xk.xaml 的交互逻辑
    /// </summary>
    public partial class xk : Window
    {
        int stuid = 0;

        public xk()
        {

            InitializeComponent();
            id.Text = MainWindow.ID();
            comboBox1.Items.Add("2020年春季");

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            string flags = "1";
            string number = id.Text;
            SqlConnection conn = new SqlConnection(DataOper.connString);
            conn.Open();
            string sql = "select stuid from Student where Number= '" + number + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            String id1 = cmd.ExecuteScalar().ToString();

            int.TryParse(id1, out stuid);
            int claid = 0;
            int.TryParse(id2.Text, out claid);
            sql = "select sctime from sctime where claid=" + claid;
            SqlDataAdapter adp = new SqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                DataRow dr = ds.Tables[0].Rows[i];
                string time = dr[0].ToString();
                sql = "select * from sc,sctime,class where class.claid = sc.claid and class.claid = sctime.claid and sctime = '" + time + "' and sc.stuid =" + stuid;
                SqlDataAdapter adp1 = new SqlDataAdapter(sql, conn);
                DataSet ds1 = new DataSet();
                adp1.Fill(ds1);
                if (ds1.Tables[0].Rows.Count < 0)
                {
                    flags = "2";
                    MessageBox.Show("课程冲突，选课失败");
                    break;
                }
            }
            if (flags=="1")
            {
                sql = "insert into sc(claid,stuid) values(" + claid + "," + stuid + ")";
                cmd.CommandText = sql;
                if (cmd.ExecuteNonQuery()>0)
                {
                   
                    MessageBox.Show("你已成功选课");
                       
                   
                }
            }
            sql = "select class.coursename from sc,class where sc.claid = class.claid and stuid=" + stuid;
            SqlDataAdapter adp2 = new SqlDataAdapter(sql, conn);
            DataSet ds2 = new DataSet();
            adp2.Fill(ds2);
           
            conn.Close();

            bt.IsEnabled = false;


        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            while (kc.Items.Count != 0)
            {
                kc.ItemsSource = null;
            }
            
            string term = comboBox1.SelectedItem.ToString();
            Console.WriteLine(term);
            SqlConnection conn = new SqlConnection(DataOper.connString);
            conn.Open();
            string sql = "select claid as 编号,coursename as 课程,term as 学期, teacher as 授课教师,time as 授课时间 from class "; //where term='" + term + "'";
            SqlDataAdapter adp1 = new SqlDataAdapter(sql, conn);
            DataTable ds = new DataTable();
            adp1.Fill(ds);
            //载入基本信息
            kc.ItemsSource = ds.DefaultView;
            conn.Close();




        }
        private void ObtainClass()
        {
            SqlConnection conn = new SqlConnection(DataOper.connString);
            conn.Open();
            string sql = "select class.coursename from sc,class where sc.claid = class.claid and stuid=" + stuid;
            SqlDataAdapter adp2 = new SqlDataAdapter(sql, conn);
            DataSet ds2 = new DataSet();
            adp2.Fill(ds2);
           
            conn.Close();
        }/*
            string flags = "1";
            //得到stuid
            string stuxuehao = id.Text;
            SqlConnection conn = new SqlConnection(MainWindow.connectionString);
            conn.Open();
            string sql = "select stuid from student where stuxuehao = '" + stuxuehao + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            String id1 = cmd.ExecuteScalar().ToString();

            int.TryParse(id1, out stuid);
            //得到课程的id
            int claid = 0;
            int.TryParse(id2.Text, out claid);
            //查询你在该时间是否有课
            sql = "select sctime from sctime where claid =" + claid;
            SqlDataAdapter adp = new SqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                DataRow dr = ds.Tables[0].Rows[i];
                string time = dr[0].ToString();//第一列
                sql = "select * from sc,sctime,class where class.claid = sc.claid and class.claid = sctime.claid and sctime = '" + time + "' and sc.stuid =" + stuid;
                SqlDataAdapter adp1 = new SqlDataAdapter(sql, conn);
                DataSet ds1 = new DataSet();
                adp1.Fill(ds1);
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    flags = "2";
                    MessageBox.Show("课程上课时间冲突！");
                    break;
                }
            }
            if (flags == "1")
            {
                sql = "insert into sc(claid,stuid) values(" + claid + "," + stuid + ")";
                cmd.CommandText = sql;
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("选课成功！");

                }

            }
            
            sql = "select class.claname  from sc,class where sc.claid = class.claid and stuid=" + stuid;
            SqlDataAdapter adp2 = new SqlDataAdapter(sql, conn);
            DataSet ds2 = new DataSet();
            adp2.Fill(ds2);
            
            conn.Close();
        }

        private void ComboBox_SelectionChanged(object sender, EventArgs e)
        {
            while (kc.Items.Count != 0)
            {
                kc.ItemsSource = null;
            }
            string term = comboBox1.SelectedItem.ToString();
            Console.WriteLine(term);
            SqlConnection conn = new SqlConnection(MainWindow.connectionString);
            conn.Open();
            string sql = "select claid as 课程id,claname as 课程 from class  where term='" + term + "'";
            SqlDataAdapter adp1 = new SqlDataAdapter(sql, conn);
            DataTable ds = new DataTable();
            adp1.Fill(ds);
            //载入基本信息
            kc.ItemsSource = ds.DefaultView;
            conn.Close();
        }

        private void listBox1_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        

        

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

        private void getKecheng()
        {
            SqlConnection conn = new SqlConnection(MainWindow.connectionString);
            conn.Open();
            string sql = "select class.claname  from sc,class where sc.claid = class.claid and stuid=" + stuid;
            SqlDataAdapter adp2 = new SqlDataAdapter(sql, conn);
            DataSet ds2 = new DataSet();
            adp2.Fill(ds2);
           
            conn.Close();
        }
        */
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Close();
            Stu stu = new Stu();
            stu.Show();
        }
    }
}




