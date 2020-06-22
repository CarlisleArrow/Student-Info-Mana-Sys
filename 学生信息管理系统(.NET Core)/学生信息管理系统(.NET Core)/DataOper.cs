using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace 学生信息管理系统_.NET_Core_
{
    class DataOper
    {

        //定义数据库增删改查类
        public static string connString = @"Data Source=www.lovesakura.top,12315;Database=Analysis;User ID=sa;Pwd=Rr1Ee2Ww3Qq4!@#$#@!;";
        public static SqlConnection connection = new SqlConnection(connString);
        public int ExecSQL(string sql)
        {
            SqlCommand command = new SqlCommand(sql, connection);
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();

            }
            int num = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();
            return num;
        }
        public int ExecSQLResult(string sql)
        {
            SqlCommand command = new SqlCommand(sql, connection);
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            int result = command.ExecuteNonQuery();
            connection.Close();
            return result;
        }
        public SqlDataReader GetDataReader(string sql)

        {
            
            SqlCommand command = new SqlCommand(sql, connection);
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
                connection.Open();
                SqlDataReader dataReader = command.ExecuteReader();
                return dataReader;
            
        }
        public DataSet GetDataSet(string sql)
        {
            SqlDataAdapter sqlda = new SqlDataAdapter(sql, connection);
            DataSet ds = new DataSet();
            sqlda.Fill(ds);
            return ds;
        }
    }
}
