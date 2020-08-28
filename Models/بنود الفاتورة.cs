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
        public double كمية{ get; set; }
       

        [ForeignKey(nameof(كودالمنتج))]
        public المنتجات منتج { get; set; }

        [ForeignKey(nameof(رقم))]
        public فواتير فاتورة{ get; set; }
    }

}
