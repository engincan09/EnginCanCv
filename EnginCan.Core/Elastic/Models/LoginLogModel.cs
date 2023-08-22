using System;
using System.Collections.Generic;
using System.Text;

namespace EnginCan.Core.Elastic.Models
{
    public class LoginLogModel
    {
        public string UserID { get; set; }
        public DateTime PostDate { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
    }
}
