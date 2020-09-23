using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ElAhram.Models
{
  public  class حسابات_موظف
    {
        [Key]
        [Column(Order = 0)]
        public DateTime تاريخ{ get; set; }
       
        public int ساعةحضور{ get; set; }
        public int دقيقةحضور{ get; set; }
        public int ساعةانصراف{ get; set; }
        public int دقيقةانصراف{ get; set; }
        public decimal سلف{ get; set; }
        
        public string ملاحظات{ get; set; }

     
        [Key]
        [Column(Order = 1)]
        public int كودموظف { get; set; }



        public bool غياب { get; set; }
        [ForeignKey(nameof(كودموظف))]
        public موظف موظف { get; set; }
    }
}
