using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Library.Comm;
namespace Library.DataAccess
{
    public class TestUserPtoho
    {
        SqlCommand com;

        
        public TestUserPtoho()
        {
            com = new SqlCommand();
           
            com.CommandType = CommandType.StoredProcedure;
        }
        public DataSet TestGetUserPtohoInfoByUserID(string userid)
        {
            com.CommandText = "TestGetUserPtohoInfoByUserID";
            com.Parameters.Clear();
            com.Parameters.Add("@userid", SqlDbType.Char, 11).Value = userid;
            return DBAccess.QueryData(com);
        }
        public bool TestInsertUserPtohoInfo(string userid, string ptoho)
        {
            try
            {
                com.CommandText = "TestInsertUserPtohoInfo";
                com.Parameters.Clear();
                com.Parameters.Add("@userid", SqlDbType.Char, 11).Value = userid;

                com.Parameters.Add("@ptoho", SqlDbType.Image).Value = ImageRead.ReadPhoto(ptoho);
                int i = DBAccess.ExecuteSQL(com);
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
