using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Comm
{
    interface IInputCheck
    {
        //接口是一种规范，成员只包涵抽象类和抽象属性
        bool CheckBookID(string bookid);
        bool CheckIsbn(string isbn);
        bool CheckPassword(string password);
    }
}
