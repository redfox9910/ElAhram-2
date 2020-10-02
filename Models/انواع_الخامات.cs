using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ElAhram.Models
{
    public class انواع_الخامات
    {
        [Key]
        
        public int كودالنوع { get; set; }
        public string النوع { get; set; }
    }
}
