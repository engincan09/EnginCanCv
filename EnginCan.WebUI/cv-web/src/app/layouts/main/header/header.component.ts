import { Component, OnInit } from '@angular/core';
import Typed from 'typed.js';
import { Setting } from '../../admin/pages/setting/models/setting.model';
import { SettingService } from '../../admin/pages/setting/services/setting.service';
declare var $: any;
@Component({
  selector: 'in-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  setting: Setting = new Setting();
  settingId: number;

  constructor(private settingService: SettingService) { }

  ngOnInit() {
    // Typed Initiate
    if ($('.typed').length == 1) {
      var typed_strings = $('.typed').attr('data-typed-items');
      var typed = new Typed('.typed', {
        strings: typed_strings.split(', '),
        loop: true,
        typeSpeed: 100,
        backSpeed: 50,
        backDelay: 2000
      });
    }
    this.settingId = 1;
    this.getSetting(this.settingId);
  }

  getSetting(settingId: number) {
    this.settingService.getSetting(settingId).subscribe((res) => {
      this.setting = res.data;
    });
  }
}
