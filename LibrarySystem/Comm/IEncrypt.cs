﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Comm
{
   public interface IEncrypt
    {
       byte[] EncryptPassword(string pwd);
    }
}
