using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyF.Model
{
   public class Main_InfoAccount 
    {
        public InfoAccount MY_INFO_ACCOUNT { get; set; }
        public int STT { get; set; }
  
        public Main_InfoAccount()
        {
            this.MY_INFO_ACCOUNT = null;
            this.STT = 0;
        }
        public Main_InfoAccount(Main_InfoAccount info)
        {
            this.MY_INFO_ACCOUNT = info.MY_INFO_ACCOUNT;
        }
    }
}
