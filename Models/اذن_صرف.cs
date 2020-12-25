using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ElAhram.Models
{
  public  class اذن_صرف
    {
        [Key]
        public int كود { get; set; }
        public int كودالخامة { get; set; }
      
        public double الكمية { get; set; }
        public string ملاحظات { get; set; }
        public DateTime تاريخ { get; set; }
    }
}
