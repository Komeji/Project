using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Library.DataAccess;
using System.IO;

namespace LibraryWindowsUI
{
    public partial class UserPtohoTest : Form
    {
        TestUserPtoho tup;
        public UserPtohoTest()
        {
            tup = new TestUserPtoho();
            InitializeComponent();
        }

        private void pBTest_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.InitialDirectory = "D:\\陈龙\\照片";             
                openFileDialog1.Filter = "JPG文件|*.jpg|BMP文件|*.bmp|GIF文件|*.gif";
                openFileDialog1.FilterIndex = 1;
                DialogResult dir = openFileDialog1.ShowDialog();

                if (dir == DialogResult.OK) //判断对话框是否选择OK
                {
                    if (openFileDialog1.FileName != "")
                    {
                        string strFile = openFileDialog1.FileName;//获得文件路径
                        pBTest.Image = Image.FromFile(strFile);//按照路径显示照片

                    }

                }
            }
            catch
            {

                MessageBox.Show("请选择图片文件!");
            }

        }

        private void btInsertTest_Click(object sender, EventArgs e)
        {
            try
            {


                string file = openFileDialog1.FileName;


                if (file == "")//插入照片为空时
                {


                    DialogResult dir = MessageBox.Show("您没有选择照片,是否插入一张为暂无的图片?", "消息提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);

                    if (dir == DialogResult.Yes)
                    {
                        file = "照片//no.gif";
                        bool bl = tup.TestInsertUserPtohoInfo(tbTest.Text, file);

                        if (bl)
                        { MessageBox.Show("插入成功!"); }
                        else
                        { MessageBox.Show("插入失败!"); }


                    }
                    else
                    {
                        return;
                    }

                }
                else
                {
                    bool bl = tup.TestInsertUserPtohoInfo(tbTest.Text, file);
                    if (bl)
                    {
                        MessageBox.Show("插入成功!");
                    }
                    else
                    {
                        MessageBox.Show("插入失败!");
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private void btSelectTest_Click(object sender, EventArgs e)
        {
            try
            {

           
            string userid = tbTest.Text;
           DataSet ds = tup.TestGetUserPtohoInfoByUserID(userid);
           DataTable dt = ds.Tables[0];
            DataRow dr = dt.Rows[0];
            if (dr["ptoho"] == Convert.DBNull)
            {
                pBTest.Image = Image.FromFile("照片//no.gif"); 
            }
            else 
            {
            byte[] sqlPhoto = dr["ptoho"] as byte[];
            MemoryStream ms = new MemoryStream(sqlPhoto);//创建一个内存流,读取byte数组sqlPhoto
             pBTest.Image = Image.FromStream(ms);//将读取的流加载到Image
            }
           }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }  
        
        }

        private void UserPtohoTest_Load(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            toolTip1.SetToolTip(pBTest,"点击选择图片");
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {
            
        }
    
    }
}
