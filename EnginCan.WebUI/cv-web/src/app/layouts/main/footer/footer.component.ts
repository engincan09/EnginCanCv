import { Component, OnInit } from '@angular/core';
import { Setting } from '../../admin/pages/setting/models/setting.model';
import { SettingService } from '../../admin/pages/setting/services/setting.service';

@Component({
  selector: 'in-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.css'],
})
export class FooterComponent implements OnInit {
  setting: Setting = new Setting();
  settingId: number;

  constructor(private settingService: SettingService) {}

  ngOnInit() {
    this.settingId = 1;
    this.getSetting(this.settingId);
  }

  getSetting(settingId: number) {
    this.settingService.getSetting(settingId).subscribe((res) => {
      this.setting = res.data;
    });
  }
}
