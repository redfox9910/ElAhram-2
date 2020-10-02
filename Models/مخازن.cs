using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ElAhram.Models
{
    public class مخازن
    {
        [Key]
         public int كودالمخزن { get; set; }
        public string المخزن { get; set; }
    }
}

