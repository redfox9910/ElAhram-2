using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ElAhram.Models
{
   public  class التحويلات_الداخلية
    {
        [Key]
        public int id { get; set; }
        public DateTime تاريخ { get; set; }
        public char نوع { get; set; }
        public decimal قيمة{ get; set; }
    }
}
