using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ElAhram.Models
{
   public  class شيكات
    {
        [Key]
        [Column(Order = 0)]
        public string رقم { get; set; }

        [Key]
        [Column(Order = 1)]
        public int كودعميل { get; set; }
        public decimal قيمة{ get; set; }
        public DateTime تاريخ { get; set; }
        public string ملاحظات { get; set; }
        public string بنك{ get; set; }

        [ForeignKey(nameof(كودعميل))]
        public عميل عميل { get; set; }
    }
}
