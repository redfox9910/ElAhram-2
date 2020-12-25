using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ElAhram.Models
{
  public  class موظف
  {   
        
        [Key]
        public int كودموظف{ get; set; }
        public string اسم{ get; set; }
        public string رقم{ get; set; }
        public string بطاقة{ get; set; }
        public string عنوان{ get; set; }
        public string رقم_قومى{ get; set; }
        public char حالةالعمل { get; set; }
   }
}
