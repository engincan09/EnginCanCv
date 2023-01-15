import { BaseEntity } from "src/app/shared/core/models/base-entity.model";

/**Yeteneklerin tutulduğu tablodur */
export class Skill extends BaseEntity {
  /**Tablo tekil bilgisidir */
  id: number;

  /**Yetenek adı bilgisidir */
  ad: string;

  /**Bilgi oran bilgisdiir */
  oran: number;
}
