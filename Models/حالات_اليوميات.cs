using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ElAhram.Models
{
  public   class حالات_اليوميات
    {
        [Key]

        public int كودحالة { get; set; }

        public string حالة { get; set; }

        
    }
}
