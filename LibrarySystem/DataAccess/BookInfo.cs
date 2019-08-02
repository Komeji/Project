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
    public class BookInfo
    {
        private SqlCommand cmd;
        public BookInfo()
        {
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
        }

       
        public bool DeleteBook(string bookid)
        {

            cmd.CommandText = "Delete_Book";
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
        public DataSet GetPageWordLittleBookInfo() 
        {
            cmd.CommandText = "GetPageWordLittleBookInfo";
            cmd.Parameters.Clear();
            DataSet ds = DBAccess.QueryData(cmd);
            return ds;
        }
        public DataSet GetOverdueBorroweInfo() 
        {
            cmd.CommandText = "GetOverdueBorroweInfo";
            cmd.Parameters.Clear();
            DataSet ds = DBAccess.QueryData(cmd);
            return ds;
        }
        public DataSet Get2019BorroweInfo() 
        {
            cmd.CommandText = "Get2019BorroweInfo";
            cmd.Parameters.Clear();
            DataSet ds = DBAccess.QueryData(cmd);
            return ds;
        }
        public DataSet Get2018UserBorroweInfo() 
        {
            cmd.CommandText = "Get2018UserBorroweInfo";
            cmd.Parameters.Clear();
            DataSet ds = DBAccess.QueryData(cmd);
            return ds;
        }
        public DataSet GetShanghaiPublisherBookInfo()
        {
            cmd.CommandText = "GetShanghaiPublisherBookInfo";
            cmd.Parameters.Clear();
            DataSet ds = DBAccess.QueryData(cmd);
            return ds;
        }
        public DataSet GetQinhuaBookInfo()
        {
            cmd.CommandText = "GetQinhuaBookInfo";
            cmd.Parameters.Clear();
            DataSet ds = DBAccess.QueryData(cmd);
            return ds;
        }
        public DataSet Get1990to2000bookinfo()
        {
            cmd.CommandText = "Get1990to2000bookinfo";
            cmd.Parameters.Clear();
            DataSet ds = DBAccess.QueryData(cmd);
            return ds;
        }
        public DataSet GetPageWordMinBookInfo()
        {
            cmd.CommandText = "GetPageWordMinBookInfo";
            cmd.Parameters.Clear();
            DataSet ds = DBAccess.QueryData(cmd);
            return ds;
        }
        public DataSet GetAllPublisher()
        {
            cmd.CommandText = "GetAllPublisher";
            cmd.Parameters.Clear();
            DataSet ds = DBAccess.QueryData(cmd);
            return ds;
        } 
        public DataSet GetBookInfo(string bookname, string classid)
        {
            cmd.CommandText = "GetBookInfoByClassIDAndBookName";
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@BookName", SqlDbType.NVarChar, 50).Value = bookname;
            cmd.Parameters.Add("@ClassID", SqlDbType.Char, 1).Value = classid;
            DataSet ds = DBAccess.QueryData(cmd);
            return ds;

        }
        public DataSet GetBookInfo(string bookid)
        {
            cmd.CommandText = "GetBookInfoByBookID";
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@bookid", SqlDbType.Char, 20).Value = bookid;

            DataSet ds = DBAccess.QueryData(cmd);
            return ds;

        }
        public DataSet GetBookInfo(string isbn, string bookname, string author, string classid)
        {
            cmd.CommandText = "GetBookInfoByCondition";
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@ISBN", SqlDbType.Char, 20).Value = isbn;
            cmd.Parameters.Add("@bookname", SqlDbType.Char, 20).Value = bookname;
            cmd.Parameters.Add("@author", SqlDbType.NVarChar, 50).Value = author;
            cmd.Parameters.Add("@classid", SqlDbType.Char, 1).Value = classid;
            DataSet ds = DBAccess.QueryData(cmd);
            return ds;

        }
        public bool InsertNewBook(string bookid, string isbn, string bookname, string author, DateTime publishdate, string bookversion, int wordcount, int pagecount, string publisher, string classid)
        {
            cmd.CommandText = "InsertNewBook";
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@bookid", SqlDbType.Char, 20).Value = bookid;
            cmd.Parameters.Add("@isbn", SqlDbType.Char, 20).Value = isbn;
            cmd.Parameters.Add("@bkn", SqlDbType.NVarChar, 50).Value = bookname;
            cmd.Parameters.Add("@author", SqlDbType.NVarChar, 50).Value = author;
            cmd.Parameters.Add("@pubdate", SqlDbType.DateTime, 20).Value = publishdate;
            cmd.Parameters.Add("@bkv", SqlDbType.NVarChar, 20).Value = bookversion;
            cmd.Parameters.Add("@WordCount", SqlDbType.Int).Value = wordcount;
            cmd.Parameters.Add("@pageCount", SqlDbType.SmallInt).Value = pagecount;
            cmd.Parameters.Add("@publisher", SqlDbType.NVarChar, 50).Value = publisher;
            cmd.Parameters.Add("@ClassID", SqlDbType.Char, 1).Value = classid;
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
        public bool UpdateBookInfo(string bookid, string isbn, string bookname, string author, DateTime publishdate, string bookversion, int wordcount, int pagecount, string publisher, string classid)
        {
            cmd.CommandText = "UpdateBookInfo";
            cmd.Parameters.Clear();

            cmd.Parameters.Add("@bookid", SqlDbType.Char, 20).Value = bookid;
            cmd.Parameters.Add("@isbn", SqlDbType.Char, 20).Value = isbn;
            cmd.Parameters.Add("@bkn", SqlDbType.NVarChar, 50).Value = bookname;
            cmd.Parameters.Add("@author", SqlDbType.NVarChar, 50).Value = author;
            cmd.Parameters.Add("@pubdate", SqlDbType.DateTime, 20).Value = publishdate;
            cmd.Parameters.Add("@bkv", SqlDbType.NVarChar, 20).Value = bookversion;
            cmd.Parameters.Add("@WordCount", SqlDbType.Int).Value = wordcount;
            cmd.Parameters.Add("@pageCount", SqlDbType.SmallInt).Value = pagecount;
            cmd.Parameters.Add("@publisher", SqlDbType.NVarChar, 50).Value = publisher;
            cmd.Parameters.Add("@ClassID", SqlDbType.Char, 1).Value = classid;
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
        public DataSet GetAllBookClass()
        {
            cmd.CommandText = "GetAllBookClass";
            cmd.Parameters.Clear();
            DataSet ds = DBAccess.QueryData(cmd);
            return ds;
        }
        public DataSet GetBookStatisticInfo()
        {
            cmd.CommandText = "GetBookStatisticInfo";
            cmd.Parameters.Clear();
            DataSet ds = DBAccess.QueryData(cmd);
            return ds;
        }

    }
}
