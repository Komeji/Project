using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Library.DataAccess;
using System.EnterpriseServices;
using System.Data;
using System.Xml;

namespace DataAccessTest
{
    /// <summary>
    /// DataAccess 的摘要说明
    /// </summary>
    [Transaction(TransactionOption.Required)]
    [TestClass]
    public class DataAccess : ServicedComponent
    {
        public DataAccess()
        {
            //
            //TODO:  在此处添加构造函数逻辑
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///获取或设置测试上下文，该上下文提供
        ///有关当前测试运行及其功能的信息。
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region 附加测试特性
        //
        // 编写测试时，可以使用以下附加特性: 
        //
        // 在运行类中的第一个测试之前使用 ClassInitialize 运行代码
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // 在类中的所有测试都已运行之后使用 ClassCleanup 运行代码
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // 在运行每个测试之前，使用 TestInitialize 来运行代码
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // 在每个测试运行完之后，使用 TestCleanup 来运行代码
        [TestCleanup()]
        public void TransactionTestClaenup()
        {
            if (ContextUtil.IsInTransaction)
            {
                ContextUtil.SetAbort();
            }
        }

        #endregion

        [TestMethod]
        public void GetAdminNameTest()
        {

            //TODO:  在此处添加测试逻辑

            Admin ad = new Admin();
            string adminid = "0004";
            string adminName = "老梁";
            string str = Convert.ToString(ad.GetAdminInfoByID(adminid));
            Assert.AreEqual(adminName, str);
        }

        [TestMethod]

        public void BookInsertTest()
        {

            BookInfo bi = new BookInfo();
            bool bl = bi.InsertNewBook("A00", "7-302-03314-5", "蔡徐坤打篮球", "梁宇聪", Convert.ToDateTime("2001-1-2"), "", 722, 722, "722出版社", "A");
            DataSet ds = bi.GetBookInfo("蔡徐坤打篮球", "A");
            Assert.IsNotNull(ds);
            Assert.AreEqual(1, ds.Tables[0].Rows.Count);
            Assert.IsTrue(bl);
        }
        [TestMethod]
        public void DeleteBookTest()
        {
            BookInfo bi = new BookInfo();
            bool bl = bi.DeleteBook("CXK/IK".Trim());
            DataSet ds = bi.GetBookInfo("CXK/IK");
            int c = ds.Tables[0].Rows.Count;
            Assert.AreEqual(0, c);
            Assert.IsTrue(bl);
        }
        [TestMethod]
        public void UpdateBookInfoTest()
        {
            BookInfo bi = new BookInfo();
            bool bl = bi.UpdateBookInfo("CXK/IK250", "7-5026-0559-2", "梁宇聪打篮球", "蔡徐坤", Convert.ToDateTime("2001-1-2"), "", 722, 722, "722出版社", "A");
            DataSet ds = bi.GetBookInfo("CXK/IK250");
            Assert.AreEqual("梁宇聪打篮球", ds.Tables[0].Rows[0]["BookName"].ToString().Trim());
            Assert.IsTrue(bl);
        
        }
    }
}
