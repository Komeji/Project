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
   public class User
    {
        SqlCommand cmd;
       
        public User()
        {
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
        }

        public bool UpdateUserPhotoByUserID(string userid, string filename) 
        {
            try
            {
                cmd.CommandText = "UpdateUserPhotoByUserID";
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@userid", SqlDbType.Char, 11).Value = userid;
                cmd.Parameters.Add("@image", SqlDbType.Image).Value = Comm.ImageRead.ReadPhoto(filename);
                int bl = DBAccess.ExecuteSQL(cmd);
                if (bl == 1)
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
       
       public DataSet GetUserInfo(string userid)
        {
            cmd.CommandText = "GetUserInfoByID";
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@UserID",SqlDbType.Char,11).Value = userid;

            DataSet ds = DBAccess.QueryData(cmd);
            return ds;
        }
        public bool InsertUser(string userid, string username, string password, int sex, string email, string classname) 
        {
            cmd.CommandText = "InsertNewUser";
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@userid", SqlDbType.Char, 11).Value = userid;
            cmd.Parameters.Add("@username", SqlDbType.NVarChar, 20).Value = username;
            cmd.Parameters.Add("@password", SqlDbType.NVarChar, 20).Value = password;
            cmd.Parameters.Add("@sex", SqlDbType.Bit).Value = sex;
            cmd.Parameters.Add("@Email", SqlDbType.VarChar, 50).Value = email;
            cmd.Parameters.Add("@class", SqlDbType.NVarChar, 40).Value = classname;

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
    }
}
