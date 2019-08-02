using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Library.LibraryBusiness;
using Library.LibraryWinUI;

namespace LibraryWindowsUI
{
    public partial class Search : Form
    {
        WinLogic wlg;
      
       
        public Search()
        {
            wlg = new WinLogic();
            InitializeComponent();
        }

        private void btAdminLoginYes_Click(object sender, EventArgs e)
        {
            
            string adminid = tbAdminId.Text;
            string pwd = tbAdminPwd.Text;
            FrmLibrarySystem fbs = new FrmLibrarySystem(adminid);

            if (adminid == "" || pwd == "")
            {
                if (adminid == "")
                {
                    MessageBox.Show("管理员ID和密码不能为空!");
                    tbAdminId.Focus();
                }
                else
                {

                    MessageBox.Show("管理员ID和密码不能为空!");
                    tbAdminPwd.Focus();
                }
            }
            else 
            {
                bool bl = wlg.Login(adminid, pwd);
                if (bl)
                {


                    this.Visible = false;
                    fbs.ShowDialog();
                    this.Show();
                    tbAdminId.Clear();
                    tbAdminPwd.Clear();
                    tbAdminId.Focus();
                }
                else 
                {
                    MessageBox.Show("管理员ID或密码不正确!");
                    tbAdminId.Clear();
                    tbAdminPwd.Clear();
                    tbAdminId.Focus();
                }
            }
        }

        private void btAdminLoginNo_Click(object sender, EventArgs e)
        {
            tbAdminId.Clear();
            tbAdminPwd.Clear();
            tbAdminId.Focus();
        }

        private void Search_Load(object sender, EventArgs e)
        {
            //fbs.Visible = false;
        }
    }
}
