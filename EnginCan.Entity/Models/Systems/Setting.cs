using EnginCan.Entity.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnginCan.Entity.Models.Systems
{
    /// <summary>
    /// Sistem ayarlarının tutulduğu tablodur.
    /// </summary>
    public class Setting : BaseEntity
    {
        /// <summary>
        /// Tablo tekil bilgisidir.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Lokasyon bilgisidir (adres)
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Email bilgisidir.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Cep numarası bilgisidir.
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Twitter profil link bilgisidir.
        /// </summary>
        public string TwitterProfile { get; set; }

        /// <summary>
        /// Instagram profil link bilgisidir.
        /// </summary>
        public string InstagramProfile { get; set; }


        /// <summary>
        /// Facebook profil link bilgisidir.
        /// </summary>
        public string FacebookProfile { get; set; }


        /// <summary>
        /// Linkedin profil link bilgisidir.
        /// </summary>
        public string LinkedinProfile { get; set; }
    }
}
