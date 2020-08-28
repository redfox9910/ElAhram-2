using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ElAhram.Models
{
   public class فواتير
    {    [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]   
        public int رقم { get; set; }
        public int كودعميل { get; set; }
        public DateTime تاريخ_تسليم { get; set; }
        public DateTime تاريخ_استلام { get; set; }
        public char نوع_فاتورة { get; set; }
        public decimal اجمالى_نقدى{ get; set; }
        public double اجمالى_وزن{ get; set; }
        public decimal اجمالى_حساب { get; set; }
        [ForeignKey(nameof(كودعميل))]
        public عميل عميل{ get; set; }

    }
}
