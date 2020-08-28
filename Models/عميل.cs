using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ElAhram.Models
{
  public   class عميل
    {
        [Key]
        
        public int كودعميل { get; set; }
        public string اسم{ get; set; }
        public string رقم { get; set; }
        public string عنوان{ get; set; }
        public string email { get; set; }
        public decimal حساب { get; set; }
       
        public char نوع{ get; set; }
    }
}
