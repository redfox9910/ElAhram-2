using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ElAhram.Models
{
  public  class المنتجات
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int كودالخامة { get; set; }
        [Key]
        [Column(Order = 1)]
        public int كودالمخزن { get; set; }
        public int كودالنوع { get; set; }
        public string الخامة { get; set; }

        public double الكمية { get; set; }
        public char وحدة { get; set; }

        [Key]
        [Column(Order = 2)]
        public char type { get; set; }

        [ForeignKey(nameof(كودالمخزن))]
        public مخازن مخزن{ get; set; }

        [ForeignKey(nameof(كودالنوع))]
        public انواع_الخامات انواع{ get; set; }
    }
}
