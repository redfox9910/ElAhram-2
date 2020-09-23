using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ElAhram.Models
{
  public   class هالك
    {
        [Key]
        [Column(Order = 0)]
        public int شهر{ get; set; }
        [Key]
        [Column(Order = 1)]
        public int سنة { get; set; }
        public decimal مطبوع { get; set; }
        public decimal سادة { get; set; }
    }
}
