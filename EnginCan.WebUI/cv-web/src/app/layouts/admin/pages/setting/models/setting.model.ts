import { BaseEntity } from "src/app/shared/models/base-entity.model";

/**Sistem ayarlarının tutulduğu tablodur. */
export class Setting extends BaseEntity {
  /**Tablo tekil bilgisidir. */
  id: number;

  /**Lokasyon bilgisidir (adres) */
  location: string;

  /**Email bilgisidir. */
  email: string;

  /**Cep numarası bilgisidir. */
  phoneNumber: string;

  /**Twitter profil link bilgisidir. */
  twitterProfile: string;

  /**Instagram profil link bilgisidir. */
  instagramProfile: string;

  /**Facebook profil link bilgisidir. */
  facebookProfile: string;

  /**Linkedin profil link bilgisidir. */
  linkedinProfile: string;
}
