import { BaseEntity } from "src/app/shared/models/base-entity.model";

/**Arayüz üzerinden gelen iletişim taleplerinin tutulduğu tablodur. */
export class Contact extends BaseEntity {
  /**Tablo tekil bilgisidir. */
  id: number;

  /**Ad soyad bilgisidir. */
  fullName: string;

  /**Mail bilgisidir. */
  email: string;

  /**Konu bilgisidir. */
  subject: string;

  /**Mesaj içeriği */
  message: string;

  /** True: Yanıt verildi,  False: yanıt verilmedi */
  isResponse:boolean;
}
