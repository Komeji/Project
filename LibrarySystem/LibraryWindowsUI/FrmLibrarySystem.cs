using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using Library.DataAccess;
using Library.LibraryBusiness;
using Library.Comm;
//using Sunisoft.IrisSkin;

namespace Library.LibraryWinUI
{
    public partial class FrmLibrarySystem : Form
    {
        WinLogic wlg = new WinLogic();
        InputCheck ick = new InputCheck();
        bool flag_B = true; //设置一个标记 true为检索功能,false为还书功能
        bool flag_C = true;//设置一个标记 true为检索功能,false为续借功能
        private string useridB;
        private string bookidB;
        string bookname_D;
        string classid_D;
        string adminid_S;

        //SkinEngine sk = new SkinEngine();
        
        


        public FrmLibrarySystem(string adminid)
        {
            InitializeComponent();
            this.adminid_S = adminid;
            //wlg = new WinLogic();
            //ick = new InputCheck();
        
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label35_Click(object sender, EventArgs e)
        {

        }

        private void button16_Click(object sender, EventArgs e)
        {



            //----------bookinfo--------------
            //string con = ConfigurationManager.ConnectionStrings["LibraryConnStr"].ConnectionString;
            //SqlConnection conn = new SqlConnection(con);

            //conn.Open();
            //MessageBox.Show("o");
            //conn.Close();

            //DBException dbe = new DBException(new Exception());
            //MessageBox.Show(dbe.Message);


            //NoRecordException nre = new NoRecordException();
            //MessageBox.Show(nre.Message);

            //NoRecordException nre1 = new NoRecordException("dllm");
            //MessageBox.Show(nre1.Message);

            //SqlCommand com = new SqlCommand("select * from TBL_User");
            //DataSet ds = DBAccess.QueryData(com);
            //dataGridView5.DataSource = ds.Tables[0];

            //BookInfo bki = new BookInfo();
            //bool b = bki.DeleteBook("aaa");
            //MessageBox.Show(b.ToString());

            //BookInfo bki = new BookInfo();
            //bool b = bki.InsertNewBook("a1aa", "bbb", "ads", "ddd", Convert.ToDateTime("2019-1-1"), "lmf", 889, 124, "sdsda", "T");
            //MessageBox.Show(b.ToString());

            //BookInfo bki = new BookInfo();
            //DataSet ds = bki.GetBookStatisticInfo();
            //dataGridView5.DataSource = ds.Tables[0];

            //BookInfo bki = new BookInfo();
            //DataSet ds = bki.GetBookInfo("G40-092.2/5");
            //dataGridView5.DataSource = ds.Tables[0];


            //------------borrowInfo---------------
            BorrowInfo boi = new BorrowInfo();
            //bool bl = boi.IsBorrowed("G633.7/202");
            //MessageBox.Show(bl.ToString());

            bool bl =new BookInfo().InsertNewBook("A00", "7-302-03314-5", "蔡徐坤打篮球", "梁宇聪", Convert.ToDateTime("2001-1-2"), "", 722, 722, "722出版社", "A");
            MessageBox.Show(bl.ToString());

            //bool bl = boi.HasBook("G633.7/202");
            //MessageBox.Show(bl.ToString());

            WinLogic win = new WinLogic();
            //bool bl = win.BorrowBook("a1aa","20180310026");
            //MessageBox.Show(bl.ToString());

            //BorrowInfo boi = new BorrowInfo();
            //DataSet ds = boi.GetBorrowInfoByBookID("G40-092.2/5");
            //dataGridView5.DataSource = ds.Tables[0];

            //bool bl = boi.ReBorrow("CXK/IK520");
            //MessageBox.Show(bl.ToString());

            //bool bl = boi.ReturnBook("G447/9");
            //MessageBox.Show(bl.ToString());

            //-------------user----------------
            User user = new User();

            //DataSet ds = user.GetUserInfo("20180310026");
            //dataGridView5.DataSource = ds.Tables[0];

            //bool bl = user.InsertUser("20190603", "巨鹰", "123", 0, "123@qq.com", "软件0班");
            //MessageBox.Show(bl.ToString());

            //-------------admin---------------
            //Admin adm = new Admin();

            //bool bl = adm.InsertAdmin("0005", "陈龙", "123", "1226550632@qq.com");
            //if (bl)
            //{
            //    MessageBox.Show(bl.ToString());
            //}


           //bool bl = adm.ChangePassword("0004", "123");
           //MessageBox.Show(bl.ToString());

           //DataSet ds = adm.GetAdminInfoByID("0004");
           //dataGridView5.DataSource = ds.Tables[0];

           //bool bl = adm.Login("0004", "123");
           //MessageBox.Show(bl.ToString());
           
            //-----------comm----------------
           //bool bl = ick.CheckIsbn("7-111-03581-X");
           //MessageBox.Show(bl.ToString());
           
        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            //1.获取读者编号
            string useridA = tbUserIDA.Text.Trim();
            //2.过滤输入信息
            if (useridA == "")
            {
                MessageBox.Show("读者编号不能为空！");
                tbUserIDA.Focus();
                return;
            }

            //3.返回结果
            try
            {
                DataSet ds = wlg.GetUserInfo(useridA);
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count == 0) //如果表中的行计数为0条
                {
                    MessageBox.Show("没有这个用户！");
                    tbUserIDA.Text = "";
                    tbUserIDA.Focus();
                    ClearControlA();
                    btBorrowBookA.Enabled = false;
                    return;
                }

                //显示用户信息   
                DataRow dr = dt.Rows[0];
                tbUserNameA.Text = dr["username"].ToString();
                tbUserClassA.Text = dr["class"].ToString();
                if (Convert.ToInt16(dr["sex"]) == 1)
                {
                    radioButton1.Checked = true;

                }
                else
                {
                    radioButton2.Checked = true;
                }

                //查询借阅信息
                dgBorrowInfoA.DataSource = wlg.GetBorrowInfoByUserID(useridA).Tables[0];

                //照片
                if (dr["photo"].ToString() != "")//判断是否有照片
                {
                    Byte[] imgb = (Byte[])dr["photo"];//转为Byte类型


                    System.IO.MemoryStream ms = new System.IO.MemoryStream(imgb);
                    Image img = Image.FromStream(ms);
                    pictureBox1.Image = img;
                    ms.Close();
                }


                //借书按钮设为可触发
                btBorrowBookA.Enabled = true;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }



        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgBorrowInfoA_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //清空
            ClearControlA();
        }

