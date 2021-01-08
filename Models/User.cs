using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ElAhram.Models
{
   public class User
    {
        [Key]
        public string name { get; set; }
        public string password { get; set; }
    }
}
