using Library.Comm;
using Library.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Library.LibraryBusiness
{
   public class WinLogic
    {
       DataAccess.Admin adm;
        BookInfo bki;
        BorrowInfo bri;
        User user;
        public WinLogic() 
        {
            adm = new Admin();
            bki = new BookInfo();
            bri = new BorrowInfo();
            user = new User();          
        }
        public bool UpdateUserPhotoByUserID(string userid,string filename) 
        {
            return user.UpdateUserPhotoByUserID(userid,filename);
        }
        public DataSet GetQinhuaBookInfo()
        {
            return bki.GetQinhuaBookInfo();
        }
        public DataSet GetAllPublisher()
        {
            return bki.GetAllPublisher();
        }
        public DataSet Get1990to2000bookinfo() 
        {
            return bki.Get1990to2000bookinfo();
        }
        public DataSet GetPageWordMinBookInfo()
        {
            return bki.GetPageWordMinBookInfo();
        }
        public DataSet GetBoyOrGirlBorrowInfo() 
        {
            return bri.GetBoyOrGirlBorrowInfo();
        }

        public bool Login(string adminid,string pwd) 
        {
            return adm.Login(adminid,pwd);
        }
       public bool ChangePassword(string adminid, string newpassword)
       {
       return adm.ChangePassword(adminid,newpassword);

       }
       public object GetAdminInfoByID(string adminid) 
       {
           return adm.GetAdminInfoByID(adminid);
       }
       public bool InsertAdmin(string adminid, string adminname, string password, string email) 
       {
           return adm.InsertAdmin(adminid, adminname, password, email);
       }
           public DataSet GetPageWordLittleBookInfo()
        {
            return bki.GetPageWordLittleBookInfo();
        }
        public DataSet GetOverdueBorroweInfo() 
        {
            return bki.GetOverdueBorroweInfo();
        }
        public DataSet Get2019BorroweInfo() 
        {
            return bki.Get2019BorroweInfo();
        }
        public DataSet Get2018UserBorroweInfo() 
        {
            return bki.Get2018UserBorroweInfo();
        }
        public DataSet GetShanghaiPublisherBookInfo() 
        {
            return bki.Get2018UserBorroweInfo();
        }
        public DataSet GetUserInfo(string userid) 
        {
           return user.GetUserInfo(userid);
        }
        public DataSet GetBorrowInfoByUserID(string userid) 
        {
            return bri.GetBorrowInfoByUserID(userid);
        }
        public bool BorrowBook(string bookid, string userid) 
        {
            return bri.BorrowBook(bookid,userid);
        }
        public DataSet GetBookInfoByBookID(string bookid) 
        {
            return bki.GetBookInfo(bookid);
        }
        public DataSet GetBorrowInfoByBookID(string bookid) 
        {
            return bri.GetBorrowInfoByBookID(bookid);
        }
        public bool InsertNewBook(string bookid, string isbn, string bookname, string author, DateTime publishdate, string bookversion, int wordcount, int pagecount, string publisher, string classid) 
        {
            return bki.InsertNewBook(bookid, isbn, bookname, author, publishdate, bookversion, wordcount, pagecount, publisher, classid);
        }
        public DataSet GetBookInfo(string bookname, string classid) 
        {
            return bki.GetBookInfo(bookname, classid);
        }
        public bool DeleteBook(string bookid) 
        {
           return bki.DeleteBook(bookid);
        }
        public bool UpdateBookInfo(string bookid, string isbn, string bookname, string author, DateTime publishdate, string bookversion, int wordcount, int pagecount, string publisher, string classid) 
        {
            return bki.UpdateBookInfo(bookid, isbn, bookname, author, publishdate, bookversion, wordcount, pagecount,publisher,classid);
        }
        //public bool ChangePassword(string adminid, string newpassword){}
        public DataSet GetAllBookClass() 
        {
            return bki.GetAllBookClass();
        }
        public bool ReturnBook(string bookid) 
        {
            return bri.ReturnBook(bookid);
        }
        public bool ReBorrow(string bookid) 
        {
            return bri.ReBorrow(bookid);
        }
        public DataSet GetBookStatisticInfo() 
        {
            return bki.GetBookStatisticInfo();
        }

    }
}
