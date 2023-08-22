using System;
using System.Collections.Generic;
using System.Text;

namespace EnginCan.Core.Elastic.Models
{
    public class ElasticConnectionSettings
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ElasticSearchHost { get; set; }
        public string ElasticLoginIndex { get; set; }
        public string ElasticErrorIndex { get; set; }
        public string ElasticAuditIndex { get; set; }
    }
}
