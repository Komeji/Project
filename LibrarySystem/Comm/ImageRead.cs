using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Library.Comm
{
   public static class ImageRead
    {
       public static byte[] ReadPhoto(string FileName) 
       {
         FileStream fs = new FileStream(FileName,FileMode.Open,FileAccess.Read);//创建一个流的对象
         BinaryReader br = new BinaryReader(fs);//创建一个二进制读取器的对象，将流的对象传入
           byte[] buffer = br.ReadBytes((int)fs.Length);//变量byte[]记录对象br读取的二进制数据,进行了一次隐式转换(int)
         return buffer;

       
       }
     
    }
}
