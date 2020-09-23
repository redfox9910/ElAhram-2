using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace ElAhram.Models
{
   
    public  class الخزنة
    {    [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public char رقم{ get; set; }
        public decimal دائن { get; set; }
        public decimal مدين{ get; set; }
        public decimal اجمالى { get; set; }
        public decimal نقدى{ get; set; }
        public decimal شيكات { get; set; }
        public decimal حساب { get; set; }

    }
}
