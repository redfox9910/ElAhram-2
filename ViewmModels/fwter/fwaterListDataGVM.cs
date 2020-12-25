using System;
using System.Collections.Generic;
using System.Text;

namespace ElAhram.ViewmModels.fwter
{
  public  class fwaterListDataGVM
    {

        public int رقم { get; set; }
        

        public DateTime تاريخ_تشغيل { get; set; }
        public DateTime تاريخ_تسليم { get; set; }

        public decimal اجمالى_نقدى { get; set; }
        public double اجمالى_وزن { get; set; }

        public decimal اجمالى_حساب { get; set; }
        public decimal اجمالى_حساب_جديد { get; set; }
    }
}
