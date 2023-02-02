import { BaseEntity } from 'src/app/shared/models/base-entity.model';

/**Eğitim ve iş deneyimlerinin tutulduğu tablodur. */
export class Qualification extends BaseEntity {
  /**Tablo tekil bilgisidir */
  id: number;

  /**Veri tip bilgisidir. */
  qualificationType: QualificationType | string;

  /**Deneyim/Eğitim dönem bilgisidir. */
  donem: string;

  /**Eğitim / iş başlığı */
  baslik: string;

  /**Bölüm/departman bilgisidir. */
  bolum: string;

  /**Yapılan işlere ait açıklama bilgisidir. */
  aciklama: string;
}

/**Eğitim / İş tiplerinin tutulduğu enum. */
export enum QualificationType {
  Job = 1,
  Education,
}

export const QualificationTypeDataSource = {
  [QualificationType.Job]: 'İş Deneyimi',
  [QualificationType.Education]: 'Eğitim',
};
