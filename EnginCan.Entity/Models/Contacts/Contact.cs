using EnginCan.Entity.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnginCan.Entity.Models.Contacts
{
    /// <summary>
    /// Arayüz üzerinden gelen iletişim taleplerinin tutulduğu tablodur.
    /// </summary>
    public class Contact : BaseEntity
    {
        /// <summary>
        /// Tablo tekil bilgisidir.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Ad soyad bilgisidir.
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Mail bilgisidir.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Konu bilgisidir.
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Mesaj içeriği
        /// </summary>
        public string Message { get; set; }
    }
}
