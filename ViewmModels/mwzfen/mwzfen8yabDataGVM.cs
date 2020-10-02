using System;
using System.Collections.Generic;
using System.Text;

namespace ElAhram.ViewmModels.mwzfen
{
   public class mwzfen8yabDataGVM
    {


        public string موظف { get; set; }
        public DateTime تاريخ { get; set; }

        public int ساعةحضور { get; set; }
        public int دقيقةحضور { get; set; }
        public int ساعةانصراف { get; set; }
        public int دقيقةانصراف { get; set; }

        public int عمل { get; set; }
        public string ملاحظات { get; set; }

        public bool حضور { get; set; }
    }
}
