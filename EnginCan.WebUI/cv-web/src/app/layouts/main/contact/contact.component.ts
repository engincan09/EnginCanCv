import { ContactService } from './../../admin/pages/iletisim-talepleri/services/contact.service';
import { Component, OnInit } from '@angular/core';
import { Setting } from '../../admin/pages/setting/models/setting.model';
import { SettingService } from '../../admin/pages/setting/services/setting.service';
import { Contact } from '../../admin/pages/iletisim-talepleri/models/contact.model';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { DataStatus } from 'src/app/shared/models/base-entity.model';

@Component({
  selector: 'in-contact',
  templateUrl: './contact.component.html',
  styleUrls: ['./contact.component.css'],
})
export class ContactComponent implements OnInit {
  setting: Setting = new Setting();
  contact: Contact = new Contact();
  contactForm: FormGroup;
  settingId: number;
  submitted = false;

  constructor(
    private settingService: SettingService,
    private formBuilder: FormBuilder,
    private contactService: ContactService,
    private toastr: ToastrService
  ) {}

  ngOnInit() {
    this.settingId = 1;
    this.getSetting(this.settingId);
    this.createContactAddForm();
  }

  get formControl() {
    return this.contactForm.controls;
  }

  getSetting(settingId: number) {
    this.settingService.getSetting(settingId).subscribe((res) => {
      this.setting = res.data;
    });
  }

  createContactAddForm() {
    this.contactForm = this.formBuilder.group({
      fullName: ['', Validators.required],
      email: ['', Validators.required],
      subject: ['', Validators.required],
      message: ['', Validators.required],
    });
  }

  postMessage() {
    if (this.contactForm.valid) {
      let model: Contact = Object.assign({}, this.contactForm.value);
      this.contact.isResponse = false;
      model.dataStatus = DataStatus[DataStatus.Activated];
      this.addMessage(model);
    } else {
      this.toastr.error('Zorunlu alanları kontrol ediniz!', 'Hata');
    }
  }

  addMessage(model) {
    this.contactService.postContact(model).subscribe((res) => {
      if (res.success) {
        this.toastr.success(res.messages, 'Başarılı!');
        this.contact = new Contact();
      } else {
        this.toastr.error(res.messages, 'Hata!');
      }
    });
  }
}
