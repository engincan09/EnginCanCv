using EnginCan.Entity.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnginCan.Entity.Models.Skills
{
    /// <summary>
    /// Yeteneklerin tutulduğu tablodur
    /// </summary>
    public  class Skill : BaseEntity
    {
        /// <summary>
        /// Tablo tekil bilgisidir
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Yetenek adı bilgisidir
        /// </summary>
        public string Ad { get; set; }

        /// <summary>
        /// Bilgi oran bilgisdiir
        /// </summary>
        public short Oran { get; set; }
    }
}
