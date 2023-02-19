using EnginCan.Entity.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnginCan.Entity.Models.Systems
{
    /// <summary>
    /// Mail configurationlarının tutulduğu tablodur.
    /// </summary>
    public class MailConfiguration : BaseEntity
    {
        /// <summary>
        /// Tablo tekil bilgisidir.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gönderici 
        /// </summary>
        public string Sender { get; set; }

        /// <summary>
        /// Gönderen ad
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Gönderici mail hostu
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// Mail port bilgisidir
        /// </summary>
        public string Port { get; set; }

        /// <summary>
        /// Mail giriş kullanıcı adı
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Mail giriş şifre bilgisidir.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Sssl bilgisidir
        /// </summary>
        public string EnableSsl { get; set; }

        /// <summary>
        /// Giriş durum bilgisdir
        /// </summary>
        public string Auth { get; set; }
    }
}
