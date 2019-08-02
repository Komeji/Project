using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library.LibraryWinUI
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(true);
            //Application.Run(new LibraryWindowsUI.Search());
            Application.Run(new FrmLibrarySystem("0004"));
            //Application.Run(new LibraryWindowsUI.About());
            //Application.Run(new LibraryWindowsUI.UserPtohoTest());
        }
    }
}
