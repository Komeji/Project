using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Library.DataAccess;

namespace Library.DataAccess
{
   public class BorrowInfo
    {
        SqlCommand cmd;

        public BorrowInfo()
        {
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
        }
        /// <summary>
        /// 根据参数bookid判断图书是否借出
        /// </summary>
        /// <param name="bookid"></param>
        /// <returns>true = 是,false = 否</returns>
        public bool IsBorrowed(string bookid) 
        {
            cmd.CommandText = "IsBorrowed";
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@bookid", SqlDbType.Char, 20).Value = bookid;
            object obj = DBAccess.GetScalar(cmd);
            if (obj == null)
            {
                return false;
            }
            else 
            {
                if (Convert.ToInt16(obj) == 1)
                {
                    return false;
                }
                else 
                {
                    return true;
                }
            }
        
        }

        /// <summary>
        /// 根据bookid参数判断此书是否存在
        /// </summary>
        /// <param name="bookid"></param>
        /// <returns>true = 是, false = 否</returns>
        public bool HasBook(string bookid)
        {
            cmd.CommandText = "HasThisBook";
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@bookid", SqlDbType.Char, 20).Value = bookid;
            object str = DBAccess.GetScalar(cmd);
            if (Convert.ToInt16(str) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }




        /// <summary>
        /// 跟据bookid,userid两条参数执行插入一条借阅记录操作
        /// </summary>
        /// <param name="bookid"></param>
        /// <param name="userid"></param>
        /// <returns>true=成功,false=失败</returns>
        public bool BorrowBook(string bookid, string userid)
        {
            try
            {
                cmd.CommandText = "BorrowBook";
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@bookid", SqlDbType.Char, 20).Value = bookid;
                cmd.Parameters.Add("@userid", SqlDbType.Char, 11).Value = userid;
                int i = DBAccess.ExecuteSQL(cmd);

                if (i == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch
            {

                return false;
            }



        }

        /// <summary>
        /// 跟据bookid参数完成图书归还
        /// </summary>
        /// <param name="bookid"></param>
        /// <returns>true = 归还成功,false = 失败</returns>
        public bool ReturnBook(string bookid)
        {

            cmd.CommandText = "ReturnBook";
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@bookid", SqlDbType.Char, 20).Value = bookid;

            try
            {
                int i = DBAccess.ExecuteSQL(cmd);

                if (i == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch
            {

                return false;

            }
        }
        /// <summary>
        /// 根据bookid参数完成图书的续借
        /// </summary>
        /// <param name="bookid"></param>
        /// <returns></returns>
        public bool ReBorrow(string bookid)
        {
            cmd.CommandText = "ReborrowBook";
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@bookid", SqlDbType.Char, 20).Value = bookid;
            try
            {
                int i = DBAccess.ExecuteSQL(cmd);
                if (i > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch
            {
                return false;

            }
        }
        /// <summary>
        /// 根据userid编号查询该读者的相关信息
        /// </summary>
        /// <param name="bookid"></param>
        /// <returns>数据集</returns>
        public DataSet GetBorrowInfoByBookID(string bookid)
        {
            cmd.CommandText = "GetBorrowInfoByBookID";
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@bookid", SqlDbType.Char, 20).Value = bookid;
            DataSet ds = DBAccess.QueryData(cmd);
            return ds;

        }
        /// <summary>
        /// 根据userid参数查询该读者借阅的所有信息
        /// </summary>
        /// <param name="userid"></param>
        /// <returns>数据集</returns>
        public DataSet GetBorrowInfoByUserID(string userid)
        {
            cmd.CommandText = "GetBorrowInfoByUserID";
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@userid", SqlDbType.Char,11).Value = userid;
            DataSet ds = DBAccess.QueryData(cmd);
            return ds;


        }


        public DataSet GetBoyOrGirlBorrowInfo()
        {
            cmd.CommandText = "GetBoyOrGirlBorrowInfo";
            cmd.Parameters.Clear();
            DataSet ds = DBAccess.QueryData(cmd);
            return ds;
        }
    }
}
