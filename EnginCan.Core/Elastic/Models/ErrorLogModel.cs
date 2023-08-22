using System;
using System.Collections.Generic;
using System.Text;

namespace EnginCan.Core.Elastic.Models
{
    public class ErrorLogModel
    {
        public int UserID { get; set; }
        public string Message { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string Method { get; set; }
        public string Service { get; set; }
        public DateTime PostDate { get; set; }
        public int ErrorCode { get; set; }
    }
}
