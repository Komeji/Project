using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Library.DataAccess;
using Library.Comm;

namespace Library.DataAccess
{

    public class Admin
    {
        Encrypt enc;
        SqlCommand cmd;
        public Admin()
        {
            cmd = new SqlCommand();
            enc = new Encrypt();
            cmd.CommandType = CommandType.StoredProcedure;
        }

        public bool Login(string adminid, string password)
        {
            cmd.CommandText = "AdminLogin";
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@adminid", SqlDbType.Char, 10).Value = adminid;
            cmd.Parameters.Add("@password", SqlDbType.Binary, 20).Value = enc.EncryptPassword(password);
            try
            {
                int i = Convert.ToInt16(DBAccess.GetScalar(cmd));
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
        public bool ChangePassword(string adminid, string newpassword)
        {
            cmd.CommandText = "ChangeAdminPassword";
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@adminid", SqlDbType.Char, 10).Value = adminid;
            cmd.Parameters.Add("@password", SqlDbType.Binary, 20).Value = enc.EncryptPassword(newpassword);
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
        public object GetAdminInfoByID(string adminid)
        {
            cmd.CommandText = "GetAdminNameByID";
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@adminid", SqlDbType.Char, 10).Value = adminid;
            object ds = DBAccess.GetScalar(cmd);
            return ds;
            

        }
        public bool InsertAdmin(string adminid, string adminname, string password, string email)
        {
            cmd.CommandText = "InsertAdmin";
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@adminid", SqlDbType.Char, 10).Value = adminid;
            cmd.Parameters.Add("@adminname", SqlDbType.NVarChar, 30).Value = adminname;
            cmd.Parameters.Add("@password", SqlDbType.Binary, 20).Value = enc.EncryptPassword(password);
            cmd.Parameters.Add("@email", SqlDbType.NVarChar, 40).Value = email;
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

