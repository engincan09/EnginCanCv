import { BaseEntity } from "src/app/shared/core/models/base-entity.model";

 /**Hakkımda bilgisinin tutulduğu tablodur */
    export class About extends BaseEntity {
        /**Tablo tekil bilgisidir */
        id: number;

        /**İsim Bilgisidir */
        fullName: string;

        /**Doğum tarih bilgisidir. */
        dogumTarih:Date;

        /**Mezuniyet Bilgisidir */
        mezuniyetDurum: string;

        /**İş deneyim süresi */
        deneyimSuresi: number;

        /**Email bilgisidir. */
        email: string;

        /**Hakkımda özet yazı */
        ozetMetin: string;

        /**Ek açıklama */
        altAciklama: string;

        /**Yaş bilgisi */
        yas: number;

        /**Web sitesi url adresi */
        url: string;

        /**şehir bilgisi */
        sehir: string;

        /**Fotoğraf bilgisi */
        photo:string;
    }