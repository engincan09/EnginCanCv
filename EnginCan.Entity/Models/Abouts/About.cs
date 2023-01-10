using EnginCan.Entity.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnginCan.Entity.Models.Abouts
{
    /// <summary>
    /// Hakkımda bilgisinin tutulduğu tablodur
    /// </summary>
    public class About : BaseEntity
    {
        /// <summary>
        /// Tablo tekil bilgisidir
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// İsim Bilgisidir
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Doğum tarih bilgisidir.
        /// </summary>
        public string DogumTarih { get; set; }

        /// <summary>
        /// Mezuniyet Bilgisidir
        /// </summary>
        public string MezuniyetDurum { get; set; }

        /// <summary>
        ///  İş deneyim süresi
        /// </summary>
        public short DeneyimSuresi { get; set; }

        /// <summary>
        /// Email bilgisidir.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Hakkımda özet yazı
        /// </summary>
        public string OzetMetin { get; set; }
        
        /// <summary>
        /// Ek açıklama
        /// </summary>
        public string AltAciklama { get; set; }

        /// <summary>
        /// Yaş bilgisi
        /// </summary>
        public short Yas { get; set; }

        /// <summary>
        /// Web sitesi url adresi
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// şehir bilgisi
        /// </summary>
        public string Sehir { get; set; }
    }
}
