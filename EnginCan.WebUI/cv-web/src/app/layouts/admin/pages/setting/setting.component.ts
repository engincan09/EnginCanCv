import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { DataStatus } from 'src/app/shared/models/base-entity.model';
import { CustomvalidationService } from 'src/app/shared/services/custom-validation.service';
import { environment } from 'src/environments/environment';
import { Setting } from './models/setting.model';
import { SettingService } from './services/setting.service';

@Component({
  selector: 'app-setting',
  templateUrl: './setting.component.html',
  styleUrls: ['./setting.component.css'],
})
export class SettingComponent implements OnInit {
  setting: Setting = new Setting();
  environment = environment;
  submitted = false;
  settingForm: FormGroup;
  settingId: number;

  constructor(
    private formBuilder: FormBuilder,
    private toastr: ToastrService,
    private settingService: SettingService,
    private activatedRoute: ActivatedRoute,
    private route: ActivatedRoute,
    private router: Router,
    private customValidator: CustomvalidationService,
    public datepipe: DatePipe
  ) {}

  ngOnInit() {
    this.settingId = 1;
    this.getSetting(this.settingId);
    this.createSettingUpdateForm();
  }

  get formControl() {
    return this.settingForm.controls;
  }

  saveSetting() {
    this.submitted = true;
    if (this.settingForm.valid) {
      let model: Setting = Object.assign({}, this.settingForm.value);
      model.dataStatus = DataStatus[DataStatus.Activated];
      if (this.setting.id) {
        this.updateAbout(model);
      }
    } else {
      this.toastr.error('Zorunlu alanları kontrol ediniz!', 'Hata');
    }
  }

  updateAbout(model) {
    this.settingService.updateSetting(model).subscribe((res) => {
      if (res.success) {
        this.toastr.success(res.messages, 'Başarılı!');
      } else {
        this.toastr.error(res.messages, 'Hata!');
      }
    });
  }

  createSettingUpdateForm() {
    this.settingForm = this.formBuilder.group({
      id: this.settingId,
      location: ['', Validators.required],
      email: ['', Validators.required],
      phoneNumber: ['', Validators.required],
      twitterProfile: ['', Validators.required],
      instagramProfile: ['', Validators.required],
      facebookProfile: ['', [Validators.required]],
      linkedinProfile: ['', [Validators.required]],
    });
  }

  getSetting(settingId: number) {
    this.settingService.getSetting(settingId).subscribe((res) => {
      this.setting = res.data;
    });
  }
}
