using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ElAhram.Models
{
   public class امرشراء
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
        public double كمية { get; set; }


        [ForeignKey(nameof(كودالخامة))]
        public المنتجات منتج { get; set; }

        [ForeignKey("رقم,نوع_فاتورة ")]
        public فواتير فاتورة { get; set; }
    }
}
