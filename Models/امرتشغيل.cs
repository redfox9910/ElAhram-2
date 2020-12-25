using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ElAhram.Models
{
  public  class امرتشغيل
    {
        [Key]
        [Column(Order = 0)]
        public int كودالخامة { get; set; }
        [Key]
        [Column(Order = 1)]
        public int رقم { get; set; }
        [Key]
        [Column(Order = 2)]
        public char نوع_فاتورة { get; set; }
       
        public char type { get; set; }
       
        public double كمية { get; set; }

        public string سمك { get; set; }
        public string مقاس_طباعة{ get; set; }
        public string مقاس_تقطيع { get; set; }
        public string كميةخامة { get; set; }

        public bool بيور { get; set; }
        public bool اوميا { get; set; }

        [ForeignKey("كودالخامة , type ")]
        public المنتجات منتج { get; set; }

        [ForeignKey("رقم,نوع_فاتورة ")]       
        public فواتير فاتورة { get; set; }
    }
}
