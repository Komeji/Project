using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Library.Comm
{
  public  class Encrypt:IEncrypt
    {
        /// <summary>
        /// 加密算法,将传入的值SHA1加密后返回byte[]类型值
        /// </summary>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public byte[] EncryptPassword(string pwd)
        {
            //取得密码的字节数据
            ASCIIEncoding en = new ASCIIEncoding();
            byte[] password = en.GetBytes(pwd);//将传入的字符串转换为byte[]类型

            //进行加密,使用.Net框架自带的类,使用加密方法SHA1
            SHA1Managed sha = new SHA1Managed();
            //返回结果
            return sha.ComputeHash(password);

        }
    }
}
