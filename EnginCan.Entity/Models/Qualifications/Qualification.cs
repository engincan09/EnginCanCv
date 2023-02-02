using EnginCan.Entity.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnginCan.Entity.Models.Qualifications
{
    /// <summary>
    /// Eğitim ve iş deneyimlerinin tutulduğu tablodur.
    /// </summary>
    public class Qualification : BaseEntity
    {
        /// <summary>
        /// Tablo tekil bilgisidir
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Veri tip bilgisidir.
        /// </summary>
        public QualificationType QualificationType { get; set; }

        /// <summary>
        /// Deneyim/Eğitim dönem bilgisidir.
        /// </summary>
        public string Donem { get; set; }

        /// <summary>
        /// Eğitim / iş başlığı
        /// </summary>
        public string Baslik { get; set; }

        /// <summary>
        /// Bölüm/departman bilgisidir
        /// </summary>
        public string Bolum { get; set; }

        /// <summary>
        /// Yapılan işlere ait açıklama bilgisidir.
        /// </summary>
        public string Aciklama { get; set; }
    }

    /// <summary>
    /// Eğitim / İş tiplerinin tutulduğu enum.
    /// </summary>
    public enum QualificationType
    {
        Job=1,
        Education
    }
}
