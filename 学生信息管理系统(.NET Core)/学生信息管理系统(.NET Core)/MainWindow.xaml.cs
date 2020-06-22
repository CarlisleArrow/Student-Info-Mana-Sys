using System;
using System.Data;
using System.Windows;

namespace 学生信息管理系统_.NET_Core_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //public static string connectionString = "uid=sa;pwd=msosg00921;initial catalog=student;data source=DESKTOP-C4T32Q9;Connect Timeout=900";
        public static string display;
        static public MainWindow lo;
        public MainWindow()
        {
            InitializeComponent();
            try
            {

            }
            catch (Exception)
            {

                MessageBox.Show("暂时无法使你登录");
            }
        }
       
            //调用数据库连接类
            DataOper dataOper = new DataOper();
        
        private bool ValidateInput()
        {
            if (txtID.Text.Trim() == "")
            {
                MessageBox.Show("我们查询不到您的工号", "遇到异常！", MessageBoxButton.OK, MessageBoxImage.Error);
                txtID.Focus();
                return false;
            }
            else if (txtID.Text.Length > 9 && Pwd.Password.Trim() == "")
            {
                MessageBox.Show("空密码", "遇到异常！", MessageBoxButton.OK, MessageBoxImage.Error);
                Pwd.Focus();
                return false;
            }
            return true;
        }
        //登录判断
        private void Next_Click(object sender, RoutedEventArgs e)
        {
            display = txtID.Text.Trim();
            if (ValidateInput())
            {
                    PublicClass.loginID = int.Parse(txtID.Text.Trim());
                    if (int.Parse(txtID.Text.Trim())<=9999999)
                    {
                      
                        string sql = "select count(*) from Admin where ID=" + int.Parse(txtID.Text.Trim()) + "and Password= " + Pwd.Password.Trim() + "";
                        int num = dataOper.ExecSQL(sql);
                        if (num == 1)
                        {

                            //MessageBox.Show("教师登录成功！", "成功！", MessageBoxButton.OK, MessageBoxImage.Information);
                            display = txtID.Text.Trim();
                            Login mainForm = new Login();


                            mainForm.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("找不到！");
                        }
                    }
                    
                    else if (int.Parse(txtID.Text.Trim()) <= 9999999999)
                    {
                        string sql = "select count(*) from StuLogon where ID=" + int.Parse(txtID.Text.Trim()) + "and Password= " + Pwd.Password.Trim() + "";
                        int num = dataOper.ExecSQL(sql);
                        if (num == 1)
                        {
                            //MessageBox.Show("学生登录成功！", "成功！", MessageBoxButton.OK, MessageBoxImage.Information);
                            display = txtID.Text.Trim();
                            Login studentForm = new Login();
                            studentForm.Show();
                            this.Hide();
                        }
                        else
                            MessageBox.Show("找不到！");
                        
                    }
                    else
                    {
                        MessageBox.Show("我们查询不到您的工号", "遇到异常！", MessageBoxButton.OK, MessageBoxImage.Error);
                    }

                }
            }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
           
        }
        public static String ID()
        {
            String id = "";
            id = MainWindow.display;
            return id;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void cboxR_Checked(object sender, RoutedEventArgs e)
        {
            if (cboxR.IsChecked!=true)
            {
                cboxA.IsChecked = false;
            }
        }

        private void newstu_Click(object sender, RoutedEventArgs e)
        {
            Reg reg = new Reg();
            reg.Show();
            this.Hide();
        }
    }
   
   
}
    


