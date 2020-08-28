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
        public double كمية { get; set; }


        [ForeignKey(nameof(كودالخامة))]
        public المنتجات منتج { get; set; }

        [ForeignKey(nameof(رقم))]
        public فواتير فاتورة { get; set; }
    }
}
