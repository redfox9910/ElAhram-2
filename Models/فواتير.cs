using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ElAhram.Models
{
   public class فواتير
    {    [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]   
        public int رقم { get; set; }
        public int كودعميل { get; set; }
        public DateTime تاريخ_تسليم { get; set; }
        public DateTime تاريخ_تشغيل { get; set; }
        [Key]
        [Column(Order = 1)]
        public char نوع_فاتورة { get; set; }
        public decimal اجمالى_نقدى{ get; set; }
        public double اجمالى_وزن{ get; set; }
        public decimal اجمالى_حساب { get; set; }
        public char فاتورة { get; set; }  // تحديد هى فى فاتورة ل امر الشراء او لا 

        [ForeignKey(nameof(كودعميل))]
        public عميل عميل{ get; set; }


    }
}
