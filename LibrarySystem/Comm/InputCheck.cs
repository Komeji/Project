using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Library.Comm
{
    public class InputCheck : IInputCheck
    {
        /// <summary>
        /// 检查图书编号的开头是否为类别编号,长度是否超过20个字符,输入的字符是否包含汉字,输入的字符是否包含分号
        /// </summary>
        /// <param name="bookid"></param>
        /// <returns>布尔型</returns>
        public bool CheckBookID(string bookid)
        {
            //创建正则表达式的对象,\u4e00-\u9fa5为中文编码库匹配的开始和结束的两个值
            Regex reg = new Regex(@"[\u4e00-\u9fa5]");


            string classid = "ABCDEFGHIJKNOPQRSTUVXZ";
            string sem = "/";
            char a = bookid[0];

            if (classid.Contains(a) && bookid.Contains(sem) && bookid.Length < 20 && !reg.IsMatch(bookid))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckIsbn(string isbn)
        {
            try
            {
                //string Cisbn = Regex.Replace(isbn, @"[\D]*", "");
               string Cisbn = Regex.Replace(isbn, @"[^\d]*", "");//使用正则表达式去掉非数字的字符  Regex.Replace(参数,非数字字符,空串代替)
                string Cisbn_xm = isbn.Substring(isbn.Length - 1, 1);//记录isbn原本的校检码

                if (Cisbn.Length == 10 || (Cisbn.Length == 9 && (Cisbn_xm == "x" || Cisbn_xm == "X"))) //十位算法
                {
                    int[] x = new int[9];
                    int p = 0;
                    int y = 10;
                    for (int i = 0; i < 9; i++)
                    {
                        x[i] = Convert.ToInt32(Cisbn.Substring(i, 1)) * y;//循环x数组记录isbn码每个下标的乘值
                        p = p + x[i];//数组累加计算校检码
                        y--;
                    }

                    if (11 - (p % 11) == 10)//差值等10
                    {
                        if (Cisbn_xm == "x" ||Cisbn_xm == "X")
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else if (11 - (p % 11) == Convert.ToInt32(Cisbn_xm))//差值等值
                    {
                        return true;
                    }
                    else if (11 - (p % 11) == 11)//差值等11
                    {
                        if (isbn.Substring(isbn.Length - 1, 1) == "0")
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }

                else if (Cisbn.Length == 13) //十三位算法
                {
                    int[] x = new int[12];
                    int b = 1;
                    int p = 0;
                    for (int i = 0; i < 12; i++)
                    {
                        x[i] = Convert.ToInt32(Cisbn.Substring(i, 1)) * b;//循环x数组记录isbn码每个下标的乘值
                        p = p + x[i];//数组累加计算校检码

                        if (b == 1)//每循环一次变量b变更一次值
                        {
                            b = 3;
                        }
                        else
                        {
                            b = 1;
                        }
                    }
                    if (10 - (p % 10) == 10 && Convert.ToInt32(Cisbn_xm) == 0)//差值等10
                    {
                        return true;
                    }
                    else if (10 - (p % 10) == Convert.ToInt32(Cisbn_xm))//差值等值
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
                else//格式错误
                {
                    return false;
                }

            }
            catch
            {
                return false;
            }
        }

        public bool CheckPassword(string password)
        {
            if (password.Length < 6)
            {
                return false;
            }
            else return true;
        }
    }
}
