using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Library.DataAccess
{
   public class DBAccess
    {
      
       /// <summary>
       /// 执行Update,insert,delect
       /// </summary>
       /// <param name="cmd">SqlCommand的对象</param>
       /// <returns>整型</returns>
        public static int ExecuteSQL(SqlCommand cmd)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LibraryConnStr"].ConnectionString);
            try
            {
                //创建连接对象
              
               
                //创建命令对象
                cmd.Connection = con;
               
                //打开连接
                con.Open();

                int i = cmd.ExecuteNonQuery();//用i记录ExecuteNonQuery返回的值

                return i;
            }
            catch (Exception ex)
            {
                throw new DBException(ex);//从底层抛出异常到DBException处理
            }
            finally
            {
                if (con.State == ConnectionState.Open)//判断连接状态
             {
           con.Close();//关闭连接
             }

            }

        }
       /// <summary>
       ///select查询一条语句
       /// </summary>
       /// <param name="cmd"></param>
       /// <returns>obj</returns>
        public static object GetScalar(SqlCommand cmd)
        {
            
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LibraryConnStr"].ConnectionString);
            try
            {
                //创建连接对象
                
               
                //创建命令对象
                cmd.Connection = con;
               
                //打开连接
                con.Open();


                object i = cmd.ExecuteScalar();//用i记录ExecuteScalar返回的值
                return i;
            }
            catch (Exception ex)
            {
                throw new DBException(ex);//从底层抛出异常到DBException处理
            }
            finally
            {
                if (con.State == ConnectionState.Open)//判断连接状态
                {
                    //关闭连接
                    con.Close();
                }
            }
        }
       /// <summary>
       /// select查询多条语句,数据集
       /// </summary>
       /// <param name="cmd"></param>
       /// <returns>返回数据集</returns>
        public static DataSet QueryData(SqlCommand cmd)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LibraryConnStr"].ConnectionString);
            cmd.Connection = con;//cmd的连接对象
            SqlDataAdapter sda = new SqlDataAdapter(cmd);//创建适配器对象
            DataSet ds = new DataSet();//创建数据集对象

            try
            {
                sda.Fill(ds);//填充到数据集
                return ds;
            }
            catch (Exception ex)
            {
                throw new DBException(ex);//从底层抛出异常到DBException处理
            }
        }

    }
}
