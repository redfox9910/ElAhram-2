using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ElAhram.Models
{
  public  class يوميات
    {   [Key]
        public int كود{ get; set; }
        
        public decimal مبلغ { get; set; }
       
        public string ملاحظات{ get; set; }
        public int كودصاحب { get; set; }
        public int كودحالة { get; set; }
        public DateTime تاريخ { get; set; }
        public char flag { get; set; }   // تكتب هو موظف ولا مورد ولا عميل و كدة 

        [ForeignKey(nameof(كودحالة))]
        public حالات_اليوميات حالة { get; set; }

    }
}
