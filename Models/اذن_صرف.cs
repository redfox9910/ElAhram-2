using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ElAhram.Models
{
    class اذن_صرف
    {
        [Key]
        public int كود { get; set; }
        public int كودالخامة { get; set; }
        public int كودالمخزن { get; set; }
        public double الكمية { get; set; }
        public string ملاحظات { get; set; }
        public DateTime تاريخ { get; set; }
    }
}
