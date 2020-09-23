 using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElAhram.Models
{
   public class بنود_الفاتورة
    {
        [Key]
        [Column(Order = 0)]
        public int كودالمنتج { get; set; }
        [Key]
        [Column(Order = 1)]
        public int رقم { get; set; }
        [Key]
        [Column(Order = 2)]
        public char نوع_فاتورة { get; set; }
        public double كمية{ get; set; }

        public double سعر_الوحدة { get; set; }
        public double الاجمالى { get; set; }
        [Key]
        [Column(Order = 3)]
        public char type { get; set; }
        [ForeignKey("كودالمنتج ,type")]
        public المنتجات منتج { get; set; }

        [ForeignKey("رقم, نوع_فاتورة")]
        public فواتير فاتورة{ get; set; }
    }

}