        private void ClearControlA()
        {
            tbUserIDA.Text = "";
            tbUserNameA.Text = "";
            tbUserClassA.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            pictureBox1.Image = null;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //清空
            tbBookIDA.Text = "";
            dgBorrowInfoA.DataSource = null;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (tbBookIDA.Text != "")
            {
                try
                {
                    //借书
                    bool bl = wlg.BorrowBook(tbBookIDA.Text.Trim(), tbUserIDA.Text.Trim());
                    if (bl == true)
                    {
                        MessageBox.Show("借书成功");

                    }
                    else
                    {
                        MessageBox.Show("借书失败");
                        tbBookIDA.Clear();
                        tbBookIDA.Focus();
                        return;
                    }
                    //刷新
                    dgBorrowInfoA.DataSource = wlg.GetBorrowInfoByUserID(tbUserIDA.Text).Tables[0];


                }
                catch (Exception ex)
                {
                    //显示错误信息
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                //防止输入空串
                MessageBox.Show("图书编号不能为空！");
                return;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

            try
            {

                //获得图书编号
                if (flag_B == true)//检索功能
                {

                    //获得图书编号
                    bookidB = bookIdTextBox_B.Text;
                    //过滤输入信息
                    if (bookidB == "")
                    {
                        MessageBox.Show("您输入的图书编号为空！");
                        return;
                    }
                    else
                    {
                        //返回结果

                        DataSet ds = wlg.GetBorrowInfoByBookID(bookidB);
                        DataTable dt = ds.Tables[0];
                        if (dt.Rows.Count == 0)
                        {
                            //如果未被借出
                            errorInfo_B.Visible = true;
                            errorInfo_B.Text = "没有此书或未被借出";
                            return;
                        }

                        //已被借出或未归还

                        DataRow dr = dt.Rows[0];
                        if (Convert.ToInt16(dr["isreturned"]) == 0)
                        {
                            MessageBox.Show("此书正在借出");

                        }
                        ISBNTextBox_B.Text = dr["isbn"].ToString();
                        bookIdTextBox_B.Text = dr["bookid"].ToString();
                        bookNameTextBox_B.Text = dr["bookname"].ToString();
                        authorTestBox_B.Text = dr["author"].ToString();
                        publisherTextBox_B.Text = dr["publisher"].ToString();

                        //逾期
                        DateTime bordate = Convert.ToDateTime(dr["borrowdate"]);
                        DateTime sysdate = DateTime.Now;
                        TimeSpan span = sysdate.Subtract(bordate);
                        int day = span.Days + 1;
                        if (day > 90)
                        {
                            yesRadioButton_B.Checked = true;
                        }
                        else
                        {
                            noRadioButton_B.Checked = true;
                        }

                        userNameTestBox_B.Text = dr["username"].ToString();


                        classTestBox_B.Text = dr["class"].ToString();
                        if (Convert.ToInt16(dr["sex"]) == 1)//判断性别
                        {
                            maleRadioButton_B.Checked = true;
                        }
                        else
                        {
                            girlRadioButton_B.Checked = true;
                        }
                        dgView_B.DataSource = dt;


                        DataRow dtr = wlg.GetBorrowInfoByUserID(dr["userid"].ToString()).Tables[0].Rows[0];
                        bookidB = dtr["bookid"].ToString().Trim();
                    }



                    borrowBookButtonYes_B1.Text = "还书";
                    flag_B = false;

                }
                else//还书功能
                {


                    bool i = wlg.ReturnBook(bookidB);
                    if (i == true)
                    {
                        MessageBox.Show("还书成功");
                        ClearControlB();
                    }
                    else
                    {
                        MessageBox.Show("还书失败");
                    }
                    borrowBookButtonYes_B1.Text = "检索";
                    flag_B = true;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void borrowBookButtonNo_B_Click(object sender, EventArgs e)
        {
            ClearControlB();
        }

        private void ClearControlB()
        {
            ISBNTextBox_B.Text = "";
            bookIdTextBox_B.Text = "";
            bookNameTextBox_B.Text = "";
            authorTestBox_B.Text = "";
            publisherTextBox_B.Text = "";
            userNameTestBox_B.Text = "";
            classTestBox_B.Text = "";
            maleRadioButton_B.Checked = false;
            girlRadioButton_B.Checked = false;
            dgView_B.DataSource = null;
            errorInfo_B.Text = "";
            errorInfo_B.Visible = false;
            borrowBookButtonYes_B1.Text = "检索";
            yesRadioButton_B.Checked = false;
            noRadioButton_B.Checked = false;
            flag_B = true;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //获取图书编号
            string bookidC = tbBookIdC.Text;
            //筛选判断图书编号
            if (bookidC == "")
            {
                MessageBox.Show("您输入的图书编号为空!");
                return;
            }
            else
            {
                if (flag_C == true)
                {
                    //检索
                    DataTable dt = wlg.GetBorrowInfoByBookID(bookidC).Tables[0];
                    if (dt.Rows.Count == 0)
                    {
                        errorInfoC.Visible = true;
                        errorInfoC.Text = "没有此书或未被借出";
                        return;
                    }
                    DataRow dr = dt.Rows[0];
                    if (Convert.ToInt16(dr["isreturned"]) == 0)
                    {
                        MessageBox.Show("此书正在借出");

                    }
                    tbIsbnC.Text = dr["isbn"].ToString();
                    tbBookIdC.Text = dr["bookid"].ToString();
                    tbBookNameC.Text = dr["bookname"].ToString();
                    tbAuthorC.Text = dr["author"].ToString();


                    //逾期
                    DateTime bordate = Convert.ToDateTime(dr["borrowdate"]);
                    DateTime sysdate = DateTime.Now;
                    TimeSpan span = sysdate.Subtract(bordate);
                    int day = span.Days + 1;
                    if (day > 90)
                    {
                        rbYesC.Checked = true;
                    }
                    else
                    {
                        rbNopC.Checked = true;
                    }

                    tbUserNameC.Text = dr["username"].ToString();


                    tbClassC.Text = dr["class"].ToString();

                    //判断性别
                    if (Convert.ToInt16(dr["sex"]) == 1)
                    {
                        rbManC.Checked = true;
                    }
                    else
                    {
                        rbGirlC.Checked = true;
                    }

                    dgViewC.DataSource = dt;


                    DataRow dtr = wlg.GetBorrowInfoByUserID(dr["userid"].ToString()).Tables[0].Rows[0];
                    bookidC = dtr["bookid"].ToString().Trim();

                    btnReBorrowC.Text = "续借";
                    flag_C = false;
                }
                else
                {
                    //续借
                    string bookidC_1 = tbBookIdC.Text;
                    DataTable dt = wlg.GetBorrowInfoByBookID(bookidC_1).Tables[0];
                    bool bl = wlg.ReBorrow(bookidC);
                    if (bl == true)
                    {


                        MessageBox.Show("续借成功");
                        tbBookIdC.Focus();

                    }
                    else
                    {
                        MessageBox.Show("续借失败");
                        ClearControC();
                        tbBookIdC.Focus();
                    }

                    dgViewC.DataSource = dt;
                    btnReBorrowC.Text = "检索";
                    flag_C = true;
                }
            }



        }

        private void clearReBorrowC_Click(object sender, EventArgs e)
        {
            ClearControC();
        }

        private void ClearControC()
        {
            tbBookIdC.Text = "";
            tbIsbnC.Text = "";
            tbAuthorC.Text = "";
            tbBookNameC.Text = "";
            tbPublisherC.Text = "";
            tbUserNameC.Text = "";
            tbClassC.Text = "";
            dgViewC.DataSource = null;
            rbYesC.Checked = false;
            rbNopC.Checked = false;
            rbManC.Checked = false;
            rbGirlC.Checked = false;
            btnReBorrowC.Text = "检索";
            flag_C = true;
        }

        private void cbClassD_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void FrmLibrarySystem_Load(object sender, EventArgs e)
        {
            try
            {

                //软件启用时加载
                //组合框的值
                DataSet ds = wlg.GetAllBookClass();
                cbClass_1D.DataSource = ds.Tables[0];
                cbClass_1D.DisplayMember = "ClassName";
                cbClass_1D.ValueMember = "ClassID";


                DataSet ds1 = wlg.GetAllBookClass();
                cbClass_2D.DataSource = ds1.Tables[0];
                cbClass_2D.DisplayMember = "ClassName";
                cbClass_2D.ValueMember = "ClassID";

                cbReportE.SelectedIndex = 0;//默认显示的选项卡

                DateTime sysdate = DateTime.Now;//获得系统时间              
                lbSysTime.Text = sysdate.ToLongDateString() + " " + sysdate.ToLongTimeString();

                lbAdminID.Text = wlg.GetAdminInfoByID(adminid_S).ToString();//显示管理员名字


                //sk.SkinFile = "ys//RealOne.ssk";


                openFileDialog1.FileName = "";
               
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void button10_Click(object sender, EventArgs e)
        {
            //图书检索

            try
            {
                bookname_D = tbBookName2_D.Text;
                classid_D = Convert.ToString(cbClass_2D.SelectedValue);
                //string classid = cbClass_2D.ToString();错误：null值不能调用tostring方法
                DataSet ds = wlg.GetBookInfo(bookname_D, classid_D);
                //判断数据集的数据行,为0则情况数据表并输出一个消息框
                if (ds.Tables[0].Rows.Count == 0)
                {
                    dgViewD.DataSource = null;
                    MessageBox.Show("没有找到此书!");
                    return;
                }
                dgViewD.DataSource = ds.Tables[0];
            }
            catch (Exception ex) //异常处理
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void cbClass_2D_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dgViewD_CellClick(object sender, DataGridViewCellEventArgs e)//数据表事件,当选择记录时触发
        {
            //当选择其中一个字段时整条记录反蓝
            dgViewD.CurrentRow.Selected = true;



            //将数据表中选中的数据返回到对应的控件
            DataTable dt = dgViewD.DataSource as DataTable;//as用于类型转换，不成功则返回null;.ToString()不成功则抛出异常;is则返回真假     
            DataRow dr = dt.Rows[dgViewD.CurrentRow.Index];//用一个变量dr记录选中的数据行
            tbBookIdD.Text = dr["bookid"].ToString();
            tbBookNameD.Text = dr["bookname"].ToString();
            tbAuthorD.Text = dr["author"].ToString();
            tbPageCountD.Text = dr["pagecount"].ToString();
            tbPublishDateD.Text = dr["publishdate"].ToString();
            tbPublisherD.Text = dr["publisher"].ToString();
            tbIsbnD.Text = dr["isbn"].ToString();
            tbWordCountD.Text = dr["wordcount"].ToString();
            tbVD.Text = dr["BookVersion"].ToString();

            cbClass_1D.SelectedValue = dr["classid"].ToString();

            btDeleteD.Enabled = true;
            rbBookUpdateD.Checked = true;



        }

        private void btDeleteD_Click(object sender, EventArgs e)
        {
            //删除

            //消息框进阶用法
            DialogResult drs = MessageBox.Show("确定要删除吗?", "消息提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);



            if (drs == DialogResult.Yes)//当用户选择消息框中的按钮
            {
                try
                {
                    bool bl = wlg.DeleteBook(tbBookIdD.Text.Trim());
                    if (bl == true)
                    {
                        MessageBox.Show("删除成功!");
                        dgViewD.DataSource = wlg.GetBookInfo(bookname_D, classid_D).Tables[0];
                        tbBookIdD.Text = "";
                        cbClass_2D.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("删除失败");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            tbClear();
        }

        private void tbClear()
        {
            //清空

            foreach (Control c in groupBox10.Controls) //使用foreach清空文本框内容,变量Control意为控件
            //groupBox10.Controls意为组合框中的控件
            {
                if (c is TextBox) //is为类型转换,若转换成功则返回真
                {
                    c.Text = "";
                }
            }
        }

        private void btYe_Click(object sender, EventArgs e)
        {
            foreach (Control c in groupBox10.Controls)
            {
                if(c is TextBox && c.Text =="")
                {
                    MessageBox.Show("输入的图书信息为空");
                    c.Focus();
                    return;
                }
            }
             string bookid = tbBookIdD.Text.Trim();
                    if (!ick.CheckBookID(bookid))
                    {
                        MessageBox.Show("输入的图书编号有误");
                        return;
                    }
                    string isbn = tbIsbnD.Text;
                    if (!ick.CheckIsbn(isbn))
                    {
                        MessageBox.Show("输入的isbn有误");
                        return;
                    }

                    int wordCount;
                    try
                    {
                        wordCount = Convert.ToInt32(tbWordCountD.Text);
                    }
                    catch (Exception)
                    {

                        MessageBox.Show("输入的字数不为数字");
                        return;
                    }
                    
                    
                    string v = tbVD.Text;
                    string bookname = tbBookNameD.Text;
                    string author = tbAuthorD.Text;

                    int pageCount;
                    try
                    {
              pageCount = Convert.ToInt16(tbPageCountD.Text);
                    }
                    catch (Exception)
                    {

                        MessageBox.Show("输入的页数不为数字");
                        return;
                    }

                    DateTime publishDate;
                    try
                    {
                    publishDate = Convert.ToDateTime(tbPublishDateD.Text);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("输入的日期类型不正确");
                        return;                   
                    }
                   
                    string publisher = tbPublisherD.Text;
                    string classid = cbClass_1D.SelectedValue.ToString();
            //更新图书|新书入库
                    if (rbBookUpdateD.Checked == true)
                    {
                        try
                        {
                            //更新图书

                            DialogResult dir = MessageBox.Show("确定要更新图书吗?", "消息提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);//消息框进阶用法                  

                            if (dir == DialogResult.Yes)
                            {
                                //执行更新命令
                                bool i = wlg.UpdateBookInfo(bookid, isbn, bookname, author, publishDate, v, wordCount, pageCount, publisher, classid);

                                //判断更新是否完成
                                if (i == true)
                                {
                                    DataTable dt = dgViewD.DataSource as DataTable;
                                    DataRow dr = dt.Rows[dgViewD.CurrentRow.Index];//用一个变量dr记录选中的数据行
                                    int di = dt.Rows.IndexOf(dr);

                                    MessageBox.Show("更新完成");
                                    DataSet ds = wlg.GetBookInfo(bookname_D, classid_D);
                                    dgViewD.DataSource = ds.Tables[0];


                                    //将指定的行标蓝




                                    //用变量di记录选定的行的下标

                                    dgViewD.Rows[di].Selected = true;//根据变量di将选定的行标蓝
                                    dgViewD.CurrentCell.Selected = false;//取消当前单元格的标蓝
                                    dgViewD.CurrentCell = dgViewD.Rows[di].Cells[0];//将当前单元格设为选定行单元格,自动回滚至当前单元格




                                    //dgViewD..Selected = true;


                                }
                                else
                                {
                                    MessageBox.Show("更新失败");
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else
                    {
                        try
                        {
                            //新书入库
                            DialogResult dir = MessageBox.Show("确定要入库图书吗?", "消息提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);//消息框进阶用法   
                            if (dir == DialogResult.Yes)
                            {
                                bool bl = wlg.InsertNewBook(bookid, isbn, bookname, author, publishDate, v, wordCount, pageCount, publisher, classid);

                                //判断插入是否完成
                                if (bl == true)
                                {
                                    MessageBox.Show("入库完成");
                                    DataSet ds = wlg.GetBookInfoByBookID(bookid);

                                    dgViewD.DataSource = ds.Tables[0];

                                }
                                else
                                {
                                    MessageBox.Show("入库失败");
                                }
                            }
                        }

                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
        }
        
        private void groupBox10_Enter(object sender, EventArgs e)
        {

        }

        private void dgViewD_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void rbBookInsertD_CheckedChanged(object sender, EventArgs e)
        {
            if (rbBookInsertD.Checked)
            {
                tbBookIdD.Enabled = true;
            }
        }

        private void rbBookUpdateD_CheckedChanged(object sender, EventArgs e)
        {
            if (rbBookUpdateD.Checked)
            {
                tbBookIdD.Enabled = false;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button13_Click(object sender, EventArgs e)
        {
            //获得上海出版出版的图书
            //获得页数小于200页的图书
            //获得2019年内所借的图书的信息
            //获得柳职院2018级的用户的借阅信息
            //查询逾期的借阅信息
            //获得清华大学出版社出版的图书
            //获得所有图书的出版社
            //查看1990-2000年出版的图书
            //查看最薄的图书
            //查看男女生各借过多少图书
            try
            {
                if (cbReportE.Text == "")
                {
                    MessageBox.Show("请选择一项");
                }
                else
                {
                    if (cbReportE.SelectedItem.ToString() == "获得上海出版社出版的图书")
                    {
                        DataSet ds = wlg.GetShanghaiPublisherBookInfo();
                        dgViewE.DataSource = ds.Tables[0];

                    }
                    else if (cbReportE.SelectedItem.ToString() == "获得页数小于200页的图书")
                    {
                        DataSet ds = wlg.GetPageWordLittleBookInfo();
                        dgViewE.DataSource = ds.Tables[0];
                    }
                    else if (cbReportE.SelectedItem.ToString() == "获得2019年内所借的图书的信息")
                    {
                        DataSet ds = wlg.Get2019BorroweInfo();
                        dgViewE.DataSource = ds.Tables[0];
                    }
                    else if (cbReportE.SelectedItem.ToString() == "获得柳职院2018级的用户的借阅信息")
                    {
                        DataSet ds = wlg.Get2018UserBorroweInfo();
                        dgViewE.DataSource = ds.Tables[0];
                    }
                    else if (cbReportE.SelectedItem.ToString() == "查询逾期的借阅信息")
                    {
                        DataSet ds = wlg.GetOverdueBorroweInfo();
                        dgViewE.DataSource = ds.Tables[0];
                    }
                    else if (cbReportE.SelectedItem.ToString() == "获得清华大学出版社出版的图书")
                    {
                        DataSet ds = wlg.GetQinhuaBookInfo();
                        dgViewE.DataSource = ds.Tables[0];
                    }
                    else if (cbReportE.SelectedItem.ToString() == "获得所有图书的出版社")
                    {
                        DataSet ds = wlg.GetAllPublisher();
                        dgViewE.DataSource = ds.Tables[0];
                    }
                    else if (cbReportE.SelectedItem.ToString() == "查看1990-2000年出版的图书")
                    {
                        DataSet ds = wlg.Get1990to2000bookinfo();
                        dgViewE.DataSource = ds.Tables[0];
                    }
                    else if (cbReportE.SelectedItem.ToString() == "查看最薄的图书")
                    {
                        DataSet ds = wlg.GetPageWordMinBookInfo();
                        dgViewE.DataSource = ds.Tables[0];
                    }
                    else if (cbReportE.SelectedItem.ToString() == "查看男女生各借过多少图书")
                    {
                        DataSet ds = wlg.GetBoyOrGirlBorrowInfo();
                        dgViewE.DataSource = ds.Tables[0];
                    }

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void groupBox11_Enter(object sender, EventArgs e)
        {

        }

        private void tbBookIdD_TextChanged(object sender, EventArgs e)
        {

        }

        private void 登录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process st = System.Diagnostics.Process.GetProcessById(System.Diagnostics.Process.GetCurrentProcess().Id);
            st.Kill();//直接杀死与本程序相关的所有进程，有可能会导致数据丢失，但是不会抛出异常。  
        }

        private void 更改密码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 5;
        }

        private void 借书ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }

        private void 还书ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        private void 续借ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
        }

        private void 图书管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 3;
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void rbYesC_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void 报表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 4;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime sysdate = DateTime.Now;
            lbSysTime.Text = sysdate.ToLongDateString() + " " + sysdate.ToLongTimeString();
        }

        private void btPwdF(object sender, EventArgs e)
        {
            string adminid = adminid_S;
            string modoPwd = tbAPwdF.Text.Trim();
            string newPwd = tbCPwdF.Text.Trim();


            if (tbAPwdF.Text == "" || tbBPwdF.Text == "" || tbCPwdF.Text == "")
            {
                MessageBox.Show("密码不能为空！");

            }
            else 
            {
                if (ick.CheckPassword(tbAPwdF.Text) || ick.CheckPassword(tbBPwdF.Text) || ick.CheckPassword(tbCPwdF.Text))
                {
                    if (wlg.Login(adminid, modoPwd))
                    {
                        if (tbBPwdF.Text == tbCPwdF.Text)
                        {
                            if (wlg.ChangePassword(adminid, newPwd))
                            { MessageBox.Show("密码修改成功"); }
                            else
                            { MessageBox.Show("密码修改失败"); }
                        }
                        else
                        {
                            MessageBox.Show("两次密码不一致!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("原密码不正确!");
                    }
                }
                else 
                {
                    MessageBox.Show("密码长度小于6位!");
                }
                
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            tbAPwdF.Text = "";
            tbBPwdF.Text = "";
            tbCPwdF.Text = "";
            tbAPwdF.Focus();
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LibraryWindowsUI.About abo = new LibraryWindowsUI.About();
            abo.ShowDialog();
        }

        private void pBTest_Click(object sender, EventArgs e)
        {

            openFileDialog1.InitialDirectory = "//照片";
            //openFileDialog1.FileName = "";
            openFileDialog1.Filter = "JPG文件|*.jpg|BMP文件|*.bmp|GIF文件|*.gif";
            openFileDialog1.FilterIndex = 1;
            DialogResult dir = openFileDialog1.ShowDialog();
            if (dir == DialogResult.OK) 
            {
                string ofdFileName = openFileDialog1.FileName;
                pBPhoto.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void btSelectTest_Click(object sender, EventArgs e)
        {
            
            if (tbTextPhoto.Text == "") 
            {
                MessageBox.Show("您输入的用户ID为空！");
                return;
            }
            if (openFileDialog1.FileName == "")
            {
                DialogResult dir = MessageBox.Show("您没有选择照片,是否插入一张为暂无的图片?", "消息提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                if (dir == DialogResult.Yes)
                {
                    bool bl = wlg.UpdateUserPhotoByUserID(tbTextPhoto.Text, "照片//no.gif");
                    if (bl)
                    {
                        MessageBox.Show("添加成功");
                        ClearPhoto();
                    }
                    else
                    {
                        MessageBox.Show("添加失败");
                    }
                }
                else
                {
                    return;
                }

            }
            else 
            {
                bool bl = wlg.UpdateUserPhotoByUserID(tbTextPhoto.Text, openFileDialog1.FileName);
                if (bl)
                {
                    MessageBox.Show("添加成功");
                    ClearPhoto();
                }
                else
                {
                    MessageBox.Show("添加失败");
                }


            }
            

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void btClearPhoto_Click(object sender, EventArgs e)
        {
            ClearPhoto();
        }

        private void ClearPhoto()
        {
            tbTextPhoto.Text = "";
            pBPhoto.Image = null;
            openFileDialog1.FileName = "";
        }

        private void groupBox9_Enter(object sender, EventArgs e)
        {

        }


    }
}
