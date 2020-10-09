using System;
using System.Collections.Generic;
using System.Text;

namespace ElAhram.ViewmModels.amrT48el
{
  public  class amrt48elDataGVM
    {
        public int رقم { get; set; }
        public string اسم { get; set; }
        public double كمية { get; set; }
        public string سمك { get; set; }
        public string مقاس_طباعة { get; set; }
        public string مقاس_تقطيع { get; set; }

        public bool بيور { get; set; }
        public bool اوميا { get; set; }
    }
}
